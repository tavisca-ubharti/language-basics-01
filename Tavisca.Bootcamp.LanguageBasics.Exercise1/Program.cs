using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Test("42*47=1?74", 9);
            Test("4?*47=1974", 2);
            Test("42*?7=1974", 4);
            Test("42*?47=1974", -1);
            Test("2*12?=247", -1);
            Console.ReadKey(true);
        }

        private static void Test(string args, int expected)
        {
            var result = FindDigit(args).Equals(expected) ? "PASS" : "FAIL";
            Console.WriteLine($"{args} : {result}");
        }

        public static int FindDigit(string equation)
        {
            //Equation : a * b = c

            string a = equation.Substring(0, equation.IndexOf('*'));
            string b = equation.Substring(equation.IndexOf('*') + 1, equation.IndexOf('=') - equation.IndexOf('*') - 1);
            string c = equation.Substring(equation.IndexOf('=') + 1);

            if (a.Contains('?'))
            {
                int result = (int.Parse(c)) / int.Parse(b);
                if (result * int.Parse(b) == int.Parse(c))
                {
                    string strResult = result.ToString();
                    if (strResult.Length == a.Length)
                    {
                        int index = a.IndexOf('?');
                        return int.Parse(strResult[index].ToString());
                    }
                }
            }
            else if (b.Contains('?'))
            {

                int result = (int.Parse(c)) / int.Parse(a);
                if (result * int.Parse(a) == int.Parse(c))
                {
                    string strResult = result.ToString();
                    if (strResult.Length == b.Length)
                    {
                        int index = b.IndexOf('?');
                        return int.Parse(strResult[index].ToString());

                    }
                }
            }
            else
            {
                int result = int.Parse(a) * int.Parse(b);
                if (int.Parse(a) * int.Parse(b) == result)
                {
                    string strResult = result.ToString();
                    if (strResult.Length == c.Length)
                    {
                        int index = c.IndexOf('?');
                        return int.Parse(strResult[index].ToString());

                    }
                }
            }
            return -1;
        }
    }
}