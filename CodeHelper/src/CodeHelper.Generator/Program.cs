using System;
using CodeHelper.Models;
using RazorEngine;
using RazorEngine.Templating;

namespace CodeHelper.Generator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var simpleCoder = new SimpleCoder();
            //simpleCoder.Builder();

            string template = "Hello @Model.Name, welcome to RazorEngine!";
            var result = Engine.Razor.RunCompile(template, "templateKey", null, new { Name = "World" });
            Console.WriteLine(result);
            
            Console.Read();
        }
    }
}
