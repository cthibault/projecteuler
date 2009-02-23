using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProjectEuler.Solutions
{
    static class Program
    {
        static EulerProblems _problems = new EulerProblems();
        private static bool _exit = false;

        static void Main(string[] args)
        {
            MenuLoop();
        }

        static void MenuLoop()
        {
            while (!_exit)
            {
                Console.WriteLine("What question would you like to run?");
                string selection = Console.ReadLine();
                Console.WriteLine();

                switch (selection.ToUpper())
                {
                    case "EXIT":
                    case "E":
                    case "QUIT":
                    case "Q":
                    case "":
                        return;

                    case "HELP":
                    case "H":
                    case "?":
                        Help();
                        break;

                    case "LIST":
                    case "L":
                        List();
                        break;

                    case "TEST":
                    case "T":
                        Solution.Problem13();
                        break;

                    default:
                        RunProblem(selection);
                        break;
                }

                Console.ReadLine();
                Console.Clear();
            }
        }

        static void Help()
        {
            Console.WriteLine("The HELP feature is not available yet");
        }

        static void List()
        {
            Console.WriteLine("The LIST feature is not available yet");
        }

        static void RunProblem(string selection)
        {
            int questionId;
            if (!Int32.TryParse(selection, out questionId))
            {
                Console.WriteLine("[{0}] is an invalid selection", selection);
                return;
            }

            _problems.RunProblem(questionId);
        }

    }
}
