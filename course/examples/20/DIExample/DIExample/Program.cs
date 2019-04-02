using System;

namespace DIExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Report
    {
        public Guid Id { get; set; }

        public DateTime Date { get; set; }

        // Some other fields 
    }

    public interface IReportSender
    {
        void SendReport(Report report);
    }

    class ReportProcessor
    {
        private readonly IReportSender _reportSender;

        // Constuctor Injection: передача обязательной зависимости
        public ReportProcessor(IReportSender reportSender)
        {
            _reportSender = reportSender;
            Logger = LogManager.DefaultLogger;
        }

        // Method Injection: передача обязательных зависимостей метода
        public void SendReport(Report report, IReportFormatter formatter)
        {
            Logger.Info("Sending report...");
            var formattedReport = formatter.Format(report);
            _reportSender.SendReport(formattedReport);
            Logger.Info("Report has been sent");
        }

        // Property Injection: установка необязательных "инфраструктурных" зависимостей
        public ILogger Logger { get; set; }
    }
}
