using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageSqlDB.Interfaces
{
    public interface IVillage
    {
        //mangler reference
        ICollection <IProsumer> Villages { get; set; }

        //tag key
        [Key]
        int VillageID { get; set; }

        int VillageMeter { get; set; }
        int CookerAmount { get; set; }
        int CookerCapacity { get; set; }
        int CookerConsumption { get; set; }
    }
}
