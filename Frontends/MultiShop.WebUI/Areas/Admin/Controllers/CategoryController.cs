using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICategoryService _categoryService;
        private readonly IToastNotification _toastNotification;
        public CategoryController(IHttpClientFactory httpClientFactory, ICategoryService categoryService, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _categoryService = categoryService;
            _toastNotification = toastNotification;
        }
        void CategoryViewbagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Kategoriler";
            ViewBag.v3 = "Kategori Listesi";
            ViewBag.v0 = "Kategori İşlemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            CategoryViewbagList();
            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateCategory")]
        public IActionResult CreateCategory()
        {
            CategoryViewbagList();
            return View();
        }

        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await _categoryService.CreateCategoryAsync(createCategoryDto);
            _toastNotification.AddInfoToastMessage("Kategori Eklendi");
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [Route("DeleteCategory/{id}")]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await _categoryService.DeleteCategoryAsync(id);
            _toastNotification.AddErrorToastMessage("Kategori Silindi");
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }

        [Route("UpdateCategory/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateCategory(string id)
        {
            CategoryViewbagList();
            var values = await _categoryService.GetByIdCategoryAsync(id);
            return View(values);
        }
        [Route("UpdateCategory/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await _categoryService.UpdateCategoryAsync(updateCategoryDto);
            _toastNotification.AddSuccessToastMessage("Kategori Güncellendi");
            return RedirectToAction("Index", "Category", new { area = "Admin" });
        }
    }
}