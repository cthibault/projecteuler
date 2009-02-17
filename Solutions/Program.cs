using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Solutions
{
    static class Program
    {
        private static bool _exit = false;

        static void Main(string[] args)
        {
            _mainMenu("Welcome!");
        }

        private static void _mainMenu(string mes)
        {
            string message = mes;
            while (!_exit)
            {
                Console.Clear();

                if (!string.IsNullOrEmpty(message))
                    Console.WriteLine(message);

                Console.WriteLine("What question would you like to run?");
                string selection = Console.ReadLine();
                Console.WriteLine();

                message = _switchBoard(selection);
            }
        }
        private static string _switchBoard(string selection)
        {
            bool isKeyword = true;
            switch (selection.ToUpper())
            {
                case "?":
                    break;
                case "LIST":
                case "L":
                    break;
                case "":
                case "EXIT":
                case "E":
                    _exit = true;
                    break;
                case "TEST":
                case "T":
                    Tests.GetHashCodes_Test();
                    break;
                default:
                    isKeyword = false;
                    break;
            }

            if (!isKeyword)
            {
                try
                {
                    int question = Convert.ToInt32(selection);
                    return _runQuestion(question);
                }
                catch (FormatException ex)
                {
                    //_mainMenu(string.Format("[{0}] is an invalid selection.", selection));'
                    return string.Format("[{0}] is an invalid selection.", selection);
                }
            }
            return string.Empty;
        }
        private static string _runQuestion(int question)
        {
            string message = string.Empty;
            switch (question)
            {
                case 1:
                    Solution.Problem1();
                    break;
                case 2:
                    Solution.Problem2();
                    break;
                case 3:
                    Solution.Problem3();
                    break;
                case 4:
                    Solution.Problem4();
                    break;
                case 5:
                    Solution.Problem5();
                    break;
                case 6:
                    Solution.Problem6();
                    break;
                case 7:
                    Solution.Problem7();
                    break;
                case 8:
                    Solution.Problem8();
                    break;
                case 9:
                    Solution.Problem9();
                    break;
                case 10:
                    Solution.Problem10();
                    break;
                case 11:
                    Solution.Problem11();
                    break;
                case 12:
                    Solution.Problem12();
                    break;
                case 13:
                    Solution.Problem13();
                    break;
                case 14:
                    Solution.Problem14();
                    break;
                case 15:
                    Solution.Problem15();
                    break;
                case 16:
                    Solution.Problem16();
                    break;

                default:
                    //_mainMenu(string.Format("I'm sorry, but question {0} hasn't been answered yet.", question.ToString()));
                    message = string.Format("I'm sorry, but question {0} hasn't been answered yet.", question.ToString());
                    break;
            }
            return message;
        }
    }
}
