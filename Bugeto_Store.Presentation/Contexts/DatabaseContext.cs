using Bugeto_Store.Application.Interfaces.Contexts;
using Bugeto_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Bugeto_Store.Presistence.Contexts
{
    public class DatabaseContext:DbContext , IDatabaseContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<User> Users {  get; set; }
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
    }
}
