using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class Mainland
    {
        public Mainland()
        {
            Countries = new HashSet<Country>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Country> Countries { get; set; }
    }
}
