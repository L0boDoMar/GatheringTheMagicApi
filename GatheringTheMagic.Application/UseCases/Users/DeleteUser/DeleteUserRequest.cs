using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users.DeleteUser
{
    public sealed record DeleteUserRequest(Guid Id) : IRequest<DeleteUserResponse>;
}
