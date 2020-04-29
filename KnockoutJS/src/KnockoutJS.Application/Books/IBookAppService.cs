using KnockoutJS.Core;
using KnockoutJS.Core.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 书籍应用服务接口
    /// </summary>
    public interface IBookAppService : IAppServiceBase
    {
        /// <summary>
        /// 获取置顶书籍列表
        /// </summary>
        /// <returns></returns>
        Task<List<Book>> GetFeaturedBooks();

        /// <summary>
        /// 获取指定类别下的书籍列表
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<List<Book>> GetByCategoryId(int categoryId);

        /// <summary>
        /// 获取单个书籍详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetById(int id);
    }
}
