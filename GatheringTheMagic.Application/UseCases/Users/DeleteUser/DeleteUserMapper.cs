using GatheringTheMagic.Domain.Entities;
using AutoMapper;

namespace GatheringTheMagic.Application.UseCases.Users;

public sealed class DeleteUserMapper : Profile
{
    public DeleteUserMapper()
    {
        CreateMap<DeleteUserRequest,User>();
        CreateMap<User, DeleteUserResponse>();
    }
}
