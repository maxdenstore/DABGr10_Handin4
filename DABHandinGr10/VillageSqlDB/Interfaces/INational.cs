using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageSqlDB.Interfaces
{
    interface INational
    {
        ICollection<IVillage> Villages { get; set; }

        int NationalID { get; set; }
    }
}
