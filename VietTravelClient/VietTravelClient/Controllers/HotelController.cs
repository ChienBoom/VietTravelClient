using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnidecodeSharpCore;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Controllers
{
    public class HotelController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string tokenAnonymous;

        public HotelController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            tokenAnonymous = _configuration["tokenAnonymous"];
        }

        [HttpGet]
        [Route("hotelManager")]
        public async Task<IActionResult> HotelManager(int page)
        {
            string url = domainServer + "hotel/page/" + page.ToString();
            string urlTotalPage = domainServer + "hotel/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(responseData.Data);
                    ViewData["Hotels"] = hotels;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    return View();
                }
                return RedirectToAction("Error", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [Route("hotelDetail")]
        public async Task<IActionResult> HotelDetail(string itemId, int page)
        {
            string url = domainServer + "hotel/" + itemId;
            string urlEva = domainServer + "evaluate/evaHotel/" + itemId;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenAnonymous);
                if (responseData.Success && responseDataEva.Success)
                {
                    ViewData["Hotel"] = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
                    ViewData["Evaluates"] = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    return View();
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        //Search với từ khóa là tên của City
        [HttpPost]
        [Route("searchHotelPost")]
        public async Task<IActionResult> SearchHotelPost(string searchValue, int page)
        {
            return RedirectToAction("SearchHotel", new { controller = "Hotel", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchHotel")]
        public async Task<IActionResult> SearchHotel(string searchValue, int page)
        {
            string url = domainServer + "hotel/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "hotel/search/totalPage/" + searchValue.Unidecode();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseData.Data);
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["SearchValue"] = searchValue;
                    return View();
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", "Home");
            }
        }

    }
}
