using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using User_Module.Modal;
using UserModule.Repository.Repository_Interfaces;

namespace UserModule.Repository.Repositories
{
    public class UserRegisterRepository : IUserRegisterRepository
    {
        private readonly IStoredProcedures _storedProcedures;

        public UserRegisterRepository(IStoredProcedures storedProcedures)
        {
            _storedProcedures = storedProcedures;
        }

        public async Task<User> AddNewUser(User userDetials)
        {
            var spName = "sp_AddNewUser";
            var parameter = new DynamicParameters();
            parameter.Add("Name", userDetials.Name);
            parameter.Add("Email", userDetials.Email);
            parameter.Add("Phone",userDetials.Phone);
            parameter.Add("RoleId", userDetials.RoleId);

            var user = await _storedProcedures.ExecuteStoredProcedureAsync<User>(spName, parameter);
            return user;
        }
    }
}
