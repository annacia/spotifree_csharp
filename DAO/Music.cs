using Spotifree.Models;
using System.Collections.Generic;

namespace Spotifree.DAO
{
    public class DAO_Music:DAO_Abstract
    {
        private User user;
        private Category category;

        public override Model_Abstract SearchById(int id)
        {            
            return Session.QueryOver<Music>()
                    .JoinAlias(x => x.User, () => user)
                    .JoinAlias(x => x.Category, () => category)
                    .Where(x => x.Id == id)
                    .SingleOrDefault();
        }

        public IList<Music> Search()
        {
            return Session.QueryOver<Music>()
                    .JoinAlias(x => x.User, () => user)
                    .JoinAlias(x => x.Category, () => category)
                    .List();
        }
    }
}