using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class City
    {
        public City()
        {
            VacationsCities = new HashSet<VacationsCity>();
        }

        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<VacationsCity> VacationsCities { get; set; }
    }
}
