namespace CodeFormating.Contracts
{
    using System;

    public interface IEventHolder
    {
        void AddEvent(DateTime date, string title, string location);

        void DeleteEvents(string titleToDelete);

        string ListEvents(DateTime date, int count);
    }
}