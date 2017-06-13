using System;
using Madlibs;

namespace Madlibs
{
    class Program
    {
        static void Main(string[] args)
        {
            var madlib = new Madlib(
                "my name is {name}. I like to {task}. My favorite food is {food}.",
                new
                {
                    name = new[] { "Khalid", "Nicole" },
                    task = new[] { "code", "dance", "watch television", "sing" },
                    food = new[] { "pizza", "tacos", "steak", "ice cream" }
                }
            );

            var result = madlib.Execute();
            
            Console.WriteLine("### Random Result");
            Console.WriteLine($"    Seed : {result.Seed}\n    Text : {result.Text}");

            var regenerated = madlib.Execute("123");

            Console.WriteLine("### Seeded Result");
            Console.WriteLine($"    Seed : {regenerated.Seed}\n    Text : {regenerated.Text}");
        }
    }
}
