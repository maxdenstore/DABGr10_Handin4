using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGT_DocDB.DBContext
{
    public class SGT_DocDBUnitOfWork
    {
        public SGT_DocDB.Repository.SGT_Repository _SGT_Repository;

        private readonly SGT_DocDB.DBContext.SGTDBContext _context;

        public SGT_DocDBUnitOfWork(SGT_DocDB.DBContext.SGTDBContext context)
        {
            _context = context;
            _SGT_Repository = new SGT_DocDB.Repository.SGT_Repository(_context);
        }
    }
}
