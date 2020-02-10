using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.Training.UI.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = (int)EntityName.Exit;
            UIFactory factory = new UIFactory();
            do
            {
                Menu.Print(typeof(EntityName));
                choice = Convert.ToInt32(Console.ReadLine());
                IRunnable runnable = factory.GetObject(choice);
                if (runnable != null)
                {
                    runnable.Run();
                    Console.WriteLine("Press Enter to continue...");
                    Console.ReadLine();
                }
                Console.Clear();
            } while (choice != (int)EntityName.Exit);

        }
    }
}
