namespace CodeFormating.Models
{
    using System;
    using System.Text;

    public class Event : IComparable<Event>
    {
        private DateTime date;
        private string title;
        private string location;

        public Event(DateTime date, string title, string location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(Event other)
        {
            int comparisonResult;
            int comparedByDate = this.date.CompareTo(other.date);
            int comparedByTitle = string.Compare(this.title, other.title, StringComparison.InvariantCulture);
            int comparedByLocation = string.Compare(this.location, other.location, StringComparison.InvariantCulture);
            if (comparedByDate == 0)
            {
                if (comparedByTitle == 0)
                {
                    comparisonResult = comparedByLocation;
                }
                else
                {
                    comparisonResult = comparedByTitle;
                }
            }
            else
            {
                comparisonResult = comparedByDate;
            }

            return comparisonResult;
        }

        public override string ToString()
        {
            StringBuilder toString = new StringBuilder();
            toString.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            toString.Append(" | " + this.title);
            if (string.IsNullOrEmpty(this.location))
            {
                toString.Append(" | " + this.location);
            }

            return toString.ToString();
        }
    }
}
