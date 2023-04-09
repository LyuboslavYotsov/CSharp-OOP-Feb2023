using MyLogger.Enums;
using MyLogger.Models.Interfaces;
using MyLogger.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLogger.Models
{
    public class Message : IMessage
    {
        private string createdTime;
        private string text;

        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }

        public string CreatedTime
        {
            get => createdTime;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Date cannot be null or whitespace!");
                }

                if (!DateTimeValidator.ValidateDateTime(value))
                {
                    throw new ArgumentException("Invalid date!");
                }

                createdTime = value;
            }
        }

        public string Text
        {
            get => text;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Text cannot be null or whitespace!");
                }

                text = value;
            }
        }

        public ReportLevel ReportLevel { get; private set; }
    }
}
