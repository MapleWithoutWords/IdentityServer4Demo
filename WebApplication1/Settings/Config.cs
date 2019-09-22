using IdentityServer4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Settings
{
    public class Config
    {
        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new List<IdentityResource>
            {
            new IdentityResources.OpenId(), //必须要添加，否则报无效的 scope 错误
            new IdentityResources.Profile(),
            new IdentityResources.Email()
            };
        }
    }
}
