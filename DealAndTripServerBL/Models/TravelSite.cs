using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class TravelSite
    {
        public TravelSite()
        {
            VacationsTravelSites = new HashSet<VacationsTravelSite>();
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public string WebSiteLink { get; set; }

        public virtual ICollection<VacationsTravelSite> VacationsTravelSites { get; set; }
    }
}
