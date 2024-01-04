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
    public class HotelCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private string tokenCustomer;

        public HotelCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("hotelManager")]
        public async Task<IActionResult> HotelManager(int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "hotel/page/" + page.ToString();
            string urlTotalPage = domainServer + "hotel/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenCustomer);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    List<Hotel> hotels = JsonConvert.DeserializeObject<List<Hotel>>(responseData.Data);
                    ViewData["Hotels"] = hotels;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

        [HttpGet]
        [Route("hotelDetail")]
        public async Task<IActionResult> HotelDetail(string itemId, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "hotel/" + itemId;
            string urlEva = domainServer + "evaluate/evaHotel/" + itemId;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenCustomer);
                if (responseData.Success && responseDataEva.Success)
                {
                    ViewData["Hotel"] = JsonConvert.DeserializeObject<Hotel>(responseData.Data);
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
        [Route("searchHotelPost")]
        public async Task<IActionResult> SearchHotelPost(string searchValue, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchHotel", new { area = "Customer", controller = "HotelCustomer", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchHotel")]
        public async Task<IActionResult> SearchHotel(string searchValue, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "hotel/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "hotel/search/totalPage/" + searchValue.Unidecode();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenCustomer);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseData.Data);
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["SearchValue"] = searchValue;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller="HomeCustomer"});
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "HomeCustomer" });
            }
        }

    }
}
