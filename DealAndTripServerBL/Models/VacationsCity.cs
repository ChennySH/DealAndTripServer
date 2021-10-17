using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class VacationsCity
    {
        public int Id { get; set; }
        public int VacationId { get; set; }
        public int CityId { get; set; }

        public virtual City City { get; set; }
        public virtual Vacation Vacation { get; set; }
    }
}
