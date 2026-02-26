using FluentValidation;

namespace GatheringTheMagic.Application.UseCases.Users;

public class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator()
    {
        //sem validação
    }
}
