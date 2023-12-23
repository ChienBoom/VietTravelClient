using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using VietTravelClient.Common;
using VietTravelClient.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using VietTravelClient.Controllers;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using UnidecodeSharpCore;
using static Microsoft.EntityFrameworkCore.Internal.AsyncLock;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using OfficeOpenXml;

namespace VietTravelClient.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("/admin")]
    public class ReportAdminController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CallApi _callApi;
        private readonly UploadFile _uploadFile;
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly string domainServer;
        private readonly string uploadPath;
        private string tokenAdmin;

        public ReportAdminController(ILogger<HomeController> logger, CallApi callApi, IConfiguration configuration, UploadFile uploadFile, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _callApi = callApi;
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            domainServer = _configuration["DomainServer"];
            uploadPath = _configuration["UploadPath"];
            _uploadFile = uploadFile;
        }

        [HttpGet]
        [Route("revenueMonthReport")]
        public async Task<IActionResult> RevenueMonthReport()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    var wwwrootPath = _hostingEnvironment.WebRootPath;
                    string excelFileName = UpdateDataReport("Bao_cao_thong_ke_doanh_thu_theo_thang.xlsx", revenue, 1, "Bao_cao_thong_ke_doanh_thu_theo_thang");
                    string excelFilePath = Path.Combine(wwwrootPath,"ReportExcelOutput", excelFileName);
                    byte[] fileBytes = System.IO.File.ReadAllBytes(excelFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("revenueCityReport")]
        public async Task<IActionResult> RevenueCityReport()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    var wwwrootPath = _hostingEnvironment.WebRootPath;
                    string excelFileName = UpdateDataReport("Bao_cao_thong_ke_doanh_thu_theo_thanh_pho.xlsx", revenue, 1, "Bao_cao_thong_ke_doanh_thu_theo_thanh_pho");
                    string excelFilePath = Path.Combine(wwwrootPath, "ReportExcelOutput", excelFileName);
                    byte[] fileBytes = System.IO.File.ReadAllBytes(excelFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("revenueTourReport")]
        public async Task<IActionResult> RevenueTourReport()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    var wwwrootPath = _hostingEnvironment.WebRootPath;
                    string excelFileName = UpdateDataReport("Bao_cao_thong_ke_doanh_thu_theo_tour.xlsx", revenue, 1, "Bao_cao_thong_ke_doanh_thu_theo_tour");
                    string excelFilePath = Path.Combine(wwwrootPath, "ReportExcelOutput", excelFileName);
                    byte[] fileBytes = System.IO.File.ReadAllBytes(excelFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("visitorMonthReport")]
        public async Task<IActionResult> VisitorMonthReport()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    var wwwrootPath = _hostingEnvironment.WebRootPath;
                    string excelFileName = UpdateDataReport("Bao_cao_thong_ke_so_luot_khach_theo_thang.xlsx", revenue, 2, "Bao_cao_thong_ke_so_luot_khach_theo_thang");
                    string excelFilePath = Path.Combine(wwwrootPath, "ReportExcelOutput", excelFileName);
                    byte[] fileBytes = System.IO.File.ReadAllBytes(excelFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("visitorCityReport")]
        public async Task<IActionResult> VisitorCityReport()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    var wwwrootPath = _hostingEnvironment.WebRootPath;
                    string excelFileName = UpdateDataReport("Bao_cao_thong_ke_so_luot_khach_theo_thanh_pho.xlsx", revenue, 2, "Bao_cao_thong_ke_so_luot_khach_theo_thanh_pho");
                    string excelFilePath = Path.Combine(wwwrootPath, "ReportExcelOutput", excelFileName);
                    byte[] fileBytes = System.IO.File.ReadAllBytes(excelFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        [HttpGet]
        [Route("visitorTourReport")]
        public async Task<IActionResult> VisitorTourReport()
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour";
            try
            {
                ResponseData responseData = await _callApi.GetApi(url, tokenAdmin);
                if (responseData.Success)
                {
                    Revenue revenue = JsonConvert.DeserializeObject<Revenue>(responseData.Data);
                    var wwwrootPath = _hostingEnvironment.WebRootPath;
                    string excelFileName = UpdateDataReport("Bao_cao_thong_ke_so_luot_khach_theo_tour.xlsx", revenue, 2, "Bao_cao_thong_ke_so_luot_khach_theo_tour");
                    string excelFilePath = Path.Combine(wwwrootPath, "ReportExcelOutput", excelFileName);
                    byte[] fileBytes = System.IO.File.ReadAllBytes(excelFilePath);
                    return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", excelFileName);
                }
                else return RedirectToAction("Error", "HomeAdmin");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "HomeAdmin");
            }
        }

        public string UpdateDataReport(string excelNameTemp, Revenue revenue, int status, string name)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            var wwwrootPath = _hostingEnvironment.WebRootPath;
            var templateFilePath = Path.Combine(wwwrootPath, "ReportExcelTemp", excelNameTemp);
            if (!System.IO.File.Exists(templateFilePath))
            {
                return "NotFound";
            }
            var excelFolderPath = Path.Combine(wwwrootPath, "ReportExcelOutput");
            if (!Directory.Exists(excelFolderPath))
            {
                Directory.CreateDirectory(excelFolderPath);
            }
            var excelFileName = $"{name}_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.xlsx";
            var excelFilePath = Path.Combine(excelFolderPath, excelFileName);
            using (var templatePackage = new ExcelPackage(new FileInfo(templateFilePath)))
            {
                var templateWorksheet = templatePackage.Workbook.Worksheets[0];

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Sheet1");

                    for (int row = 1; row <= templateWorksheet.Dimension.Rows; row++)
                    {
                        for (int col = 1; col <= templateWorksheet.Dimension.Columns; col++)
                        {
                            var cellValue = templateWorksheet.Cells[row, col].Value;
                            worksheet.Cells[row, col].Value = cellValue;
                        }
                    }

                    int startRow = 5;
                    int startColumn = 2;


                    for (int i = 0; i < revenue.Labels.Count; i++)
                    {
                        List<Ticket> lstTicket = revenue.Data[i];
                        string labelItem = revenue.Labels[i];
                        string sumData = "";
                        switch (status)
                        {
                            case 1:
                                decimal sumRevenue = 0;
                                foreach(Ticket item in lstTicket)
                                {
                                    sumRevenue += item.TourPackage.LastPrice;
                                }
                                sumData = sumRevenue.ToString("N2");
                                break;
                            case 2:
                                int sumPeople = 0;
                                foreach (Ticket item in lstTicket)
                                {
                                    sumPeople += item.TourPackage.NumberOfAdult + item.TourPackage.NumberOfChildren;
                                }
                                sumData = sumPeople.ToString();
                                break;
                        }
                        worksheet.Cells[startRow + i, startColumn].Value = i;
                        worksheet.Cells[startRow + i, startColumn + 1].Value = labelItem;
                        worksheet.Cells[startRow + i, startColumn + 2].Value = sumData;
                    }

                    package.SaveAs(new FileInfo(excelFilePath));
                }
            }
            return excelFileName;
        }

    }
}
