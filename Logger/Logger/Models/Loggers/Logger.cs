namespace Logger.Models.Loggers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;

    public class Logger : ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(ReportLevel reportLevel, params IAppender[] appenders)
        {
            this.ReportLevel = reportLevel;
            this.Appenders = appenders;
        }

        public IEnumerable<IAppender> Appenders
        {
            get
            {
                return this.appenders;
            }

            private set
            {
                if (value == null || !value.Any())
                {
                    throw new ArgumentException("There are no appender supplied");
                }

                this.appenders = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }

        public void Critical(string message)
        {
            this.LogtoAllAppenders(ReportLevel.Critical, message);
        }

        public void Error(string message)
        {
            this.LogtoAllAppenders(ReportLevel.Error, message);
        }

        public void Fatal(string message)
        {
            this.LogtoAllAppenders(ReportLevel.Fatal, message);
        }

        public void Info(string message)
        {
            this.LogtoAllAppenders(ReportLevel.Info, message);
        }

        public void Warn(string message)
        {
            this.LogtoAllAppenders(ReportLevel.Warning, message);
        }

        private void LogtoAllAppenders(ReportLevel reportLevel, string message)
        {
            if (reportLevel >= this.ReportLevel)
            {
                DateTime date = DateTime.Now;

                foreach (IAppender appender in this.Appenders)
                {
                    appender.AppendMessage(date, reportLevel, message);
                }
            }
        }
    }
}