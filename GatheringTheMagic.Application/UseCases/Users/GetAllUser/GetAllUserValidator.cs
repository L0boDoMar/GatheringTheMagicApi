using FluentValidation;

namespace GatheringTheMagic.Application.UseCases.Users.GetAllUser;

public class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
{
    public GetAllUserValidator()
    {
        //sem validação
    }
}
