using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ingenuity.Web.Models;

namespace Ingenuity.Web.Infrastructure
{
    /// <summary>
    /// 数据库上下文
    /// </summary>
    public class BJDbContext : DbContext
    {
        public BJDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<EquipInfo> EquipInfo { get; set; }
        public virtual DbSet<InventoryInfo> InventoryInfo { get; set; }
        public virtual DbSet<MaterialInfo> MaterialInfo { get; set; }
        public virtual DbSet<ProcessInfo> ProcessInfo { get; set; }
        public virtual DbSet<Ship> Ship { get; set; }
        public virtual DbSet<Warehouse> Warehouse { get; set; }
        public virtual DbSet<WorkingProductInfo> WorkingProductInfo { get; set; }
        public virtual DbSet<PartProcess> PartProcess { get; set; }
        public virtual DbSet<BadPart> BadPart { get; set; }

    }
}
