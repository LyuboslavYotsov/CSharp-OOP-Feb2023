﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class StationayPhone : ICallable
    {
        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Dialing... {number}";
            }
        }
    }
}
