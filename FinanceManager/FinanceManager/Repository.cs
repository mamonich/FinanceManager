using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinanceManager
{
    public class Repository
    {
        private List<FinanceReport> FinanceReports = new List<FinanceReport>();
        private DateTime BeginDate;
        private DateTime EndDate;
        private string FilePath;

        public void setFilePath(string filePath)
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
                        ReportType = frsMas[3] == "income" ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION

                    }); 
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        public FinanceReport GetFinanceReport(int id)
        {
            return FinanceReports.FirstOrDefault(_ => _.Id == id);
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

    }
}
