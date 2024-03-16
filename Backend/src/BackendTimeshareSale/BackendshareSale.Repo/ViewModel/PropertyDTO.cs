using BackendshareSale.Repo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackendshareSale.Repo.ViewModel
{
    public class PropertyDTO
    {
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public decimal? Price { get; set; }
        public bool? IsAvailable { get; set; }
        public string Description { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Images { get; set; }
        public int? OwnerId { get; set; }
    }

    public class PropertyVM : PropertyDTO
    {
        public virtual ICollection<Booking>? Bookings { get; set; }
        public virtual ICollection<BookmarkTimeShare>? BookmarkTimeShares { get; set; }

    }
}
