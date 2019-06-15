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
    /// 分类
    /// </summary>
    public class CategoryController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryAppService categoryAppService, IMapper mapper)
        {
            _categoryAppService = categoryAppService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int selectedCategoryId)
        {
            var categories = await _categoryAppService.Get();
            var cartViewModelList = _mapper.Map<List<CategoryViewModel>>(categories);
            ViewBag.SelectedCategoryId = selectedCategoryId;
            return View(cartViewModelList);
        }
    }
}