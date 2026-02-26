using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users;

public sealed record CreateUserRequest(string Email, string Name): IRequest<CreateUserResponse>;
