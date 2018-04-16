using CastorCoinUsingdemo.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CastorCoinUsingdemo.Controllers
{
    public class WalletController : Controller
    {
        string API_Key = ConfigurationManager.AppSettings["API_Key"].ToString();
        string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();
        string UrlAddress = ConfigurationManager.AppSettings["UrlAddress"].ToString();
        Encryption obj = new Encryption();
        public ActionResult Index()
        {
            return View();
        }

        public async Task<string> GetWalletList()
        {
            string UrlParameters = obj.Encrypt("Email=test123@gmail.com", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Wallet/GetWalletList?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);
            
            HttpResponseMessage response = client.PostAsync(UrlAddress + "Wallet/GetWalletList?" + UrlParameters,null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> AddWallet()
        {
            string UrlParameters = obj.Encrypt("Email=test123@gmail.com&AccountName=Test&IsDefault=true", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Wallet/AddWallet?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Wallet/AddWallet?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> RequestWalletAddress()
        {
            string UrlParameters = obj.Encrypt("Email=test123@gmail.com&AccountId=17", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Wallet/RequestWalletAddress?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Wallet/RequestWalletAddress?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> SendCoin()
        {
            string UrlParameters = obj.Encrypt("Email=test123@gmail.com&AccountId=17&AccountNumber=CA1EA907A3444DA5B81B459C8D936E5C&CoinAmount=10&USDAmount=600&Description=test", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Wallet/SendCoin?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Wallet/SendCoin?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> GetCastorRate()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Wallet/GetCastorRate");
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.GetAsync(UrlAddress + "Wallet/GetCastorRate").Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

    }
}