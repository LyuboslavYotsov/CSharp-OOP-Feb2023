﻿using MyLogger.Appenders;
using MyLogger.Appenders.Interfaces;
using MyLogger.Layouts;
using MyLogger.Layouts.Interfaces;
using MyLogger.Loggers;
using MyLogger.Loggers.Interfaces;
using System;

namespace MyLogger;
public class StartUp
{
    static void Main(string[] args)
    {
        ILayout simpleLayout = new SimpleLayout();
        IAppender consoleAppender =
        new ConsoleAppender(simpleLayout);
        ILogger logger = new Logger(consoleAppender);

        logger.Error("3/26/2015 2:08:11 PM", "Error parsing JSON.");
        logger.Info("3/26/2015 2:08:11 PM", "User Pesho successfully registered.");

    }
}