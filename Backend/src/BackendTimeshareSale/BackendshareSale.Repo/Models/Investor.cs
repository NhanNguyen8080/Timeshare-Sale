using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Investor
    {
        public Investor()
        {
            Properties = new HashSet<Property>();
        }

        public int InvestorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string CitizenId { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        public bool? IsActive { get; set; }
        public int? Revenue { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
    }
}
