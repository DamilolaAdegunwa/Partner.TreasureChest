using KnockoutJS.Core.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Core.IRepositories
{
    public interface IBookRepository: IRepositoryBase<Book>
    {
        /// <summary>
        /// 特色书籍
        /// </summary>
        /// <returns></returns>
        Task<List<Book>> GetFeaturedBooks();

        Task<List<Book>> GetByCategoryId(int categoryId);

        Task<Book> GetById(int id);
    }
}
