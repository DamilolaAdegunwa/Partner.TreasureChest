using System;

namespace RedisOperate.BackgroundService
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceProcessor.Run();
            Console.Read();
        }
    }
}
