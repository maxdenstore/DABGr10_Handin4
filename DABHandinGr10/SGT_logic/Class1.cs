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

    public class Class1
    {


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
        private SGT_DocDB.DBContext.SGT_DocDBUnitOfWork onGoing;
        private SGT_DocDB.DBContext.SGT_DocDBUnitOfWork previous;
        private ProsumerDocDB.DbContext.ProsumerDocumentDBUnitOfWork prosumerDB;
        private UnitOfWork.SmartGridUnitOfWork unitOfWork; 

        private int tramsactionIdCounter = 0;
        private int prPositiveCounter = 0;
        private int prNegativeCounter = 0;

        public Class1()
        {
            x = new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("upcomming"));
            onGoing = new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("onGoing"));
            previous = new SGT_DocDB.DBContext.SGT_DocDBUnitOfWork(new SGT_DocDB.DBContext.SGTDBContext("previous"));
            prosumerDB = new ProsumerDocDB.DbContext.ProsumerDocumentDBUnitOfWork(new ProsumerDocDB.DbContext.ProsumerDbContext());
            unitOfWork = new UnitOfWork.SmartGridUnitOfWork();
        }


        public void addTransactions(National nation)
        {
            foreach (Village village in nation.Villages)
            {
                int energyForSale = village.VillageMeter;
                int restFromLast = 0;

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

                    foreach (Prosumer prNeg in negativeProsumers.Skip(prNegativeCounter))
                    {

                        int prNegMeterCount = prNeg.smartmeter;

                        if (prPosMeterCount > Math.Abs(prNegMeterCount))
                        {
                            prNegMeterCount = prNeg.smartmeter - restFromLast;
                            Transaction transaction = new Transaction();
                            transaction.amount = Math.Abs(prNegMeterCount);
                            transaction.sellerId = prPos.CopperID;
                            transaction.buyerId = prNeg.CopperID;
                            transaction.transactionId = tramsactionIdCounter.ToString();
                            transaction.sellerType = prPos.prosumerType;
                            transaction.buyerType = prNeg.prosumerType;
                            transaction.transactionType = "pr2pr";
                            prPosMeterCount -= Math.Abs(prNegMeterCount);
                            restFromLast = prPosMeterCount - Math.Abs(prNegMeterCount);
                            allTransactions.Add(transaction);
                            tramsactionIdCounter++;
                            prNegativeCounter++;
                        }
                        else if ((prPosMeterCount <= Math.Abs(prNegMeterCount)) && (prPosMeterCount != 0))
                        {
                            Transaction transaction = new Transaction();
                            transaction.sellerId = prPos.CopperID;
                            transaction.buyerId = prNeg.CopperID;
                            transaction.sellerType = prPos.prosumerType;
                            transaction.transactionId = tramsactionIdCounter.ToString();
                            transaction.buyerType = prNeg.prosumerType;
                            transaction.transactionType = "pr2pr";
                            transaction.amount = prPosMeterCount;
                            prNegMeterCount = prNegMeterCount + prPosMeterCount;
                            restFromLast = prPosMeterCount - Math.Abs(prNegMeterCount);
                            allTransactions.Add(transaction);
                            tramsactionIdCounter++;
                            prNegativeCounter++;
                            break;
                        }
                        else
                        {
                            break;
                        }

                    }
                    if(prNegativeCounter == negativeProsumers.Count)
                    {
                        break;
                    }
                    prPositiveCounter++;
                }


                List<Prosumer> restOfPrPos = new List<Prosumer>();
                foreach (Prosumer pr in positiveProsumers.Skip(prPositiveCounter))
                {
                    restOfPrPos.Add(pr);
                }

                List<Prosumer> restOfPrNeg = new List<Prosumer>();
                foreach (Prosumer pr in negativeProsumers.Skip(prNegativeCounter))
                {
                    restOfPrNeg.Add(pr);
                }

                int cookerAmount = village.CookerAmount - village.CookerConsumption;
                int cookerCapacity = village.CookerCapacity;

                // Selling/buying to/from village
                if (village.VillageMeter > 0)
                {
                    foreach (Prosumer pr in restOfPrPos)
                    {
                        Transaction tr = new Transaction();
                        if (restFromLast != 0)
                        {
                            tr.amount = restFromLast;
                        }
                        else
                        {
                            tr.amount = pr.smartmeter;
                        }
                        tr.buyerId = village.VillageID.ToString();
                        tr.sellerId = pr.CopperID;
                        tr.sellerType = pr.prosumerType;
                        tr.buyerType = "village";
                        tr.transactionId = tramsactionIdCounter.ToString();
                        tr.transactionType = "pr2Village";
                        allTransactions.Add(tr);
                        tramsactionIdCounter++;
                        restFromLast = 0;


                    }
                }
                else if (village.VillageMeter < 0)
                {
                    foreach (Prosumer pr in restOfPrNeg)
                    {
                        Transaction tr = new Transaction();
                        tr.amount = Math.Abs(pr.smartmeter);
                        tr.sellerId = village.VillageID.ToString();
                        tr.buyerId = pr.CopperID;
                        tr.buyerType = pr.prosumerType;
                        tr.sellerType = "village";
                        tr.transactionId = tramsactionIdCounter.ToString();
                        tr.transactionType = "village2pr";
                        allTransactions.Add(tr);
                        tramsactionIdCounter++;
                    }
                }


                //Selling/buying to/from national
                if (((cookerAmount - Math.Abs(village.VillageMeter)) > 0) && ((cookerAmount + village.VillageMeter) <= cookerCapacity))
                {
                }
                else if (((cookerAmount - village.VillageMeter) > 0) && ((cookerAmount + village.VillageMeter) > cookerCapacity))
                {
                    Transaction tr = new Transaction();
                    tr.amount = village.VillageMeter - (cookerCapacity - cookerAmount);
                    tr.buyerId = nation.NationalID.ToString();
                    tr.sellerId = village.VillageID.ToString();
                    tr.sellerType = "village";
                    tr.buyerType = "nation";
                    tr.transactionType = "village2Nation";
                    tr.transactionId = tramsactionIdCounter.ToString();
                    allTransactions.Add(tr);
                    tramsactionIdCounter++;
                }
                else if (village.VillageMeter < 0 && Math.Abs(village.VillageMeter) < cookerAmount)
                {
                }
                else if (village.VillageMeter < 0 && Math.Abs(village.VillageMeter) > cookerAmount)
                {
                    Transaction tr = new Transaction();
                    tr.amount = Math.Abs(village.VillageMeter) - cookerAmount;
                    tr.sellerId = nation.NationalID.ToString();
                    tr.buyerId = village.VillageID.ToString();
                    tr.buyerType = "village";
                    tr.sellerType = "nation";
                    tr.transactionType = "nation2Village";
                    tr.transactionId = tramsactionIdCounter.ToString();
                    allTransactions.Add(tr);
                    tramsactionIdCounter++;
                }

                foreach (Transaction tr in allTransactions)
                {
                    x._SGT_Repository.AddTransaction(tr).Wait();
                }

            }

        }

        
        public int doTransaction(int transactionIdCounter, string villageName)
        {
            var tempTransactionIdCounter = transactionIdCounter -1 ;
            Transaction tr = new Transaction();
            Prosumer prosumer1 = new Prosumer();
            Prosumer prosumer2 = new Prosumer();
            var vil = new Village();

            tr = x._SGT_Repository.GetTransactionById(tempTransactionIdCounter.ToString());

            while (tr != null)
            {
                x._SGT_Repository.DeleteTransaction(tempTransactionIdCounter.ToString());

                tempTransactionIdCounter--;

                onGoing._SGT_Repository.AddTransaction(tr).Wait();
                tr = onGoing._SGT_Repository.GetTransactionById(tr.transactionId);

                switch (tr.transactionType)
                {
                    case "pr2pr":
                        prosumer1 = prosumerDB._prosumerRepository.GetProsumerByCopperID(tr.buyerId);
                        prosumer1.wallet = prosumer1.wallet - tr.amount;
                        prosumer1.smartmeter = 0;
                        prosumerDB._prosumerRepository.Update(prosumer1);
                        prosumer2 = prosumerDB._prosumerRepository.GetProsumerByCopperID(tr.sellerId);
                        prosumer2.wallet = prosumer2.wallet + tr.amount;
                        prosumer2.smartmeter = 0;
                        prosumerDB._prosumerRepository.Update(prosumer2);
                        break;
                    case "pr2Village":
                        prosumer1 = prosumerDB._prosumerRepository.GetProsumerByCopperID(tr.sellerId);
                        prosumer1.wallet = prosumer1.wallet - tr.amount;
                        prosumer1.smartmeter = 0;
                        prosumerDB._prosumerRepository.Update(prosumer1);
                        vil = unitOfWork.ReadVillage(villageName);
                        vil.CookerAmount = vil.CookerAmount + tr.amount;
                        unitOfWork.UpdateVillage(vil);
                        break;
                    case "village2pr":
                        prosumer1 = prosumerDB._prosumerRepository.GetProsumerByCopperID(tr.buyerId);
                        prosumer1.wallet = prosumer1.wallet + tr.amount;
                        prosumer1.smartmeter = 0;
                        prosumerDB._prosumerRepository.Update(prosumer1);
                        vil = unitOfWork.ReadVillage(villageName);
                        vil.CookerAmount = vil.CookerAmount - tr.amount;
                        unitOfWork.UpdateVillage(vil);
                        break;
                    case "village2Nation":
                        vil = unitOfWork.ReadVillage(villageName);
                        vil.CookerAmount = vil.CookerAmount - tr.amount;
                        unitOfWork.UpdateVillage(vil);
                        break;
                    case "nation2Village":
                        vil = unitOfWork.ReadVillage(villageName);
                        vil.CookerAmount = vil.CookerAmount + tr.amount;
                        unitOfWork.UpdateVillage(vil);
                        break;
                    default:
                        break;
                }
                
                previous._SGT_Repository.AddTransaction(tr).Wait();

                onGoing._SGT_Repository.DeleteTransaction(tr.transactionId);

                tr = x._SGT_Repository.GetTransactionById(tempTransactionIdCounter.ToString());
            }


            return 0;
        }
    }

}
