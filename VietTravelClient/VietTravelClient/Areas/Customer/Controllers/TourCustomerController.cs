using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Models;

namespace VietTravelClient.Areas.Customer.Controllers
{
    public class TourCustomerController : Controller
    {
        private readonly ILogger<HomeCustomerController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;

        public TourCustomerController(ILogger<HomeCustomerController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("tourDetail")]
        public async Task<IActionResult> TourDetail(string tourId)
        {
            string urlTour = domailServer + "tour/" + tourId;
            string urlTourPackage = domailServer + "tourpackage/searchByTourId/" + tourId;
            string urlTimePackage = domailServer + "timepackage";
            Tour tour = new Tour();
            List<TourPackage> tourPackages = new List<TourPackage>();
            List<TimePackage> timePackages = new List<TimePackage>();
            try
            {
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    string urlTourGuide = domailServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domailServer + "hotel/searchByCityId/" + tour.CityId.ToString();
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
            string urlTour = domailServer + "tour/" + searchTourSelect;
            string urlTourPackage = domailServer + "tourpackage/searchByTourId/" + searchTourSelect;
            string urlTimePackage = domailServer + "timepackage";
            Tour tour = new Tour();
            List<TourPackage> tourPackages = new List<TourPackage>();
            List<TimePackage> timePackages = new List<TimePackage>();
            try
            {
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                ResponseData responseDataTourPackage = await _callApi.GetApi(urlTourPackage);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage);
                if (responseDataTour.Success && responseDataTourPackage.Success && responseDataTimePackage.Success)
                {
                    tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseDataTourPackage.Data);
                    timePackages = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                    string urlTourGuide = domailServer + "tourguide/searchByCityId/" + tour.CityId.ToString();
                    string urlHotel = domailServer + "hotel/searchByCityId/" + tour.CityId.ToString();
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
        public async Task<IActionResult> TourManager()
        {
            string url = domailServer + "tour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseData.Data);
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
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue)
        {
            if (searchValue.Trim().Equals("") || searchValue == null) return RedirectToAction("TourManager");
            string url = domailServer + "tour/search/" + searchValue;
            List<Tour> tours = new List<Tour>();
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                string result = responseData.Data;
                tours = JsonConvert.DeserializeObject<List<Tour>>(result);
                ViewData["Tours"] = tours;
                return View();
            }
            catch (Exception e)
            {
                return View();
            }
        }

    }
}
