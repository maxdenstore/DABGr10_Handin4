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
            prosumer.CopperID = "2";
            prosumer.smartmeter = 131;
            prosumer.wallet = 10;
            prosumer.prosumerType = "private";

            ProsumerDocumentDBUnitOfWork x = new ProsumerDocDB.DbContext
                .ProsumerDocumentDBUnitOfWork(new ProsumerDocDB.DbContext.ProsumerDbContext());

          //  x._prosumerRepository.AddProsumer(prosumer).Wait();
           var test = x._prosumerRepository.GetProsumerByCopperID(prosumer.CopperID);

            var test2 = x._prosumerRepository.GetProsumerByCopperID("4");


              Console.WriteLine("CopperID: " + test.CopperID + "\n" + "Prosumer Type: "+ test.prosumerType + "\n" + "SmartMeter: " + test.smartmeter +"\n" + "Wallet: " +test.wallet + "\n");
            Console.WriteLine("CopperID: " + test2.CopperID + "\n" + "Prosumer Type: " + test2.prosumerType + "\n" + "SmartMeter: " + test2.smartmeter + "\n" + "Wallet: " + test2.wallet + "\n");

            //x._prosumerRepository.DeleteProsumer("4");

        }
    }
}
