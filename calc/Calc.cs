using System;
using System.Collections.Generic;
using System.Linq;


namespace calc
{
    public class Calc
    {

        private const int NumberLimit = 1000;
        public static int calculator(string str)
        {
            List<string> delimeter = new List<string> { "," };
            int result = 0;
            int index = 0;

            if (string.IsNullOrEmpty(str)) return 0;

            if (str.Contains("\n"))
            {
                if (str.Contains("//"))
                {
                    index = str.IndexOf("\n");

                    delimeter.AddRange(str.Substring(2, index - 2).Select(c => c.ToString()).ToList());

                    str = str.Substring(index + 1, str.Length - index - 1);
                }

            }


            result = AddArray(str, delimeter);
            return (result);
        }
        public static int AddArray(String str, List<string> delimeter)
        {
            int result = 0;

            var numbers = str.Split(delimeter.ToArray(), StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            if (numbers.Any(x => x < 0))
            {
                var negativeNumbers = string.Join(",", numbers.Where(x => x < 0).Select(x => x.ToString()).ToArray());
                throw new FormatException($"negatives not allowed '{negativeNumbers}'");
            }

            result = numbers.Where(x => x <= NumberLimit).Sum();
            return result;

        }

    }

}

