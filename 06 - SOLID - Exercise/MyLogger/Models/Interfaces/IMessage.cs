﻿using MyLogger.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Models.Interfaces
{
    public interface IMessage
    {
        string CreatedTime { get; }
        string Text { get; }
        ReportLevel ReportLevel { get; }
    }
}
