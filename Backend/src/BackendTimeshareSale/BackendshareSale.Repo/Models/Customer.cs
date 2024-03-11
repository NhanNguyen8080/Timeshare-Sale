using System;
using System.Collections.Generic;

#nullable disable

namespace BackendshareSale.Repo.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Bookings = new HashSet<Booking>();
        }

        public int CusId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CusEmail { get; set; }
        public string Gender { get; set; }
        public string CitizenId { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string CusAddress { get; set; }
        public bool? IsActive { get; set; }
        public int? BookingHistory { get; set; }
        public int? RoleId { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
