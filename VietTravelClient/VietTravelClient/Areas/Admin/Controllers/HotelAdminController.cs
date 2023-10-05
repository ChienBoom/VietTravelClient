using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class HotelAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public HotelAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addHotel")]
        public IActionResult AddHotel()
        {
            return View();
        }

        [HttpGet]
        [Route("HotelManager")]
        public async Task<IActionResult> HotelManager()
        {
            string url = domailServer + "Hotel";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseData.Data);
                    return View()
;
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("searchHotel")]
        public async Task<IActionResult> SearchHotel(string searchValue, string UsernameAccount)
        {
            string url = domailServer + "Hotel/search/" + searchValue;
            List<Hotel> hotels = new List<Hotel>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.Data;
                hotels = JsonConvert.DeserializeObject<List<Hotel>>(result);
                ViewData["UsernameAccount"] = UsernameAccount;
                ViewData["Hotel"] = hotels;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

        //[HttpPost]
        //[Route("searchHotelTourDetail")]
        //public async Task<IActionResult> SearchHotelTourDetail(string searchHotelSelect, string UsernameAccount)
        //{
        //    string url = domailServer + "search/" + searchHotelSelect;
        //    Hotel Hotel = new Hotel();
        //    try
        //    {
        //        ResponseData responseData = await _callApi.GetApi(url);
        //        string result = responseData.Data;
        //        Hotel = JsonConvert.DeserializeObject<Hotel>(result);
        //        ViewData["UsernameAccount"] = UsernameAccount;
        //        ViewData["HotelTourDetail"] = Hotel;
        //        return View();
        //    }
        //    catch (Exception e)
        //    {
        //        return View();
        //    }
        //}

        //[HttpPost]
        //[Route("saveHotel")]
        //public async Task<IActionResult> CreateHotel(Hotel value, IFormFile file)
        //{
        //    string url = domailServer + "Hotel";
        //    Hotel Hotel = new Hotel();
        //    if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
        //    value.Pictures = _uploadFile.SaveFile(file).Message;
        //    try
        //    {
        //        string stringValue = JsonConvert.SerializeObject(value);
        //        ResponseData responseData = await _callApi.PostApi(url, stringValue);
        //        Hotel = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
        //        return RedirectToAction("HotelManager");
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"HttpRequestException: {e.Message}");
        //        return View();
        //    }
        //}

        [HttpGet]
        [Route("HotelById")]
        public async Task<IActionResult> GetHotelById(long id)
        {
            string url = domailServer + "Hotel/" + id.ToString();
            Hotel Hotel = new Hotel();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.Data;
                Hotel = JsonConvert.DeserializeObject<Hotel>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpDelete]
        [Route("DeleteHotel")]
        public async Task<IActionResult> DeleteHotel(long id)
        {
            string url = "https://localhost:44348/api/Hotel/" + id.ToString();
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }
    }
}
