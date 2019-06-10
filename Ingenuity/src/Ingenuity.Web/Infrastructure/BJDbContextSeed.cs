using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingenuity.Web.Models;

namespace Ingenuity.Web.Infrastructure
{
    public class BJDbContextSeed
    {
        public static void Initialize(BJDbContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Order.Any())
            {
                var order = new Order()
                {
                    CompanyName = "比亚迪制造中心",
                    Count = 20,
                    ModleNum = "9527",
                    OrderNumber = DateTime.Now.ToLongTimeString(),
                    ProductName = "橡胶轮胎C型",
                    CreateDate = DateTime.Now,
                    Size = "300件",
                    WorkerName = "玲珑",
                };
                context.Add(order);
                context.SaveChanges();
            }
        }
    }
}
