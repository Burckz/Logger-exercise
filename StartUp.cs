namespace Logger
{
    using Appenders;
    using Layouts;
    using Appenders.Contracts;
    using Layouts.Contracts;
    using Loggers;
    using System;
    using Logger.Loggers.Contracts;

    class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            IAppender[] appenders = new IAppender[n];

            AddAppenders(n, appenders);

            ILogger logger = new Logger(appenders);

            Messages(appenders, logger);

            Console.WriteLine("Logger info" + Environment.NewLine + logger);
        }

        private static void Messages(IAppender[] appenders, ILogger logger)
        {
            string input = Console.ReadLine();

            while(input != "END")
            {
                string[] args = input.Split(new string[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                
                string time = args[1];
                string message = args[2];

                switch (args[0].ToLower())
                {
                    case "info":
                        logger.Info(time, message);
                        break;
                    case "warning":
                        logger.Warning(time, message);
                        break;
                    case "error":
                        logger.Error(time, message);
                        break;
                    case "critical":
                        logger.Critical(time, message);
                        break;
                    case "fatal":
                        logger.Fatal(time, message);
                        break;
                }

                input = Console.ReadLine();
            }
        }

        private static void AddAppenders(int n, IAppender[] appenders)
        {
            for (int i = 0; i < n; i++)
            {
                string[] args = Console.ReadLine().Split();

                IAppender appender = null;
                string appenderType = args[0];

                ILayout layout = null;
                string layoutType = args[1];

                ReportLevel reportLevel = ReportLevel.INFO;
                

                switch (layoutType.ToLower())
                {
                    case "simplelayout":
                        layout = new SimpleLayout();
                        break;
                    case "xmllayout":
                        layout = new XmlLayout();
                        break;
                    default:
                        layout = null;
                        break;
                }

                switch (appenderType.ToLower())
                {
                    case "consoleappender":
                        appender = new ConsoleAppender(layout);
                        break;
                    case "fileappender":
                        appender = new FileAppender(layout, new LogFile());
                        break;
                    default:
                        appender = null;
                        break;
                }

                if (args.Length == 3)
                {
                    switch (args[2].ToLower())
                    {
                        case "info":
                            reportLevel = ReportLevel.INFO;
                            break;
                        case "warning":
                            reportLevel = ReportLevel.WARNING;
                            break;
                        case "error":
                            reportLevel = ReportLevel.ERROR;
                            break;
                        case "critical":
                            reportLevel = ReportLevel.CRITICAL;
                            break;
                        case "fatal":
                            reportLevel = ReportLevel.FATAL;
                            break;
                        default:
                            reportLevel = ReportLevel.INFO;
                            break;

                    }
                }

                ((Appender)appender).ReportLevel = reportLevel;

                appenders[i] = appender;
            }
        }
    }
}
