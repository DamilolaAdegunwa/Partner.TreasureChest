using KnockoutJS.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace koInstance.EFCore
{
    public static class KnockoutJSDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<ShoppingCartContext> builder, string connectionString)
        {
            builder.UseMySql(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<ShoppingCartContext> builder, DbConnection connection)
        {
            builder.UseMySql(connection);
        }
    }
}
