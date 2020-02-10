using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Data.Model;
using Antra.Training.Service;
namespace Antra.Training.UI.ConsoleApp
{
    class ManageEmployee : IRunnable
    {
        EmployeeService empService;
        public ManageEmployee()
        {
            empService = new EmployeeService();
        }
        void PrintById()
        {
            Console.Write("Enter Id -> ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employee emp = empService.GetById(id);
            Console.WriteLine(emp.Id+"\t"+emp.EName+"\t"+emp.Salary+"\t"+emp.Mobile+"\t"+emp.Department.DName+"\t"+emp.Department.Loc);
        }

        void AddEmployee()
        {
            Employee e = new Employee();

            Console.Write("Enter Name -> ");
            e.EName = Console.ReadLine();

            Console.Write("Enter Salary -> ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Moblie -> ");
            e.Mobile = Console.ReadLine();

            Console.Write("Enter DeptId -> ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            int result = empService.Insert(e);
            if (result > 0)
            {
                Console.WriteLine("Employee added successfully...");
            }
            else
            {
                Console.WriteLine("Some Error has occurred");
            }
        }

        void DeleteEmployee()
        {
            Console.Write("Enter Employee Id -> ");
            int id = Convert.ToInt32(Console.ReadLine());

            int result = empService.Delete(id);
            if (result > 0)
                Console.WriteLine("Employee deleted successfully...");
            else
                Console.WriteLine("Some Error has occured");
        }

        void UpdateEmployee()
        {
            Employee e = new Employee();

            Console.Write("Enter Id -> ");
            e.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name -> ");
            e.EName = Console.ReadLine();

            Console.Write("Enter Salary -> ");
            e.Salary = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Enter Moblie -> ");
            e.Mobile = Console.ReadLine();

            Console.Write("Enter DeptId -> ");
            e.DeptId = Convert.ToInt32(Console.ReadLine());

            int result = empService.Update(e);
            if (result > 0)
            {
                Console.WriteLine("Employee Updated successfully...");
            }
            else
            {
                Console.WriteLine("Some Error has occurred");
            }
        }
        void PrintAll()
        {
            IEnumerable <Employee> empCollection = empService.GetAll();
            foreach (Employee item in empCollection)
            {
                Console.WriteLine(item.Id + "\t" + item.EName + "\t" + item.Salary + "\t" + item.Mobile + "\t" + item.DeptId);
            }
        }
        public void Run()
        {
            int choice = (int)CrudOperation.Exit;
            do
            {
                Console.Clear();
                Menu.Print(typeof(CrudOperation));
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case (int)CrudOperation.Add:
                        AddEmployee();
                        break;
                    case (int)CrudOperation.Delete:
                        DeleteEmployee();
                        break;
                    case (int)CrudOperation.Update:
                        UpdateEmployee();
                        break;
                    case (int)CrudOperation.Exit:
                        Console.WriteLine("Thanks for Visit....");
                        break;
                    case (int)CrudOperation.Print:
                        PrintAll();
                        break;
                    default:
                        Console.WriteLine("Invalid Input....");
                        break;
                }
                Console.ReadLine();
            } while (choice != (int)CrudOperation.Exit);
        }



    }
}
