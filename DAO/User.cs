using NHibernate;
using Spotifree.Helper;
using Spotifree.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Spotifree.DAO
{
    public class DAO_User:DAO_Abstract
    {
        public override Model_Abstract SearchById(int id)
        {
            User model = Session.Get<User>(id);

            return model;
        }

        public User FindByEmailPassword(string email, string password)
        {
            Password_Cryptography cryp = new Password_Cryptography();
            string hash = cryp.Encode(password);
            return Session.QueryOver<User>()
                    .Where(x => x.Email == email)
                    .Where(x => x.Password == hash)
                    .SingleOrDefault();
        }
    }
}