namespace WebApiAuthentication.Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using DomainModel;
    using Insight.Database;

    public interface IAuthenticationRepository
    {
        [Sql(@"SELECT *  FROM [dbo].[UserDetail]")]
        Task<List<UserDetailModel>> GetAllUserDetailsAsync();

        [Sql(@"[dbo].[P_RegisterUser]")]
        Task<UserDetailModel> RegisterUserAsync(UserDetailModel userDetail);

        [Sql(@"SELECT TOP 1 * FROM  [dbo].[UserDetail]  WHERE UserName = @userName AND Password = @password")]
        Task<UserDetailModel> AuthenticateUser(string userName, string password);
    }
}