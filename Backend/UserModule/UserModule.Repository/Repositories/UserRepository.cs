using Dapper;
using User_Module.Modal;
using UserModule.Modal.DataAccess;
using UserModule.Repository.Repository_Interfaces;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;

namespace UserModule.Repository.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly SqlServerConnection _config;
        private readonly IStoredProcedures _storedProcedures;
        public UserRepository(SqlServerConnection config, IStoredProcedures storedProcedures)
        {
            _config = config;
            _storedProcedures = storedProcedures;
        }

        public async Task<User> UserExistsByPhonenumber(string phone)
        {
            var spName = "sp_GetUserByPhoneNumber";
            var parameter = new DynamicParameters();
            parameter.Add("Phone", phone);

            var user = await _storedProcedures.ExecuteStoredProcedureAsync<User>(spName, parameter);
            return user;
        }

        public async Task<User> UserExistsByEmail(string email)
        {
            var spName = "sp_GetUserByEmail";
            var parameter = new DynamicParameters();
            parameter.Add("Email", email);

            var user = await _storedProcedures.ExecuteStoredProcedureAsync<User>(spName, parameter);
            return user;
        }
        
        public async Task<GetUserDetails> GetUserByNumberOrEmail(string contact)
        {
            var spName = "sp_GetUserByEmailOrPhone";
            var parameter = new DynamicParameters();
            if (contact.Contains("@"))
                parameter.Add("Email", contact);
            else
                parameter.Add("Phone", contact);
            var details = await _storedProcedures.ExecuteStoredProcedureAsync<GetUserDetails>(spName, parameter);
            return details;
        }
    }
}

