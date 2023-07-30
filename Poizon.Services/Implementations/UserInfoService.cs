using Poizon.DAL.Interfaces;
using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Services.Interfaces;

namespace Poizon.Services.Implementations;

public class UserInfoService : IUserInfoService
{
    private readonly IUserInfoRepository _userInfoRepository;

    public UserInfoService(IUserInfoRepository userInfoRepository)
    {
        _userInfoRepository = userInfoRepository;
    }

    public async Task<IBaseResponse<UserInfo>> Add(UserInfo userInfo)
    {
        var baseResponse = new BaseResponse<UserInfo>();
        if (userInfo != null)
        {
            await _userInfoRepository.Add(userInfo);
            baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<UserInfo>> Delete(UserInfo userInfo)
    {
        var baseResponse = new BaseResponse<UserInfo>();
        if (userInfo != null)
        {
            await _userInfoRepository.Delete(userInfo);
            baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<UserInfo>>> GetAll()
    {
        var baseResponse = new BaseResponse<IEnumerable<UserInfo>>();
        var usersInfo = await _userInfoRepository.GetAll();
        if (usersInfo != null)
        {
            baseResponse = new BaseResponse<IEnumerable<UserInfo>>
            {
                Data = usersInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<UserInfo>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<UserInfo>> GetById(long id)
    {
        var baseResponse = new BaseResponse<UserInfo>();
        var userInfo = await _userInfoRepository.GetById(id);
        if (userInfo != null)
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<UserInfo>>> GetUsersByName(string name)
    {
        var baseResponse = new BaseResponse<IEnumerable<UserInfo>>();
        var usersInfo = await _userInfoRepository.GetUsersByName(name);
        if (usersInfo != null)
        {
            baseResponse = new BaseResponse<IEnumerable<UserInfo>>
            {
                Data = usersInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<UserInfo>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<IEnumerable<UserInfo>>> GetUsersBySurname(string surname)
    {
        var baseResponse = new BaseResponse<IEnumerable<UserInfo>>();
        var usersInfo = await _userInfoRepository.GetUsersBySurname(surname);
        if (usersInfo != null)
        {
            baseResponse = new BaseResponse<IEnumerable<UserInfo>>
            {
                Data = usersInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<IEnumerable<UserInfo>>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<UserInfo>> GetUserInfoByUserId(long id)
    {
        var baseResponse = new BaseResponse<UserInfo>();
        var userInfo = await _userInfoRepository.GetUserInfoByUserId(id);
        if (userInfo != null)
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "No Info",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<UserInfo>> Update(UserInfo userInfo)
    {
        var baseResponse = new BaseResponse<UserInfo>();
        if (userInfo != null)
        {
            await _userInfoRepository.Update(userInfo);
            baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            baseResponse = new BaseResponse<UserInfo>
            {
                Description = "Error",
                StatusCode = Domain.Enums.StatusCode.Error
            };
        }
        return baseResponse;
    }

    public async Task<IBaseResponse<UserInfo>> GetChanges(UserInfo userInfo)
    {
        var baseResponse = new BaseResponse<UserInfo>();
        var user = await _userInfoRepository.GetUserInfoByUserId(userInfo.UserId);
        if (user == null)
        {
            await _userInfoRepository.Add(userInfo);
            return baseResponse = new BaseResponse<UserInfo>
            {
                Data = userInfo,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        else
        {
            user.Name = userInfo.Name;
            user.Surname = userInfo.Surname;
            user.Age = userInfo.Age;

            await _userInfoRepository.Update(user);
            return baseResponse = new BaseResponse<UserInfo>
            {
                Data = user,
                Description = "Success",
                StatusCode = Domain.Enums.StatusCode.OK
            };
        }
        
    }
}
