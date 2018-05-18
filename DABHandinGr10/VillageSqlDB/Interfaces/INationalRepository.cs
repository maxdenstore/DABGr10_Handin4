using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VillageSqlDB.Models;

namespace VillageSqlDB.Interfaces
{
    public interface INationalRepository
    {
        IEnumerable<National> GetAll();

        IEnumerable<National> Find(Expression<Func<National, bool>> prediExpression);

        National SingleOrDefault(Expression<Func<National, bool>> prediExpression);

        National First(Expression<Func<National, bool>> prediExpression);

        National GetNationalByID(int NationalId);

        void InsertNational(National National);

        void DeleteNational(int NationalID);

        void UpdateNational(National National);

        void Save();
    }
}
