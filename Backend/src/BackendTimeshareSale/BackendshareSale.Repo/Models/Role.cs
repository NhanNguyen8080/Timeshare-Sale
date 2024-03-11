using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Role
    {
        public Role()
        {
            Customers = new HashSet<Customer>();
            UserRoles = new HashSet<UserRole>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
