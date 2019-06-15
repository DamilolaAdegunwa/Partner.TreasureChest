using KnockoutJS.Core;
using KnockoutJS.Core.Categories;
using KnockoutJS.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KnockoutJS.EFCore.Repositories
{
    public class CategoryRepository : KnockoutJSRepositoryBase<Category>, ICategoryRepository
    {
        private readonly ShoppingCartContext _shoppingCartContext;

        public CategoryRepository(ShoppingCartContext shoppingCartContext)
              : base(shoppingCartContext)
        {
            _shoppingCartContext = shoppingCartContext;
        }

        public async Task<List<Category>> Get()
        {
            Console.WriteLine($"CategoryRepository Get-Start ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            var list = await _shoppingCartContext.Categories
                .OrderBy(c => c.Name)
                .AsNoTracking()
                .ToListAsync();
            Console.WriteLine($"CategoryRepository Get-End ThreadId:{Thread.CurrentThread.ManagedThreadId}");

            return list;
        }
    }
}
