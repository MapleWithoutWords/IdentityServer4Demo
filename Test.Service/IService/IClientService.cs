using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Entity.Entities;
using Test.Service.DTO;

namespace Test.Service
{
    public interface IClientService:IBaseService<ClientEntity>
    {
        Task<ClientDTO> FindClientByIdAsync(string clientId);
    }
}
