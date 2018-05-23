using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Models;

namespace VillageSqlDB.Interfaces
{
    interface INational
    {
        ICollection<Village> Villages { get; set; }

        int NationalID { get; set; }

        string NationName { get; set; }
    }
}
