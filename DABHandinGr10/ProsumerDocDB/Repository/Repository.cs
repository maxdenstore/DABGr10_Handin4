using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerDocDB.Repository
{
    public class Repository<T> where T : class
    {
        protected readonly ProsumerDocDB.DbContext.ProsumerDbContext _Context;

        public Repository(ProsumerDocDB.DbContext.ProsumerDbContext context)
        {
            _Context = context;
        }
    }
}
