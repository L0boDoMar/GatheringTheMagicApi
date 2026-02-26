using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users.GetAllUser;

public sealed record GetAllUserRequest : IRequest<List<GetAllUserResponse>>;
