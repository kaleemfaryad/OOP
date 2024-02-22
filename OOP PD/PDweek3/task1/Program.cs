using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task1.BL;

namespace task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = null;
            int option = 0;

            while (option != 8)
            { 
                Console.WriteLine("\n\n Menu: ");
                Console.WriteLine("1. Create the a single object of Calculator ");
                Console.WriteLine("2. Change values of Attributes ");
                Console.WriteLine("3. Add ");
                Console.WriteLine("4. Subtract ");
                Console.WriteLine("5. Multiply ");
                Console.WriteLine("6. Divide ");
                Console.WriteLine("7. Modulo ");
                Console.WriteLine("8. Exit ");

                Console.WriteLine("Choose an Option...");
                option = int.Parse(Console.ReadLine());

                if (option == 1) 
                {
                    if (calculator == null)
                    {
                        Console.WriteLine("Calculator Object Created.");
                        calculator = new Calculator();
                    }
                    else
                    {
                        Console.WriteLine("Calculator Object already exists.");
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 2) 
                {
                    if (calculator == null) 
                    {
                        Console.WriteLine("Create a Calculator Object First.");
                    }
                    else
                    {
                        Console.WriteLine("Enter value for num1: ");
                        calculator.Number1 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter value for num2: ");
                        calculator.Number2 = int.Parse(Console.ReadLine());
                        Console.WriteLine("Attributes updated! ");
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 3 )
                {
                    if (calculator == null)
                    {
                        Console.WriteLine("Create a Calculator Object First.");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + calculator.Add());
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 4 )
                {
                    if (calculator == null)
                    {
                        Console.WriteLine("Create a Calculator Object First.");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + calculator.Subtract());
                    }

                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 5 ) 
                {
                    if (calculator == null)
                    {
                        Console.WriteLine("Create a Calculator Object First.");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + calculator.Multiply());
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 6 ) 
                {
                    if (calculator == null)
                    {
                        Console.WriteLine("Create a Calculator Object First.");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + calculator.Divide());
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 7 ) 
                {
                    if (calculator == null)
                    {
                        Console.WriteLine("Create a Calculator Object First.");
                    }
                    else
                    {
                        Console.WriteLine("Result: " + calculator.Modulo());
                    }
                    Console.ReadLine();
                    Console.Clear();
                }
                if (option == 8 )
                {
                    Console.WriteLine("Exiting...");
                    break;
                } 
                if (option > 8 )
                {
                    Console.WriteLine("Invalid Option! Please choose a option between 1 & 8 ...");
                    Console.ReadLine();
                    Console.Clear();
                } 
            }
        }
    }
}