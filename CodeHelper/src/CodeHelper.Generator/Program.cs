using System;
using CodeHelper.Generator.SimpleCoders;

namespace CodeHelper.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Simple Generator!");
            var simpleCoder = new SimpleCoder();
            simpleCoder.Builder();
            Console.WriteLine("See You Simple Generator!");

            Console.Read();
        }
    }
}
