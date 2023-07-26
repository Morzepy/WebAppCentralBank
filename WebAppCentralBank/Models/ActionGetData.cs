using WebAppCentralBank.Models;
using WebAppCentralBank.Models.Parse;
using WebAppCentralBank.Models.DataBase;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Models
{
    public class ModelGetData
    {
        private const string LIKEVALUEUSD = "USD";
        private const string LIKEVALUEEUR = "EUR";
        private const string LIKEVALUEGBP = "GBP";
        private const string LIKEVALUETRY = "TRY";
        private const string LIKEVALUECNY = "CNY";
        
        public void RefreshingDATA()
        {
            DataBaseContext connection = new DataBaseContext();

            DateTime dateTimeBaseDate = connection.SelectLastRecordDateTime();

            DateTime nowDateTime = DateTime.Now;

            TimeSpan timer;
            if (nowDateTime.DayOfWeek == DayOfWeek.Saturday)
            {
                timer = TimeSpan.FromDays(2);
            }
            else if (nowDateTime.DayOfWeek == DayOfWeek.Sunday)
            {
                timer = TimeSpan.FromDays(3);
            }
            else if (nowDateTime.DayOfWeek == DayOfWeek.Monday)
            {
                timer = TimeSpan.FromDays(4);
            }
            else
            {
                timer = TimeSpan.FromDays(1);
            }

            ///Checking the time data for data parsing
            if (nowDateTime - dateTimeBaseDate > timer)
            {
                Parsing.WritingData(connection);
            }

        }

        /// <summary>
        /// Getting DateTime data from the database
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime GetDateTime()
        {
            DataBaseContext connection = new DataBaseContext(); ;
            DateTime dateTimeBaseDate = connection.SelectLastRecordDateTime();
            return dateTimeBaseDate;
        }

        /// <summary>
        /// Getting ICurrency USD data from the database
        /// </summary>
        /// <returns>ICurrency</returns>
        public ICurrency GetUSDDbCurrency()
        {
            var usdDB = DBcurrency(new USD(), LIKEVALUEUSD);
            return usdDB;
        }

        /// <summary>
        /// Getting ICurrency EUR data from the database
        /// </summary>
        /// <returns>ICurrency</returns>
        public ICurrency GetEURDbCurrency()
        {
            var eurDB = DBcurrency(new EUR(), LIKEVALUEEUR);
            return eurDB;
        }

        /// <summary>
        /// Getting ICurrency GBP data from the database
        /// </summary>
        /// <returns>ICurrency</returns>
        public ICurrency GetGBPDbCurrency()
        {
            var gbpDB = DBcurrency(new GBP(), LIKEVALUEGBP);
            return gbpDB;

        }

        /// <summary>
        /// Getting ICurrency TRY data from the database
        /// </summary>
        /// <returns>ICurrency</returns>
        public ICurrency GetTRYDbCurrency()
        {
            var tryDB = DBcurrency(new TRY(), LIKEVALUETRY);
            return tryDB;

        }

        /// <summary>
        /// Getting ICurrency CNY data from the database
        /// </summary>
        /// <returns>ICurrency</returns>
        public ICurrency GetCNYDbCurrency()
        {
            var cnyDB = DBcurrency(new CNY(), LIKEVALUECNY);
            return cnyDB;

        }

        /// <summary>
        /// Selecting a currency from the database
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="LIKEVALUE"></param>
        /// <returns>ICurrency</returns>
        static private ICurrency DBcurrency(ICurrency currency, string LIKEVALUE)
        {
            DataBaseContext connection = new DataBaseContext();
            var dataBD = connection.SelectLastRecordCurrency(currency, LIKEVALUE);
            return dataBD;
        }
        
    }
}
