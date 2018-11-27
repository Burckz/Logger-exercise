namespace Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;

    class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout) : base(layout)
        {

        }

        public override void Append(string dateTime, ReportLevel report, string message)
        {
            if (this.ReportLevel <= report)
            {
                Console.WriteLine(string.Format(this.Layout.Format, dateTime, report, message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                   $" Report level: {this.ReportLevel}, Messages appended: {this.MessageCount}");


            return output.ToString().TrimEnd();
        }
    }
}
