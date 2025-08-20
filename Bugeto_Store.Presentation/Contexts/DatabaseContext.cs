using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Common.Roles;
using Bugeto_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bugeto_Store.Presistence.Contexts
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInRole> UserInRoles { get; set; }

        public int Savechanges(bool acceptAllChangesOnSucces)
        {
            throw new NotImplementedException();
        }

        public int Savechanges()
        {
            throw new NotImplementedException();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                Name = nameof(UserRoles.Admin),
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 2,
                Name = nameof(UserRoles.Operator),
            });
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 3,
                Name = nameof(UserRoles.Customer),
            });
        }

    }
}
