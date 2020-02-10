using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Model;
using System.Data;
namespace Antra.Training.Data.Repository
{
    public class EmployeeRepository : IRepository<Employee>
    {
        DBHelper dbHelper;
        public EmployeeRepository()
        {
            dbHelper = new DBHelper();
        }
        public int Delete(int id)
        {
            string command = "Delete from Employee where id=@id";
            Dictionary<string, object> commandParameters = new Dictionary<string, object>();
            commandParameters.Add("@id", id);
            return dbHelper.ExecuteDMLStatements(command, commandParameters);
        }

        public IEnumerable<Employee> GetAll()
        {
            List<Employee> employeeCollection = new List<Employee>();
            string str = "Select Id, EName, Salary, Moblie, DeptId from Employee";
            DataTable dt = dbHelper.GetDataFromTable(str, null);
            foreach (DataRow item in dt.Rows)
            {
                Employee e = new Employee();
                e.Id = Convert.ToInt32(item["Id"]);
                e.EName = Convert.ToString(item["EName"]);
                e.Salary = Convert.ToDecimal(item["Salary"]);
                e.Mobile = Convert.ToString(item["Mobile"]);
                e.DeptId = Convert.ToInt32(item["DeptId"]);
                employeeCollection.Add(e);
            }
            return employeeCollection;
        }

        public Employee GetById(int id)
        {
            string str = "Select Id,EName,Salary,Mobile,DeptId from Employee where Id =@id";
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters.Add("@id", id);
            DataTable dt = dbHelper.GetDataFromTable(str, parameters);
            if (dt != null)
            {
                DataRow item = dt.Rows[0];
                Employee e = new Employee();
                e.Id = Convert.ToInt32(item["Id"]);
                e.EName = Convert.ToString(item["EName"]);
                e.Mobile = Convert.ToString(item["Mobile"]);
                e.Salary = Convert.ToDecimal(item["Salary"]);
                e.DeptId = Convert.ToInt32(item["DeptId"]);
                return e;
            }
            return null;
        }

        public int Insert(Employee obj)
        {
            string command = "Insert into Employee values (@ename,@mobile,@salary,@deptid)";
            Dictionary<string, object> commandParameters = new Dictionary<string, object>();
            commandParameters.Add("@dname", obj.EName);
            commandParameters.Add("@mobile", obj.Mobile);
            commandParameters.Add("@salary", obj.Salary);
            commandParameters.Add("@deptid", obj.DeptId);
            return dbHelper.ExecuteDMLStatements(command, commandParameters);
        }

        public int Update(Employee obj)
        {
            string command = "Update Employee set EName =@ename, Moblie =@moblie, Salary =@salary, DeptId =@deptid where id=@id";
            Dictionary<string, object> commandParameters = new Dictionary<string, object>();
            commandParameters.Add("@dname", obj.EName);
            commandParameters.Add("@mobile", obj.Mobile);
            commandParameters.Add("@salary", obj.Salary);
            commandParameters.Add("@deptid", obj.DeptId);
            commandParameters.Add("@id", obj.Id);
            return dbHelper.ExecuteDMLStatements(command, commandParameters);
        }
    }
}
