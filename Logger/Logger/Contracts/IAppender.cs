namespace Logger.Contracts
{
    using System;

    using Logger.Models;

    public interface IAppender
    {
        ILayout Layout { get; set; }

        void AppendMessage(DateTime date, ReportLevel reportLevel, string msg);
    }
}