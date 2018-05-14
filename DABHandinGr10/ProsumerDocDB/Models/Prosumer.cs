using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Interfaces;

namespace ProsumerDocDB.Models
{
    class Prosumer : IProsumer
    {
        public int smartmeter { get; set; }
        public int copperId { get; set; }

        public int wallet { get; set; }
        public string prosumerType { get; set; }

    }
}
