using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Services
{
    public interface IAuthService
    {
        Task<ApiResponse> Login(LoginModel loginRequest);
        Task<ApiResponse> Register(RegisterModel registerRequest);
        Task<ApiResponse> Logout();
        //Task<CurrentUser> CurrentUserInfo();
    }
}
