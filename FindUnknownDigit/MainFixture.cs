using System;
using FindUnknownDigit;

namespace FindUnknownDigit
{
    class MainFixture
    {
        private static string GenerateRandomExpression()
        {
            Random rand = new Random();
            int number1 = rand.Next(0, 99);
            int number2 = rand.Next(0, 99);
            int operation = rand.Next(0, 2);

            int result = 0;
            string operand = "#";
            switch(operation)
            {
                case 0: // addition
                    operand = "+";
                    result = number1 + number2;
                    break;
                case 1: // subraction
                    operand = "-";
                    result = number1 - number2;
                    break;
                case 2: // multiplication
                    operand = "*";
                    result = number1 * number2;
                    break;
            }

            string expression = number1 + operand + number2 + "=" + result;

            bool replaced = false;
            int i = rand.Next(0, 9);
            while (!replaced)
            {
                string curNum = i.ToString();
                if (expression.Contains(curNum))
                {
                    expression = expression.Replace(curNum[0], '?');
                    replaced = true;
                }
                i = (i + 1) % 10;
            }

            return expression;
        }

        static void Main(string[] args)
        {
            string expression = (args.Length > 1) ? args[1] : GenerateRandomExpression();
            int missingDigit = Runes.SolveExpression(expression);

            Console.WriteLine("Answer for expression '" + expression + "' is " + missingDigit + ".");
            Console.ReadLine();
        }
    }
}
