using System;
using System.Collections.Generic;
using System.Linq;
using Test.Entity;
using Test.Entity.Entities;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (TestDbContext db = new TestDbContext())
            {
                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                //List<APIResourceEntity> aPIResource = new List<APIResourceEntity> {
                //    new APIResourceEntity() {  Name="PostAPI", DisplayName="帖子接口"},
                //    new APIResourceEntity() {  Name="UserAPI", DisplayName="用户接口"}
                //};
                //db.Set<APIResourceEntity>().AddRange(aPIResource);


                //List<ClientEntity> clients = new List<ClientEntity>() {
                //     new ClientEntity{ Name="手机端", Secret="147369" },
                //     new ClientEntity{ Name="电脑端", Secret="147369"  },
                //};
                //db.Set<ClientEntity>().AddRange(clients);

                //List<ClientAPIResourceEntity> clientAPIResourceEntities = new List<ClientAPIResourceEntity>() {
                //     new ClientAPIResourceEntity{  APIResourceId=aPIResource[0].Id, ClientId=clients[0].Id },
                //     new ClientAPIResourceEntity{APIResourceId=aPIResource[1].Id, ClientId=clients[1].Id },
                //};
                //db.Set<ClientAPIResourceEntity>().AddRange(clientAPIResourceEntities);

                db.Set<UserEntity>().Add(new UserEntity { Account="liming", Password="123456" });

                db.SaveChanges();

            }
            Console.WriteLine("ok");

            Console.ReadKey();
        }
    }
}
