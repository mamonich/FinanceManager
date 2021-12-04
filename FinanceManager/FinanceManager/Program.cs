using System;

namespace FinanceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.setFilePath("test.csv");
            repository.calculateSumForDates(new DateTime(2021, 12, 4), new DateTime(2021, 12, 10));
            repository.safeFile();
        }
    }
}
