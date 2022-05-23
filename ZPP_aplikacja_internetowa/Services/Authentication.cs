using Microsoft.AspNetCore.Identity;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Services
{
    public class Authentication : IAuthentication
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public Authentication(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Login(User user, string password)
        {
            var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (result.Succeeded)
                return result.Succeeded;

            return false;
        }
    }
}
