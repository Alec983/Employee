using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.Training.UI.ConsoleApp
{
    class UIFactory
    {
        public IRunnable GetObject(int choice)
        {
            switch (choice)
            {
                case (int)EntityName.Department:
                    return new ManageDepartment();
                case (int)EntityName.Employee:
                    return new ManageEmployee();
                default:
                    return null;
            }

        }
    }
}
