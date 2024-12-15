using AutoMapper;
using Jcf.EasyShopFlow.Api.Models.DTOs;
using Jcf.EasyShopFlow.Core.Entities;

namespace Jcf.EasyShopFlow.Api.Configs
{
    public class MappingConfig : Profile
    {
        public MappingConfig() 
        { 
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
