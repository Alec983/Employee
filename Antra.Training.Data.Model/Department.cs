using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.Training.Data.Model
{
    public class Department
    {
        private List<Employee> empCollection = new List<Employee>();
        public int Id { get; set; }
        public string DName { get; set; }
        public string Loc { get; set; }

        public List<Employee> Employees
        {
            get
            {
                return empCollection;
            }
            set
            {
                empCollection = value;
            }
        }
    }
}
