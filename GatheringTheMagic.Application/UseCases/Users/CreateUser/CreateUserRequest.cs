using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users.CreateUser;

public sealed record CreateUserRequest(string Email, string Name): IRequest<CreateUserResponse>;
