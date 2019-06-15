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
        /// Get方法
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> Get();
    }
}
