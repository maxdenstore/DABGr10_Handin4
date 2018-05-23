﻿using System;
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
                GetProsumerByCopperID(prosumer.CopperID);

            }
            catch(Exception e)
            {
                Document created = await _Context.client.CreateDocumentAsync(_Context.ProsumorCollection.DocumentsLink, prosumer);
            }
        }

        public ProsumerDocDB.Models.Prosumer GetProsumerByCopperID(string CopperID)
        {
            ProsumerDocDB.Models.Prosumer prosumer = _Context.client.CreateDocumentQuery<ProsumerDocDB.Models.Prosumer>(_Context.ProsumorCollection.DocumentsLink)
                .Where(x => x.CopperID == CopperID)
                .AsEnumerable()
                .FirstOrDefault();
            if(prosumer == null)
            {
                throw new ArgumentException("Prosumer does not exsist");
            }
            return prosumer;
        }

        public void DeleteProsumer(string CopperID)
        {
            Document doc = GetDoc(CopperID);
            if( doc != null)
            {
                _Context.client.DeleteDocumentAsync(doc.SelfLink).Wait();
            }
        }

       private Document GetDoc(string CopperID)
       {
            return _Context.client.CreateDocumentQuery(_Context.ProsumorCollection.DocumentsLink).Where(x => x.Id == CopperID)
                .AsEnumerable().FirstOrDefault();
       }

    }
}
