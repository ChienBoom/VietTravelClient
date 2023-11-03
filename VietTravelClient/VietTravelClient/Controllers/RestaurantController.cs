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
    public class RestaurantController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public RestaurantController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("restaurantManager")]
        public async Task<IActionResult> RestaurantManager(int page)
        {
            string url = domainServer + "restaurant/page/" + page.ToString();
            string urlTotalPage = domainServer + "restaurant/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(responseData.Data);
                    ViewData["Restaurants"] = restaurants;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    return View();
                }
                return RedirectToAction("Error", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpGet]
        [Route("restaurantDetail")]
        public async Task<IActionResult> RestaurantDetail(string itemId, int page)
        {
            string url = domainServer + "restaurant/" + itemId;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Restaurant"] = JsonConvert.DeserializeObject<Restaurant>(responseData.Data);
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
        [Route("searchRestaurantPost")]
        public async Task<IActionResult> SearchRestaurantPost(string searchValue, int page)
        {
            return RedirectToAction("SearchRestaurant", new { controller = "Restaurant", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchRestaurant")]
        public async Task<IActionResult> SearchRestaurant(string searchValue, int page)
        {
            string url = domainServer + "restaurant/search/" + searchValue + "/" + page.ToString();
            string urlTotalPage = domainServer + "restaurant/search/totalPage/" + searchValue.Unidecode();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Restaurants"] = JsonConvert.DeserializeObject<List<Restaurant>>(responseData.Data);
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
