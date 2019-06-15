using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KnockoutJS.Application;
using KnockoutJS.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace KnockoutJS.Web.Controllers
{
    /// <summary>
    /// 书籍
    /// </summary>
    public class BookController : Controller
    {
        private readonly IBookAppService _bookAppService;
        private readonly IMapper _mapper;

        public BookController(IBookAppService bookAppService, IMapper mapper)
        {
            _bookAppService = bookAppService;
            _mapper = mapper;
        }

        /// <summary>
        /// 根据分类Id获取图书
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Index(int categoryId)
        {
            var bookList = await _bookAppService.GetByCategoryId(categoryId);
            ViewBag.SelectedCategoryId = categoryId;
            var booksViewModel = _mapper.Map<List<BookViewModel>>(bookList);
            return View(booksViewModel);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _bookAppService.GetById(id);
            var bookViewModel = _mapper.Map<BookViewModel>(book);
            return View(bookViewModel);
        }
    }
}