using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class VacationType
    {
        public VacationType()
        {
            Vacations = new HashSet<Vacation>();
        }

        public int Id { get; set; }
        public string TypeName { get; set; }
        public string TypeDescription { get; set; }

        public virtual ICollection<Vacation> Vacations { get; set; }
    }
}
