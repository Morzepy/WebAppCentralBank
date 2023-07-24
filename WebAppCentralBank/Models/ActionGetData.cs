using WebAppCentralBank.Models.Parse;
using WebAppCentralBank.Models.DataBase;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Models
{
    public class ActionGetData
    {
        const string LIKEVALUEUSD = "USD";
        const string LIKEVALUEEUR = "EUR";
        const string LIKEVALUECNY = "CNY";

        public void Action()
        {
            DataBaseContext connection = new DataBaseContext();

            DateTime dateTimeBaseDate = connection.SelectLastRecordDateTime();

            DateTime nowDateTime = DateTime.Now;

            TimeSpan timer = TimeSpan.FromHours(24);

            ///Checking the time data for data parsing
            if (nowDateTime - dateTimeBaseDate > timer)
            {
                Parsing.Updatingdata(connection);
            }
            List<string> listEurDB = GettingListDataCurrency(connection, new EUR(), LIKEVALUEEUR);
            List<string> listCnyDB = GettingListDataCurrency(connection, new CNY(), LIKEVALUECNY);
            List<string> listUsdDB = GettingListDataCurrency(connection, new USD(), LIKEVALUEUSD);

        }
        static List<string> GettingListDataCurrency(DataBaseContext connection, ICurrency currency, string LIKEVALEU)
        {
            var dataBD = connection.SelectLastRecordCurrency(currency, LIKEVALEU);
            return ConvertorList.ConvertListStringCurrency(dataBD);
        }
        
    }
}
