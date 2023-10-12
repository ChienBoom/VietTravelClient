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
        private readonly string domailServer;
        private readonly string uploadPath;

        public TourPackageAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            domailServer = _configuration["DomainServer"];
            _uploadFile = uploadFile;
            uploadPath = _configuration["UploadPath"];
        }

        [HttpGet]
        [Route("addTourPackage")]
        public async Task<IActionResult> AddTourPackage()
        {
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string urlTours = domailServer + "tour";
            string urlHotels = domailServer + "hotel";
            string urlTimePackage = domailServer + "timepackage";
            try
            {
                ResponseData responseDataTours = await _callApi.GetApi(urlTours);
                ResponseData responseDataHotels = await _callApi.GetApi(urlHotels);
                ResponseData responseDataTimePackages = await _callApi.GetApi(urlTimePackage);
                if (responseDataTours.Success && responseDataHotels.Success)
                {
                    ViewData["Tours"] = JsonConvert.DeserializeObject<List<Tour>>(responseDataTours.Data);
                    ViewData["Hotels"] = JsonConvert.DeserializeObject<List<Hotel>>(responseDataHotels.Data);
                    ViewData["TimePackages"] = JsonConvert.DeserializeObject<List<TimePackage>>(responseDataTimePackages.Data);
                    ViewData["UsernameAccount"] = usernameAccount;
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

    }
}
