using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Models;
using SGT_DocDB.DBContext;
using SGT_DocDB.Models;
using SGT_logic;
using VillageSqlDB.Models;

namespace SGT_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1 class1 = new Class1();
            Village village = new Village();
            National national = new National();
            ICollection<Prosumer> prosumers = new List<Prosumer>();
            Prosumer prosumer1 = new Prosumer();
            prosumer1.CopperID = "1";
            prosumer1.prosumerType = "prosumer";
            prosumer1.smartmeter = 3;
            prosumer1.wallet = 3;

            Prosumer prosumer2 = new Prosumer();
            prosumer2.CopperID = "2";
            prosumer2.prosumerType = "prosumer";
            prosumer2.smartmeter = -4;
            prosumer2.wallet = 3;

            Prosumer prosumer3 = new Prosumer();
            prosumer3.CopperID = "3";
            prosumer3.prosumerType = "prosumer";
            prosumer3.smartmeter = -1;
            prosumer3.wallet = 3;

            Prosumer prosumer4 = new Prosumer();
            prosumer4.CopperID = "4";
            prosumer4.prosumerType = "prosumer";
            prosumer4.smartmeter = -2;
            prosumer4.wallet = 3;

            prosumers.Add(prosumer1);
            prosumers.Add(prosumer2);
            prosumers.Add(prosumer3);
            prosumers.Add(prosumer4);

            village.CookerAmount = 1;
            village.CookerCapacity = 32;
            village.CookerConsumption = 3;
            village.VillageID = 3;
            village.VillageMeter = prosumer1.smartmeter + prosumer2.smartmeter + prosumer3.smartmeter + prosumer4.smartmeter;
            village.VillageName = "lol";
            village.Villages = prosumers;

            national.Villages.Add(village);
            national.NationalID = 2;
            national.NationName = "hej";

            class1.addTransactions(national);

            /*Transaction trans = new Transaction
            {
                transactionId = "1",
                amount = 100,
                buyerId = "1",
                buyerType = "prviat",
                sellerId = "2",
                sellerType = "privat",
                transactionType = "upcomming"
            };
            Transaction trans1 = new Transaction
            {
                transactionId = "2",
                amount = 100,
                buyerId = "21",
                buyerType = "prviat",
                sellerId = "23",
                sellerType = "privat",
                transactionType = "ongoing"
            };*/





            SGT_DocDB.DBContext.SGT_DocDBUnitOfWork x =
                new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("upcomming"));

            SGT_DocDB.DBContext.SGT_DocDBUnitOfWork y =
                new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("onGoing"));

            /*x._SGT_Repository.AddTransaction(trans).Wait();

            //x._SGT_Repository.AddTransaction(trans).Wait();


            //x._SGT_Repository.DeleteTransaction(trans.transactionId);

            y._SGT_Repository.AddTransaction(trans1).Wait();

            var getTrans = y._SGT_Repository.GetTransactionById("2");

            Console.WriteLine("transactionId: " + getTrans.transactionId + ", amount: " + getTrans.amount);

            y._SGT_Repository.DeleteTransaction("2");*/

        }
    }
}
