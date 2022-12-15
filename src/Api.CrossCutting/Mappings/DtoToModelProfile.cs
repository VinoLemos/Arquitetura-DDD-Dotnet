using Api.Domain.Dtos.User;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            // < source, destination >
            CreateMap<UserModel, UserDto>()
                    // converts from destination to source
                    .ReverseMap();
        }
    }
}