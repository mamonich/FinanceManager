using System;

namespace FinanceManager
{
    public class FinanceReport
    {
        public int Id;
        public string Description;
        public double Sum;
        public DateTime Date;
        public FinanceReportType ReportType;
        public bool isRealized;
    }
}