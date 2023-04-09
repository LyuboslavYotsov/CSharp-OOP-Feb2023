using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01.Stream_Progress
{
    public class Movie : IStreamable
    {
        public string Name { get; set; }

        public string Platform { get; set; }

        public TimeSpan MovieLenght { get; set; }
        public Movie(int length, int bytesSent)
        {
            Length = length;
            BytesSent = bytesSent;
        }

        public int Length {get; private set;}

        public int BytesSent { get; private set;}
    }
}
