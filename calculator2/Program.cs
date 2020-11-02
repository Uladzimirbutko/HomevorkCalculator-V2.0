using System;
using System.Collections.Generic;

namespace calculator2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to my calculator!");
            Start(); // погнали.
        }

        static void Start() // метод для ввода первого числа.
        {
            Console.WriteLine("Enter the first number:");
            double firstNumber;
            string input =  Console.ReadLine();
            if (double.TryParse(input, out firstNumber) & (firstNumber < Double.MaxValue) & (firstNumber > Double.MinValue)) // проверяем на возможность приведения строки к double, макс и мин значения.
            {
                Oper(ref firstNumber); //отлично! первое число уходит в метод выбора операции.
            }
            else
            {
                Console.WriteLine("The first number was entered incorrect. Try again."); // тут всё понятно.
                Start();
            }
            
        }

        static void Oper(ref double total) //здесь уже первое число и оно будет отправленно в конструкцию в зависимости от операции
        {
            Console.WriteLine("Enter arithmetic operation: \n+ - addition \n- - subtraction \n* - multiplication \n/ - division \n^ - exponentiation \n!n - factorial (min 0, max 170)");
            string operazion = Console.ReadLine(); //пришла операция
            switch (operazion)
            {
                case "+": 
                {
                    Add(ref total); // первое число уходит в метод сложения и тд. со всеми операциями
                    break;
                }
                case "-":
                {
                    Subtraction(ref total);
                    break;
                }
                case "*":
                {
                    Multiplication(ref total);
                    break;
                }
                case "/":
                {
                    Division(ref total);
                    break;
                }
                case "^":
                {
                    Exponentiation(ref total);
                    break;
                }
                case "!n":
                {
                    Fac(ref total);
                    break;
                }
                default:
                {
                    Console.WriteLine("Unknown arithmetic operation. Try again.");
                    Oper(ref total);
                    break;
                }
            }

            Console.WriteLine("Want to start again?\nYes - Press \"Y\"\nNo - Press \"Enter\"");
            string again = Console.ReadLine();
            if (again == "Y")
            {
                Start();
            }

        }

        static void Add(ref double firstNumber) //тут сложение и тут первое число
        {
            double secondNumber;
            Console.WriteLine("Enter the second number:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out secondNumber) & (secondNumber < Double.MaxValue) & (secondNumber > Double.MinValue)) //проверочка на корректность ввода как и с первым числом
            {
                double total;
                total = firstNumber + secondNumber;
                Proverka(ref total); // результат нужно тоже проверить на макс и мин. идем в метод проверки.
                Console.WriteLine($"Addition {firstNumber}  and  {secondNumber}  equally  {total}."); // проверка прошла - результат тут.
            }
            else
            {
                Console.WriteLine("The second number was entered incorrect. Try again.");
                Add(ref firstNumber);
            }


        }

        static void Subtraction(ref double firstNumber) //тут короче всё тоже самое.
        {
            double secondNumber;
            Console.WriteLine("Enter the second number: ");
            string input = Console.ReadLine();
            if (double.TryParse(input, out secondNumber) & (secondNumber < Double.MaxValue) & (secondNumber > Double.MinValue))
            {
                double total;
                total = firstNumber - secondNumber;
                Proverka(ref total); // тоже нужно проверить. мало ли чё.
                Console.WriteLine($"Subtraction {firstNumber}  and  {secondNumber}  equally  {total}.");
            }
            else
            {
                Console.WriteLine("The second number was entered incorrect. Try again.");
                Subtraction(ref firstNumber);
            }
        }

        static void Multiplication(ref double firstNumber)//тоже самое
        {
            double secondNumber;
            Console.WriteLine("Enter the second number:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out secondNumber) & (secondNumber < Double.MaxValue) & (secondNumber > Double.MinValue))
            {
                double total;
                total = firstNumber * secondNumber;
                Proverka(ref total);
                Console.WriteLine($"Multiplication {firstNumber} and {secondNumber} equally {total}.");
            }
            else
            {
                Console.WriteLine("The second number was entered incorrect. Try again.");
                Multiplication(ref firstNumber);
            }
        }
        static void Division(ref double firstNumber)
        {
            double secondNumber;
            Console.WriteLine("Enter the second number:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out secondNumber) & (secondNumber < Double.MaxValue) & (secondNumber > Double.MinValue)) // перебор со вложенностью, но что ж поделать. Главное, что работает)
            {
                if (secondNumber == 0)
                {
                  Console.WriteLine("Division by zero is prohibited.");
                  Division(ref firstNumber);
                }
                else
                {
                    double total;
                    total = firstNumber / secondNumber;
                    Proverka(ref total);
                    Console.WriteLine($"Division {firstNumber} and {secondNumber} equally {total}.");
                }
                
            }
            else 
            {
                Console.WriteLine("The second number was entered incorrect. Try again.");
                Division(ref firstNumber);
            }
        }

        static void Exponentiation(ref double firstNumber) // норм. дроби тоже считает
        {
            double secondNumber;
            Console.WriteLine("Enter exponentiation:");
            string input = Console.ReadLine();
            if (double.TryParse(input, out secondNumber) & (secondNumber < Double.MaxValue) & (secondNumber > Double.MinValue))
            {
                double total;
                total = Math.Pow(firstNumber, secondNumber);
                Proverka(ref total);
                Console.WriteLine($"Exponentiation {firstNumber} to {secondNumber} equally {total}.");
            }
            else
            {
                Console.WriteLine("The number or exponentiation was entered incorrect. Try again.");
                Exponentiation(ref firstNumber);
            }
        }
        

        static void Proverka(ref double total) // проверка на макс и мин значения результата
        {
            
            if ((total > Double.MaxValue) & (total < Double.MinValue))
            {
                Console.WriteLine("The calculation result exceeds the allowed value. Try again.");
                Start();
            }
        }
        static double Factorial(double x) //сам факториал
        {
            if (x == 0)
            {
                return 1;
            }
            else
            {
                return x * Factorial(x - 1);
            }
            
        }

        static void Fac(ref double total) // метод, в котором выводится результат факториала и корректноть ввода для его вычисления
        {
            if ((total < 170) & (total > 0) & (total % 1 == 0))
            {
                Console.WriteLine($"Factorial {total} equally {Factorial(total)}.");
                
            }
            else
            {
                Console.WriteLine("The number for the factorial is incorrect. Try again.");
                Start();
            }
        }

    }
}
