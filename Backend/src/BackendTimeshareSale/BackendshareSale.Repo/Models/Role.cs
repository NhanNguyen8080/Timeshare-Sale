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
            Investors = new HashSet<Investor>();
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Investor> Investors { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
