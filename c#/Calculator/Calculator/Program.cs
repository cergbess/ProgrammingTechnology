using System;
using System.Collections.Generic;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите выражение = ");
                Console.WriteLine("Результат = " + Calculate(Console.ReadLine()));
            }
        }
        static private bool DesignateDelimiters(char symbol)
        {
            switch (symbol)
            {
                case ' ':
                    return true;
                default:
                    return false;
            }
        }
        static private bool DesignateOperators(char symbol)
        {
            switch (symbol)
            {
                case '(':
                case ')':
                case '+':
                case '-':
                case '*':
                case '/':
                    return true;
                default:
                    return false;
            }
        }
        static private byte DesignateThePriorityOfOperators(char string1)
        {
            switch (string1)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 2;
                case '*': return 3;
                case '/': return 3;
                default: return 4;
            }
        }
        static private double Calculate(string input)
        {
            string output = TranslateIntoPolishNotation(input);
            Console.WriteLine("Польская нотация = " + TranslateIntoPolishNotation(input));
            double result = Counting(output);
            return result;
        }
        static private string TranslateIntoPolishNotation(string input)
        {
            string output = string.Empty;
            Stack<char> operStack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {

                if (DesignateDelimiters(input[i]))
                    continue;

                if (Char.IsDigit(input[i]))
                {

                    while (!DesignateDelimiters(input[i]) && !DesignateOperators(input[i]))
                    {
                        output += input[i];
                        i++;

                        if (i == input.Length) break;
                    }

                    output += " ";
                    i--;
                }

                if (DesignateOperators(input[i]))
                {
                    if (input[i] == '(')
                        operStack.Push(input[i]);
                    else if (input[i] == ')')
                    {
                        char string1 = operStack.Pop();

                        while (string1 != '(')
                        {
                            output += string1.ToString() + ' ';
                            string1 = operStack.Pop();
                        }
                    }
                    else
                    {
                        if (operStack.Count > 0)
                            if (DesignateThePriorityOfOperators(input[i]) <= DesignateThePriorityOfOperators(operStack.Peek()))
                                output += operStack.Pop().ToString() + " ";

                        operStack.Push(char.Parse(input[i].ToString()));
                    }
                }
            }


            while (operStack.Count > 0)
                output += operStack.Pop() + " ";

            return output;
        }
        static private double Counting(string input)
        {
            double result = 0;
            Stack<double> temp = new Stack<double>();

            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    string a = string.Empty;

                    while (!DesignateDelimiters(input[i]) && !DesignateOperators(input[i]))
                    {
                        a += input[i];
                        i++;
                        if (i == input.Length) break;
                    }
                    temp.Push(double.Parse(a));
                    i--;
                }
                else if (DesignateOperators(input[i]))
                {
                    double a = temp.Pop();
                    double b = temp.Pop();

                    switch (input[i])
                    {
                        case '+': result = b + a; break;
                        case '-': result = b - a; break;
                        case '*': result = b * a; break;
                        case '/': result = b / a; break;
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();

        }
    }
}