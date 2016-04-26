namespace Logger.Models.Layouts
{
    using System;

    using Contracts;

    public class SimpleLayout : ILayout
    {
        public string FormatMessage(DateTime date, ReportLevel reportLevel, string message)
        {
            string level = string.Format(reportLevel.ToString());
            string result = string.Format("{0} - {1} - {2}", date.ToString("dd/MM/yyyy H:mm:ss"), level, message);
            return result;
        }
    }
}