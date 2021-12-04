using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager
{
    public class FinanceManager
    {
        Repository Repository = new Repository();

        public void showGreeting()
        {
            Console.WriteLine("Hello, user");
        }
        public void showMainMenu()
        {
            Console.WriteLine("1.Read from file\n" + 
                "2.Safe in file\n" + 
                "3.Add report\n" + 
                "4.Delete report\n" +
                "5.Change report\n" +
                "6.Calculate between dates\n" +
                "7.Calculate this week\n" +
                "8.Calculate this month\n");
        }
    }
}
