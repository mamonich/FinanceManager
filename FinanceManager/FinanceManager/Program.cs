using System;

namespace FinanceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.setFilePath("test.csv");
            repository.calculateSumForMonth();
            repository.safeFile();
        }
    }
}
