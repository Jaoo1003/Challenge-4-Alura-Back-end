using FluentResults;
using Microsoft.AspNetCore.Identity;

namespace Challenge_4_Users.Services {
    public class LogoutService {

        private SignInManager<IdentityUser<int>> _signInManager;

        public LogoutService(SignInManager<IdentityUser<int>> signInManager) {
            _signInManager = signInManager;
        }

        public Result DeslogaUsuario() {
            var deslogaUsuario = _signInManager.SignOutAsync();
            if (deslogaUsuario.IsCompleted) return Result.Ok();
            return Result.Fail("Logout falhou");
        }
    }
}    