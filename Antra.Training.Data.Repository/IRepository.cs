using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.Training.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        int Insert(T obj);
        int Delete(int id);
        int Update(T obj);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}
