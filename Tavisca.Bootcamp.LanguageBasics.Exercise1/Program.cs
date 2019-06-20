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
            string a = equation.Substring(0, equation.IndexOf('*'));
            string b = equation.Substring(equation.IndexOf('*') + 1, equation.IndexOf('=') - equation.IndexOf('*') - 1);
            string c = equation.Substring(equation.IndexOf('=') + 1);
            if (a.Contains('?'))
            {
                int ans = (int.Parse(c)) / int.Parse(b);
                if (ans * int.Parse(b) == int.Parse(c))
                {
                    string res = ans.ToString();
                    if (res.Length == a.Length)
                    {
                        int index = a.IndexOf('?');
                        return int.Parse(res[index].ToString());
                    }
                }
            }
            else if (b.Contains('?'))
            {
                int ans = (int.Parse(c)) / int.Parse(a);
                if (ans * int.Parse(a) == int.Parse(c))
                {
                    string res = ans.ToString();
                    if (res.Length == b.Length)
                    {
                        int index = b.IndexOf('?');
                        return int.Parse(res[index].ToString());
                    }
                }
            }
            else
            {
                int ans = int.Parse(a) * int.Parse(b);
                if (int.Parse(a) * int.Parse(b) == ans)
                {
                    string res = ans.ToString();
                    if (res.Length == c.Length)
                    {
                        int index = c.IndexOf('?');
                        return int.Parse(res[index].ToString());
                    }
                }
            }
            return -1;
        }
    }
}
