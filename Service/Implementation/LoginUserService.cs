using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectManager.Dto;
using ProjectManager.Repository.Interface;
using ProjectManager.Service.Interface;

namespace ProjectManager.Service.Implementation
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IUserRepository _userRepository;

        public LoginUserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public UserDto LogIn(LogInUserRequestModel model)
        {
            
            var logIn = _userRepository.GetUserForLogIn(model.Email, model.PassWord);
            if (logIn == null)
            {
                return null;

            }



            return new UserDto
            {
                Id = logIn.Id,
                Email = logIn.Email,
            };


        }
    }
}