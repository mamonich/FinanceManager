using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager
{
    public class FinanceManager
    {
        public Repository FinanceReportRepository = new Repository();
        public FinanceManager()
        {
            FinanceReportRepository.SetFilePath(ConfigurationManager.AppSettings["fileName"]);
        }
        public void showGreeting()
        {
            Console.WriteLine("Приветствуем вас, пользователь");
            setSpace();
        }
        public void showMainMenu()
        {
            Console.WriteLine("1.Добавить запись\n" +
                "2.Удалить  запись\n" +
                "3.Изменить запись\n" +
                "4.Посчитать итог между датами\n" +
                "5.Посчитать итог этой недели\n" +
                "6.Посчитать итог этого месяца\n" +
                "7.Показать записи\n" +
                "0.Завершить работу");
        }
        public void AddFinanceReport(string financeReportString)
        {

            string[] frMas = financeReportString.Split(";");
            List<FinanceReport> financeReports = FinanceReportRepository.GetReports();
            FinanceReport financeReport = financeReports.LastOrDefault();
            try
            {
                FinanceReportRepository.AddFinanceReport(new FinanceReport
                {
                    Id = financeReport.Id + 1,
                    Description = frMas[0],
                    Sum = double.Parse(frMas[1]),
                    Date = DateTime.Parse(frMas[2]),
                    ReportType = frMas[3] == "income" ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION,
                    isRealized = frMas[4] == "да" ? true : false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            setSpace();
        }
        public void DeleteFinanceReport(int id)
        {            
            FinanceReportRepository.DeleteFinanceReport(id);
            setSpace();
        }
        public void ChangeFinanceReport(int id, string changedFinanceReportString)
        {
            string[] frMas = changedFinanceReportString.Split(";");
            try
            {
                FinanceReportRepository.ChangeFinanceReport(id, new FinanceReport
                {
                    Id = id,
                    Description = frMas[0],
                    Sum = double.Parse(frMas[1]),
                    Date = DateTime.Parse(frMas[2]),
                    ReportType = frMas[3] == "income" ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION,
                    isRealized = frMas[4] == "да" ? true : false
                });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            setSpace();
        }
        public void CalculateSumForDates(string StartDate, string EndDate)
        {
            try
            {
                FinanceReportRepository.CalculateSumForDates(DateTime.Parse(StartDate), DateTime.Parse(EndDate));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            setSpace();
        }
        public void CalculateSumForWeek()
        {
            FinanceReportRepository.CalculateSumForWeek();
            setSpace();
        }
        public void showFinanceReports()
        {
            List<FinanceReport> financeReports = FinanceReportRepository.GetReports();
            financeReports.ForEach(fr =>
            {
                Console.WriteLine(fr.Id + " " + fr.Description + " " + fr.Sum +
                    " " + fr.Date + " " + fr.ReportType + " " + fr.isRealized);
            });
            Console.WriteLine();
        }
        public void CalculateSumForMonth()
        {
            FinanceReportRepository.CalculateSumForMonth();
            setSpace();
        }
        private void setSpace()
        {
            Console.WriteLine();
        }
        public int GetNumberFromConsole(int numberOfChoice)
        {
            try
            {
                numberOfChoice = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }

            return numberOfChoice;
        }
    }
}
