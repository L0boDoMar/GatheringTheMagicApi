using FluentValidation;
using MediatR;

namespace GatheringTheMagic.Application.Shared.Behavior;

/// <summary>
/// Criação de um pipeline para validação das requisições recebidas
/// 
/// Esse pipeline será chamado sempre que o MediatR interceptar uma requisição
/// </summary>
/// <typeparam name="TRequest"></typeparam>
/// <typeparam name="TResponse"></typeparam>
public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if(!_validators.Any()) return await next();

        var context = new ValidationContext<TRequest>(request);

        if (_validators.Any())
        {
           context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));

            var failures = validationResults.SelectMany(r => r.Errors).Where(f=>f != null).ToList();

            if (failures.Count != 0) throw new ValidationException(failures);
        }

        return await next();
    }
}
