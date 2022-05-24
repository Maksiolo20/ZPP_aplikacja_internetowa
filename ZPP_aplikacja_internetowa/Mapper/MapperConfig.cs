using AutoMapper;
using Microsoft.AspNetCore.Identity;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Mapper
{

    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<User, IdentityUser>();
            CreateMap<IdentityUser, User>();
        }
    }
}
