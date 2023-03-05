using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    public class Smartphone : IBrowsable
    {
        public string Browse(string webAdress)
        {
            if (webAdress.Any(c => char.IsDigit(c)))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {webAdress}!";
            }

        }

        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }
    }
}
