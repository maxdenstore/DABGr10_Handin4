using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProsumerDocDB.Interfaces;

namespace ProsumerDocDB.Models
{
    public class Prosumer : IProsumer
    {
        public  Prosumer()
        { }

        public Prosumer(Prosumer prosumer)
        {
            CopperID = prosumer.CopperID;
            smartmeter = prosumer.smartmeter;
            wallet = prosumer.wallet;
            prosumerType = prosumer.prosumerType;

        }


        [Key]
        [JsonProperty(Required = Required.Always, PropertyName = "id")]
        public string CopperID { get; set; }

        public int smartmeter { get; set; }


        public int wallet { get; set; }
        public string prosumerType { get; set; }

        public int villageId { get; set; }


    }
}
