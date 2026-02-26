using AutoMapper;
using GatheringTheMagic.Domain.Entities;

namespace GatheringTheMagic.Application.UseCases.Users;

public sealed class CreateUserMapper : Profile
{
    public CreateUserMapper()
    {
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUserResponse>();
    }
}
