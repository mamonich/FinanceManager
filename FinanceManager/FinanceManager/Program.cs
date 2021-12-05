using System;

namespace FinanceManager
{
    class Program
    {
        static void Main(string[] args)
        {
            FinanceManager financeManager = new FinanceManager();
            financeManager.showGreeting();
            int numberOfChoice = 5;
            while(numberOfChoice != 0)
            {
                financeManager.showMainMenu();
                numberOfChoice = financeManager.GetNumberFromConsole(numberOfChoice);
                switch (numberOfChoice)
                {
                    case 1:
                        Console.WriteLine("Напишите параметры таким образом(описание;сумма;дата;тип записи;учавствует ли в подсчётах(да,нет))");
                        financeManager.AddFinanceReport(Console.ReadLine());
                        break;
                    case 2:
                        Console.WriteLine("Укажите номер записи, которую желаете удалить");
                        financeManager.DeleteFinanceReport(int.Parse(Console.ReadLine()));
                        break;
                    case 3:
                        Console.WriteLine("Укажите номер записи, которую желаете редактировать");
                        string idString = Console.ReadLine();
                        Console.WriteLine("Напишите параметры таким образом(описание;сумма;дата;тип записи;учавствует ли в подсчётах(да,нет))");
                        financeManager.ChangeFinanceReport(int.Parse(idString), Console.ReadLine());
                        break;
                    case 4:
                        Console.WriteLine("Напишите дату(день, месяц, год), с которой начнётся подсчёт");
                        string StartDateString = Console.ReadLine();
                        Console.WriteLine("Напишите дату(день, месяц, год), на которой закончится подсчёт");
                        string EndDateString = Console.ReadLine();
                        financeManager.CalculateSumForDates(StartDateString, EndDateString);
                        break;
                    case 5:
                        financeManager.CalculateSumForWeek();
                        break;
                    case 6:
                        financeManager.CalculateSumForMonth();
                        break;
                    case 7:
                        financeManager.showFinanceReports();
                        break;
                    case 0:
                        financeManager.FinanceReportRepository.SafeFile();
                        break;

                    default:
                        Console.WriteLine("Нету такого варианта ответа");
                        break;
                }
            }
        }

       
    }
}
