using System;
using System.Collections.Generic;
using System.Text;
using Test.Entity.Entities;

namespace Test.Service.DTO
{
    public class ClientDTO
    {
        public ClientEntity Client { get; set; } = new ClientEntity();
        public List<APIResourceEntity> APIResources { get; set; } = new List<APIResourceEntity>();
    }
}
