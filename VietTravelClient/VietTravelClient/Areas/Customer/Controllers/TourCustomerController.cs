﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Models;
using Microsoft.AspNetCore.Http;
using UnidecodeSharpCore;
using System.Linq;
using VietTravelClient.Models.WeatherModel;

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
        private readonly string keyWeather;
        private string tokenCustomer;

        public TourCustomerController(ILogger<HomeCustomerController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            keyWeather = _configuration["KeyWeatherApi"];
        }

        [HttpGet]
        [Route("tourDetail")]
        public async Task<IActionResult> TourDetail(string itemId)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTour = domainServer + "tour/" + itemId;
            string urlRelateTour = domainServer + "tour/searchRelatedTour/" + itemId;
            string urlTourPackage = domainServer + "tourpackage/searchByTourId/" + itemId;
            string urlTimePackage = domainServer + "timepackage";
            string urlEva = domainServer + "evaluate/evaTour/" + itemId;
            string urlEvent = domainServer + "event/searchEventByTourId/" + itemId;
            Tour tour = new Tour();
            List<TourPackage> tourPackages = new List<TourPackage>();
            List<TimePackage> timePackages = new List<TimePackage>();
            List<Evaluate> evaluates = new List<Evaluate>();
            List<Event> events = new List<Event>();
            try
            {
                ResponseData responseDataTour = await _callApi.GetApi(urlTour, tokenCustomer);
                ResponseData responseDataRelateTour = await _callApi.GetApi(urlRelateTour, tokenCustomer);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage, tokenCustomer);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage, tokenCustomer);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenCustomer);
                ResponseData responseDataEvent = await _callApi.GetApi(urlEvent, tokenCustomer);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success && responseDataEva.Success && responseDataEvent.Success && responseDataRelateTour.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    List<Tour> relateTours = JsonConvert.DeserializeObject<List<Tour>>(responseDataRelateTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    events = JsonConvert.DeserializeObject<List<Event>>(responseDataEvent.Data);
                    string urlTourGuide = domainServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    string urlRestaurant = domainServer + "restaurant/searchByCityId/" + tour.CityId.ToString();
                    string urlSchedule = domainServer + "schedule/getByTourId/" + itemId;
                    string urlWeather = "https://api.openweathermap.org/data/2.5/weather?lat=" + tour.CoordLat + "&lon=" + tour.CoordLon + "&appid=" + keyWeather;
                    List<TourGuide> tourGuides = new List<TourGuide>();
                    List<Hotel> hotels = new List<Hotel>();
                    List<Restaurant> restaurants = new List<Restaurant>();
                    List<Schedule> schedules = new List<Schedule>();
                    ResponseData responseDataTourGuide = await _callApi.GetApi(urlTourGuide, tokenCustomer);
                    ResponseData responseDataHotel = await _callApi.GetApi(urlHotel, tokenCustomer);
                    ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant, tokenCustomer);
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule, tokenCustomer);
                    ResponseData responseDataWeather = await _callApi.GetApi(urlWeather, tokenCustomer);
                    if (responseDataTourGuide.Success && responseDataHotel.Success && responseDataRestaurant.Success && responseDataSchedule.Success)
                    {
                        tourGuides = JsonConvert.DeserializeObject<List<TourGuide>>(responseDataTourGuide.Data);
                        hotels = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotel.Data);
                        restaurants = JsonConvert.DeserializeObject<List<Restaurant>>(responseDataRestaurant.Data);
                        schedules = JsonConvert.DeserializeObject<List<Schedule>>(responseDataSchedule.Data);
                        ViewData["Tour"] = tour;
                        if (relateTours.Count >= 4)
                        {
                            ViewData["RelateTours"] = relateTours.Take(4).ToList();
                        }
                        else
                        {
                            ViewData["RelateTours"] = relateTours.Take(relateTours.Count).ToList();
                        }
                        ViewData["TourGuides"] = tourGuides;
                        ViewData["TourPackages"] = tourPackages.Where(o => o.CreateBy == "Admin").ToList();
                        ViewData["Hotels"] = hotels;
                        ViewData["Restaurants"] = restaurants;
                        ViewData["TimePackages"] = timePackages;
                        ViewData["Evaluates"] = evaluates;
                        ViewData["Schedules"] = schedules;
                        ViewData["Events"] = events;
                        if (responseDataWeather.Data != null) ViewData["Weather"] = JsonConvert.DeserializeObject<WeatherOpen>(responseDataWeather.Data);
                        else ViewData["Weather"] = new List<WeatherOpen>();
                        ViewData["UsernameAccount"] = usernameAccount;
                        return View();
                    }
                    return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

        //Search với Id của Tour
        [HttpPost]
        [Route("searchTourDetail")]
        public async Task<IActionResult> SearchTourDetail(string itemId)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTour = domainServer + "tour/" + itemId;
            string urlRelateTour = domainServer + "tour/searchRelatedTour/" + itemId;
            string urlTourPackage = domainServer + "tourpackage/searchByTourId/" + itemId;
            string urlTimePackage = domainServer + "timepackage";
            string urlEva = domainServer + "evaluate/evaTour/" + itemId;
            string urlEvent = domainServer + "event/searchEventByTourId/" + itemId;
            Tour tour = new Tour();
            List<TourPackage> tourPackages = new List<TourPackage>();
            List<TimePackage> timePackages = new List<TimePackage>();
            List<Evaluate> evaluates = new List<Evaluate>();
            List<Event> events = new List<Event>();
            try
            {
                ResponseData responseDataTour = await _callApi.GetApi(urlTour, tokenCustomer);
                ResponseData responseDataRelateTour = await _callApi.GetApi(urlRelateTour, tokenCustomer);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage, tokenCustomer);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage, tokenCustomer);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenCustomer);
                ResponseData responseDataEvent = await _callApi.GetApi(urlEvent, tokenCustomer);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success && responseDataEva.Success && responseDataRelateTour.Success && responseDataEvent.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    List<Tour> relateTours = JsonConvert.DeserializeObject<List<Tour>>(responseDataRelateTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    events = JsonConvert.DeserializeObject<List<Event>>(responseDataEvent.Data);
                    string urlTourGuide = domainServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    string urlRestaurant = domainServer + "restaurant/searchByCityId/" + tour.CityId.ToString();
                    string urlSchedule = domainServer + "schedule/getByTourId/" + itemId;
                    string urlWeather = "https://api.openweathermap.org/data/2.5/weather?lat=" + tour.CoordLat + "&lon=" + tour.CoordLon + "&appid=" + keyWeather;
                    ResponseData responseDataTourGuide = await _callApi.GetApi(urlTourGuide, tokenCustomer);
                    ResponseData responseDataHotel = await _callApi.GetApi(urlHotel, tokenCustomer);
                    ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant, tokenCustomer);
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule, tokenCustomer);
                    ResponseData responseDataWeather = await _callApi.GetApi(urlWeather, tokenCustomer);
                    if (responseDataTourGuide.Success && responseDataHotel.Success && responseDataRestaurant.Success && responseDataSchedule.Success)
                    {
                        ViewData["Tour"] = tour;
                        if (relateTours.Count >= 4)
                        {
                            ViewData["RelateTours"] = relateTours.Take(4).ToList();
                        }
                        else
                        {
                            ViewData["RelateTours"] = relateTours.Take(relateTours.Count).ToList();
                        }
                        ViewData["TourGuides"] = JsonConvert.DeserializeObject<List<TourGuide>>(responseDataTourGuide.Data);
                        ViewData["TourPackages"] = tourPackages.Where(o => o.CreateBy == "Admin").ToList();
                        ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotel.Data);
                        ViewData["Restaurants"] = JsonConvert.DeserializeObject<List<Restaurant>>(responseDataRestaurant.Data);
                        ViewData["TimePackages"] = timePackages;
                        ViewData["Evaluates"] = evaluates;
                        ViewData["Events"] = events;
                        ViewData["Schedules"] = JsonConvert.DeserializeObject<List<Schedule>>(responseDataSchedule.Data);
                        if (responseDataWeather.Data != null) ViewData["Weather"] = JsonConvert.DeserializeObject<WeatherOpen>(responseDataWeather.Data);
                        else ViewData["Weather"] = new List<WeatherOpen>();
                        ViewData["UsernameAccount"] = usernameAccount;
                        return View();
                    }
                    return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

        [HttpGet]
        [Route("TourManager")]
        public async Task<IActionResult> TourManager(int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "tour/page/" + page.ToString();
            string urlTotalPage = domainServer + "tour/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenCustomer);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    return View()
;
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

        //Search với từ khóa là tên của Tour
        [HttpPost]
        [Route("searchTourPost")]
        public async Task<IActionResult> SearchTourPost(string searchValue, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            return RedirectToAction("SearchTour", new { area = "Customer", controller = "TourCustomer", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue, int page)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("TourManager");
            string url = domainServer + "tour/search/" + searchValue + "/" + page.ToString();
            string urlTotalPage = domainServer + "tour/search/totalPage/" + searchValue.Unidecode();
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenCustomer);
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
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception e)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

    }
}
