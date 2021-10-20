using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
            HotelsVacactions = new HashSet<HotelsVacaction>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string WebSiteLink { get; set; }

        public virtual ICollection<HotelsVacaction> HotelsVacactions { get; set; }
    }
}
