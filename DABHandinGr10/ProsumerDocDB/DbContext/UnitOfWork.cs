using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerDocDB.DbContext
{
    public class ProsumerDocumentDBUnitOfWork
    {
        public ProsumerDocDB.Repository.ProsumerRepository _prosumerRepository;

        private readonly ProsumerDocDB.DbContext.ProsumerDbContext _context;

        public ProsumerDocumentDBUnitOfWork(ProsumerDocDB.DbContext.ProsumerDbContext context)
        {
            _context = context;
            _prosumerRepository = new ProsumerDocDB.Repository.ProsumerRepository(_context);
        }
    }
}
