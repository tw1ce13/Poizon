using System.Security.Claims;
using Poizon.DAL.Implementations;
using Poizon.Domain.Helpers;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Domain.ViewModel;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserRepository _userRepository;
        public AccountService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>
                {
                    Description = "Пользователь не найден"
                };
            }
            if (user.Password != HashPassword.HashPassowrd(model.Password))
            {
                return new BaseResponse<ClaimsIdentity>()
                {
                    Description = "Неверный пароль или логин"
                };
            }

            var result = Authenticate(user);
            return new BaseResponse<ClaimsIdentity>
            {
                Data = result,
                Description = "Успешно",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }

        public async Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model)
        {
            var user = await _userRepository.GetUserByEmail(model.Email);
            if (user == null)
            {
                return new BaseResponse<ClaimsIdentity>
                {
                    Description = "Пользователь с таким логином уже есть"
                };
            }
            user = new User()
            {
                Email = model.Email,
                Role = Domain.Enums.Role.User,
                Password = HashPassword.HashPassowrd(model.Password)
            };
            await _userRepository.Add(user);

            var result = Authenticate(user);
            return new BaseResponse<ClaimsIdentity>
            {
                Data = result,
                Description = "Пользователь добавлен",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }

        private ClaimsIdentity Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.ToString())
            };
            return new ClaimsIdentity(claims, "ApplicationCookie",
                ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}

