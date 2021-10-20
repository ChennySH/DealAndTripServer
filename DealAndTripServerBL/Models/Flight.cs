using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class Flight
    {
        public Flight()
        {
            VacationEnterFlights = new HashSet<Vacation>();
            VacationExitFlights = new HashSet<Vacation>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime TakeOffTime { get; set; }
        public TimeSpan FlightTime { get; set; }
        public DateTime LandingTime { get; set; }
        public int StartingPointCityId { get; set; }
        public int DestinationCityId { get; set; }

        public virtual ICollection<Vacation> VacationEnterFlights { get; set; }
        public virtual ICollection<Vacation> VacationExitFlights { get; set; }
    }
}
