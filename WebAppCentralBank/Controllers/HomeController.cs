using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebAppCentralBank.Models;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Controllers
{
    public class HomeController : Controller
    {
        public void GettingAndRefreshingData()
        {
            ActionGetData businessLogic = new ActionGetData();
            businessLogic.RefreshingDATA();

            ICurrency usdDB = businessLogic.GetUSDDbCurrency();
            ICurrency eurDB = businessLogic.GetEURDbCurrency();
            ICurrency gbpDB = businessLogic.GetGBPDbCurrency();
            ICurrency tryDB = businessLogic.GetTRYDbCurrency();
            ICurrency cnyDB = businessLogic.GetCNYDbCurrency();

            DateTime dateDB = businessLogic.GetDateTime();
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