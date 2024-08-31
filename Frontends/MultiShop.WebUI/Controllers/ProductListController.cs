using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public ProductListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult Index(string id)
        {
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            ViewBag.x = id;
            return View();
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            return PartialView();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateUserCommentDto createUserCommentDto)
        {
            createUserCommentDto.ImageUrl = "defaultImage.png"; // Varsayılan bir resim URL'si ayarlayabilirsiniz
            createUserCommentDto.CreatedDate = DateTime.Now;
            createUserCommentDto.Status = true; // Varsayılan olarak onaylıyorum. Bunu ihtiyacınıza göre değiştirebilirsiniz.

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createUserCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7283/api/Comments", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            {
                // Yorum başarılı bir şekilde gönderildiğinde kullanıcının mevcut ürüne geri dönmesini sağlayın
                return RedirectToAction("ProductDetail", new { id = createUserCommentDto.ProductId });
            }

            return View();
        }
    }
}
