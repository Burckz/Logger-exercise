namespace Logger.Loggers
{
    using Contracts;
    using global::Logger.Appenders.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Logger : ILogger
    {
        private IAppender appender;

        private List<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders.ToList();
        }

        public IReadOnlyCollection<IAppender> Appenders => this.appenders.AsReadOnly();

        public void Critical(string dateTime, string message)
        {
            foreach(var appender in appenders)
            {
                appender.Append(dateTime, ReportLevel.CRITICAL, message);
            }
        }

        public void Error(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, ReportLevel.ERROR, message);
            }
        }

        public void Fatal(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, ReportLevel.FATAL, message);
            }
        }

        public void Info(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, ReportLevel.INFO, message);
            }
        }

        public void Warning(string dateTime, string message)
        {
            foreach (var appender in appenders)
            {
                appender.Append(dateTime, ReportLevel.WARNING, message);
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            foreach(var appender in appenders)
            {
                output.AppendLine(appender.ToString());
            }

            return output.ToString().TrimEnd();
        }
    }
}
