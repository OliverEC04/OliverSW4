using System;

namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator myCalc = new Calculator();

            Console.WriteLine($"Add 6 + 27  |  Expected: 33  |  Result: {myCalc.Add(6, 27)}");
            Console.WriteLine($"Subtract 6 - 27  |  Expected: -21  |  Result: {myCalc.Subtract(6, 27)}");
            Console.WriteLine($"Multiply 6 * 27  |  Expected: 162  |  Result: {myCalc.Multiply(6, 27)}");
            Console.WriteLine($"Power 6 ^ 4  |  Expected: 1296  |  Result: {myCalc.Power(6, 4)}");

            // Considerations:
            // Jeg magter ikke teste mere, det er hårdt. Man kunne teste uendeligt mange ting.
            // Man kunne lave noget med if, så den siger hvad der bestod og ikke gjorde.
        }
    }
}