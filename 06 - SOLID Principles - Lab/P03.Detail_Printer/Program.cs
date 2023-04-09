using System.Collections.Generic;

namespace P03.Detail_Printer
{
    class Program
    {
        static void Main()
        {
            List<string> docs = new List<string> {"doc1", "doc2", "doc3" };
            Employee employee = new Employee("Gosho");
            Manager manager = new Manager("Pesho", docs);

            DetailsPrinter dprinter = new DetailsPrinter(new List<Employee> { employee, manager });

            dprinter.PrintDetails();
        }
    }
}
