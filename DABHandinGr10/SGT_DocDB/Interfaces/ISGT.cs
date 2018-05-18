using System.Collections;
using System.Collections.Generic;
using SGT_DocDB.Models;
using VillageSqlDB.Models;

namespace SGT_DocDB.Interfaces
{
    public interface ISGT
    {
        ICollection<National> national { get; set; }
        ICollection<Transaction> transaction { get; set; }
    }
}