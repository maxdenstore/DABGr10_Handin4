using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Models;
using SGT_DocDB.Models;
using VillageSqlDB.Models;

namespace SGT_logic
{
    public class Class1 {



        /*
         * generate a list of all coming transactions
         * save size of list
         * put them in the database
         * get first transaction
         * delete this transaction
         * put the transaction in the ongoing database
         * do the transaction
         * add transaction to completed
         * delete transaction from ongoing
         * do it all over again
         */

        private SGT_DocDB.DBContext.SGT_DocDBUnitOfWork x;
        private int tramsactionIdCounter = 0;
        private int completedP2PTransactions = 0;

        Class1()
        {
            x = new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("upcomming"));
        }


        public void addTransactions(Village village)
        {
            int energyForSale = village.VillageMeter;

            List<Prosumer> positiveProsumers = new List<Prosumer>();
            List<Prosumer> negativeProsumers = new List<Prosumer>();
            List<Transaction> allTransactions = new List<Transaction>();

            //Seperateing the overproduction and underproduction
            foreach (Prosumer pr in village.Villages)
            {
                if (pr.smartmeter < 0)
                {
                    negativeProsumers.Add(pr);
                }
                else if (pr.smartmeter > 0)
                {
                    positiveProsumers.Add(pr);
                }
            }

            //Creating the relevant transactions
            foreach (Prosumer prPos in positiveProsumers)
            {

                int prPosMeterCount = prPos.smartmeter;

                foreach (Prosumer prNeg in negativeProsumers)
                {
                    int prNegMeterCount = prNeg.smartmeter;

                    if (prPosMeterCount > Math.Abs(prNegMeterCount))
                    {
                        Transaction transaction = new Transaction();
                        transaction.amount = Math.Abs(prNegMeterCount);
                        transaction.sellerId = prPos.CopperID;
                        transaction.buyerId = prNeg.CopperID;
                        transaction.transactionId = tramsactionIdCounter.ToString();
                        transaction.sellerType = prPos.prosumerType;
                        transaction.buyerType = prNeg.prosumerType;
                        prPosMeterCount -= Math.Abs(prNegMeterCount);
                        prNegMeterCount = 0;
                        allTransactions.Add(transaction);
                        tramsactionIdCounter++;
                    }
                    else if (prPosMeterCount < Math.Abs(prNegMeterCount))
                    {
                        Transaction transaction = new Transaction();
                        transaction.sellerId = prPos.CopperID;
                        transaction.buyerId = prNeg.CopperID;
                        transaction.sellerType = prPos.prosumerType;
                        transaction.transactionId = tramsactionIdCounter.ToString();
                        transaction.buyerType = prNeg.prosumerType;
                        transaction.amount = prPosMeterCount;
                        prNegMeterCount = prNegMeterCount + prPosMeterCount;
                        allTransactions.Add(transaction);
                        tramsactionIdCounter++;
                        completedP2PTransactions++;
                        continue;
                    }
                    else
                    {
                        continue;
                    }
                    
                }
                continue;
            }

            int totalProduction = 0;
            int totalConsumption = 0;
            int cookerAmount = village.CookerAmount;
            int cookerCapacity = village.CookerCapacity;
            int cookerTransferAmount = 0;

            List<Prosumer> restOfPrPos = new List<Prosumer>();
            for(int i = completedP2PTransactions; i < positiveProsumers.Count; i++)
            {
                restOfPrPos.Add(positiveProsumers.ElementAt(i));
            }

            //HERTIL - tanken var at lave en ny transaction for hver prosumer i restOfPr, som overfører til village, så længe cookercapacity er overholdt
            foreach (Prosumer pr in restOfPrPos)
            {
                while (cookerCapacity > cookerAmount)
                {
                    
                }

                Transaction tr = new Transaction();
                tr.amount = pr.smartmeter;

            }


            

            if (totalProduction > totalConsumption)
            {
                Transaction tr = new Transaction();
                while (totalProduction - totalConsumption < cookerCapacity - cookerAmount) {
                    cookerTransferAmount++;
                    tr.amount = cookerTransferAmount;
                }
                if(tr.amount > 0)
                {
                    tr.buyerId = village.VillageID.ToString();
                    tr.sellerId;
                }

                Transaction tr = new Transaction();
                tr.amount = totalProduction - totalConsumption;
                if(tr.amount < )
                tr.buyerId =
            }



            foreach (Transaction tr in allTransactions)
            {
                x._SGT_Repository.AddTransaction(tr).Wait();
            }

        }
        

        public int doTransaction(int tramsactionIdCounter)
        {
            
            Transaction tr = new Transaction();
            tr = x._SGT_Repository.GetTransactionById(tramsactionIdCounter.ToString());
            x._SGT_Repository.DeleteTransaction(tramsactionIdCounter.ToString());
            x._SGT_Repository.AddTransaction(tr).Wait();
            

        }
    }
}
