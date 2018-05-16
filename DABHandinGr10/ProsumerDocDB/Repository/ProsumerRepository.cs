using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Documents;
using Microsoft.Azure.Documents.Client;

namespace ProsumerDocDB.Repository
{
    public class ProsumerRepository : Repository<ProsumerDocDB.Models.Prosumer>
    {
        private ProsumerDocDB.DbContext.ProsumerDbContext _context;
        
        public ProsumerRepository(ProsumerDocDB.DbContext.ProsumerDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProsumer(ProsumerDocDB.Models.Prosumer prosumer)
        {
            try
            {
                GetProsumerByCopperId(prosumer.copperId);

            }
            catch(Exception e)
            {
                Document created = await _Context.client.CreateDocumentAsync(_Context.ProsumorCollection.DocumentsLink, prosumer);
            }
        }

        public ProsumerDocDB.Models.Prosumer GetProsumerByCopperId(int copperId)
        {
            ProsumerDocDB.Models.Prosumer prosumer = _Context.client.CreateDocumentQuery<ProsumerDocDB.Models.Prosumer>(_Context.ProsumorCollection.DocumentsLink)
                .Where(x => x.copperId == copperId)
                .AsEnumerable()
                .FirstOrDefault();
            if(prosumer == null)
            {
                throw new ArgumentException("Prosumer does not exsist");
            }
            return prosumer;
        }

        public void DeleteProsumer(int copperId)
        {
            Document doc = GetDoc(copperId);
            if( doc != null)
            {
                _Context.client.DeleteDocumentAsync(doc.SelfLink).Wait();
            }
        }

       private Document GetDoc(int copperId)
       {
            return _Context.client.CreateDocumentQuery(_Context.ProsumorCollection.DocumentsLink).Where(x => x.Id == copperId.ToString())
                .AsEnumerable().FirstOrDefault();
       }

    }
}
