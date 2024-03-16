using System;
using System.Collections.Generic;


namespace BackendshareSale.Repo.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
            BookmarkTimeShares = new HashSet<BookmarkTimeShare>();
            Properties = new HashSet<Property>();
            UserRoles = new HashSet<UserRole>();
            staff = new HashSet<Staff>();
        }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? HashPassword { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? Country { get; set; }
        public string? Address { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? CitizenId { get; set; }
        public bool? IsActive { get; set; }
        public string?PhoneNumber { get; set; }
        public string? RefreshToken { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<BookmarkTimeShare> BookmarkTimeShares { get; set; }
        public virtual ICollection<Property> Properties { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Staff> staff { get; set; }
    }
}
