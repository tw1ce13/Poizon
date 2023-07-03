using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;
using System.Threading.Tasks;

namespace Poizon.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IBaseResponse<User>> Add(User user)
        {
            var baseResponse = new BaseResponse<User>();
            if (user != null)
            {
                await _userRepository.Add(user);
                baseResponse = new BaseResponse<User>
                {
                    Data = user,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<User>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<User>> Delete(User user)
        {
            var baseResponse = new BaseResponse<User>();
            if (user != null)
            {
                await _userRepository.Delete(user);
                baseResponse = new BaseResponse<User>
                {
                    Data = user,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<User>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<User>> GetUserByEmail(string email)
        {
            var baseResponse = new BaseResponse<User>();
            var user = await _userRepository.GetUserByEmail(email);
            if (user != null)
            {
                baseResponse = new BaseResponse<User>
                {
                    Data = user,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<User>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<User>> GetById(long id)
        {
            var baseResponse = new BaseResponse<User>();
            var user = await _userRepository.GetById(id);
            if (user != null)
            {
                baseResponse = new BaseResponse<User>
                {
                    Data = user,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<User>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<User>> Update(User user)
        {
            var baseResponse = new BaseResponse<User>();
            if (user != null)
            {
                await _userRepository.Update(user);
                baseResponse = new BaseResponse<User>
                {
                    Data = user,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<User>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }

        public async Task<IBaseResponse<IEnumerable<User>>> GetAll()
        {
            var baseResponse = new BaseResponse<IEnumerable<User>>();
            var usersInfo = await _userRepository.GetAll();
            if (usersInfo != null)
            {
                baseResponse = new BaseResponse<IEnumerable<User>>
                {
                    Data = usersInfo,
                    Description = "Success",
                    StatusCode = Domain.Enums.StatusCode.OK
                };
            }
            else
            {
                baseResponse = new BaseResponse<IEnumerable<User>>
                {
                    Description = "Error",
                    StatusCode = Domain.Enums.StatusCode.Error
                };
            }
            return baseResponse;
        }
    }
}
