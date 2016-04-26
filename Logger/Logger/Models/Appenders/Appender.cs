namespace Logger.Models.Appenders
{
    using System;

    using Contracts;

    public abstract class Appender : IAppender
    {
        private ILayout layout;

        protected Appender(ILayout layout)
        {
            this.Layout = layout;
        }

        public ILayout Layout
        {
            get
            {
                return this.layout;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("layout");
                }

                this.layout = value;
            }
        }

        public abstract void AppendMessage(DateTime date, ReportLevel reportLevel, string msg);
    }
}