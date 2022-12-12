using AutoMapper;
using Challenge_4_Users.Data.Dtos;
using Challenge_4_Users.Models;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using System.Text;
using System.Web;

namespace Challenge_4_Users.Services {
    public class CadastroService {

        private UserManager<IdentityUser<int>> _userManager;
        private IMapper _mapper;
        private EmailService _emailService;

        public CadastroService(UserManager<IdentityUser<int>> userManager, IMapper mapper, EmailService emailService) {
            _userManager = userManager;
            _mapper = mapper;
            _emailService = emailService;
        }

        public Result CadastraUsuario(CreateUsuarioDto createDto) {
            Usuario user = _mapper.Map<Usuario>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> resultado = _userManager.CreateAsync(userIdentity, createDto.Password);

            if (resultado.Result.Succeeded) {
                var code = _userManager.GenerateEmailConfirmationTokenAsync(userIdentity).Result;
                var encodedCode = HttpUtility.UrlEncode(code);

                _emailService.EmailSend(new[] { userIdentity.Email }, "Ativation Link", userIdentity.Id, encodedCode);

                return Result.Ok().WithSuccess(code);
            }
            return Result.Fail("Falha ao cadastrar novo usuario");
        }
    }
}
