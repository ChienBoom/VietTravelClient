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
        private readonly string uploadPath;

        public HotelAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("addHotel")]
        public async Task<IActionResult> AddHotel()
        {
            string urlCities = domailServer + "city";
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities);
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                return View();
            }
            catch (HttpRequestException e)
            {
                return View();
            }
            return View();
        }

        [HttpGet]
        [Route("hotelManager")]
        public async Task<IActionResult> HotelManager()
        {
            string url = domailServer + "hotel";
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
            if(searchValue != null || !searchValue.Trim().Equals(""))
            {
                string url = domailServer + "hotel/search/" + searchValue;
                List<Hotel> hotels = new List<Hotel>();
                try
                {
                    ResponseData responseData = await _callApi.GetApi(url);
                    string result = responseData.Data;
                    hotels = JsonConvert.DeserializeObject<List<Hotel>>(result);
                    ViewData["UsernameAccount"] = UsernameAccount;
                    ViewData["hotels"] = hotels;
                    return View();
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            return RedirectToAction("HotelManager");
        }

        [HttpPost]
        [Route("saveHotel")]
        public async Task<IActionResult> CreateHotel(Hotel value, IFormFile file)
        {
            string url = domailServer + "hotel";
            Hotel hotel = new Hotel();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                value.Description = "";
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                hotel = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
                return RedirectToAction("HotelManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("updateHotel")]
        public async Task<IActionResult> UpdateHotel(Hotel value, IFormFile file)
        {
            string url = domailServer + "hotel/" + value.Id.ToString();
            Hotel Hotel = new Hotel();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                value.Description = "";
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                Hotel = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
                return RedirectToAction("HotelManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpGet]
        [Route("hotelInfo")]
        public async Task<IActionResult> HotelInfo(long HotelId)
        {
            string urlCities = domailServer + "city";
            string urlHotel = domailServer + "hotel/" + HotelId.ToString();
            Hotel hotel = new Hotel();
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities);
                ResponseData response = await _callApi.GetApi(urlHotel);
                string result = response.Data;
                hotel = JsonConvert.DeserializeObject<Hotel>(result);
                hotel.Pictures = uploadPath + hotel.Pictures;
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                ViewData["Hotel"] = hotel;
                return View();
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        //[HttpGet]
        //[Route("HotelById")]
        //public async Task<IActionResult> GetHotelById(long id)
        //{
        //    string url = domailServer + "Hotel/" + id.ToString();
        //    Hotel Hotel = new Hotel();
        //    try
        //    {
        //        ResponseData response = await _callApi.GetApi(url);
        //        string result = response.Data;
        //        Hotel = JsonConvert.DeserializeObject<Hotel>(result);
        //        return View();
        //    }
        //    catch (HttpRequestException e)
        //    {
        //        Console.WriteLine($"HttpRequestException: {e.Message}");
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("deleteHotel")]
        public async Task<IActionResult> DeleteHotel(string HotelId)
        {
            string url = domailServer + "hotel/" + HotelId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("HotelManager");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
