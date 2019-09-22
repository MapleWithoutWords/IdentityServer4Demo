using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Test.Entity.Entities;

namespace Test.Service
{
    public interface IUserService : IBaseService<UserEntity>
    {
        Task<UserEntity> Login(string account,string pwd);
    }
}
