namespace CodeFormating.Core
{
    using System.Collections.Generic;
    using CodeFormating.Contracts;

    public class EventLogger : IEventLogger
    {
        private readonly IList<string> logger;

        public EventLogger()
        {
            this.logger = new List<string>();
        }

        public IEnumerable<string> LoggedMessages
        {
            get { return this.logger; }
        }

        public void AddToLog(string input)
        {
            this.logger.Add(input);
        }
    }
}