using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Models;
using Microsoft.AspNetCore.Http;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class TourCustomerController : Controller
    {
        private readonly ILogger<HomeCustomerController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public TourCustomerController(ILogger<HomeCustomerController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("tourDetail")]
        public async Task<IActionResult> TourDetail(string tourId)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTour = domainServer + "tour/" + tourId;
            string urlTourPackage = domainServer + "tourpackage/searchByTourId/" + tourId;
            string urlTimePackage = domainServer + "timepackage";
            string urlEva = domainServer + "evaluate/evaTour/" + tourId;
            Tour tour = new Tour();
            List<TourPackage> tourPackages = new List<TourPackage>();
            List<TimePackage> timePackages = new List<TimePackage>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success && responseDataEva.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    string urlTourGuide = domainServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    List<TourGuide> tourGuides = new List<TourGuide>();
                    List<Hotel> hotels = new List<Hotel>();
                    try
                    {
                        ResponseData responseDataTourGuide = await _callApi.GetApi(urlTourGuide);
                        ResponseData responseDataHotel = await _callApi.GetApi(urlHotel);
                        if (responseDataTourGuide.Success && responseDataHotel.Success)
                        {
                            tourGuides = JsonConvert.DeserializeObject<List<TourGuide>>(responseDataTourGuide.Data);
                            hotels = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotel.Data);
                            ViewData["Tour"] = tour;
                            ViewData["TourGuides"] = tourGuides;
                            ViewData["TourPackages"] = tourPackages;
                            ViewData["Hotels"] = hotels;
                            ViewData["TimePackages"] = timePackages;
                            ViewData["Evaluates"] = evaluates;
                            ViewData["UsernameAccount"] = usernameAccount;
                            return View();
                        }
                        return RedirectToAction("Error");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Error");
                    }
                }
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        //Search với Id của Tour
        [HttpPost]
        [Route("searchTourDetail")]
        public async Task<IActionResult> SearchTourDetail(string searchTourSelect)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTour = domainServer + "tour/" + searchTourSelect;
            string urlTourPackage = domainServer + "tourpackage/searchByTourId/" + searchTourSelect;
            string urlTimePackage = domainServer + "timepackage";
            string urlEva = domainServer + "evaluate/evaTour/" + searchTourSelect;
            Tour tour = new Tour();
            List<TourPackage> tourPackages = new List<TourPackage>();
            List<TimePackage> timePackages = new List<TimePackage>();
            List<Evaluate> evaluates = new List<Evaluate>();
            try
            {
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success && responseDataEva.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    string urlTourGuide = domainServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    List<TourGuide> tourGuides = new List<TourGuide>();
                    List<Hotel> hotels = new List<Hotel>();
                    try
                    {
                        ResponseData responseDataTourGuide = await _callApi.GetApi(urlTourGuide);
                        ResponseData responseDataHotel = await _callApi.GetApi(urlHotel);
                        if (responseDataTourGuide.Success && responseDataHotel.Success)
                        {
                            tourGuides = JsonConvert.DeserializeObject<List<TourGuide>>(responseDataTourGuide.Data);
                            hotels = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotel.Data);
                            ViewData["Tour"] = tour;
                            ViewData["TourGuides"] = tourGuides;
                            ViewData["TourPackages"] = tourPackages;
                            ViewData["Hotels"] = hotels;
                            ViewData["TimePackages"] = timePackages;
                            ViewData["Evaluates"] = evaluates;
                            ViewData["UsernameAccount"] = usernameAccount;
                            return View();
                        }
                        return RedirectToAction("Error");
                    }
                    catch (Exception ex)
                    {
                        return RedirectToAction("Error");
                    }
                }
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

        [HttpGet]
        [Route("TourManager")]
        public async Task<IActionResult> TourManager(int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "tour/page/" + page.ToString();
            string urlTotalPage = domainServer + "tour/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
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

        //Search với từ khóa là tên của Tour
        [HttpPost]
        [Route("searchTourPost")]
        public async Task<IActionResult> SearchTourPost(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchTour", new { area = "Customer", controller = "TourCustomer", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue, int page)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("TourManager");
            string url = domainServer + "tour/search/" + searchValue + "/" + page.ToString();
            string urlTotalPage = domainServer + "tour/search/totalPage/" + searchValue;
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    string result = responseData.Data;
                    tours = JsonConvert.DeserializeObject<List<Tour>>(result);
                    ViewData["Tours"] = tours;
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["SearchValue"] = searchValue;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
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
