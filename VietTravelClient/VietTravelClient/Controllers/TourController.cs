using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Models;
using UnidecodeSharpCore;
using System.Linq;
using VietTravelClient.Models.WeatherModel;

namespace VietTravelClient.Controllers
{
    public class TourController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string tokenAnonymous;
        private readonly string keyWeather;

        public TourController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            tokenAnonymous = _configuration["tokenAnonymous"];
            keyWeather = _configuration["KeyWeatherApi"];
        }

        [HttpGet]
        [Route("tourDetail")]
        public async Task<IActionResult> TourDetail(string itemId)
        {
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
                ResponseData responseDataTour = await _callApi.GetApi(urlTour, tokenAnonymous);
                ResponseData responseDataRelateTour = await _callApi.GetApi(urlRelateTour, tokenAnonymous);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage, tokenAnonymous);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage, tokenAnonymous);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenAnonymous);
                ResponseData responseDataEvent = await _callApi.GetApi(urlEvent, tokenAnonymous);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success && responseDataEva.Success && responseDataEvent.Success && responseDataRelateTour.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    List<Tour> relateTours = JsonConvert.DeserializeObject<List<Tour>>(responseDataRelateTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    tourPackages = await SetParamTourPackage(tourPackages);
                    if (tourPackages == null) return RedirectToAction("Error");
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    events = JsonConvert.DeserializeObject<List<Event>>(responseDataEvent.Data);
                    string urlTourGuide = domainServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    string urlRestaurant = domainServer + "restaurant/searchByCityId/" + tour.CityId.ToString();
                    string urlSchedule = domainServer + "schedule/getByTourId/" + itemId;
                    string urlWeather = "https://api.openweathermap.org/data/2.5/weather?lat=" + tour.CoordLat + "&lon=" + tour.CoordLon + "&appid=" + keyWeather;
                    ResponseData responseDataTourGuide = await _callApi.GetApi(urlTourGuide, tokenAnonymous);
                    ResponseData responseDataHotel = await _callApi.GetApi(urlHotel, tokenAnonymous);
                    ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant, tokenAnonymous);
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule, tokenAnonymous);
                    ResponseData responseDataWeather = await _callApi.GetApi(urlWeather, tokenAnonymous);
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
                        ViewData["Schedules"] = JsonConvert.DeserializeObject<List<Schedule>>(responseDataSchedule.Data);
                        ViewData["Events"] = events;
                        if (responseDataWeather.Data != null) ViewData["Weather"] = JsonConvert.DeserializeObject<WeatherOpen>(responseDataWeather.Data);
                        else ViewData["Weather"] = new List<WeatherOpen>();
                        return View();
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
        public async Task<IActionResult> SearchTourDetail(string itemId)
        {
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
                ResponseData responseDataTour = await _callApi.GetApi(urlTour, tokenAnonymous);
                ResponseData responseDataRelateTour = await _callApi.GetApi(urlRelateTour, tokenAnonymous);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage, tokenAnonymous);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage, tokenAnonymous);
                ResponseData responseDataEva = await _callApi.GetApi(urlEva, tokenAnonymous);
                ResponseData responseDataEvent = await _callApi.GetApi(urlEvent, tokenAnonymous);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success && responseDataEva.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    List<Tour> relateTours = JsonConvert.DeserializeObject<List<Tour>>(responseDataRelateTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    tourPackages = await SetParamTourPackage(tourPackages);
                    if(tourPackages == null) return RedirectToAction("Error");
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    evaluates = JsonConvert.DeserializeObject<List<Evaluate>>(responseDataEva.Data);
                    events = JsonConvert.DeserializeObject<List<Event>>(responseDataEvent.Data);
                    string urlTourGuide = domainServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    string urlRestaurant = domainServer + "restaurant/searchByCityId/" + tour.CityId.ToString();
                    string urlSchedule = domainServer + "schedule/getByTourId/" + itemId;
                    string urlWeather = "https://api.openweathermap.org/data/2.5/weather?lat=" + tour.CoordLat + "&lon=" + tour.CoordLon + "&appid=" + keyWeather;
                    ResponseData responseDataTourGuide = await _callApi.GetApi(urlTourGuide, tokenAnonymous);
                    ResponseData responseDataHotel = await _callApi.GetApi(urlHotel, tokenAnonymous);
                    ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant, tokenAnonymous);
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule, tokenAnonymous);
                    ResponseData responseDataWeather = await _callApi.GetApi(urlWeather, tokenAnonymous);
                    if (responseDataTourGuide.Success && responseDataHotel.Success && responseDataRestaurant.Success && responseDataSchedule.Success)
                    {
                        ViewData["Tour"] = tour;
                        if(relateTours.Count>=4){
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
                        ViewData["Schedules"] = JsonConvert.DeserializeObject<List<Schedule>>(responseDataSchedule.Data);
                        ViewData["Events"] = events;
                        if(responseDataWeather.Data != null) ViewData["Weather"] = JsonConvert.DeserializeObject<WeatherOpen>(responseDataWeather.Data);
                        else ViewData["Weather"] = new List<WeatherOpen>();
                        return View();
                    }
                }
                return RedirectToAction("Error");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
        }

