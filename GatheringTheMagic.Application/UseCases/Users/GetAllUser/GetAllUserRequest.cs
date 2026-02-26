using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users;

public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;
