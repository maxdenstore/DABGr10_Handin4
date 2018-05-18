using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Models;

namespace UnitOfWork.Interfaces
{
    public interface ISmartGridUnitOfWork
    {
        #region Create
        National CreateNational(National nation);
        Village CreateVillage(Village village);
        #endregion

        #region Read
        National ReadNational(string nationName);
        Village ReadVillage(string VillageName);
        #endregion


        #region Update
        National UpdateNational(National updated);
        Village UpdateVillage(Village Updated);
        #endregion



        #region Delete
        National DeleteNational(string nationName);
        Village DeleteVillage(string VillageName);

        #endregion


    }
}
