using System;
using System.Collections.Generic;
using System.Text;

namespace Homework15_5
{
    class Calculator
    {

        //Add – додавання, Sub – віднімання, Mul – множення, Div – поділ.


        public double Add(double a, double b)
        {
            return a + b;
        }

        public double Sub(double a, double b)
        {
            return a - b;
        }

        public double Mul(double a, double b)
        {
            return a * b;
        }

        public double Div(double a, double b)
        {
            try
            {
                return a / b;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return (0);
            }

        }

    }
}
