using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Interfaces;

namespace VillageSqlDB.Models
{
    public class National : INational
    {
        public ICollection<Village> Villages { get; set; } = new List<Village>();
        public int NationalID { get; set; }

        public string NationName { get; set; }
    }
}
