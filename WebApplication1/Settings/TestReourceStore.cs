using IdentityServer4.Models;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.Service;

namespace WebApplication1.Settings
{
    public class TestReourceStore : IResourceStore
    {
        public IApiResourceService resourceSvc { get; set; }
        public TestReourceStore(IApiResourceService resourceSvc)
        {
            this.resourceSvc = resourceSvc;
        }
        public async Task<ApiResource> FindApiResourceAsync(string name)
        {
            var entity = await resourceSvc.GetByNameAsync(name);
            return new ApiResource(entity.Name,entity.DisplayName);
        }

        public async Task<IEnumerable<ApiResource>> FindApiResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            var list = await resourceSvc.GetDatasByNamesAsync(scopeNames);
            return list.Select(e=>new ApiResource(e.Name,e.DisplayName));
        }

        public async Task<IEnumerable<IdentityResource>> FindIdentityResourcesByScopeAsync(IEnumerable<string> scopeNames)
        {
            return Config.GetIdentityResources().Where(e => scopeNames.Contains(e.Name)).ToList();
        }

        public async Task<Resources> GetAllResourcesAsync()
        {
            var list = await resourceSvc.GetNoramlAll();

            var resouces = list.Select(e => new ApiResource(e.Name, e.DisplayName)).ToList();
            return new Resources
            {
                ApiResources = resouces
            };

        }
    }
}
