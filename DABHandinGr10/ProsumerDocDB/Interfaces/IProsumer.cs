using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProsumerDocDB.Interfaces
{
    public interface IProsumer
    {
        int smartmeter { get; set; }
        int copperId { get; set; }

        int wallet { get; set; }
        string prosumerType { get; set; }

    }
}
