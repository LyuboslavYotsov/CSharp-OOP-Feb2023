using MyLogger.Enums;
using MyLogger.Layouts.Interfaces;
using MyLogger.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }

        ReportLevel ReportLevel { get; }

        int MessagesAppended { get; }

        void AppendMessage(IMessage message);
    }
}
