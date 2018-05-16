using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var prosumer = new ProsumerDocDB.Models.Prosumer();
            prosumer.copperId = 1;
            prosumer.smartmeter = 10;
            prosumer.wallet = 100;
            prosumer.prosumerType = "private";

            ProsumerDocDB.DbContext.ProsumerDocumentDBUnitOfWork x = new ProsumerDocDB.DbContext
                .ProsumerDocumentDBUnitOfWork(new ProsumerDocDB.DbContext.ProsumerDbContext());

            x._prosumerRepository.AddProsumer(prosumer).Wait();

        }
    }
}
