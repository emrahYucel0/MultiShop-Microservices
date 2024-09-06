using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOfferDtos;
using MultiShop.WebUI.Services.CatalogServices.SpecialOfferServices;
using NToastNotify;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/SpecialOffer")]
    public class SpecialOfferController : Controller
    {
        private readonly ISpecialOfferService _specialOfferService;
        private readonly IToastNotification _toastNotification;
        public SpecialOfferController(ISpecialOfferService specialOfferService, IToastNotification toastNotification)
        {
            _specialOfferService = specialOfferService;
            _toastNotification = toastNotification;
        }

        void SpecialOfferViewBagList()
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Özel Teklifler";
            ViewBag.v3 = "Özel Teklif ve Günün İndirim Listesi";
            ViewBag.v0 = "Özel Teklif İşlemleri";
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferService.GetAllSpecialOfferAsync();
            return View(values);
        }

        [HttpGet]
        [Route("CreateSpecialOffer")]
        public IActionResult CreateSpecialOffer()
        {
            SpecialOfferViewBagList();
            return View();
        }

        [HttpPost]
        [Route("CreateSpecialOffer")]
        public async Task<IActionResult> CreateSpecialOffer(CreateSpecialOfferDto createSpecialOfferDto)
        {
            await _specialOfferService.CreateSpecialOfferAsync(createSpecialOfferDto);
            _toastNotification.AddInfoToastMessage("Özel Teklif Eklendi");
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("DeleteSpecialOffer/{id}")]
        public async Task<IActionResult> DeleteSpecialOffer(string id)
        {
            await _specialOfferService.DeleteSpecialOfferAsync(id);
            _toastNotification.AddErrorToastMessage("Özel Teklif Silindi");
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }

        [Route("UpdateSpecialOffer/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffer(string id)
        {
            SpecialOfferViewBagList();
            var values = await _specialOfferService.GetByIdSpecialOfferAsync(id);
            return View(values);
        }
        [Route("UpdateSpecialOffer/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffer(UpdateSpecialOfferDto updateSpecialOfferDto)
        {
            await _specialOfferService.UpdateSpecialOfferAsync(updateSpecialOfferDto);
            _toastNotification.AddSuccessToastMessage("Özel Teklif Güncellendi");
            return RedirectToAction("Index", "SpecialOffer", new { area = "Admin" });
        }
    }
}