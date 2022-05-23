using Microsoft.AspNetCore.Identity;
namespace ZPP_aplikacja_internetowa.Data.DatabaseModels
{
    public class User : IdentityUser
    {
        public override string Email { get; set; }
        public ICollection<GameUser> Games { get; set; }
    }
}
