using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.BrandDtos;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Brand")]
    public class BrandController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public BrandController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.t = "Marka İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Marka Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [HttpGet]
        [Route("CreateBrand")]
        public IActionResult CreateBrand()
        {
            ViewBag.t = "Marka İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Yeni Marka Girişi";
            return View();
        }

        [HttpPost]
        [Route("CreateBrand")]
        public async Task<IActionResult> CreateBrand(CreateBrandDto createBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Brands", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddInfoToastMessage("Marka Eklendi");

                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteBrand/{id}")]
        public async Task<IActionResult> DeleteBrand(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7070/api/Brands?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage("Marka Silindi");

                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(string id)
        {
            ViewBag.t = "Marka İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Markaler";
            ViewBag.v3 = "Marka Güncelleme Sayfası";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Brands/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateBrandDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateBrand/{id}")]
        public async Task<IActionResult> UpdateBrand(UpdateBrandDto updateBrandDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateBrandDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7070/api/Brands/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddSuccessToastMessage("Marka Güncellendi");

                return RedirectToAction("Index", "Brand", new { area = "Admin" });
            }
            return View();
        }

    }
}
