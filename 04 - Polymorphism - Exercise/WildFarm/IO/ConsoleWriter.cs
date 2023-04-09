﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.IO
{
    public class ConsoleWriter : IWriter
    {
        public void Write(object obj) => Console.Write(obj);

        public void WriteLine(object obj) => Console.WriteLine(obj);
    }
}