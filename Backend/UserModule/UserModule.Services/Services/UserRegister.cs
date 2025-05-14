using AutoMapper;
using User_Module.Modal;
using UserModule.Repository.Repository_Interfaces;
using UserModule.Services.Service_Interfaces;
using UserModule.ViewModal.RequestModal.Mapper.Request_Modal;

namespace UserModule.Services.Services
{
    public class UserRegister : IUserRegister
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IUserRegisterRepository _userRegisterRepository;
        public UserRegister(IUserRepository userRepository, IMapper mapper, IUserRegisterRepository userRegisterRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _userRegisterRepository = userRegisterRepository;
        }

        public async Task<User_Register> UserRegisterAsync(User_Register user)
        {
            var userByNumber = await _userRepository.UserExistsByPhonenumber(user.Phone);
            var userByEmail = await _userRepository.UserExistsByEmail(user.Email);

            if (userByNumber != null)
                throw new Exception("Phone number already exists.");

            if (userByEmail != null)
                throw new Exception("Email already exists.");

            var userEntity = _mapper.Map<User>(user);
            var result = await _userRegisterRepository.AddNewUser(userEntity);

            if (result == null)
                throw new Exception("User registration failed.");

            var newUser = _mapper.Map<User_Register>(result);
            return newUser;
        }

    }
}
