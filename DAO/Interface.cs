using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spotifree.DAO
{
    interface Interface
    {
        public void Create(object model);

        public Array Read(string table, string where);

        public void Update(object model);

        public void Delete(object model);
    }
}
