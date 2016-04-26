namespace Logger.Models.Appenders
{
    using System;
    using System.IO;

    using Contracts;

    public class FileAppender : Appender
    {
        private StreamWriter writer;

        public FileAppender(ILayout layout, StreamWriter writer)
            : base(layout)
        {
            this.Writer = this.writer;
        }

        public StreamWriter Writer
        {
            get
            {
                return this.writer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("writer");
                }

                this.writer = value;
            }
        }

        public override void AppendMessage(DateTime date, ReportLevel reportLevel, string msg)
        {
            string formated = this.Layout.FormatMessage(date, reportLevel, msg);
            using (this.writer)
            {
                this.writer.WriteLine(formated);
            }
        }
    }
}