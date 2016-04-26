namespace CodeFormating.Contracts
{
    using System.Collections.Generic;

    public interface IEventLogger
    {
        IEnumerable<string> LoggedMessages { get; }

        void AddToLog(string input);
    }
}
