namespace CodeFormating.Models
{
    using System;
    using System.Text;
    using CodeFormating.Contracts;
    using Wintellect.PowerCollections;

    public class EventHolder : IEventHolder
    {
        private readonly OrderedBag<Event> eventsByDate = new OrderedBag<Event>();
        private readonly MultiDictionary<string, Event> eventsByTitle = new MultiDictionary<string, Event>(true);

        public void AddEvent(DateTime date, string title, string location)
        {
            var newEvent = new Event(date, title, location);
            this.eventsByTitle.Add(title.ToLower(), newEvent);
            this.eventsByDate.Add(newEvent);
        }

        public void DeleteEvents(string titleToDelete)
        {
            var title = titleToDelete.ToLower();
            var removed = 0;
            foreach (var eventToRemove in this.eventsByTitle[title])
            {
                removed++;
                this.eventsByDate.Remove(eventToRemove);
            }

            this.eventsByTitle.Remove(title);
        }

        public string ListEvents(DateTime date, int count)
        {
            StringBuilder listedEvents = new StringBuilder();
            var eventsToShow = this.eventsByDate.RangeFrom(new Event(date, string.Empty, string.Empty), true);
            listedEvents.AppendFormat("{0} events to show:", eventsToShow.Count);

            foreach (var eventToShow in eventsToShow)
            {
                listedEvents.AppendFormat("{0}{1}", eventsToShow, Environment.NewLine);
            }

            return listedEvents.ToString();
        }
    }
}