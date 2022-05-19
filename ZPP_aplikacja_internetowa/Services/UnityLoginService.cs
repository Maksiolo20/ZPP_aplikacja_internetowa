using Dapper;
using ZPP_aplikacja_internetowa.Data;
using ZPP_aplikacja_internetowa.Data.DatabaseModels;

namespace ZPP_aplikacja_internetowa.Services
{
    public class UnityLoginService
    {
        private readonly ISqlConnectionService _sqlConnectionService;
        public UnityLoginService(ISqlConnectionService sqlConnectionService)
        {
            _sqlConnectionService = sqlConnectionService;
        }
        public async Task<bool> UserExists(UnityUser unityUser)
        {
            using (var connection = await _sqlConnectionService.GetAsync())
            {
                var sql =
                    "SELECT * " +
                    "FROM dbo.AspNetUsers " +
                    "WHERE (Email='" + unityUser.Email +
                    "' AND PasswordHash ='" + unityUser.Password + "')";
                var query = connection.Query<User>(sql);
                if (query != null) return true;
                return false;
            }
        }
    }
}
