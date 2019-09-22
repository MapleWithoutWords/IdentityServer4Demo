using IdentityServer4.Models;
using IdentityServer4.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Test.Service;

namespace WebApplication1.Settings
{
    public class TestResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        public IUserService UserSvc { get; set; }
        public TestResourceOwnerPasswordValidator(IUserService UserSvc)
        {
            this.UserSvc = UserSvc;
        }
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            string account = context.UserName;
            string pwd = context.Password;

            var loginResult = await UserSvc.Login(account, pwd);

            if (loginResult == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant, "invalid custom credential");
                return;
            }
            context.Result = new GrantValidationResult(
                     subject: context.UserName,
                     authenticationMethod: "custom",
                     claims: new Claim[] {
                         new Claim("Name",context.UserName),
                         new Claim("UserId",loginResult.Id),
                         new Claim("Roles","Admin,Contact"),    //模拟获取登录用户的角色信息
                         new Claim("Premissions","List,Delete") //模拟获取登录用户的权限信息
                          });
        }
    }
}
