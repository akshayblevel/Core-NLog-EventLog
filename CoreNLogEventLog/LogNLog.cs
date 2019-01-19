using NLog;
using System;
using System.Collections.Generic;

namespace CoreNLogEventLog
{
    public class LogNLog : ILog
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public LogNLog()
        {
        }

        public void Debug(string message)
        {
            Logger logger = LogManager.GetLogger("EventLogTarget");
            var logEventInfo = new LogEventInfo(LogLevel.Error, "EventLogMessage", $"{message}, generated at {DateTime.UtcNow}.");
            logEventInfo.Properties["EmployeeID"] = "5677";
            logEventInfo.Properties["EmployeeName"] = "Akshay Patel";
            logEventInfo.Properties["fields"] = new List<KeyValuePair<string, object>>
             {
             new KeyValuePair<string, object>("Address", "Hyderabad")
             };
            logger.Log(logEventInfo);
            //LogManager.Shutdown();
        }

        public void Error(string message)
        {
            logger.Error(message);
        }

        public void Information(string message)
        {
            logger.Info(message);
        }

        public void Warning(string message)
        {
            logger.Warn(message);
        }
    }
}
