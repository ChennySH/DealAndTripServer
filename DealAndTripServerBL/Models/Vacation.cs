using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class Vacation
    {
        public Vacation()
        {
            HotelsVacactions = new HashSet<HotelsVacaction>();
            VacationsCities = new HashSet<VacationsCity>();
            VacationsResturants = new HashSet<VacationsResturant>();
            VacationsTravelSites = new HashSet<VacationsTravelSite>();
        }

        public int Id { get; set; }
        public string TravelAgentUserName { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Rank { get; set; }
        public int EnterFlightId { get; set; }
        public int ExitFlightId { get; set; }
        public int NightsNumber { get; set; }
        public int Price { get; set; }

        public virtual Flight EnterFlight { get; set; }
        public virtual Flight ExitFlight { get; set; }
        public virtual VacationType Type { get; set; }
        public virtual ICollection<HotelsVacaction> HotelsVacactions { get; set; }
        public virtual ICollection<VacationsCity> VacationsCities { get; set; }
        public virtual ICollection<VacationsResturant> VacationsResturants { get; set; }
        public virtual ICollection<VacationsTravelSite> VacationsTravelSites { get; set; }
    }
}
