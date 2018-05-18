using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace SGT_DocDB.Repository
{
    class SGT_Repository : Repository<SGT_DocDB.Models.SGT>
    {
        private SGT_DocDB.DBContext.SGTDBContext _context;

        public SGT_Repository(SGT_DocDB.DBContext.SGTDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddSGT(SGT_DocDB.Models.SGT sgt)
        {
            try
            {
                // TODO: Fix GetSGTbytransation
            }
            catch(Exception e)
            {
                Document created = await _Context.client.CreateDocumentAsync(_Context.SGT_Collection.DocumentsLink, sgt);
            }
        }


    }
}
