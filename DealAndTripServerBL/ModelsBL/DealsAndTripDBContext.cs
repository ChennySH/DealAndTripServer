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
        public User GetUser(string userName)
        {
            return this.Users.Include(uc=>uc.).Where(uc => uc.UserName == userName)
        }
    }
}
