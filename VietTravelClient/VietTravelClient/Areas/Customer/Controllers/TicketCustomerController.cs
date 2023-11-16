using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VietTravelClient.Common;
using VietTravelClient.Controllers;
using VietTravelClient.Models;

namespace VietTravelClient.Areas.Customer.Controllers
{
    [Area("Customer")]
    [Route("/customer")]
    public class TicketCustomerController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly IConfiguration _configuration;
        private readonly string domainServer;

        public TicketCustomerController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domainServer = _configuration["DomainServer"];
        }

        [HttpPost]
        [Route("saveTicketPackage")]
        public async Task<IActionResult> SaveTicketPackage(string tourPackageId)
        {
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = new ResponseData();
                responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    User user = JsonConvert.DeserializeObject<User>(responseData.Data);
                    Ticket ticket = new Ticket();
                    ticket.UserId = user.Id;
                    ticket.TourPackageId = long.Parse(tourPackageId);
                    ticket.BookingDate = DateTime.Now;
                    ticket.Status = 1;
                    string urlTicket = domainServer + "ticket";
                    string stringTicket = JsonConvert.SerializeObject(ticket);
                    ResponseData responseDataTicket = await _callApi.PostApi(urlTicket, stringTicket);
                    if(responseDataTicket.Success)
                    {
                        return RedirectToAction("History", new {area = "Customer", controller= "HomeCustomer", status = 1, ticketStatus = 1});
                    }
                    return RedirectToAction("TourDetail", new {area = "Customer", controller="TourCustomer", status = 2, ticketStatus = 1});
                }
                return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 2, ticketStatus = 1});
            }
            catch (Exception ex)
            {
                return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 3, ticketStatus = 1});
            }
        }

        [HttpPost]
        [Route("saveTicketSingle")]
        public async Task<IActionResult> SaveTicketSingle(TourPackage value, string ScheduleList)
        {
            string[] ArrayScheduleId = ScheduleList.Split(',');
            List<Schedule> schedules = new List<Schedule>();
            foreach(string item in ArrayScheduleId)
            {
                string urlSchedule = domainServer + "schedule/" + item;
                try
                {
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule);
                    if (!responseDataSchedule.Success)
                    {
                        return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 2 });
                    }
                    schedules.Add(JsonConvert.DeserializeObject<Schedule>(responseDataSchedule.Data));
                }
                catch (Exception e)
                {
                    return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 3 });
                }
            }
            value.ListScheduleTourPackage = JsonConvert.SerializeObject(schedules);
            value = await CreateTourPackageSingle(value);

            if(value == null) return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 2 });

            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTourPackage = domainServer + "tourpackage/";
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                ResponseData responseDataTourPackage = await _callApi.PostApi(urlTourPackage, JsonConvert.SerializeObject(value));
                if (responseData.Success && responseDataTourPackage.Success)
                {
                    User user = JsonConvert.DeserializeObject<User>(responseData.Data);
                    TourPackage tourPackage = JsonConvert.DeserializeObject<TourPackage>(responseDataTourPackage.Data);
                    Ticket ticket = new Ticket();
                    ticket.UserId = user.Id;
                    ticket.TourPackageId = tourPackage.Id;
                    ticket.BookingDate = DateTime.Now;
                    ticket.Status = 1;
                    string urlTicket = domainServer + "ticket";
                    string stringTicket = JsonConvert.SerializeObject(ticket);
                    ResponseData responseDataTicket = await _callApi.PostApi(urlTicket, stringTicket);
                    if (responseDataTicket.Success)
                    {
                        return RedirectToAction("History", new { area = "Customer", controller = "HomeCustomer", status = 1, ticketStatus =1});
                    }
                    return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 2, ticketStatus = 1 });
                }
                return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 2, ticketStatus = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("TourDetail", new { area = "Customer", controller = "TourCustomer", status = 3, ticketStatus = 1 });
            }
        }

        public async Task<TourPackage> CreateTourPackageSingle(TourPackage tourPackage)
        {
            tourPackage.Name = RandomName(10);
            tourPackage.CreateBy = "Customer";
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
                    tourPackage.BasePrice = hotel.PriceHour * timePackage.HourNumber;
                    tourPackage.EndTime = tourPackage.StartTime.AddHours(timePackage.HourNumber);
                    foreach (Schedule schedule in schedules)
                    {
                        tourPackage.BasePrice += schedule.PriceTicketAdult * tourPackage.NumberOfAdult + schedule.PriceTicketKid * tourPackage.NumberOfChildren;
                    }
                    tourPackage.Discount = 0;
                    tourPackage.LastPrice = tourPackage.BasePrice * (100 - (int)tourPackage.Discount) / 100;
                    return tourPackage;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public string RandomName(int lengthName)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            string result = "";

            for (int i = 0; i < lengthName; i++)
            {
                int index = random.Next(chars.Length);
                result += chars[index];
            }
            return result;
        }

    }
}
