namespace TheatreInformationSystem
{
    using System.Globalization;
    using System.Threading;

    using TheatreInformationSystem.Core;
    using TheatreInformationSystem.Data;

    public class InformationSystemProgram
    {
        public static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var database = new PerformanceDatabase();
            var reader = new ConsoleReader();
            var renderer = new ConsoleRenderer();
            var engine = new TheatreInformationEngine(database, renderer, reader);
            engine.Run();
        }
    }
}