using System;

namespace Homework15_5
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.InputEncoding = System.Text.Encoding.Unicode;
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            char[] signs = new char[] { '+', '-', '*', '/' };
            string user_input = default;
            Calculator calculator = new Calculator();

            try
            {
                Console.WriteLine("Input first number:");
                double.TryParse(Console.ReadLine(), out double a);


                Console.WriteLine("Input second number:");
                double.TryParse(Console.ReadLine(), out double b);

                Console.Write("Select sign ( ");
                foreach (char ch in signs)
                {
                    Console.Write(ch + " ");
                }
                Console.Write(" ) : ");

                user_input = Console.ReadLine();

                var p = Array.IndexOf(signs, Convert.ToChar(user_input));

                if (b == 0 && p == 3)
                {
                    Console.WriteLine("Dividing by zero!");
                }

                if (p != -1)
                {
                    Console.Write("Result = ");
                    if (user_input == "+") { Console.WriteLine(calculator.Add(a, b)); }
                    if (user_input == "-") { Console.WriteLine(calculator.Sub(a, b)); }
                    if (user_input == "*") { Console.WriteLine(calculator.Mul(a, b)); }
                    if (user_input == "/") { Console.WriteLine(calculator.Div(a, b)); }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.ReadKey();
        }


       

    }
}
