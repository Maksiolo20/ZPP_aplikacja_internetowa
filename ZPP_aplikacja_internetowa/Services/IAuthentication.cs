using Microsoft.AspNetCore.Identity;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Services
{
    public interface IAuthentication
    {
        public Task<bool> Login(User user, string password);
    }
}
