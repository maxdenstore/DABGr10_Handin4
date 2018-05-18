using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_DocDB.Repository
{
    public class Repository<T> where T : class
    {
        protected readonly SGT_DocDB.DBContext.SGTDBContext _Context;

        public Repository(SGT_DocDB.DBContext.SGTDBContext context)
        {
            _Context = context;
        }
    }
}
