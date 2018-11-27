namespace Logger.Appenders.Contracts
{
    using Layouts.Contracts;

    public interface IAppender
    {
        ILayout Layout { get; }

        void Append(string dateTime, ReportLevel report, string message);

        ReportLevel ReportLevel { get; }

        int MessageCount { get; }
    }
}
