using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Entity.Entities;
using Test.Service.DTO;

namespace Test.Service.ServiceImpl
{
    public class ClientServiceImpl : BaseServiceImpl<ClientEntity>, IClientService
    {
        public virtual async Task<ClientDTO> FindClientByIdAsync(string clientId)
        {
            var client = await Db.Set<ClientEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Id == clientId);
            if (client == null)
            {
                return null;
            }
            var resourceIds = await Db.Set<ClientAPIResourceEntity>().Where(e => e.ClientId == clientId).Select(e => e.APIResourceId).ToListAsync();
            var apiResources =await Db.Set<APIResourceEntity>().AsNoTracking().Where(e => resourceIds.Contains(e.Id)).ToListAsync();

            return new ClientDTO
            {
                Client = client,
                APIResources = apiResources
            };
        }
    }
}
