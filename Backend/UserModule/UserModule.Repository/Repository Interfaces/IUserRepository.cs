using User_Module.Modal;
using UserModule.ViewModal.RequestModal.Mapper.View_Modal;

namespace UserModule.Repository.Repository_Interfaces
{
    public interface IUserRepository
    {
        Task<User> UserExistsByPhonenumber(string phone);
        Task<User> UserExistsByEmail(string email);
        Task<GetUserDetails> GetUserByNumberOrEmail(string contact);
    }
}
