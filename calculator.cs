using System;
using System.Collections.Generic;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double val = 0;
            double memory = 0;
            bool firstInput = true;
            string input;
            char[] TwoNumOperators = { '+', '-', '*', '/', '%', '^' };
            List<string> OneNumOperators = new List<string> { "M+", "M-", "MR", "√" };
            Console.WriteLine("Калькулятор запущен. Для выхода введите 'exit'");

            while (true)
            {
                if (firstInput)
                {
                    Console.WriteLine("Введите число:");
                }
                else
                {
                    Console.WriteLine("Введите операцию или число:");
                }

                input = Console.ReadLine().Trim();

                if (input.ToLower() == "exit")
                    break;
                if (string.IsNullOrEmpty(input))
                    continue;
                if (input == "MR")
                {
                    Console.WriteLine("Память: " + memory);
                    continue;
                }

                if (firstInput)
                {
                    if (double.TryParse(input, out double number))
                    {
                        val = number;
                        firstInput = false;
                        Console.WriteLine("Введите операцию");
                    }
                    else
                    {
                        Console.WriteLine("Ошибка: введите корректное число!");
                    }
                }
                else
                {
                    if (input.Length > 0 && Array.Exists(TwoNumOperators, op => op == input[0]))
                    {
                        char operation = input[0];
                        Console.WriteLine("Введите второе число:");
                        string secondInput = Console.ReadLine();

                        if (double.TryParse(secondInput, out double secondNumber))
                        {
                            switch (operation)
                            {
                                case '+':
                                    val += secondNumber;
                                    break;
                                case '-':
                                    val -= secondNumber;
                                    break;
                                case '*':
                                    val *= secondNumber;
                                    break;
                                case '/':
                                    if (secondNumber != 0)
                                        val /= secondNumber;
                                    else
                                        Console.WriteLine("Ошибка: деление на ноль!");
                                    break;
                                case '%':
                                    val %= secondNumber;
                                    break;
                                case '^':
                                    val = Math.Pow(val, secondNumber);
                                    break;
                            }
                            Console.WriteLine("Результат: " + val);
                            firstInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Ошибка: введите корректное число!");
                        }
                    }
                    else if (OneNumOperators.Contains(input))
                    {
                        switch (input)
                        {
                            case "M+":
                                memory += val;
                                Console.WriteLine("Значение добавлено в память");
                                break;
                            case "M-":
                                memory -= val;
                                Console.WriteLine("Значение вычтено из памяти");
                                break;
                            case "√":
                                if (val >= 0)
                                {
                                    val = Math.Sqrt(val);
                                    Console.WriteLine("Результат: " + val);
                                }
                                else
                                {
                                    Console.WriteLine("Ошибка: нельзя извлечь корень из отрицательного числа!");
                                }
                                break;
                        }
                        firstInput = true;
                    }
                    else if (double.TryParse(input, out double newNumber))
                    {
                        val = newNumber;
                        Console.WriteLine("Введите операцию");
                    }
                    else
                    {
                        Console.WriteLine("Введена не поддерживаемая операция, введите другую");
                    }
                }
            }

            Console.WriteLine("Калькулятор завершил работу.");
        }
    }
}