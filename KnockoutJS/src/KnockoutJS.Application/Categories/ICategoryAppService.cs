using KnockoutJS.Core;
using KnockoutJS.Core.Categories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 书籍类别应用服务
    /// </summary>
    public interface ICategoryAppService : IAppServiceBase
    {
        /// <summary>
        /// 获取书籍类别列表
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAllList();
    }
}
