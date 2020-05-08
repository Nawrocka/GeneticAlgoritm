using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGAMaria
{
    public class Program1
    {        
        static void Main(string[] args)
        {
            TestShakespeare test = new TestShakespeare();
            testFunkcja test2 = new testFunkcja();
            test2.Start();
            test.Start();
            Console.ReadLine();
        }
    }
}
