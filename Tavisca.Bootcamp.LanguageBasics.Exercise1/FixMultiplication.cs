namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    class FixMultiplication
    {
        public static int FindDigit(string equation)
        {
            //Equation : A * B = C

            string strValueOfA = equation.Substring(0, equation.IndexOf('*'));
            string strValueOfB = equation.Substring(equation.IndexOf('*') + 1, equation.IndexOf('=') - equation.IndexOf('*') - 1);
            string strValueOfC = equation.Substring(equation.IndexOf('=') + 1);

            int intValueOfA,intValueOfB, intValueOfC;

            if (strValueOfA.Contains('?'))
            {
                if(int.TryParse(strValueOfB,out intValueOfB) &&int.TryParse(strValueOfC,out intValueOfC))
                {
                    int result = intValueOfC / intValueOfB;
                    if (result * intValueOfB == intValueOfC)
                        return Digit(strValueOfA, result);
                }
            }
            else if (strValueOfB.Contains('?'))
            {

                if (int.TryParse(strValueOfA, out intValueOfA) && int.TryParse(strValueOfC, out intValueOfC))
                {
                    int result = intValueOfC / intValueOfA;
                    if (result * intValueOfA == intValueOfC)
                        return Digit(strValueOfB, result);
                }
            }
            else
            {
                if (int.TryParse(strValueOfA, out intValueOfA) && int.TryParse(strValueOfB, out intValueOfB))
                {
                    int result = intValueOfA * intValueOfB;
                    return Digit(strValueOfC, result);
                }
            }
            return -1;
        }
        public static int Digit(string strValue, int result)
        {
            string strResult = result.ToString();
            if (strResult.Length == strValue.Length)
            {
                int index = strValue.IndexOf('?');
                return int.Parse(strResult[index].ToString());
            }
            return -1;
        }
    }
}
