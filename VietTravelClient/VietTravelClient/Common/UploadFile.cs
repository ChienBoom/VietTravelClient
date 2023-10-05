using Microsoft.AspNetCore.Http;
using System.IO;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using VietTravelClient.Controllers;
using VietTravelClient.Models;

namespace VietTravelClient.Common
{
    public class UploadFile
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadFile(ILogger<HomeController> logger, IWebHostEnvironment hostingEnvironment)
        {
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
        }
        public ResponseData SaveFile(IFormFile file)
        {
            ResponseData responseData = new ResponseData();
            if (file != null && file.Length > 0)
            {
                try
                {
                    responseData.Success = true;
                    string fileName = Path.GetFileName(file.FileName);
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "UploadImage");
                    string filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    responseData.Message = fileName;
                    return responseData;
                }
                catch (Exception ex)
                {
                    responseData.Success = false;
                    responseData.Message = ex.Message;
                    return responseData;
                }
            }
            else
            {
                responseData.Success = false;
                responseData.Message = "File null";
                return responseData;
            }
        }
    }
}
