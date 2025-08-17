using Bugeto_Store.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bugeto_Store.Application.Interfaces.Contexts
{
    public interface IDatabaseContext
    {
         DbSet<User> Users { get; set; }
         DbSet<Role> Roles { get; set; }
         DbSet<UserInRole> UserInRoles { get; set; }

        int Savechanges(bool acceptAllChangesOnSucces);
        int Savechanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSucces, CancellationToken canlcellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());  
    }
}
 