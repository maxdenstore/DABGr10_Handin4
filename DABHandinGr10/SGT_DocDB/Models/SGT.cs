using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Models;

namespace SGT_DocDB.Models
{
    class SGT: Interfaces.ISGT
    {
        public ICollection<National> national { get; set; }
        public ICollection<Transaction> transaction { get; set; }
    }
}
