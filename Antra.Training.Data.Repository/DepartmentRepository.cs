using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Model;
using System.Data;
namespace Antra.Training.Data.Repository
{
    public class DepartmentRepository : IRepository<Department>
    {
        DBHelper dbHelper;
        public DepartmentRepository()
        {
            dbHelper = new DBHelper();
        }
        public int Delete(int id)
        {
            string command = "Delete from Department where id=@id";
            Dictionary<string, object> commandParameters = new Dictionary<string, object>();
            commandParameters.Add("@id", id);
            return dbHelper.ExecuteDMLStatements(command, commandParameters);
        }

        public IEnumerable<Department> GetAll()
        {

            List<Department> departmentCollection = new List<Department>();
            string str = "Select Id, DName,Loc from Department";
            DataTable dt = dbHelper.GetDataFromTable(str, null);
            foreach (DataRow item in dt.Rows)
            {
                Department d = new Department();
                d.Id = Convert.ToInt32(item["Id"]);
                d.DName = Convert.ToString(item["DName"]);
                d.Loc = Convert.ToString(item["Loc"]);
                departmentCollection.Add(d);
            }
            return departmentCollection;
        }

        public Department GetById(int id)
        {
            string str = "Select Id,DName,Loc from Department where id=@id";
            Dictionary<string, object> commandParameter = new Dictionary<string, object>();
            commandParameter.Add("@id", id);
            DataTable dt = dbHelper.GetDataFromTable(str, commandParameter);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow item = dt.Rows[0];
                Department d = new Department();
                d.Id = Convert.ToInt32(item["Id"]);
                d.DName = Convert.ToString(item["DName"]);
                d.Loc = Convert.ToString(item["Loc"]);
                return d;
            }
            return null;
        }

        public int Insert(Department obj)
        {

            string command = "Insert into Department values (@dname,@loc)";
            Dictionary<string, object> commandParameters = new Dictionary<string, object>();
            commandParameters.Add("@dname", obj.DName);
            commandParameters.Add("@loc", obj.Loc);
            return dbHelper.ExecuteDMLStatements(command, commandParameters);
        }



        public int Update(Department obj)
        {
            string command = "Update Department set DName =@dname, Loc =@loc where id=@id";
            Dictionary<string, object> commandParameters = new Dictionary<string, object>();
            commandParameters.Add("@dname", obj.DName);
            commandParameters.Add("@loc", obj.Loc);
            commandParameters.Add("@id", obj.Id);
            return dbHelper.ExecuteDMLStatements(command, commandParameters);

        }
    }
}
