using MyLogger.Appenders.Interfaces;
using MyLogger.Enums;
using MyLogger.Layouts.Interfaces;
using MyLogger.Models.Interfaces;
using System;

namespace MyLogger.Appenders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get; set; }

        public int MessagesAppended { get; private set; }

        public void AppendMessage(IMessage message)
        {
            Console.WriteLine(string.Format(Layout.Format(), message.CreatedTime, message.ReportLevel, message.Text));

            MessagesAppended++;
        }
        public override string ToString()
            => $"Appender type: {this.GetType().Name}, Layout type: {Layout.GetType().Name}, Report level: {ReportLevel.ToString().ToUpper()}, Messages appended: {MessagesAppended}";
    }
}
