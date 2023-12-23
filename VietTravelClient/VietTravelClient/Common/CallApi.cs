using System.Net.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Threading.Tasks;
using System;
using VietTravelClient.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace VietTravelClient.Common
{
    public class CallApi
    {
        public async Task<ResponseData> GetApi(string url, string token)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await httpClient.GetAsync(url);
                switch(response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        string result = await response.Content.ReadAsStringAsync();
                        responseData.Success = true;
                        responseData.Message = "Success";
                        responseData.Data = result;
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        responseData.Success = false;
                        responseData.Message = "NotFound";
                        responseData.Data = null;
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        responseData.Success = false;
                        responseData.Message = "Unauthorized";
                        responseData.Data = null;
                        break;
                    default:
                        responseData.Success = false;
                        responseData.Message = "BadRequest";
                        responseData.Data = null;
                        break;
                }
                return responseData;
            }
            catch (HttpRequestException e)
            {
                responseData.Success = false;
                responseData.Message = e.Message;
                responseData.Data = null;
                return responseData;
            }
        }

        public async Task<ResponseData> PostApi(string url, string data, string token)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                responseData.Success = true;
                HttpContent content = new StringContent(data, null, "application/json");
                var response = await httpClient.PostAsync(url, content);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        string result = await response.Content.ReadAsStringAsync();
                        responseData.Success = true;
                        responseData.Message = "Success";
                        responseData.Data = result;
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        responseData.Success = false;
                        responseData.Message = "NotFound";
                        responseData.Data = null;
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        responseData.Success = false;
                        responseData.Message = "Unauthorized";
                        responseData.Data = null;
                        break;
                    default:
                        responseData.Success = false;
                        responseData.Message = "BadRequest";
                        responseData.Data = null;
                        break;
                }
                if (response.Headers.TryGetValues("Authorization", out IEnumerable<string> values))
                {
                    responseData.Message = values.FirstOrDefault();
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Success = false;
                responseData.Message = ex.Message;
                responseData.Data = null;
                return responseData;
            }
        }

        public async Task<ResponseData> PutApi(string url, string data, string token)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                responseData.Success = true;
                var content = new StringContent(data, null, "application/json");
                var response = await httpClient.PutAsync(url, content);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        string result = await response.Content.ReadAsStringAsync();
                        responseData.Success = true;
                        responseData.Message = "Success";
                        responseData.Data = result;
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        responseData.Success = false;
                        responseData.Message = "NotFound";
                        responseData.Data = null;
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        responseData.Success = false;
                        responseData.Message = "Unauthorized";
                        responseData.Data = null;
                        break;
                    default:
                        responseData.Success = false;
                        responseData.Message = "BadRequest";
                        responseData.Data = null;
                        break;
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Success = false;
                responseData.Message = ex.Message;
                responseData.Data = null;
                return responseData;
            }
        }

        public async Task<ResponseData> DeleteApi(string url, string token)
        {
            HttpClient httpClient = new HttpClient();
            ResponseData responseData = new ResponseData();
            try
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                responseData.Success = true;
                var response = await httpClient.DeleteAsync(url);
                switch (response.StatusCode)
                {
                    case System.Net.HttpStatusCode.OK:
                        string result = await response.Content.ReadAsStringAsync();
                        responseData.Success = true;
                        responseData.Message = "Success";
                        responseData.Data = result;
                        break;
                    case System.Net.HttpStatusCode.NotFound:
                        responseData.Success = false;
                        responseData.Message = "NotFound";
                        responseData.Data = null;
                        break;
                    case System.Net.HttpStatusCode.Unauthorized:
                        responseData.Success = false;
                        responseData.Message = "Unauthorized";
                        responseData.Data = null;
                        break;
                    default:
                        responseData.Success = false;
                        responseData.Message = "BadRequest";
                        responseData.Data = null;
                        break;
                }
                return responseData;
            }
            catch (Exception ex)
            {
                responseData.Success = false;
                responseData.Message = ex.Message;
                responseData.Data = null;
                return responseData;
            }
        }

    }
}
