using Microsoft.AspNetCore.Identity;
using ZPP_aplikacja_internetowa.Services;

namespace ZPP_aplikacja_internetowa.Data.DatabaseModels
{
    public class User : IdentityUser , IUser
    {
        //public override string Email { get; set; }
        public ICollection<GameUser> Games { get; set; }
    }
}
