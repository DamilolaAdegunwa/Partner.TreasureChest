using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KnockoutJS.Core;
using KnockoutJS.Core.Categories;
using KnockoutJS.Core.IRepositories;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 书籍类别应用服务
    /// </summary>
    public class CategoryAppService : KnockoutJSAppServiceBase, ICategoryAppService
    {
        public readonly ICategoryRepository _categoryRepository;

        public CategoryAppService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> GetAllList()
        {
            var list = await _categoryRepository.Get();
            return list;
        }
    }
}
