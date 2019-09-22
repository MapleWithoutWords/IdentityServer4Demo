using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Service;

namespace WebApplication1.Settings
{
    public class TestClientStore : IClientStore
    {
        public IClientService ClientSvc { get; set; }
        public IClientApiResourceService ClientApiResourceSvc { get; set; }
        public IApiResourceService ApiResourceSvc { get; set; }
        public TestClientStore(IClientService ClientSvc, IClientApiResourceService ClientApiResourceSvc, IApiResourceService ApiResourceSvc)
        {
            this.ClientSvc = ClientSvc;
            this.ClientApiResourceSvc = ClientApiResourceSvc;
            this.ApiResourceSvc = ApiResourceSvc;
        }
        public async Task<Client> FindClientByIdAsync(string clientId)
        {
            var dto = await ClientSvc.FindClientByIdAsync(clientId);
            if (dto==null)
            {
                return null;
            }
            var scopes = dto.APIResources.Select(e => e.Name).ToList();
            scopes.Add(IdentityServerConstants.StandardScopes.OpenId);
            scopes.Add(IdentityServerConstants.StandardScopes.Profile);
            return new Client
            {
                ClientId = dto.Client.Id,//API账号、客户端Id
                AllowedGrantTypes = GrantTypes.ResourceOwnerPassword,
                ClientSecrets =
                 {
                    new Secret(dto.Client.Secret.Sha256())//秘钥
                 },
                AllowedScopes = scopes//这个账号支持访问哪些应用
            };
        }
    }
}
