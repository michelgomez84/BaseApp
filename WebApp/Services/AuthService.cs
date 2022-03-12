using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<ApiResponse> Login(LoginModel request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiResponse() { Result=false,Message= "User does not exist" };
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) return new ApiResponse() { Result = false, Message = "Invalid password" };
            await _signInManager.SignInAsync(user, request.RememberMe);
            return new ApiResponse() { Result = true};
        }
        
        public async Task<ApiResponse> Register(RegisterModel parameters)
        {
            var user = new ApplicationUser();
            user.UserName = parameters.UserName;
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return new ApiResponse() { Result = false, Message = result.Errors.FirstOrDefault()?.Description };

            return await Login(new LoginModel
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }
        
        //[Authorize]
        public async Task<ApiResponse> Logout()
        {
            await _signInManager.SignOutAsync();
            return new ApiResponse() { Result = true };
        }
        
        //public CurrentUser CurrentUserInfo()
        //{
        //    return new CurrentUser
        //    {
        //        IsAuthenticated = User.Identity.IsAuthenticated,
        //        UserName = User.Identity.Name,
        //        Claims = User.Claims
        //        .ToDictionary(c => c.Type, c => c.Value)
        //    };
        //}
    
    }
}
