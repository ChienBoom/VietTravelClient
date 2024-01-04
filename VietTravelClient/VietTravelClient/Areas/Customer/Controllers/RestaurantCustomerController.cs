using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;
using Microsoft.AspNetCore.Http;
using UnidecodeSharpCore;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class RestaurantCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private string tokenCustomer;

        public RestaurantCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
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
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "restaurant/page/" + page.ToString();
            string urlTotalPage = domainServer + "restaurant/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenCustomer);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    List<Restaurant> restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(responseData.Data);
                    ViewData["Restaurants"] = restaurants;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        [HttpGet]
        [Route("restaurantDetail")]
        public async Task<IActionResult> RestaurantDetail(string itemId, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "restaurant/" + itemId;
            string urlEva = domainServer + "evaluate/evaRestaurant/" + itemId;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenCustomer);
                if (responseData.Success && responseDataEva.Success)
                {
                    ViewData["Restaurant"] = JsonConvert.DeserializeObject<Restaurant>(responseData.Data);
                    ViewData["Evaluates"] = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        //Search với từ khóa là tên của City
        [HttpPost]
        [Route("searchRestaurantPost")]
        public async Task<IActionResult> SearchRestaurantPost(string searchValue, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchRestaurant", new { area="Customer", controller = "RestaurantCustomer", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchRestaurant")]
        public async Task<IActionResult> SearchRestaurant(string searchValue, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "restaurant/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "restaurant/search/totalPage/" + searchValue.Unidecode();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenCustomer);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Restaurants"] = JsonConvert.DeserializeObject<List<Restaurant>>(responseData.Data);
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["SearchValue"] = searchValue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

    }
}
