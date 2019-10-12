using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class UserContext: DbContext
    {
        public UserContext() : base()
        {

        }

        public DbSet<User> User { get; set; }
    }
}