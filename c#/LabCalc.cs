using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите выражение: ");
            }
        }
    }
    class LabRab
    {
        static public bool SearchForOperators(char string)
        {
            if ("+-/*()=".IndexOf(string) != -1)
                return true;
            return false;
        }
        static public byte NameOperations(char string)
        {
            switch (string)
            {
                case '(': return 0;
                case ')': return 1;
                case '+': return 2;
                case '-': return 3;
                case '*': return 4;
                case '/': return 5;
                case '=': return 6;
                default: return 7;
            }
        }
    }
}
