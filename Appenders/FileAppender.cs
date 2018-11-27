namespace Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class FileAppender : Appender
    {
        private LogFile file;

        public FileAppender(ILayout layout, LogFile file) : base(layout)
        {
            this.file = file;

        }

        public override void Append(string dateTime, ReportLevel report, string message)
        {
            if (this.ReportLevel <= report)
            {
                File.AppendAllText("../../../LogFile.txt", string.Format(this.Layout.Format, dateTime, report, message));
                this.MessageCount++;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}," +
                   $" Report level: {this.ReportLevel}, Messages appended: {this.MessageCount}, File Size: {file.Size()}");


            return output.ToString().TrimEnd();
        }
    }
}
