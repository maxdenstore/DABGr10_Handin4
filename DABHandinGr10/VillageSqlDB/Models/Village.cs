using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Interfaces;

namespace VillageSqlDB.Models
{
    public class Village : IVillage
    {
        public ICollection<IProsumer> Villages { get; set; }
        public int VillageID { get; set; }
        public int VillageMeter { get; set; }
        public int CookerAmount { get; set; }
        public int CookerCapacity { get; set; }
        public int CookerConsumption { get; set; }
    }
}
