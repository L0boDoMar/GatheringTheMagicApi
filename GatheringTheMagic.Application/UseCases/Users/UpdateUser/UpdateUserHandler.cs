using AutoMapper;
using GatheringTheMagic.Domain.Interfaces;
using MediatR;

namespace GatheringTheMagic.Application.UseCases.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserRequest, UpdateUserResponse>
{
    private readonly IUnityOfWork _unityOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserHandler(IUnityOfWork unityOfWork, IUserRepository userRepository, IMapper mapper)
    {
        _unityOfWork = unityOfWork;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdateUserResponse> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id, cancellationToken);
        
        if (user == null)  return default;

        user.Name = request.Name;
        user.Email = request.Email;

        _userRepository.Update(user);

        await _unityOfWork.Commit(cancellationToken);

        return _mapper.Map<UpdateUserResponse>(user);
    }
}
