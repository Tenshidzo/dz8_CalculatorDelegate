using System;

namespace CalculatorApp
{
    class Program
    {
        delegate double Operation(double x, double y);

        static void Main(string[] args)
        {
            Console.WriteLine("Простой калькулятор");
            Console.WriteLine("===================");

            while (true)
            {
                Console.WriteLine("Выберите операцию:");
                Console.WriteLine("1. Сложение (+)");
                Console.WriteLine("2. Вычитание (-)");
                Console.WriteLine("3. Умножение (*)");
                Console.WriteLine("4. Деление (/)");
                Console.WriteLine("5. Выход");

                Console.Write("Введите номер операции: ");
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
                                Console.WriteLine("Ошибка: Деление на ноль!");
                                return double.NaN;
                            }
                            return x / y;
                        };
                        break;
                    default:
                        Console.WriteLine("Ошибка: Неправильный ввод!");
                        continue;
                }

                Console.Write("Введите первое число: ");
                if (!double.TryParse(Console.ReadLine(), out double num1))
                {
                    Console.WriteLine("Ошибка: Неправильный формат числа!");
                    continue;
                }

                Console.Write("Введите второе число: ");
                if (!double.TryParse(Console.ReadLine(), out double num2))
                {
                    Console.WriteLine("Ошибка: Неправильный формат числа!");
                    continue;
                }

                double result = operation(num1, num2);
                Console.WriteLine($"Результат: {result}");
            }
        }
    }
}