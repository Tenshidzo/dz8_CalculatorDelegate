using System;

namespace CalculatorApp
{
    class Program
    {
        delegate double Operation(double x, double y);

        static void Main(string[] args)
        {
            Console.WriteLine("Calculator");
            Console.WriteLine("===================");

            while (true)
            {
                Console.WriteLine("Choose operation:");
                Console.WriteLine("1.Sum (+)");
                Console.WriteLine("2.Sub (-)");
                Console.WriteLine("3.Multiplication (*)");
                Console.WriteLine("4. Division (/)");
                Console.WriteLine("5. Exit");

                Console.Write("Enter number of operation: ");
                string choice = Console.ReadLine();

                if (choice == "5")
                    break;

                Operation operation = null;

                switch (choice)
                {
                    case "1":
                        operation = (x, y) => x + y;
                        break;
                    case "2":
                        operation = (x, y) => x - y;
                        break;
                    case "3":
                        operation = (x, y) => x * y;
                        break;
                    case "4":
                        operation = (x, y) =>
                        {
                            if (y == 0)
                            {
                                Console.WriteLine("Error: Division by zero!");
                                return double.NaN;
                            }
                            return x / y;
                        };
                        break;
                    default:
                        Console.WriteLine("Error: Incorrect input!");
                        continue;
                }

                Console.Write("Enter first number: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Error: Incorrect format of number!");
                    continue;
                }

                Console.Write("Enter second number: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Error: Неправильный формат числа!");
                    continue;
                }

                double result = operation(num1, num2);
                Console.WriteLine($"Result: {result}");
            }
        }
    }
}