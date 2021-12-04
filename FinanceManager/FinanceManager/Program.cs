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
                numberOfChoice = int.Parse(Console.ReadLine());
                switch (numberOfChoice)
                {
                    case 1 :
                        Console.WriteLine("Напишите путь к файлу");
                        string filePath = Console.ReadLine();
                        financeManager.FinanceReportRepository.SetFilePath(filePath);
                        break;
                    case 2 :
                        financeManager.FinanceReportRepository.SafeFile();
                        break;
                    case 3 :
                        Console.WriteLine("Напишите параметры таким образом(описание;сумма;дата;тип записи;учавствует ли в подсчётах(да,нет))");                 
                        financeManager.AddFinanceReport(Console.ReadLine());
                        break;
                    case 4 :
                        Console.WriteLine("Укажите номер записи, которую желаете удалить");
                        financeManager.DeleteFinanceReport(int.Parse(Console.ReadLine()));
                        break;
                    case 5 :
                        Console.WriteLine("Укажите номер записи, которую желаете редактировать");
                        string idString = Console.ReadLine();
                        Console.WriteLine("Напишите параметры таким образом(описание;сумма;дата;тип записи;учавствует ли в подсчётах(да,нет))");

                        financeManager.ChangeFinanceReport(int.Parse(idString), Console.ReadLine());
                        break;
                    case 6 :
                        Console.WriteLine("Напишите дату(день, месяц, год), с которой начнётся подсчёт");
                        string StartDateString = Console.ReadLine();
                        Console.WriteLine("Напишите дату(день, месяц, год), на которой закончится подсчёт");
                        string EndDateString = Console.ReadLine();
                        financeManager.CalculateSumForDates(StartDateString, EndDateString);
                        break;
                    case 7 :
                       financeManager.CalculateSumForWeek();
                        break;
                    case 8 :
                        financeManager.CalculateSumForMonth();
                        break;
                    case 9:
                        financeManager.showFinanceReports();
                        break;
                    case 0:
                        break;

                    default:
                        break;
                }
            }
        }
    }
}
