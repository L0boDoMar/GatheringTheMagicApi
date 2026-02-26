using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users;

    public sealed record DeleteUserRequest(Guid Id) : IRequest<DeleteUserResponse>;

