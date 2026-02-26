using AutoMapper;
using GatheringTheMagic.Domain.Interfaces;
using MediatR;

namespace GatheringTheMagic.Application.UseCases.Users;

internal class DeleteUserHandler : IRequestHandler<DeleteUserRequest, DeleteUserResponse>
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserHandler(IUnityOfWork unityOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<DeleteUserResponse> Handle(DeleteUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);

        if (user == null) return default;

        _userRepository.Delete(user);
        await _unityOfWork.Commit(cancellationToken);

        return _mapper.Map<DeleteUserResponse>(user);
    }
}
