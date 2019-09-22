using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Test.Entity.Entities;

namespace Test.Entity
{
    public class TestDbContext : DbContext
    {
        public TestDbContext() { }
        public TestDbContext(DbContextOptions options):base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySql(new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build().GetSection("connectionString").Value);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientEntity>(option =>
            {
                option.ToTable("tab_clients");
            });
            modelBuilder.Entity<APIResourceEntity>(option =>
            {
                option.ToTable("tab_api_resources");
            });
            modelBuilder.Entity<UserEntity>(option =>
            {
                option.ToTable("tab_users");
            });
            modelBuilder.Entity<ClientAPIResourceEntity>(option =>
            {
                option.ToTable("tab_client_api_resource");
            });
        }
    }
}
