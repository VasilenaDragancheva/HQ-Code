namespace Logger.Contracts
{
    using System.Collections.Generic;

    using Logger.Models;

    public interface ILogger
    {
        IEnumerable<IAppender> Appenders { get; }

        void Critical(string message);

        void Error(string message);

        void Fatal(string message);

        void Info(string message);

        void Warn(string message);
    }
}