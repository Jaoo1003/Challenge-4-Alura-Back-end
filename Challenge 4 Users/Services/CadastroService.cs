using AutoMapper;
using Challenge_4_Users.Data.Dtos;
using Challenge_4_Users.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Challenge_4_Users.Services {
    public class CadastroService {

        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;

        public CadastroService(UserManager<IdentityUser<int>> userManager, IMapper mapper) {
            _userManager = userManager;
            _mapper = mapper;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto) {
            Usuario user = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultado = _userManager.CreateAsync(userIdentity, createDto.Password);

            if (resultado.Result.Succeeded) {
                return Result.Ok();
            }
            return Result.Fail("Falha ao cadastrar novo usuario");
        }
    }
}
