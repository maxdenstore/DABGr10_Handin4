

using UnitOfWork.Interfaces;
using VillageSqlDB.Models;


namespace UnitOfWork
{
    public class SmartGridUnitOfWork : ISmartGridUnitOfWork
    {

        #region Create
        public National CreateNational(National nation)
        {
            throw new System.NotImplementedException();
        }

        public Village CreateVillage(Village village)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        #region Read
        public National ReadNational(string nationName)
        {
            throw new System.NotImplementedException();
        }

        public Village ReadVillage(string VillageName)
        {
            throw new System.NotImplementedException();
        }
        #endregion


        #region Update
        public National UpdateNational(National updated)
        {
            throw new System.NotImplementedException();
        }

        public Village UpdateVillage(Village Updated)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Delete
        public National DeleteNational(string nationName)
        {
            throw new System.NotImplementedException();
        }

        public Village DeleteVillage(string VillageName)
        {
            throw new System.NotImplementedException();
        }
        #endregion






    }
}
