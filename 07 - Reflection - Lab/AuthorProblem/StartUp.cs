using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthorProblem
{
    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        static void Main(string[] args)
        {
            Tracker tracker= new Tracker();
            tracker.PrintMethodsByAuthor();
        }

        [Author("Bai Pesho")]
        public void DoSomething()
        {

        }
    }
}
