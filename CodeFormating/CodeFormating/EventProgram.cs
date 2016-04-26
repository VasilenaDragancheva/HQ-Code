namespace CodeFormating
{
    using Contracts;
    using Core;
    using Models;

    public class EventProgram
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            IEventHolder events = new EventHolder();
            IEventLogger logger = new EventLogger();
            IEventEngine eventEngine = new EventEngine(reader, writer, events, logger);
            eventEngine.Run();
        }
    }
}
