using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.Training.UI.ConsoleApp
{
    enum CrudOperation
    {
        Add = 1,
        Print,
        Delete,
        Update,
        Exit
    }

    enum EntityName
    {
        Department = 1,
        Employee,
        Exit
    }

    class Menu
    {
      public  static void Print(Type t)
        {
            string[] names = Enum.GetNames(t);
            int[] values = (int[])Enum.GetValues(t);
            int length = names.Length;
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Press {0} for {1}", values[i], names[i]);
            }
            Console.Write("Enter your choice -> ");
        }
    }

}
