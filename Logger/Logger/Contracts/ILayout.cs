namespace Logger.Contracts
{
    using System;

    using Logger.Models;

    public interface ILayout
    {
        string FormatMessage(DateTime date, ReportLevel reportLevel, string error);
    }
}