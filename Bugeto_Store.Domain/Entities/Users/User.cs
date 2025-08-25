using Bugeto_Store.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bugeto_Store.Domain.Entities.Users
{
    public class User:BaseEntity
    {
        public string FullName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Pasword { get; set; }
        public bool IsActive { get; set; }
        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
