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
using VietTravelClient.ModelsDto;
using System.Linq;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class TourPackageAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;
        private readonly string uploadPath;

        public TourPackageAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

//        [HttpGet]
//        [Route("addTourPackage")]
//        public async Task<IActionResult> AddTourPackage()
//        {
//            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
//            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
//            string urlTours = domainServer + "tour";
//            string urlHotels = domainServer + "hotel";
//            string urlTimePackage = domainServer + "timepackage";
//            try
//            {
//                ResponseData responseDataTours = await _callApi.GetApi(urlTours);
//                ResponseData responseDataHotels = await _callApi.GetApi(urlHotels);
//                ResponseData responseDataTimePackages = await _callApi.GetApi(urlTimePackage);
//                if (responseDataTours.Success && responseDataHotels.Success)
//                {
//                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
//                    ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotels.Data);
//                    ViewData["TimePackages"] = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackages.Data);
//                    ViewData["UsernameAccount"] = usernameAccount;
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
        [Route("tourPackageManager")]
        public async Task<IActionResult> TourPackageManager(string TourId, string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "tourpackage/searchByTourId/" + TourId;
            string urlTimePackage = domainServer + "timepackage";
            string urlTour = domainServer + "tour/" + TourId;
            string urlSchedule = domainServer + "schedule/getByTourId/" + TourId;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule);
                if (responseData.Success && responseDataTimePackage.Success && responseDataTour.Success && responseDataSchedule.Success)
                {
                    Tour tour = JsonConvert.DeserializeObject<Tour>(responseDataTour.Data);
                    string urlHotel = domainServer + "hotel/searchByCityId/" + tour.CityId.ToString();
                    string urlRestaurant = domainServer + "restaurant/searchByCityId/" + tour.CityId.ToString();
                    ResponseData responseDataHotel = await _callApi.GetApi(urlHotel);
                    ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant);
                    if (responseDataHotel.Success && responseDataRestaurant.Success)
                    {
                        List<TourPackage> tourPackages = JsonConvert.DeserializeObject<List<TourPackage>>(responseData.Data);
                        //ViewData["TourPackages"] = tourPackages.Where(o => o.CreateBy.Equals("Admin")).ToList();
                        List<TourPackage> lstTourPackage = tourPackages.Where(O => O.CreateBy == "Admin").ToList();
                        if(lstTourPackage != null && lstTourPackage.Count > 0)
                        {
                            foreach(TourPackage item in lstTourPackage)
                            {
                                item.ScheduleTourPackages = JsonConvert.DeserializeObject<List<Schedule>>(item.ListScheduleTourPackage);
                            }
                        }
                        ViewData["TourPackages"] = tourPackages.Where(O => O.CreateBy == "Admin").ToList();
                        ViewData["TourId"] = TourId;
                        ViewData["TimePackages"] = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackage.Data);
                        ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotel.Data);
                        ViewData["Restaurants"] = JsonConvert.DeserializeObject<List<Restaurant>>(responseDataRestaurant.Data);
                        ViewData["Schedules"] = JsonConvert.DeserializeObject<List<Schedule>>(responseDataSchedule.Data);
                        ViewData["Status"] = status;
                        ViewData["UsernameAccount"] = usernameAccount;
                        return View();
                    }
                    return RedirectToAction("Error", "Home");
                }
                return RedirectToAction("Error","Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("getTourPackageDetail")]
        public async Task<IActionResult> GetTourPackageDetail([FromBody] TourPackageDto value)
        {
            TourPackage tourPackage = new TourPackage();
            tourPackage.Name = value.Name;
            tourPackage.StartTime = value.StartTime;
            tourPackage.NumberOfAdult = value.NumberOfAdult;
            tourPackage.NumberOfChildren = value.NumberOfChildren;
            tourPackage.Discount = value.Discount;
            tourPackage.TourId = value.TourId;
            tourPackage.HotelId = value.HotelId;
            tourPackage.TimePackageId = value.TimePackageId;
            tourPackage.Description = value.Description;

            string urlTimePackage = domainServer + "timepackage/" + value.TimePackageId.ToString();
            string urlHotel = domainServer + "hotel/" + value.HotelId.ToString();
            try
            {
                ResponseData responseTimePackage = await _callApi.GetApi(urlTimePackage);
                ResponseData responseHotel = await _callApi.GetApi(urlHotel);
                if(responseTimePackage.Success && responseHotel.Success)
                {
                    TimePackage timePackage = JsonConvert.DeserializeObject<TimePackage>(responseTimePackage.Data);
                    Hotel hotel = JsonConvert.DeserializeObject<Hotel>(responseHotel.Data);

                    tourPackage.EndTime = value.StartTime.AddHours(timePackage.HourNumber);
                    decimal PriceHotel = hotel.PriceHour * timePackage.HourNumber;
                    decimal PriceSchedule = 12;
                    tourPackage.BasePrice = PriceHotel + PriceSchedule;
                    return Ok(tourPackage);
                }
                return RedirectToAction("Error", "Home");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        [Route("saveTourPackage")]
        public async Task<IActionResult> CreateTourPackage(TourPackage value, string ScheduleList)
        {
            string[] ArrayScheduleId = ScheduleList.Split(',');
            List<Schedule> schedules = new List<Schedule>();
            foreach (string item in ArrayScheduleId)
            {
                string urlSchedule = domainServer + "schedule/" + item;
                try
                {
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule);
                    if (!responseDataSchedule.Success)
                    {
                        return RedirectToAction("Error", "Home");
                    }
                    schedules.Add(JsonConvert.DeserializeObject<Schedule>(responseDataSchedule.Data));
                }
                catch (Exception e)
                {
                    return RedirectToAction("Error", "Home");
                }
            }
            value.ListScheduleTourPackage = JsonConvert.SerializeObject(schedules);
            value = await CompleteTourPackage(value);
            if (value == null) return RedirectToAction("Error", "Home");

            string urlSave = domainServer + "tourpackage";
            try
            {
                ResponseData responseDataSave = await _callApi.PostApi(urlSave, JsonConvert.SerializeObject(value));
                if (responseDataSave.Success)
                {

                    return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "CreateSuccess" });
                }
                return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "CreateFaild" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "CreateFaild" });
            }
        }

        [HttpPost]
        [Route("updateTourPackage")]
        public async Task<IActionResult> UpdateTourPackage(TourPackage value, string ScheduleList)
        {
            string[] ArrayScheduleId = ScheduleList.Split(',');
            List<Schedule> schedules = new List<Schedule>();
            foreach (string item in ArrayScheduleId)
            {
                string urlSchedule = domainServer + "schedule/" + item;
                try
                {
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule);
                    if (!responseDataSchedule.Success)
                    {
                        return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "UpdateFaild" });
                    }
                    schedules.Add(JsonConvert.DeserializeObject<Schedule>(responseDataSchedule.Data));
                }
                catch (Exception e)
                {
                    return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "UpdateFaild" });
                }
            }
            value.ListScheduleTourPackage = JsonConvert.SerializeObject(schedules);
            value = await CompleteTourPackage(value);
            if (value == null) return RedirectToAction("Error", "Home");

            string urlUpdate = domainServer + "tourpackage/" + value.Id.ToString();
            try
            {
                ResponseData responseDataSave = await _callApi.PutApi(urlUpdate, JsonConvert.SerializeObject(value));
                if (responseDataSave.Success)
                {

                    return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "UpdateSuccess" });
                }
                return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "UpdateFaild" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = value.TourId, status = "UpdateFaild" });
            }
        }

        [HttpPost]
        [Route("deleteTourPackage")]
        public async Task<IActionResult> DeleteTourPackage(string Id, string tourId)
        {
            string url = domainServer + "tourpackage/" + Id;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                if (responseData.Success)
                {
                    return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin",TourId = tourId, status = "DeleteSuccess" });
                }
                return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = tourId, status = "DeleteFaild" });
            }
            catch (Exception e)
            {
                return RedirectToAction("TourPackageManager", new { area = "Admin", controller = "TourPackageAdmin", TourId = tourId, status = "DeleteFaild" });
            }
        }

        public async Task<TourPackage> CompleteTourPackage(TourPackage tourPackage)
        {
            tourPackage.CreateBy = "Admin";
            List<Schedule> schedules = new List<Schedule>();
            schedules = JsonConvert.DeserializeObject<List<Schedule>>(tourPackage.ListScheduleTourPackage);
            string urlHotel = domainServer + "hotel/" + tourPackage.HotelId.ToString();
            string urlRestaurant = domainServer + "restaurant/" + tourPackage.RestaurantId.ToString();
            string urlTimePackage = domainServer + "timepackage/" + tourPackage.TimePackageId.ToString();
            try
            {
                ResponseData responseDataHotel = await _callApi.GetApi(urlHotel);
                ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage);
                if (responseDataHotel.Success && responseDataRestaurant.Success && responseDataTimePackage.Success)
                {
                    Hotel hotel = JsonConvert.DeserializeObject<Hotel>(responseDataHotel.Data);
                    Restaurant restaurant = JsonConvert.DeserializeObject<Restaurant>(responseDataRestaurant.Data);
                    TimePackage timePackage = JsonConvert.DeserializeObject<TimePackage>(responseDataTimePackage.Data);
                    tourPackage.BasePrice = hotel.PriceHour * tourPackage.NumberOfAdult / 2 * timePackage.HourNumber / 24 + restaurant.PriceDefault * tourPackage.NumberOfAdult + restaurant.PriceDefault * tourPackage.NumberOfChildren / 2 * timePackage.HourNumber / 12;
                    tourPackage.EndTime = tourPackage.StartTime.AddHours(timePackage.HourNumber);
                    foreach (Schedule schedule in schedules)
                    {
                        tourPackage.BasePrice += schedule.PriceTicketAdult * tourPackage.NumberOfAdult + schedule.PriceTicketKid * tourPackage.NumberOfChildren;
                    }
                    tourPackage.BasePrice = tourPackage.BasePrice * 110 / 100;
                    tourPackage.LastPrice = tourPackage.BasePrice * (100 - (int)tourPackage.Discount)/ 100;
                    return tourPackage;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

    }
}
