using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2.BL
{
    internal class Calculator
    {

        public int Number1;
        public int Number2;

        public Calculator(int number1 = 10, int number2 = 10)
        {
            Number1 = number1;
            Number2 = number2;
        }
        public int Add()
        {
            return Number1 + Number2;
        }
        public int Subtract()
        {
            return Number1 - Number2;
        }
        public int Multiply()
        {
            return Number1 * Number2;
        }
        public float Divide()
        {
            if (Number2 == 0)
            {
                Console.WriteLine("Error! Can't divide by Zero...");
                return 0;
            }
            return Number1 / Number2;
        }
        public float Modulo()
        {
            if (Number2 == 0)
            {
                Console.WriteLine("Error! Can't perfume modulo with Zero...");
                return 0;
            }
            return Number1 % Number2;
        }
           public double Sqrt(int number)
        {
            return Math.Sqrt(number);
        }
        public double Exp(int exponent)
        {
            return Math.Exp(exponent);
        }
        public double Log(int number)  
        {
            return Math.Log(number);
        }

        public double Sin(int angle)
        {
            return Math.Sin(angle * (Math.PI / 180 ));
        }
        public double Cos(int angle)
        {
            return Math.Cos(angle * (Math.PI / 180));
        }
        public double Tan(int angle) 
        {
            return Math.Tan(angle * (Math.PI / 180));
        }

    }
}
