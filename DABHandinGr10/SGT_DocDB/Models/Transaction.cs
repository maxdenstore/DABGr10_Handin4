using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SGT_DocDB.Interfaces;

namespace SGT_DocDB.Models
{
    public class Transaction: ITransaction
    {
        [JsonProperty(Required = Required.Always, PropertyName = "id")]
        public string transactionId { get; set; }
        public string transactionType { get; set; }
        public string buyerType { get; set; }
        public string buyerId { get; set; }
        public string sellerType { get; set; }
        public string sellerId { get; set; }
        public int amount { get; set; }
    }
}
