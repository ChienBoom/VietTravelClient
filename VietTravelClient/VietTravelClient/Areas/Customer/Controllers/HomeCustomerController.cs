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
using System.Linq;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class HomeCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public HomeCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpGet]
        [Route("home")]
        public async Task<IActionResult> Home()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlCity = domainServer + "city";
            string urlTour = domainServer + "tour";
            try
            {
                ResponseData responseDataCity = await _callApi.GetApi(urlCity);
                ResponseData responseDataTour = await _callApi.GetApi(urlTour);
                if (responseDataCity.Success && responseDataTour.Success)
                {
                    List<City> cities = JsonConvert.DeserializeObject<List<City>>(responseDataCity.Data);
                    List<Tour> tours = JsonConvert.DeserializeObject<List<Tour>>(responseDataTour.Data);
                    ViewData["Cities"] = cities.OrderByDescending(o => o.Name).ToList();
                    ViewData["Tours"] = tours.OrderByDescending(o => o.NumberOfEvaluate).ToList();
                    List<City> hotCity = cities.OrderBy(o => o.Name).Take(4).ToList();
                    List<Tour> hotTour = tours.OrderBy(o => o.Name).Take(3).ToList();
                    ViewData["HotCities"] = hotCity;
                    ViewData["HotTours"] = hotTour;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View()
;
                }
                return RedirectToAction("Error", new {area="Customer", controller="Home"});
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
        }

        [HttpGet]
        [Route("history")]
        public async Task<IActionResult> History(string status)
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlUser = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = new ResponseData();
                responseData = await _callApi.GetApi(urlUser);
                if (responseData.Success)
                {
                    User user = JsonConvert.DeserializeObject<User>(responseData.Data);
                    string url = domainServer + "ticket/getTicketByUserId/" + user.Id;
                    ResponseData responseDataUser = await _callApi.GetApi(url);
                    List<Ticket> tickets = JsonConvert.DeserializeObject<List<Ticket>>(responseDataUser.Data);
                    foreach(Ticket ticket in tickets)
                    {
                        ticket.TourPackage = await getTourPackage(ticket.TourPackageId.ToString());
                        ticket.TourPackage.Hotel = await getHotel(ticket.TourPackage.HotelId.ToString());
                        ticket.TourPackage.Restaurant = await getRestaurant(ticket.TourPackage.RestaurantId.ToString());
                        ticket.TourPackage.Tour = await getTour(ticket.TourPackage.TourId.ToString());
                        ticket.TourPackage.TimePackage = await getTimePackage(ticket.TourPackage.TimePackageId.ToString());
                        if (ticket.TourPackage == null) return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                        if (ticket.TourPackage.Hotel == null) return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                        if (ticket.TourPackage.Restaurant == null) return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                        if (ticket.TourPackage.Tour == null) return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                        if (ticket.TourPackage.TimePackage == null) return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
                        ticket.TourPackage.ScheduleTourPackages = JsonConvert.DeserializeObject<List<Schedule>>(ticket.TourPackage.ListScheduleTourPackage);
                    }
                    ViewData["Tickets"] = tickets;
                    ViewData["Status"] = status;
                    ViewData["UsernameAccount"] = usernameAccount;
                    return View();
                }
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Customer", controller = "Home" });
            }
            
            
        }

        [HttpGet]
        [Route("accountManager")]
        public async Task<IActionResult> AccountManager()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["User"] = JsonConvert.DeserializeObject<User>(responseData.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
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

        [HttpGet]
        [Route("logout")]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Login");
        }

        [HttpGet]
        [Route("revenueStatisticsDetail")]
        public IActionResult RevenueStatisticsDetail()
        {
            return View();
        }

        [HttpGet]
        [Route("error")]
        public async Task<IActionResult> Error()
        {
            return View();
        }

        public async Task<TourPackage> getTourPackage(string id)
        {
            string url = domainServer + "tourpackage/" + id;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    return JsonConvert.DeserializeObject<TourPackage>(responseData.Data);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Hotel> getHotel(string id)
        {
            string url = domainServer + "hotel/" + id;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    return JsonConvert.DeserializeObject<Hotel>(responseData.Data);
                }
                return null;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<Restaurant> getRestaurant(string id)
        {
            string url = domainServer + "restaurant/" + id;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    return JsonConvert.DeserializeObject<Restaurant>(responseData.Data);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<TimePackage> getTimePackage(string id)
        {
            string url = domainServer + "timepackage/" + id;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    return JsonConvert.DeserializeObject<TimePackage>(responseData.Data);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Tour> getTour(string id)
        {
            string url = domainServer + "tour/" + id;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    return JsonConvert.DeserializeObject<Tour>(responseData.Data);
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
