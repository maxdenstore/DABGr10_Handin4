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

        
        

        public void villageTransaction(Village village)
        {
            int energyForSale = village.VillageMeter;

            List<Transaction> allTransactions = new List<Transaction>();
            foreach (Prosumer pr in village.Villages)
            {
                Transaction transaction = new Transaction();
                transaction.amount = pr.smartmeter;
                transaction.sellerId = pr.copperId;
                allTransactions.Add(transaction);
            }

            while(energyForSale > 0)
            {
                Transaction currentTransaction = new Transaction();
            }


                      
            foreach (Transaction ta in allTransactions)
            {

                while (ta.amount > 0) { 

                    //If totalProduction is still in minus we can sell to a prosumer inside the village
                    if(energyForSale <  0)
                    {
                        
                        if(ta.amount > 0)
                        {
                            foreach (Prosumer pr in village.Villages)
                            {

                            }
                        }

                        foreach(Prosumer pr in village.Villages)
                        {
                            if(pr.copperId != ta.sellerId)
                            {
                                while(pr.smartmeter < 0)
                                {
                                    pr.wallet--;
                                    
                                }
                            }
                        }
                        energyForSale++;
                    }
                    //If the the village meter is positive, we test if we can store the energy in the cooker.
                    else if (((village.CookerCapacity - village.CookerAmount) > 0) && energyForSale > 0)
                    {
                        while ((village.CookerCapacity - village.CookerAmount) > 0)
                        {
                            energyForSale--;
                            village.CookerAmount++;
                        }
                    }
                    // If we cannot store in the cooker, we sell to nation
                    else
                    {
                        ta.amount = 0;
                        energyForSale = 0;
                    }

                }
            }

            //onGoingTransactions.ElementAt(1).buyerId;
            //sender.wallet;
        }
    }
}
