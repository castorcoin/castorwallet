using CastorCoinUsingdemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CastorCoinUsingdemo.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        string API_Key = ConfigurationManager.AppSettings["API_Key"].ToString();
        string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();
        string UrlAddress = ConfigurationManager.AppSettings["UrlAddress"].ToString();
        Encryption obj = new Encryption();

        public async Task<string> VerifyEmailAndGetOtp()
        {
            
            string UrlParameters = obj.Encrypt("Email=test654321@gmail.com", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Account/VerifyEmailAndGetOtp?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Account/VerifyEmailAndGetOtp?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> ResendOtp()
        {
            string UrlParameters = obj.Encrypt("Email=test654321@gmail.com", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Account/ResendOtp?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Account/ResendOtp?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> VerifyOtp()
        {
            string UrlParameters = obj.Encrypt("Email=test654321@gmail.com&Otp=33AB50F", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Account/VerifyOtp?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Account/VerifyOtp?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> SetPassword()
        {
            string UrlParameters = obj.Encrypt("Email=test654321@gmail.com&Password=Test@123&API_Key="+ API_Key, EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Account/SetPassword?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Account/SetPassword?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }
    }
}