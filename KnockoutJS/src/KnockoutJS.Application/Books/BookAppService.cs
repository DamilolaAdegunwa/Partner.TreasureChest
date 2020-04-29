using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using KnockoutJS.Core;
using KnockoutJS.Core.Books;
using KnockoutJS.Core.IRepositories;

namespace KnockoutJS.Application
{
    /// <summary>
    /// 书籍应用服务
    /// </summary>
    public class BookAppService : KnockoutJSAppServiceBase, IBookAppService
    {
        public readonly IBookRepository _bookRepository;

        public BookAppService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<List<Book>> GetByCategoryId(int categoryId)
        {
            return await _bookRepository.GetByCategoryId(categoryId);
        }

        public async Task<Book> GetById(int id)
        {
            return await _bookRepository.GetById(id);
        }

        public async Task<List<Book>> GetFeaturedBooks()
        {
            return await _bookRepository.GetFeaturedBooks();
        }
    }
}
