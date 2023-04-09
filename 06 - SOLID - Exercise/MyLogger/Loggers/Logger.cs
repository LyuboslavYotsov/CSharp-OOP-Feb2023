using MyLogger.Appenders.Interfaces;
using MyLogger.Enums;
using MyLogger.Loggers.Interfaces;
using MyLogger.Models.Interfaces;
using MyLogger.Models;
using System;
using System.Collections.Generic;

namespace MyLogger.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;

        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public Logger(ICollection<IAppender> appenders)
        {
            this.appenders = appenders;
        }

        public void Info(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Info);

        public void Warning(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Warning);

        public void Error(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Error);

        public void Critical(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Critical);


        public void Fatal(string dateTime, string text)
            => AppendAll(dateTime, text, ReportLevel.Fatal);

        private void AppendAll(string dateTime, string text, ReportLevel reportLevel)
        {
            IMessage message = new Message(dateTime, text, reportLevel);

            foreach (IAppender appender in appenders)
            {
                if (message.ReportLevel >= appender.ReportLevel)
                {
                    appender.AppendMessage(message);
                }
            }
        }
    }
}
