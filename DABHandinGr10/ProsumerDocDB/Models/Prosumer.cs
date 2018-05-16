﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Interfaces;

namespace ProsumerDocDB.Models
{
    public class Prosumer : IProsumer
    {
        [Key]
        public int CopperID { get; set; }

        public int smartmeter { get; set; }


        public int wallet { get; set; }
        public string prosumerType { get; set; }



    }
}
