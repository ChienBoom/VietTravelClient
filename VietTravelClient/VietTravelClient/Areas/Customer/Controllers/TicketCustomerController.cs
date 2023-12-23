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
        private string tokenCustomer;

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
            tokenCustomer = HttpContext.Session.GetString("token");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = new ResponseData();
                responseData = await _callApi.GetApi(url, tokenCustomer);
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
                    ResponseData responseDataTicket = await _callApi.PostApi(urlTicket, stringTicket, tokenCustomer);
                    if(responseDataTicket.Success)
                    {
                        return RedirectToAction("History", new {area = "Customer", controller= "HomeCustomer", status = "BookingTourSuccess", ticketStatus = 1});
                    }
                    return RedirectToAction("History", new {area = "Customer", controller="TourCustomer", status = "BookingTourFaild", ticketStatus = 1});
                }
                return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "BookingTourFaild", ticketStatus = 1});
            }
            catch (Exception ex)
            {
                return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "ServerError", ticketStatus = 1});
            }
        }

        [HttpPost]
        [Route("saveTicketSingle")]
        public async Task<IActionResult> SaveTicketSingle(TourPackage value, string ScheduleList)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string[] ArrayScheduleId = ScheduleList.Split(',');
            List<Schedule> schedules = new List<Schedule>();
            foreach(string item in ArrayScheduleId)
            {
                string urlSchedule = domainServer + "schedule/" + item;
                try
                {
                    ResponseData responseDataSchedule = await _callApi.GetApi(urlSchedule, tokenCustomer);
                    if (!responseDataSchedule.Success)
                    {
                        return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "BookingTourFaild", ticketStatus = 1 });
                    }
                    schedules.Add(JsonConvert.DeserializeObject<Schedule>(responseDataSchedule.Data));
                }
                catch (Exception e)
                {
                    return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "ServerError", ticketStatus = 1 });
                }
            }
            value.ListScheduleTourPackage = JsonConvert.SerializeObject(schedules);
            value = await CreateTourPackageSingle(value);

            if(value == null) return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "BookingTourFaild", ticketStatus = 1 });

            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTourPackage = domainServer + "tourpackage/";
            string url = domainServer + "user/searchUserByUsername/" + usernameAccount;
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenCustomer);
                ResponseData responseDataTourPackage = await _callApi.PostApi(urlTourPackage, JsonConvert.SerializeObject(value), tokenCustomer);
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
                    ResponseData responseDataTicket = await _callApi.PostApi(urlTicket, stringTicket, tokenCustomer);
                    if (responseDataTicket.Success)
                    {
                        return RedirectToAction("History", new { area = "Customer", controller = "HomeCustomer", status = "BookingTourSuccess", ticketStatus =1});
                    }
                    return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "BookingTourFaild", ticketStatus = 1 });
                }
                return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "BookingTourFaild", ticketStatus = 1 });
            }
            catch (Exception ex)
            {
                return RedirectToAction("History", new { area = "Customer", controller = "TourCustomer", status = "ServerError", ticketStatus = 1 });
            }
        }

        public async Task<TourPackage> CreateTourPackageSingle(TourPackage tourPackage)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            tourPackage.Name = RandomName(10);
            tourPackage.CreateBy = "Customer";
            List<Schedule> schedules = new List<Schedule>();
            schedules = JsonConvert.DeserializeObject<List<Schedule>>(tourPackage.ListScheduleTourPackage);
            string urlHotel = domainServer + "hotel/" + tourPackage.HotelId.ToString();
            string urlRestaurant = domainServer + "restaurant/" + tourPackage.RestaurantId.ToString();
            string urlTimePackage = domainServer + "timepackage/" + tourPackage.TimePackageId.ToString();
            try
            {
                ResponseData responseDataHotel = await _callApi.GetApi(urlHotel, tokenCustomer);
                ResponseData responseDataRestaurant = await _callApi.GetApi(urlRestaurant, tokenCustomer);
                ResponseData responseDataTimePackage = await _callApi.GetApi(urlTimePackage, tokenCustomer);
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

        [HttpPost]
        [Route("deleteTicket")]
        public async Task<IActionResult> DeleteTicket(string Id)
        {
            tokenCustomer = HttpContext.Session.GetString("token");
            string url = domainServer + "ticket/" + Id;
            try
            {
                ResponseData response = await _callApi.DeleteApi(url, tokenCustomer);
                if (response.Success)
                {
                    return RedirectToAction("History", new { area = "Customer", controller = "HomeCustomer", status = "DeleteTourSuccess", ticketStatus = 1 });
                }
                else return RedirectToAction("History", new { area = "Customer", controller = "HomeCustomer", status = "DeleteTourFaild", ticketStatus = 1 });
            }
            catch(Exception e)
            {
                return RedirectToAction("History", new { area = "Customer", controller = "HomeCustomer", status = "ServerError", ticketStatus = 1 });
            }
        }

    }
}
