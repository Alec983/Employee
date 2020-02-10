using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antra.Training.Service;
using Antra.Training.Data.Model;
namespace Antra.Training.UI.ConsoleApp
{
    class ManageDepartment : IRunnable
    {
        DepartmentService departmentService;
        public ManageDepartment()
        {
            departmentService = new DepartmentService();
        }

        void AddDepartment()
        {
            Department d = new Department();

            Console.Write("Enter Name -> ");
            d.DName = Console.ReadLine();

            Console.Write("Enter Location -> ");
            d.Loc = Console.ReadLine();

            int result = departmentService.Insert(d);
            if (result > 0)
            {
                Console.WriteLine("Department added successfully...");
            }
            else
            {
                Console.WriteLine("Some Error has occurred");
            }
        }

        void DeleteDepartment()
        {
            Console.Write("Enter Department Id -> ");
            int id = Convert.ToInt32(Console.ReadLine());

            int result = departmentService.Delete(id);
            if (result > 0)
                Console.WriteLine("Department deleted successfully...");
            else
                Console.WriteLine("Some Error has occured");
        }

        void UpdateDepartment()
        {
            Department d = new Department();

            Console.Write("Enter Id -> ");
            d.Id = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name -> ");
            d.DName = Console.ReadLine();

            Console.Write("Enter Location -> ");
            d.Loc = Console.ReadLine();

            int result = departmentService.Update(d);
            if (result > 0)
            {
                Console.WriteLine("Department Updated successfully...");
            }
            else
            {
                Console.WriteLine("Some Error has occurred");
            }
        }
        void PrintAll()
        {
            IEnumerable<Department> deptCollection = departmentService.GetAll();
            foreach (Department item in deptCollection)
            {
                Console.WriteLine(item.Id+"\t"+item.DName+"\t"+item.Loc);
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
                        AddDepartment();
                        break;
                    case (int)CrudOperation.Delete:
                        DeleteDepartment();
                        break;
                    case (int)CrudOperation.Update:
                        UpdateDepartment();
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
