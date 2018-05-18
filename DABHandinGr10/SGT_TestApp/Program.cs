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
                transactionId = 1,
                amount = 100,
                buyerId = 1,
                buyerType = "prviat",
                sellerId = 2,
                sellerType = "privat",
                transactionType = "ongoing"
            };





            SGT_DocDB.DBContext.SGT_DocDBUnitOfWork x =
                new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext());


            x._SGT_Repository.AddTransaction(trans).Wait();
        }
    }
}
