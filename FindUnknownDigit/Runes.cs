using System.Diagnostics;
using System.Linq;

namespace FindUnknownDigit
{
    public class Runes
    {
        private static char[] operations = { '+', '*', '-' };

        private static char ExtractOperation(string expression)
        {
            foreach (char c in operations)
            { 
                if (expression.Contains(c))
                {
                    return c;
                }
            }

            Debug.Assert(false, "No operator found in expression.");
            return '#';
        }

        private static string[] ExtractNumbers(string expression)
        {
            char operation = ExtractOperation(expression);
            string[] parts = expression.Split('=');
            Debug.Assert(parts.Length == 2, "More than one = sign found in expression.");

            string result = parts[1];
            int signIndex = parts[0].LastIndexOf(operation);
            if (parts[0][signIndex - 1] == operation) signIndex--; // correction in case of subration of negative number

            string number1 = parts[0].Substring(0, signIndex);
            string number2 = parts[0].Substring(signIndex + 1);

            return new string[] { number1, number2, result };
        }

        private static bool TrySolution (string expression, int numTry)
        {
            char operation = ExtractOperation(expression);
            string[] parts = ExtractNumbers(expression);

            string strNumTry = "" + numTry;
            int number1 = int.Parse(parts[0].Replace('?', strNumTry[0]));
            int number2 = int.Parse(parts[1].Replace('?', strNumTry[0]));
            int result = int.Parse(parts[2].Replace('?', strNumTry[0]));

            switch(operation)
            {
                case '+':
                    return (number1 + number2 == result);                    
                case '-':
                    return (number1 - number2 == result);
                case '*':
                    return (number1 * number2 == result);
            }

            return false;
        }

        public static int SolveExpression(string expression)
        {
            //Write code to determine the missing digit or unknown rune
            //Expression will always be in the form
            //(number)[opperator](number)=(number)
            //Unknown digit will not be the same as any other digits used in expression

            for (int i = 0; i < 10; ++i)
            {
                if (i == 0 && expression.Contains("??")) continue;
                if (expression.Contains(i.ToString())) continue;

                if (TrySolution(expression, i))
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
