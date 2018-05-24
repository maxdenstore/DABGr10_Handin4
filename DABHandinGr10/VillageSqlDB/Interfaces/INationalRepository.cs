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
        Task<List<National>> GetAll();
 

        Task<List<National>> FindAsync(Expression<Func<National, bool>> prediExpression);


        Task<National> SingleOrDefaultAsync(Expression<Func<National, bool>> prediExpression);


        Task<National> FirstAsync(Expression<Func<National, bool>> prediExpression);


        Task<National> GetNationalByIDAsync(int NationalId);


        void InsertNational(National National);

        void DeleteNational(int NationalID);

        void UpdateNational(National National);

        void Save();
    }
}
