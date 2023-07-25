using Poizon.Domain.Models;
using Poizon.Domain.Response;
using Poizon.Domain.ViewModel;
using System.Security.Claims;

namespace Poizon.Services.Interfaces;

public interface IAccountService
{
    Task<BaseResponse<ClaimsIdentity>> Register(RegisterViewModel model);
    Task<BaseResponse<ClaimsIdentity>> Login(LoginViewModel model);
    Task<BaseResponse<User>> ChangePassword(ChangePasswordViewModel model);
}

