using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

double memory = 0;
double val = 0;
bool firstInput = true;
char[] TwoNumOperators = { '+', '-', '/', '*', '%', '^' };
string[] OneNumOperators = { "M+", "M-", "MR", "√" };

Console.WriteLine("Проект 'калькулятор' на C#");
Console.WriteLine("Для выхода введите exit \nДля использования калькулятора введите 1 число");
Console.WriteLine("Список операций: + - / * √ % ^ M+ M- MR");
while (true)
{
    string input = Console.ReadLine().Trim();

    if (input == "exit")
    {
        break;
    }

    if (firstInput)
    {
        val = Convert.ToDouble(input);
        firstInput = false;
        Console.WriteLine("Введите операцию");
    }
    else
    {
        if (input.Length > 0 && TwoNumOperators.Contains(input[0]))
        {
            char operation = input[0];
            Console.WriteLine("Введите второе число");
            double secondNumber = Convert.ToDouble(Console.ReadLine());

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
        else if (OneNumOperators.Contains(input))
        {
            switch (input)
            {
                case "M+":
                    memory += val;
                    break;
                case "M-":
                    memory -= val;
                    break;
                case "MR":
                    Console.WriteLine("Память: " + memory);
                    break;
                case "√":
                    val = Math.Sqrt(val);
                    Console.WriteLine("Результат: " + val);
                    break;
            }
            firstInput = true;
        }
        else
        {
            Console.WriteLine("Введена не поддерживаемая операция, введите другую");
        }
    }
}