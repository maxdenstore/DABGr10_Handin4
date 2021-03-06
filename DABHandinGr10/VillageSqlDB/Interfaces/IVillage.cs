﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ProsumerDocDB.Interfaces;
using ProsumerDocDB.Models;

namespace VillageSqlDB.Interfaces
{
    public interface IVillage
    {
        [JsonIgnore]
        ICollection <Prosumer> Villages { get; set; }

        //tag key

        int VillageID { get; set; }

        int VillageMeter { get; set; }
        int CookerAmount { get; set; }
        int CookerCapacity { get; set; }
        int CookerConsumption { get; set; }

        string VillageName { get; set; }
    }
}
