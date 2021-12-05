using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager
{
    public class Repository
    {
        private List<FinanceReport> FinanceReports = new List<FinanceReport>();
        private string FilePath = "test.csv";
        public void SetFilePath(string filePath)
        {
            FilePath = filePath;
            try
            {
                StreamReader file = new StreamReader(filePath);

                // skip headers of .csv
                //
                file.ReadLine();
                int countOfRows = 1;

                while (!file.EndOfStream)
                {
                    string financeReportString = file.ReadLine();
                    string[] frsMas = financeReportString.Split(";");
                    FinanceReports.Add(new FinanceReport
                    {
                        Id = countOfRows++,
                        Description = frsMas[0],
                        Sum = double.Parse(frsMas[1]),
                        Date = DateTime.Parse(frsMas[2]),
                        ReportType = frsMas[3] == "income" ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION,
                        isRealized = frsMas[4] == "да" ? true : false

                    }); 
                }

                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }
        public void SafeFile()
        {
            try
            {
                StreamWriter file = new StreamWriter(FilePath);
                string headerString = "Описание;Сумма;Дата;Тип записи;учавствует ли в подсчётах(да,нет)";
                file.WriteLine(headerString);
                FinanceReports.ForEach(fr =>
                {
                    file.WriteLine(GetFinanceRecordData(fr));
                });
                file.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private string GetFinanceRecordData(FinanceReport fr)
        {
            return fr.Description + ";" + fr.Sum + ";" + GetStringDate(fr.Date) + ";" + fr.ReportType.ToString().ToLower() + ";" + fr.isRealized;
        }
        public void AddFinanceReport(FinanceReport financeReport)
        {
            FinanceReports.Add(financeReport);
        }
        public void DeleteFinanceReport(int id)
        {
            FinanceReport financeReport = FinanceReports.FirstOrDefault(_ => _.Id == id);
            if (financeReport is null)
            {
                Console.WriteLine("Not found finance report");
            }
            else
            {
                FinanceReports.Remove(financeReport);
                Console.WriteLine("Successful removing");
            }
        }
        public void ChangeFinanceReport(int id, FinanceReport changedFinanceReport)
        {
            FinanceReport financeReport = FinanceReports.FirstOrDefault(_ => _.Id == id);
            if (financeReport is null)
            {
                Console.WriteLine("Not found finance report");
            }
            else
            {
                FinanceReports.Remove(financeReport);
                FinanceReports.Add(changedFinanceReport);
                Console.WriteLine("Successful changing");
            }
        }
        public void CalculateSumForDates(DateTime StartDate, DateTime EndDate)
        {
            List<FinanceReport> financeReports = FinanceReports.FindAll(_ => _.Date.Date >= StartDate.Date && _.Date.Date <= EndDate.Date && _.isRealized is true);
            double incomeSum = 0;
            double consumptionSum = 0;
            financeReports.ForEach(fr =>
            {
                if (fr.ReportType is FinanceReportType.INCOME)
                {
                    incomeSum += fr.Sum;
                }
                else
                {
                    consumptionSum += fr.Sum;
                }

            });
            Console.WriteLine(GetStringDate(StartDate) + "-" + GetStringDate(EndDate) + ": Доход " + incomeSum + " Расход " + consumptionSum + " Остаток: " + (incomeSum - consumptionSum));
        }
        public void CalculateSumForWeek()
        {
            DateTime StartDate = DateTime.Today;
            DateTime EndDate = DateTime.Today;

            while (StartDate.DayOfWeek != DayOfWeek.Monday || EndDate.DayOfWeek != DayOfWeek.Sunday)
            {
                if (StartDate.DayOfWeek != DayOfWeek.Monday)
                {
                    StartDate = StartDate.AddDays(-1);
                }
                if (EndDate.DayOfWeek != DayOfWeek.Sunday)
                {
                    EndDate = EndDate.AddDays(1);
                }
            }

            Console.WriteLine();
            List<FinanceReport> financeReports = FinanceReports.FindAll(_ => _.Date.Date >= StartDate.Date && _.Date.Date <= EndDate.Date && _.isRealized is true);
            double incomeSum = 0;
            double consumptionSum = 0;
            financeReports.ForEach(fr =>
            {
                if (fr.ReportType is FinanceReportType.INCOME)
                {
                    incomeSum += fr.Sum;
                }
                else
                {
                    consumptionSum += fr.Sum;
                }

            });
            Console.WriteLine(GetStringDate(StartDate) + "-" + GetStringDate(EndDate) + ": Доход " + incomeSum + " Расход " + consumptionSum + " Остаток: " + (incomeSum - consumptionSum));
        }
        public void CalculateSumForMonth()
        {
            DateTime StartDate = DateTime.Today;
            DateTime EndDate = DateTime.Today;

            while (StartDate.Month == StartDate.AddDays(-1).Month || EndDate.Month == EndDate.AddDays(1).Month)
            {
                DateTime yesterdayStartDate = StartDate.AddDays(-1);
                DateTime tomorrowEndDate = EndDate.AddDays(1);
                if (StartDate.Month == yesterdayStartDate.Month)
                {
                    StartDate = yesterdayStartDate;
                }
                if (EndDate.Month == tomorrowEndDate.Month)
                {
                    EndDate = tomorrowEndDate;
                }
            }

            List<FinanceReport> financeReports = FinanceReports.FindAll(_ => _.Date.Date >= StartDate.Date && _.Date.Date <= EndDate.Date && _.isRealized is true);
            double incomeSum = 0;
            double consumptionSum = 0;
            financeReports.ForEach(fr =>
            {
                if (fr.ReportType is FinanceReportType.INCOME)
                {
                    incomeSum += fr.Sum;
                }
                else
                {
                    consumptionSum += fr.Sum;
                }

            });
            Console.WriteLine(GetStringDate(StartDate) + "-" + GetStringDate(EndDate) + ": Доход " + incomeSum + " Расход " + consumptionSum + " Остаток: " + (incomeSum - consumptionSum));
        }
        private string GetStringDate(DateTime Date)
        {
            return Date.Day + "." + Date.Month + "." + Date.Year;
        }
        public List<FinanceReport> GetReports()
        {
            return FinanceReports;
        }
    }
}
