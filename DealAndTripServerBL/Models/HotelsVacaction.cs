using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{

    public partial class HotelsVacaction
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public int VacationId { get; set; }
        public int NightsNumber { get; set; }

        public virtual Hotel Hotel { get; set; }
        public virtual Vacation Vacation { get; set; }
    }
}
