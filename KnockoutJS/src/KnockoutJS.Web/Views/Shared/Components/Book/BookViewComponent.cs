using AutoMapper;
using KnockoutJS.Application;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KnockoutJS.Web.Views.Shared.Components.Book
{
    public class BookViewComponent : ViewComponent
    {
        private readonly IBookAppService _bookAppService;
        private readonly IMapper _mapper;

        public BookViewComponent(IBookAppService bookAppService, IMapper mapper)
        {
            _bookAppService = bookAppService;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var bookList = await _bookAppService.GetFeaturedBooks();
            var booksViewModel = _mapper.Map<List<BookViewModel>>(bookList);
            return View(booksViewModel);
        }
    }
}
