using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Model;
using Antra.Training.Data.Repository;
namespace Antra.Training.Service
{
  public  class EmployeeService
    {
        IRepository<Department> deptRepository;
        IRepository<Employee> empRepository;
        public EmployeeService()
        {
            deptRepository = new DepartmentRepository();
            empRepository = new EmployeeRepository();
        }
        public Employee GetById(int id)
        {
            Employee emp = empRepository.GetById(id);
            emp.Department = deptRepository.GetById(emp.DeptId);
            return emp;
        }

        public int Insert(Employee obj)
        {
            return empRepository.Insert(obj);
        }

        public int Delete(int id)
        {
            return empRepository.Delete(id);
        }

        public int Update(Employee obj)
        {
            return empRepository.Update(obj);
        }

        public IEnumerable<Employee> GetAll()
        {
            return empRepository.GetAll();
        }
    }
}
