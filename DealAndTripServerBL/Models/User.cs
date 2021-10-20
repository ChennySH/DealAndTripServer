using System;
using System.Collections.Generic;

#nullable disable

namespace DealAndTripServerBL.Models
{
    public partial class User
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int PhoneNumber { get; set; }
        public int? TravelAgentId { get; set; }

        public virtual TravelAgent TravelAgentNavigation { get; set; }
        public virtual TravelAgent TravelAgent { get; set; }
    }
}
