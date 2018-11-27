namespace Logger.Appenders
{
    using Logger.Appenders.Contracts;
    using Logger.Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class Appender : IAppender
    {
        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessageCount { get; protected set; }

        public virtual void Append(string dateTime, ReportLevel report, string message)
        {
            //TODO for child classes
        }

        public Appender(ILayout layout)
        {
            this.Layout = layout;
            this.ReportLevel = ReportLevel.INFO;
            this.MessageCount = 0;
        }
    }
}
