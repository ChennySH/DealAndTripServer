using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DealAndTripServerBL.Models
{
    public partial class DealAndTripDBContext : DbContext
    {
        public string GetUserLastName()
        {
            return this.Users.Where(uc => uc.Email == "kuku@kuku.com").FirstOrDefault().LastName;
        }
        public User GetUser(string userNameOrEmail, string password)
        {
            User u = this.Users.Include(uc => uc.TravelAgent).Where(uc => uc.UserName == userNameOrEmail && uc.Password == password).FirstOrDefault();
            if (u != null)
                return u;
            else
                return this.Users.Include(uc => uc.TravelAgent).Where(uc => uc.Email == userNameOrEmail && uc.Password == password).FirstOrDefault();
        }
    }
}
