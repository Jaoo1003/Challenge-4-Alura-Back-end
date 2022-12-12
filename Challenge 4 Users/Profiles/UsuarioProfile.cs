using AutoMapper;
using Challenge_4_Users.Data.Dtos;
using Challenge_4_Users.Models;
using Microsoft.AspNetCore.Identity;

namespace Challenge_4_Users.Profiles {
    public class UsuarioProfile : Profile{

        public UsuarioProfile() {
            CreateMap<CreateUsuarioDto, Usuario>();
            CreateMap<Usuario, IdentityUser<int>>();
        }
    }
}
