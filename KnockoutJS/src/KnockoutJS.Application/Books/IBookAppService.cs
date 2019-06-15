using KnockoutJS.Core;
using KnockoutJS.Core.Books;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace KnockoutJS.Application
{
    public interface IBookAppService: IAppServiceBase
    {
        Task<List<Book>> GetFeaturedBooks();

        Task<List<Book>> GetByCategoryId(int categoryId);

        Task<Book> GetById(int id);
    }
}
