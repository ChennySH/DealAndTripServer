using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class VacationsTravelSite
    {
        public int Id { get; set; }
        public int VacationId { get; set; }
        public int SiteId { get; set; }

        public virtual TravelSite Site { get; set; }
        public virtual Vacation Vacation { get; set; }
    }
}
