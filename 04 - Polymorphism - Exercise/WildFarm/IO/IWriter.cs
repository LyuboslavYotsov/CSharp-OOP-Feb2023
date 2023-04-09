using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WildFarm.IO
{
    public interface IWriter
    {
        void Write(object obj);

        void WriteLine(object obj);
    }
}
