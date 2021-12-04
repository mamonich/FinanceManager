﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager
{
    public class FinanceManager
    {
        public Repository FinanceReportRepository = new Repository();

        public void showGreeting()
        {
            Console.WriteLine("Приветствуем вас, пользователь");
            setSpace();
        }
        public void showMainMenu()
        {
            Console.WriteLine("1.Прочитать из .csv файла\n" +
                "2.Сохранить в .csv файл\n" +
                "3.Добавить запись\n" +
                "4.Удалить  запись\n" +
                "5.Изменить запись\n" +
                "6.Посчитать итог между датами\n" +
                "7.Посчитать итог этой недели\n" +
                "8.Посчитать итог этого месяца\n" +
                "9.Показать записи\n" +
                "0.Завершить работу");
        }
        public void AddFinanceReport(string financeReportString)
        {

            string[] frMas = financeReportString.Split(";");
            List<FinanceReport> financeReports = FinanceReportRepository.GetReports();
            FinanceReport financeReport = financeReports.LastOrDefault();
            FinanceReportRepository.AddFinanceReport(new FinanceReport
            {
                Id = financeReport.Id + 1,
                Description = frMas[0],
                Sum = double.Parse(frMas[1]),
                Date = DateTime.Parse(frMas[2]),
                ReportType = frMas[3] == "income" ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION,
                isRealized = frMas[4] == "да" ? true : false
            });
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
            FinanceReportRepository.ChangeFinanceReport(id, new FinanceReport
            {
                Id = id,
                Description = frMas[0],
                Sum = double.Parse(frMas[1]),
                Date = DateTime.Parse(frMas[2]),
                ReportType = frMas[3] == "да" ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION,
                isRealized = frMas[4] == "да" ? true : false
            });
            setSpace();
        }
        public void CalculateSumForDates(string StartDate, string EndDate)
        {            
            FinanceReportRepository.CalculateSumForDates(DateTime.Parse(StartDate), DateTime.Parse(EndDate));
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
    }
}
