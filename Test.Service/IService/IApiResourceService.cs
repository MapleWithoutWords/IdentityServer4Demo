using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Entity.Entities;

namespace Test.Service
{
    public interface IApiResourceService : IBaseService<APIResourceEntity>
    {
        Task<APIResourceEntity> GetByNameAsync(string name);

        Task<List<APIResourceEntity>> GetDatasByNamesAsync(IEnumerable<string> names);
    }
}
