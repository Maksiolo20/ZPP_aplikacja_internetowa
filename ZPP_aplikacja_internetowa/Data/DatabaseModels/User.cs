using Microsoft.AspNetCore.Identity;
namespace ZPP_aplikacja_internetowa.Data.DatabaseModels
{
    public class User : IdentityUser
    {
        public ICollection<GameUser> Games { get; set; }
    }
}
