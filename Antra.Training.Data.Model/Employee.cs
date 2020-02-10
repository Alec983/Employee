using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.Training.Data.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string EName { get; set; }

        public decimal Salary { get; set; }

        public string Mobile { get; set; }
        public int DeptId { get; set; }

        public Department Department { get; set; }
    }
}