//        [HttpGet]
//        [Route("TourManager")]
//        public async Task<IActionResult> TourManager()
//        {
//            string url = domainServer + "tour";
//            try
//            {
//                ResponseData responseData = await _callApi.GetApi(url);
//                if (responseData.Success)
//                {
//                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
//                    return View()
//;
//                }
//                return RedirectToAction("Error", "Home");
//            }
//            catch (Exception ex)
//            {
//                return RedirectToAction("Error", "Home");
//            }
//        }

        [HttpGet]
        [Route("TourManager")]
        public async Task<IActionResult> TourManager(int page)
        {
            string url = domainServer + "tour/page/" + page.ToString();
            string urlTotalPage = domainServer + "tour/totalPage";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseData.Success && responseDataTotalPage.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
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
        //[HttpPost]
        //[Route("searchTour")]
        //public async Task<IActionResult> SearchTour(string searchValue)
        //{
        //    if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("TourManager");
        //    string url = domainServer + "tour/search/" + searchValue;
        //    List<Tour> tours = new List<Tour>();
        //    try
        //    {
        //        ResponseData responseData = await _callApi.GetApi(url);
        //        string result = responseData.Data;
        //        tours = JsonConvert.DeserializeObject<List<Tour>>(result);
        //        ViewData["Tours"] = tours;
        //        return View();
        //    }
        //    catch (Exception e)
        //    {
        //        return View();
        //    }
        //}

        [HttpPost]
        [Route("searchTourPost")]
        public async Task<IActionResult> SearchTourPost(string searchValue, int page)
        {
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("TourManager");
            return RedirectToAction("SearchTour", new { controller = "Tour", searchValue = searchValue, page = page });
        }

        [HttpGet]
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue, int page)
        {
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("TourManager");
            string url = domainServer + "tour/search/" + searchValue.Unidecode() + "/" + page.ToString();
            string urlTotalPage = domainServer + "tour/search/totalPage/" + searchValue.Unidecode();
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAnonymous);
                ResponseData responseDataTotalPage = await _callApi.GetApi(urlTotalPage, tokenAnonymous);
                if (responseDataTotalPage.Success && responseData.Success)
                {
                    string result = responseData.Data;
                    tours = JsonConvert.DeserializeObject<List<Tour>>(result);
                    ViewData["Tours"] = tours;
                    ViewData["CurrentPage"] = page;
                    ViewData["TotalPage"] = JsonConvert.DeserializeObject<int>(responseDataTotalPage.Data);
                    ViewData["SearchValue"] = searchValue;
                    return View();
                }
                return RedirectToAction("Error");
            }
            catch (Exception e)
            {
                return RedirectToAction("Error");
            }
        }

        public async Task<List<TourPackage>> SetParamTourPackage(List<TourPackage> values)
        {
            foreach(TourPackage item in values)
            {
                if(item.ListScheduleTourPackage != null)
                {
                    item.ScheduleTourPackages = JsonConvert.DeserializeObject<List<Schedule>>(item.ListScheduleTourPackage);
                } 
                string urlHotel = domainServer + "hotel/" + item.HotelId.ToString();
                string urlRes = domainServer + "restaurant/" + item.RestaurantId.ToString();
                try
                {
                    ResponseData resHotel = await _callApi.GetApi(urlHotel, tokenAnonymous);
                    ResponseData resRes = await _callApi.GetApi(urlRes, tokenAnonymous);
                    if (resHotel.Success && resRes.Success)
                    {
                        item.Hotel = JsonConvert.DeserializeObject<Hotel>(resHotel.Data);
                        item.Restaurant = JsonConvert.DeserializeObject<Restaurant>(resRes.Data);
                    }
                    else return null;
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
            return values;
        }

    }
}
