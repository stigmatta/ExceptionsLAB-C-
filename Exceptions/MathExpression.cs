using System;
using System.Text.RegularExpressions;

namespace ExpressionClass
{
    public class Expression
    {
        private string expression;

        public Expression(string expression)
        {
            this.expression = expression.Replace(" ", "");
        }
        public double Evaluate()
        {
            try
            {
                if (Regex.IsMatch(expression, @"[^0-9*]+") || Regex.IsMatch(expression, @"\*\*") || !Regex.IsMatch(expression, @"^(?=\d)"))
                {
                    throw new ArgumentException("Выражение в неправильном формате.");
                }

                char[] strArr = expression.ToCharArray();
                string[] splittedArr = new string[strArr.Length];
                int tmp = 0;

                for (int i = 0; i < strArr.Length;)
                {
                    if (strArr[i] == '*')
                        splittedArr[tmp++] = strArr[i++].ToString();

                    string currentNumber = string.Empty;

                    while (i < strArr.Length && Char.IsDigit(strArr[i]))
                        currentNumber += strArr[i++];

                    if (!string.IsNullOrEmpty(currentNumber))
                        splittedArr[tmp++] = currentNumber;
                }

                Array.Resize(ref splittedArr, tmp);

                double result = 1;
                double num = 0;

                foreach (string part in splittedArr)
                {
                    if (double.TryParse(part, out num))
                        result *= num;
                }

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return 0;
            }
        }


    }


}
