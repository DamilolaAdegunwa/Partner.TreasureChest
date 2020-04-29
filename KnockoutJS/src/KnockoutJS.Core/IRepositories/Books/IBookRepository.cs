using KnockoutJS.Core.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Core.IRepositories
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        /// <summary>
        /// 获取置顶书籍
        /// </summary>
        /// <returns></returns>
        Task<List<Book>> GetFeaturedBooks();

        /// <summary>
        /// 依据类别获取书籍
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<List<Book>> GetByCategoryId(int categoryId);

        /// <summary>
        /// 获取单条书籍
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Book> GetById(int id);
    }
}
