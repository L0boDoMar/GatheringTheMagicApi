using AutoMapper;
using GatheringTheMagic.Domain.Entities;

namespace GatheringTheMagic.Application.UseCases.Users.GetAllUser;

public sealed class GetAllUserMapper : Profile
{
    public GetAllUserMapper() 
    {
        CreateMap<User, GetAllUserResponse>();
    }
}
