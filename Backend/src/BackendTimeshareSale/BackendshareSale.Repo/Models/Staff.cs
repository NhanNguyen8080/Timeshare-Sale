using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Staff
    {
        public Staff()
        {
            Bookings = new HashSet<Booking>();
        }

        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Photo { get; set; }
        public string Salary { get; set; }
        public bool? Status { get; set; }
        public string Department { get; set; }
        public int? UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
