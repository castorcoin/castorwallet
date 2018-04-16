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
    public class TransactionController : Controller
    {
        // GET: Transaction
        string API_Key = ConfigurationManager.AppSettings["API_Key"].ToString();
        string EncryptionKey = ConfigurationManager.AppSettings["EncryptionKey"].ToString();
        string UrlAddress = ConfigurationManager.AppSettings["UrlAddress"].ToString();
        Encryption obj = new Encryption();

        public async Task<string> GetTransactionHistory()
        {
            //
            string UrlParameters = obj.Encrypt("Email=test123@gmail.com", EncryptionKey);
            HttpClient client = new HttpClient();
            //
            client.BaseAddress = new Uri(UrlAddress + "Transaction/GetTransactionHistory?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Transaction/GetTransactionHistory?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> GetTransactionHistoryByAccountNumber()
        {
            string UrlParameters = obj.Encrypt("AccountNumber=CA1EA907A3444DA5B81B459C8D936E5C", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Transaction/GetTransactionHistoryByAccountNumber?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Transaction/GetTransactionHistoryByAccountNumber?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }

        public async Task<string> GetTransactionAmountByAccountNumber()
        {
            string UrlParameters = obj.Encrypt("AccountNumber=CA1EA907A3444DA5B81B459C8D936E5C", EncryptionKey);
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(UrlAddress + "Transaction/GetTransactionAmountByAccountNumber?" + UrlParameters);
            client.DefaultRequestHeaders.Add("API_KEY", API_Key);

            HttpResponseMessage response = client.PostAsync(UrlAddress + "Transaction/GetTransactionAmountByAccountNumber?" + UrlParameters, null).Result;
            var customerJsonString = await response.Content.ReadAsStringAsync();
            return customerJsonString;
        }
    }
}