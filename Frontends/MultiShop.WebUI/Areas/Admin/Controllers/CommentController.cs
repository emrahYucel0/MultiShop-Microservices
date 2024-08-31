﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos.UserCommentDtos;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toastNotification;

        public CommentController(IHttpClientFactory httpClientFactory, IToastNotification toastNotification)
        {
            _httpClientFactory = httpClientFactory;
            _toastNotification = toastNotification;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            ViewBag.t = "Yorum İşlemleri";
            ViewBag.v1 = "Anasayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7283/api/Comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultUserCommentDto>>(jsonData);
                return View(values);
            }

            return View();
        }

        [Route("DeleteComment/{id}")]
        public async Task<IActionResult> DeleteComment(string id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7283/api/Comments?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                _toastNotification.AddErrorToastMessage("Yorum Silindi");

                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateComment/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateComment(string id)
        {
            ViewBag.v1 = "Ana Sayfa";
            ViewBag.v2 = "Yorumlar";
            ViewBag.v3 = "Yorum Listesi";
            ViewBag.v0 = "Yorum İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7283/api/Comments/" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateUserCommentDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("UpdateComment/{id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateComment(UpdateUserCommentDto updateUSerCommentDto)
        {
            updateUSerCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateUSerCommentDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7283/api/Comments/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}