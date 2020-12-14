using System;

namespace calc
{
    public class program
    {
         public static void Main(string[] args)
        {

            string str = Console.ReadLine();
            int result = 0;
            result = Calc.calculator(str);
            Console.WriteLine(result.ToString());
        }

    }
}