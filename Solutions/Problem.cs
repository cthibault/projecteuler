using System;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ProjectEuler.Solutions
{
    public class Problem : Collection<Approach>
    {
        public int ID { get; set; }
        public string Description { get; set; }

        public Problem() { }
        public Problem(int id, string description)
        {
            ID = id;
            Description = description;
        }

        public void Run(Stopwatch watch)
        {
            Console.WriteLine("Problem {0}", ID);
            Console.WriteLine(Description);
            Console.WriteLine();

            if (Count == 0)
                Console.WriteLine("No solution approach available");

            foreach (Approach approach in this)
                approach.Run(watch);
        }
    }
}
