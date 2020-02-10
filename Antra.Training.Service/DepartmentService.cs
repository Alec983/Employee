using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Model;
using Antra.Training.Data.Repository;
namespace Antra.Training.Service
{
   public class DepartmentService
    {
        IRepository<Department> deptRepository;
        public DepartmentService()
        {
            deptRepository = new DepartmentRepository();
        }

        public int Insert(Department obj)
        {
            return deptRepository.Insert(obj);
        }

        public int Delete(int id)
        {
            return deptRepository.Delete(id);
        }

        public int Update(Department obj)
        {
            return deptRepository.Update(obj);
        }

        public IEnumerable<Department> GetAll()
        {
            return deptRepository.GetAll();
        }
    }
}
