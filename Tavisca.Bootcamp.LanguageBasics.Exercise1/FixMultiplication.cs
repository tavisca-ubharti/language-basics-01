namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public static class FixMultiplication
    {
        public static int FindDigit(string equation)
        {
            //Equation : A * B = C

            string strValueOfA = equation.Substring(0, equation.IndexOf('*'));
            string strValueOfB = equation.Substring(equation.IndexOf('*') + 1, equation.IndexOf('=') - equation.IndexOf('*') - 1);
            string strValueOfC = equation.Substring(equation.IndexOf('=') + 1);


            if (strValueOfA.Contains('?'))
            {
                return GetDigit(strValueOfB, strValueOfC, '/', strValueOfA);
            }
            else if (strValueOfB.Contains('?'))
            {

                return GetDigit(strValueOfA, strValueOfC, '/', strValueOfB);
            }
            else
            {
                return GetDigit(strValueOfA, strValueOfB, '*', strValueOfC);
            }
        }
        public static int GetDigit(string operand1,string operand2,char op,string strValue)
        {
            int intOperand1, intOperand2;
            if (int.TryParse(operand1, out intOperand1) && int.TryParse(operand2, out intOperand2))
            {
                if(op =='/')
                {
                    int result = intOperand2 / intOperand1;
                    if (result * intOperand1 == intOperand2)
                        return ExtractDigit(result, strValue);
                }
                else
                {
                    int result = intOperand2 * intOperand1;
                    return ExtractDigit(result, strValue);
                }
            }
            return -1;
        }
        public static int ExtractDigit(int result,string strValue)
        {
            string strResult = result.ToString();
            if (strResult.Length == strValue.Length)
            {
                int index = strValue.IndexOf('?');
                return strResult[index] - '0';
            }
            return -1;
        }
    }
}
