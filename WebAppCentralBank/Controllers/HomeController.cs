using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppCentralBank.Models;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// GettingAndRefreshingData
        /// </summary>
        private void GettingAndRefreshingData()
        {
            ModelGetData modelGetData = new ModelGetData();
            modelGetData.RefreshingDATA();

            ICurrency usdDB = modelGetData.GetUSDDbCurrency();
            ICurrency eurDB = modelGetData.GetEURDbCurrency();
            ICurrency gbpDB = modelGetData.GetGBPDbCurrency();
            ICurrency tryDB = modelGetData.GetTRYDbCurrency();
            ICurrency cnyDB = modelGetData.GetCNYDbCurrency();

            DateTime dateDB = modelGetData.GetDateTime();
            ViewBag.date = dateDB;

            ViewBag.usdCharCode = usdDB.CharCode;
            ViewBag.usdNominal = usdDB.Nominal;
            ViewBag.usdName = usdDB.Name;
            ViewBag.usdValue = usdDB.Value;
            ViewBag.usdChange = usdDB.Value - usdDB.Previous;

            ViewBag.eurCharCode = eurDB.CharCode;
            ViewBag.eurNominal = eurDB.Nominal;
            ViewBag.eurName = eurDB.Name;
            ViewBag.eurValue = eurDB.Value;
            ViewBag.eurChange = eurDB.Value - eurDB.Previous;

            ViewBag.gbpCharCode = gbpDB.CharCode;
            ViewBag.gbpNominal = gbpDB.Nominal;
            ViewBag.gbpName = gbpDB.Name;
            ViewBag.gbpValue = gbpDB.Value;
            ViewBag.gbpChange = gbpDB.Value - gbpDB.Previous;

            ViewBag.tryCharCode = tryDB.CharCode;
            ViewBag.tryNominal = tryDB.Nominal;
            ViewBag.tryName = tryDB.Name;
            ViewBag.tryValue = tryDB.Value;
            ViewBag.tryChange = tryDB.Value - tryDB.Previous;

            ViewBag.cnyCharCode = cnyDB.CharCode;
            ViewBag.cnyNominal = cnyDB.Nominal;
            ViewBag.cnyName = cnyDB.Name;
            ViewBag.cnyValue = cnyDB.Value;
            ViewBag.cnyChange = cnyDB.Value - cnyDB.Previous;
        }
        public IActionResult Index()
        {

            GettingAndRefreshingData();
            return View();
        }
        protected void Button_Click(object sender, EventArgs e)
        {
            GettingAndRefreshingData();
            View();
        }
    }
}