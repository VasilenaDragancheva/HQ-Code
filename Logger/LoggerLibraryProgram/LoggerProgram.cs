namespace LoggerLibraryTest
{
    using Logger.Models;
    using Logger.Models.Appenders;
    using Logger.Models.Loggers;

    public class LoggerProgram
    {
        public static void Main(string[] args)
        {
            var xmllayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmllayout);
            var logger = new Logger(ReportLevel.Info, consoleAppender);
            logger.Info("Everything seems fine");
            logger.Warn("Warning: ping is too high - disconnect imminent");
            logger.Error("Error parsing request");
            logger.Critical("No connection string found in App.config");
        }
    }
}