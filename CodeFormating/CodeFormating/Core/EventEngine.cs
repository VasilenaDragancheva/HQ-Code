namespace CodeFormating.Core
{
    using System;

    using CodeFormating.Contracts;

    public class EventEngine : IEventEngine
    {
        private readonly IEventHolder eventHolder;

        private readonly IEventLogger eventLogger;

        private readonly IReader reader;

        private readonly IWriter writer;

        public EventEngine(IReader reader, IWriter writer, IEventHolder eventHolder, IEventLogger eventLogger)
        {
            this.reader = reader;
            this.writer = writer;
            this.eventHolder = eventHolder;
            this.eventLogger = eventLogger;
        }

        public virtual void Run()
        {
            string command;
            while (true)
            {
                command = this.reader.ReadLine();
                if (command.ToLower() == "end")
                {
                    break;
                }

                string result = this.ExecuteCommand(command);
            }
        }

        protected virtual string ExecuteCommand(string command)
        {
            switch (command[0])
            {
                case 'A':
                    return this.AddEvent(command);
                case 'D':
                    return this.DeleteEvents(command);
                case 'L':
                    return this.ListEvents(command);
                default:
                    throw new InvalidOperationException("Not supported command supplied!");
            }
        }

        private string AddEvent(string command)
        {
            DateTime date;
            string title;
            string location;
            this.GetParameters(command, "AddEvent", out date, out title, out location);
            this.eventHolder.AddEvent(date, title, location);
            string result = string.Format("Add new event date:{0},title{1},location {2}", date, title, location);

            return result;
        }

        private string DeleteEvents(string command)
        {
            string title = command.Substring("DeleteEvents".Length + 1);
            this.eventHolder.DeleteEvents(title);
            string result = string.Format("Deleted title:{0}", title);

            return result;
        }

        private DateTime GetDate(string command, string commandType)
        {
            DateTime date = DateTime.Parse(command.Substring(commandType.Length + 1, 20));
            return date;
        }

        private void GetParameters(
            string commandForExecution,
            string commandType,
            out DateTime dateAndTime,
            out string eventTitle,
            out string eventLocation)
        {
            dateAndTime = this.GetDate(commandForExecution, commandType);
            int firstPipeIndex = commandForExecution.IndexOf('|');
            int lastPipeIndex = commandForExecution.LastIndexOf('|');
            if (firstPipeIndex == lastPipeIndex)
            {
                eventTitle = commandForExecution.Substring(firstPipeIndex + 1).Trim();
                eventLocation = string.Empty;
            }
            else
            {
                eventTitle =
                    commandForExecution.Substring(firstPipeIndex + 1, lastPipeIndex - firstPipeIndex - 1).Trim();
                eventLocation = commandForExecution.Substring(lastPipeIndex + 1).Trim();
            }
        }

        private string ListEvents(string command)
        {
            int pipeIndex = command.IndexOf('|');
            DateTime date = this.GetDate(command, "ListEvents");
            string countString = command.Substring(pipeIndex + 1);
            int count = int.Parse(countString);
            string result = this.eventHolder.ListEvents(date, count);

            return result;
        }
    }
}