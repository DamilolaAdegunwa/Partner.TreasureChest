using FastConnect.Tool.Models;
using Microsoft.Extensions.Configuration;
using System;

namespace FastConnect.Tool
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var dbContext = new FastConnectDbContext())
            {
                dbContext.Companys.Add(new Company
                {
                    Name = "星城科技",
                    Address = "湖南长沙雨花区"
                });

                dbContext.SaveChanges();

                Console.WriteLine("All Company in database:");
                foreach (var company in dbContext.Companys)
                {
                    Console.WriteLine("{0}-{1}", company.Name, company.Address);
                }
                Console.ReadKey();
            }
        }
    }
}
