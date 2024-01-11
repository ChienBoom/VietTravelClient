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
using OfficeOpenXml.Style;

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
        [Route("revenueMonthReport/{yearValue}")]
        public async Task<IActionResult> RevenueMonthReport(string yearValue)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth/" + yearValue; ;
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
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("revenueCityReport/{yearValue}")]
        public async Task<IActionResult> RevenueCityReport(string yearValue)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity/" + yearValue;
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
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("revenueTourReport/{yearValue}")]
        public async Task<IActionResult> RevenueTourReport(string yearValue)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour/" + yearValue;
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
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("visitorMonthReport/{yearValue}")]
        public async Task<IActionResult> VisitorMonthReport(string yearValue)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticMonth/" + yearValue;
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
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("visitorCityReport/{yearValue}")]
        public async Task<IActionResult> VisitorCityReport(string yearValue)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticCity/" + yearValue;
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
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
        }

        [HttpGet]
        [Route("visitorTourReport/{yearValue}")]
        public async Task<IActionResult> VisitorTourReport(string yearValue)
        {
            tokenAdmin = HttpContext.Session.GetString("token");
            if (HttpContext.Session.GetString("UsernameAccount") == null) return RedirectToAction("Login", "Login");
            string usernameAccount = HttpContext.Session.GetString("UsernameAccount");
            string url = domainServer + "revenueStatistics/revenueStatisticTour/" + yearValue;
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
                else return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", new { area = "Admin", controller = "HomeAdmin" });
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

                            //Cau hinh do rong, font chu va co chu
                            worksheet.Column(col).Width = templateWorksheet.Column(col).Width;
                            worksheet.Cells[row, col].Style.Font.Name = templateWorksheet.Cells[row, col].Style.Font.Name;
                            worksheet.Cells[row, col].Style.Font.Size = templateWorksheet.Cells[row, col].Style.Font.Size;
                            //worksheet.Cells[row, col].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                            //worksheet.Cells[row, col].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
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
                                worksheet.Cells[4, 2].Value = "STT";
                                worksheet.Cells[4, 3].Value = revenue.Label;
                                worksheet.Cells[4, 4].Value = "Doanh Thu (VNĐ)";

                                worksheet.Cells[4, 2].Style.Font.Name = "Times New Roman";
                                worksheet.Cells[4, 3].Style.Font.Name = "Times New Roman";
                                worksheet.Cells[4, 4].Style.Font.Name = "Times New Roman";

                                worksheet.Cells[4, 2].Style.Font.Size = 14;
                                worksheet.Cells[4, 3].Style.Font.Size = 14;
                                worksheet.Cells[4, 4].Style.Font.Size = 14;

                                worksheet.Cells[4, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                worksheet.Cells[4, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                worksheet.Cells[4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                worksheet.Cells[4, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                worksheet.Cells[4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                worksheet.Cells[4, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                worksheet.Cells[4, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[4, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                worksheet.Cells[4, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[4, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                worksheet.Cells[4, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[4, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                break;
                            case 2:
                                int sumPeople = 0;
                                foreach (Ticket item in lstTicket)
                                {
                                    sumPeople += item.TourPackage.NumberOfAdult + item.TourPackage.NumberOfChildren;
                                }
                                sumData = sumPeople.ToString();
                                worksheet.Cells[4, 2].Value = "STT";
                                worksheet.Cells[4, 3].Value = revenue.Label;
                                worksheet.Cells[4, 4].Value = "Lượt Khách (Người)";

                                worksheet.Cells[4, 2].Style.Font.Name = "Times New Roman";
                                worksheet.Cells[4, 3].Style.Font.Name = "Times New Roman";
                                worksheet.Cells[4, 4].Style.Font.Name = "Times New Roman";

                                worksheet.Cells[4, 2].Style.Font.Size = 14;
                                worksheet.Cells[4, 3].Style.Font.Size = 14;
                                worksheet.Cells[4, 4].Style.Font.Size = 14;

                                worksheet.Cells[4, 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                worksheet.Cells[4, 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                worksheet.Cells[4, 3].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                worksheet.Cells[4, 3].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                                worksheet.Cells[4, 4].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                                worksheet.Cells[4, 4].Style.VerticalAlignment = ExcelVerticalAlignment.Center;

                                worksheet.Cells[4, 2].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[4, 2].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                worksheet.Cells[4, 3].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[4, 3].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                worksheet.Cells[4, 4].Style.Fill.PatternType = ExcelFillStyle.Solid;
                                worksheet.Cells[4, 4].Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Green);
                                break;
                        }
                        worksheet.Cells[startRow + i, startColumn].Value = i+1;
                        worksheet.Cells[startRow + i, startColumn + 1].Value = labelItem;
                        worksheet.Cells[startRow + i, startColumn + 2].Value = sumData;
                        worksheet.Cells[startRow + i, startColumn].Style.Font.Name = "Times New Roman";
                        worksheet.Cells[startRow + i, startColumn + 1].Style.Font.Name = "Times New Roman";
                        worksheet.Cells[startRow + i, startColumn + 2].Style.Font.Name = "Times New Roman";
                        worksheet.Cells[startRow + i, startColumn].Style.Font.Size = 14;
                        worksheet.Cells[startRow + i, startColumn + 1].Style.Font.Size = 14;
                        worksheet.Cells[startRow + i, startColumn + 2].Style.Font.Size = 14;
                        worksheet.Cells[startRow + i, startColumn].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[startRow + i, startColumn].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells[startRow + i, startColumn + 1].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[startRow + i, startColumn + 1].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                        worksheet.Cells[startRow + i, startColumn + 2].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                        worksheet.Cells[startRow + i, startColumn + 2].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                    }

                    package.SaveAs(new FileInfo(excelFilePath));
                }
            }
            return excelFileName;
        }

    }
}
