using KnockoutJS.Core;
using KnockoutJS.Core.Books;
using KnockoutJS.Core.IRepositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KnockoutJS.EFCore.Repositories
{
    public class BookRepository : KnockoutJSRepositoryBase<Book>, IBookRepository
    {
        private readonly ShoppingCartContext _shoppingCartContext;

        public BookRepository(ShoppingCartContext shoppingCartContext)
            : base(shoppingCartContext)
        {
            _shoppingCartContext = shoppingCartContext;
        }

        public async Task<List<Book>> GetByCategoryId(int categoryId)
        {
            return await _shoppingCartContext.Books
                .Include(b => b.Author)
                .Where(b => b.CategoryId == categoryId)
                .OrderByDescending(b => b.Featured)
                .ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            var book = await _shoppingCartContext.Books
                .Include(b => b.Author)
                .Where(b => b.Id == id)
                .FirstOrDefaultAsync();

            if (book == null)
            {
                throw new Exception($"没有找到编号为{id}的书籍");
            }

            return book;
        }

        public async Task<List<Book>> GetFeaturedBooks()
        {
            return await _shoppingCartContext.Books
                .Include(b => b.Author)
                .AsNoTracking()
                .Where(b => b.Featured)
                .ToListAsync();
        }
    }
}
