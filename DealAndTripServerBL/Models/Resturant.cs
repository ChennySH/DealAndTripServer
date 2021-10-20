using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class Resturant
    {
        public Resturant()
        {
            VacationsResturants = new HashSet<VacationsResturant>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
        public string WebSiteLink { get; set; }

        public virtual ICollection<VacationsResturant> VacationsResturants { get; set; }
    }
}
