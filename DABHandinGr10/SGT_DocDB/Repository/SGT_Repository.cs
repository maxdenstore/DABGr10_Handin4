using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;
using SGT_DocDB.DBContext;

namespace SGT_DocDB.Repository
{
    public class SGT_Repository : Repository<SGT_DocDB.Models.Transaction>
    {
        private SGT_DocDB.DBContext.SGTDBContext _context;


        public SGT_Repository(SGT_DocDB.DBContext.SGTDBContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddTransaction(SGT_DocDB.Models.Transaction sgt)
        {
            try
            {
                GetTransactionById(sgt.transactionId);
            }
            catch(Exception e)
            {
                //_Context.temp = _Context.upcommingTransactions;   
                Document created = await _Context.client.CreateDocumentAsync(_Context.temp.DocumentsLink, sgt);
            }
        }

        public SGT_DocDB.Models.Transaction GetTransactionById(string transId)
        {
            SGT_DocDB.Models.Transaction sgt = _Context.client.CreateDocumentQuery<SGT_DocDB.Models.Transaction>(_Context.temp.DocumentsLink)
                .Where(x => x.transactionId == transId)
                .AsEnumerable()
                .FirstOrDefault();

            if(sgt== null)
            {
                throw new ArgumentException("Transaction does not exsist");
            }
            return sgt;
        }


        public void DeleteTransaction(string transId)
        {
            Document doc = GetDoc(transId);
            if (doc != null)
            {
                _Context.client.DeleteDocumentAsync(doc.SelfLink).Wait();
            }
        }

        private Document GetDoc(string transId)
        {
            return _Context.client.CreateDocumentQuery(_Context.temp.DocumentsLink).Where(x => x.Id == transId)
                .AsEnumerable().FirstOrDefault();
        }
    }
}
