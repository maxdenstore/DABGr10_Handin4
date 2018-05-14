using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SGT_DocDB.Interfaces;

namespace SGT_DocDB.Models
{
    public class Transaction: ITransaction
    {
        public int transactionId { get; set; }
        public string transactionType { get; set; }
        public string buyerType { get; set; }
        public int buyerId { get; set; }
        public string sellerType { get; set; }
        public int sellerId { get; set; }
        public int amount { get; set; }
    }
}
