using AutoMapper;
using GatheringTheMagic.Domain.Entities;

namespace GatheringTheMagic.Application.UseCases.Users;

public sealed class UpdateUserMapper : Profile
{
    public UpdateUserMapper()
    {
        CreateMap<UpdateUserRequest, User>();
        CreateMap<User, UpdateUserResponse>();
    }
}
