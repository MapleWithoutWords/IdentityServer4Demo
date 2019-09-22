using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Entity.Entities;

namespace Test.Service.ServiceImpl
{
    public class ApiResourceServiceImpl : BaseServiceImpl<APIResourceEntity>, IApiResourceService
    {
        public async Task<APIResourceEntity> GetByNameAsync(string name)
        {
            return await Db.Set<APIResourceEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Name == name);
        }

        public async Task<List<APIResourceEntity>> GetDatasByNamesAsync(IEnumerable<string> names)
        {
            return await Db.Set<APIResourceEntity>().AsNoTracking().Where(e=>names.Contains(e.Name)).ToListAsync();
        }
    }
}
