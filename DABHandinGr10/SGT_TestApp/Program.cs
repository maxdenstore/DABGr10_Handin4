using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGT_DocDB.DBContext;
using SGT_DocDB.Models;

namespace SGT_TestApp
{
    class Program
    {
        static void Main(string[] args)
        {


            Transaction trans = new Transaction
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
            };





            SGT_DocDB.DBContext.SGT_DocDBUnitOfWork x =
                new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("upcomming"));

            SGT_DocDB.DBContext.SGT_DocDBUnitOfWork y =
                new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("onGoing"));

            //x._SGT_Repository.AddTransaction(trans).Wait();

            //x._SGT_Repository.DeleteTransaction(trans.transactionId);

            y._SGT_Repository.AddTransaction(trans1).Wait();

            var getTrans = y._SGT_Repository.GetTransactionById("2");

            Console.WriteLine("transactionId: " + getTrans.transactionId + ", amount: " + getTrans.amount);

            y._SGT_Repository.DeleteTransaction("2");
            
        }
    }
}
