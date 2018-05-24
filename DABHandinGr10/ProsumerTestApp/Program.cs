using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB;
using ProsumerDocDB.DbContext;
using ProsumerDocDB.Models;

namespace ProsumerTestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var prosumer = new Prosumer();
            prosumer.CopperID = "4";
            prosumer.smartmeter = 10;
            prosumer.wallet = 100;
            prosumer.prosumerType = "private";

            ProsumerDocumentDBUnitOfWork x = new ProsumerDocDB.DbContext
                .ProsumerDocumentDBUnitOfWork(new ProsumerDocDB.DbContext.ProsumerDbContext());

            x._prosumerRepository.AddProsumer(prosumer).Wait();
            //x._prosumerRepository.DeleteProsumer("4");

        }
    }
}
