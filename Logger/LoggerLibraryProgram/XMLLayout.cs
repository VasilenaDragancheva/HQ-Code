namespace LoggerLibraryTest
{
    using System;
    using System.Text;

    using Logger.Contracts;
    using Logger.Models;

    public class XmlLayout : ILayout
    {
        public string FormatMessage(DateTime date, ReportLevel reportLevel, string message)
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine("<log>");
            result.AppendLine(string.Format("   <date>{0}</date>", date.ToString("dd/MM/yyyy H:mm:ss")));
            result.AppendLine(string.Format("   <level>{0}</level>", reportLevel));
            result.AppendLine(string.Format("   <message>{0}</message>", message));
            result.AppendLine("</log>");
            return result.ToString();
        }
    }
}