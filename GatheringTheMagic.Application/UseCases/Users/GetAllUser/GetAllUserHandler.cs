using AutoMapper;
using GatheringTheMagic.Domain.Interfaces;
using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users.GetAllUser;

public sealed class GetAllUserHandler : IRequestHandler<GetAllUserRequest, List<GetAllUserResponse>>
{

    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetAllUserHandler(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<List<GetAllUserResponse>> Handle(GetAllUserRequest request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAll(cancellationToken);
        return _mapper.Map<List<GetAllUserResponse>>(users);
    }
}
