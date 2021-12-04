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
        private List<FinanceReport> FinanceReports;
        private DateTime BeginDate;
        private DateTime EndDate;
        private string FilePath;

        public Repository(string filePath)
        {
            FilePath = filePath;
            try
            {
                StreamReader file = new StreamReader(filePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            for (int i = 0; i < 10; i++)
            {
                FinanceReports.Add(new FinanceReport
                {
                    Id = i,
                    Description = "Desc" + i,
                    Sum = (i + 2) * 10,
                    ReportType = i % 2 == 0 ? FinanceReportType.INCOME : FinanceReportType.CONSUMPTION,
                    Date = new DateTime().Date
                });
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
                Console.WriteLine("Successful removing");
            }
        }

    }
}
