using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Test.Entity.Entities;

namespace Test.Service.ServiceImpl
{
    public class UserServiceImpl : BaseServiceImpl<UserEntity>, IUserService
    {

        public async Task<UserEntity> Login(string account, string pwd)
        {
            var user = await Db.Set<UserEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Account == account);
            if (user == null)
            {
                return null;
            }
            if (user.Password != pwd)
            {
                return null;
            }
            return user;
        }
    }
}
