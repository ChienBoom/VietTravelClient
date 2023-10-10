﻿using Microsoft.AspNetCore.Mvc;
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
using System.Net.Http;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class TourAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly string domailServer;
        private readonly string uploadPath;

        public TourAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

        [HttpGet]
        [Route("addTour")]
        public async Task<IActionResult> AddTour()
        {
            string url = domailServer + "city";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url);
                if (responseData.Success)
                {
                    ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseData.Data);
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

        [HttpGet]
        [Route("tourManager")]
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

        [HttpPost]
        [Route("searchTour")]
        public async Task<IActionResult> SearchTour(string searchValue, string UsernameAccount)
        {
            if(!searchValue.Trim().Equals("") || searchValue != null)
            {
                string url = domailServer + "tour/search/" + searchValue;
                List<Tour> tours = new List<Tour>();
                try
                {
                    ResponseData responseData = await _callApi.GetApi(url);
                    string result = responseData.Data;
                    tours = JsonConvert.DeserializeObject<List<Tour>>(result);
                    ViewData["UsernameAccount"] = UsernameAccount;
                    ViewData["Tours"] = tours;
                    return View();
                }
                catch (Exception e)
                {
                    return View();
                }
            }
            return RedirectToAction("TourManager");
        }

        [HttpPost]
        [Route("saveTour")]
        public async Task<IActionResult> CreateTour(Tour value, IFormFile file)
        {
            string url = domailServer + "tour";
            Tour Tour = new Tour();
            if (!_uploadFile.SaveFile(file).Success) return RedirectToAction("Error", "HomeAdmin");
            value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PostApi(url, stringValue);
                Tour = JsonConvert.DeserializeObject<Tour>(responseData.Data);
                return RedirectToAction("TourManager");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpGet]
        [Route("tourInfo")]
        public async Task<IActionResult> TourInfo(long tourId)
        {
            string urlCities = domailServer + "city";
            string urlTour = domailServer + "tour/" + tourId.ToString();
            Tour tour = new Tour();
            try
            {
                ResponseData responseDataCities = await _callApi.GetApi(urlCities);
                ResponseData response = await _callApi.GetApi(urlTour);
                string result = response.Data;
                tour.Pictures = uploadPath + tour.Pictures;
                tour = JsonConvert.DeserializeObject<Tour>(result);
                ViewData["Cities"] = JsonConvert.DeserializeObject<List<City>>(responseDataCities.Data);
                ViewData["Tour"] = tour;
                return View();
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpPost]
        [Route("updateTour")]
        public async Task<IActionResult> UpdateTour(Tour value, IFormFile file)
        {
            string url = domailServer + "tour/" + value.Id.ToString();
            Tour city = new Tour();
            if (!_uploadFile.SaveFile(file).Success)
            {
                value.Pictures = "File null";
            }
            else value.Pictures = _uploadFile.SaveFile(file).Message;
            try
            {
                string stringValue = JsonConvert.SerializeObject(value);
                ResponseData responseData = await _callApi.PutApi(url, stringValue);
                city = JsonConvert.DeserializeObject<Tour>(responseData.Data);
                return RedirectToAction("TourManager");
            }
            catch (HttpRequestException e)
            {
                return View();
            }
        }

        [HttpGet]
        [Route("TourById")]
        public async Task<IActionResult> GetTourById(long id)
        {
            string url = domailServer + "Tour/" + id.ToString();
            Tour Tour = new Tour();
            try
            {
                ResponseData response = await _callApi.GetApi(url);
                string result = response.Data;
                Tour = JsonConvert.DeserializeObject<Tour>(result);
                return View();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

        [HttpPost]
        [Route("deleteTour")]
        public async Task<IActionResult> DeleteTour(string TourId)
        {
            string url = domailServer + "tour/" + TourId;
            try
            {
                ResponseData responseData = await _callApi.DeleteApi(url);
                return RedirectToAction("TourManager");
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"HttpRequestException: {e.Message}");
                return View();
            }
        }

    }
}
