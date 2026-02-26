using AutoMapper;
using GatheringTheMagic.Domain.Entities;
using GatheringTheMagic.Domain.Interfaces;
using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users;

public class CreateUserHandler : IRequestHandler<CreateUserRequest, CreateUserResponse>
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserHandler(IUnityOfWork unityOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    async Task<CreateUserResponse> IRequestHandler<CreateUserRequest, CreateUserResponse>.Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var user = _mapper.Map<User>(request);

        _userRepository.Create(user);

        await _unityOfWork.Commit(cancellationToken);

        return _mapper.Map<CreateUserResponse>(user);
    }
}
