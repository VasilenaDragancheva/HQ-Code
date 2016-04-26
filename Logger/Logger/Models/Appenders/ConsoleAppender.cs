namespace Logger.Models.Appenders
{
    using System;

    using Contracts;

    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout)
            : base(layout)
        {
        }

        public override void AppendMessage(DateTime date, ReportLevel reportLevel, string msg)
        {
            string formatedMsg = this.Layout.FormatMessage(date, reportLevel, msg);
            Console.WriteLine(formatedMsg);
        }
    }
}