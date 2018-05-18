using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProsumerDocDB.Interfaces;
using ProsumerDocDB.Models;
using VillageSqlDB.Interfaces;

namespace VillageSqlDB.Models
{
    public class Village : IVillage
    {
        
        public int VillageID { get; set; }
        public int VillageMeter { get; set; }
        public int CookerAmount { get; set; }
        public int CookerCapacity { get; set; }
        public int CookerConsumption { get; set; }

        [NotMapped] //not mapped because this is in our documentDB
        public virtual ICollection<Prosumer> Villages { get; set; } = new List<Prosumer>();
    }
}
