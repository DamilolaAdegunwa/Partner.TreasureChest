using KnockoutJS.Core.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Core.IRepositories
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        /// <summary>
        /// 获取书籍类别列表
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> Get();
    }
}
