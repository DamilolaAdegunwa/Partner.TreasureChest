using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KnockoutJS.Core;
using KnockoutJS.Core.Categories;
using KnockoutJS.Core.IRepositories;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 书籍目录
    /// </summary>
    public class CategoryAppService : KnockoutJSAppServiceBase, ICategoryAppService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> Get()
        {
            Console.WriteLine($"CategoryAppService Get-Start ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            var list = await _categoryRepository.Get();
            Console.WriteLine($"CategoryAppService Get-End ThreadId:{Thread.CurrentThread.ManagedThreadId}");
            return list;
        }
    }
}
