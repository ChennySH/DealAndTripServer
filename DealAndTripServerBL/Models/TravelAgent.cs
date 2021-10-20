using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class TravelAgent
    {
        public TravelAgent()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public int Rank { get; set; }
        public string UserName { get; set; }

        public virtual User UserNameNavigation { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
