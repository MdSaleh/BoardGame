using System;

namespace BoardGame
{
    internal class Program
    {
        public static string _input = "LLLMMMMMMMMMMMMMMM";
        static void Main(string[] args)
        {
            var result = new BoardGame().RunGame(_input);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
