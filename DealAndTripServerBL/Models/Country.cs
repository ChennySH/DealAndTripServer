using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class Country
    {
        public Country()
        {
            Cities = new HashSet<City>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int MainlandId { get; set; }

        public virtual Mainland Mainland { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
