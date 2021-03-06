using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using _0_Framework.Infrastucture;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace _0_Framework.App
{
    public class AuthHelper : IAuthHelper
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public AuthHelper(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public AuthViewModel CurrentAccountInfo()
        {
            var result = new AuthViewModel();
            if (!IsAuthenticated())
                return result;

            var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            result.AccountID = int.Parse(claims.FirstOrDefault(x => x.Type == "AccountID").Value);
            result.UserName = claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
            result.RoleID = int.Parse(claims.FirstOrDefault(x => x.Type == ClaimTypes.Role).Value);
            result.FullName = claims.FirstOrDefault(x => x.Type == ClaimTypes.Name).Value;
            result.Role = RolesAccess.GetRoleByID(result.RoleID);
            result.ProfilePhoto = claims.FirstOrDefault(x => x.Type == "ProfilePhoto")?.Value;
            return result;
        }

        public List<byte> GetPermissions()
        {
            if (!IsAuthenticated())
                return new List<byte>();

            var permissions = _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "permissions")?.Value;
            return JsonConvert.DeserializeObject<List<byte>>(permissions);
        }

        public long CurrentAccountId()
        {
            return IsAuthenticated()
                ? long.Parse(_contextAccessor.HttpContext.User.Claims.First(x => x.Type == "AccountId")?.Value)
                : 0;
        }

        public string CurrentAccountMobile()
        {
            return IsAuthenticated()
                ? _contextAccessor.HttpContext.User.Claims.First(x => x.Type == "Mobile")?.Value
                : "";
        }

        public string CurrentAccountRole()
        {
            if (IsAuthenticated())
                return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Role)?.Value;
            return null;
        }

        public bool IsAuthenticated()
        {
            return _contextAccessor.HttpContext.User.Identity.IsAuthenticated;
            //var claims = _contextAccessor.HttpContext.User.Claims.ToList();
            ////if (claims.Count > 0)
            ////    return true;
            ////return false;
            //return claims.Count > 0;
        }

        public void Signin(AuthViewModel account)
        {
            var permissions = JsonConvert.SerializeObject(account.Permissions);
            var claims = new List<Claim>
            {
                new Claim("AccountID", account.AccountID.ToString()),
                new Claim(ClaimTypes.Name, account.FullName),
                new Claim(ClaimTypes.Role, account.RoleID.ToString()),
                new Claim(ClaimTypes.NameIdentifier, account.UserName),
                new Claim("permissions", permissions),
                //new Claim("Mobile", account.FullName)
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1)
            };

            _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        public void SignOut()
        {
            _contextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        //public string CurrentAccountProfilePhoto()
        //{
        //    return _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "ProfilePhoto")?.Value;
        //}
    }
}