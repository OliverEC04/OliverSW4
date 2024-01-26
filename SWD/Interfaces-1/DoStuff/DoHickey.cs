using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DoStuff
{
    public class DoHickey : IDoThings
    {
        public void DoNothing()
        {
            Console.Write(this.GetType().Name);
            Console.WriteLine(System.Reflection.MethodBase.GetCurrentMethod().Name);
        }

        public int DoSomething(int number)
        {
            Console.Write(this.GetType().Name);
            Console.Write(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.WriteLine(number);

            return number;
        }

        public string DoSomethingElse(string input)
        {
            Console.Write(this.GetType().Name);
            Console.Write(System.Reflection.MethodBase.GetCurrentMethod().Name);
            Console.WriteLine(input);

            return input;
        }
    }
}
