namespace CodeFormating
{
    using System;
    using System.Text;
    using Models;

    /// <summary>
    /// Decided to avoid dependency on static class,because it breaks SOLID principles
    /// </summary>
    public static class Messages
    {
        private static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.AppendFormat("Event added {0}", Environment.NewLine);
        }

        public static void EventDeleted(int x)
        {
            if (x == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendFormat("{0} events deleted {1}", x, Environment.NewLine);
            }
        }

        public static void NoEventsFound()
        {
            output.AppendFormat("No events found{0}", Environment.NewLine);
        }

        public static void PrintEvent(Event eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.AppendFormat("{0}{1}", eventToPrint, Environment.NewLine);
            }
        }
    }
}
