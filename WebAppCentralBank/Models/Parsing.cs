using Newtonsoft.Json;
using System.Net;
using WebAppCentralBank.Models.Parse;
using WebAppCentralBank.Models.DataBase;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Models
{
    static class Parsing
    {
        const string PATHJSONCBRF = "https://www.cbr-xml-daily.ru/daily_json.js";


        /// <summary>
        /// Parsing of exchange rate data from the Central Bank
        /// </summary>
        /// <returns>string</returns>
        static string GetJsonCBRF()
        {
            try
            {
                using WebClient client = new WebClient();
                var json = client.DownloadString(PATHJSONCBRF);
                return json;
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// Saving a json file in the project directory
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="json"></param>
        static void SaveJsonCBRF(string fileName, string json)
        {
            File.WriteAllText(fileName, json);
        }


        static public void Updatingdata(DataBaseContext connection)
        {

            string js = GetJsonCBRF();
            string fileName = "JsonCBRF.json";
            SaveJsonCBRF(fileName, js);

            Root centralBankJsonDeserialized = JsonConvert.DeserializeObject<Root>(js);

            DateTime jsonTime = Convert.ToDateTime(centralBankJsonDeserialized?.Date);

            USD usd = new USD()
            {
                NumCode = centralBankJsonDeserialized.Valute.USD.NumCode,
                CharCode = centralBankJsonDeserialized.Valute.USD.CharCode,
                Nominal = centralBankJsonDeserialized.Valute.USD.Nominal,
                Name = centralBankJsonDeserialized.Valute.USD.Name,
                Value = centralBankJsonDeserialized.Valute.USD.Value,
                Previous = centralBankJsonDeserialized.Valute.USD.Previous
            };

            EUR eur = new EUR()
            {
                NumCode = centralBankJsonDeserialized.Valute.EUR.NumCode,
                CharCode = centralBankJsonDeserialized.Valute.EUR.CharCode,
                Nominal = centralBankJsonDeserialized.Valute.EUR.Nominal,
                Name = centralBankJsonDeserialized.Valute.EUR.Name,
                Value = centralBankJsonDeserialized.Valute.EUR.Value,
                Previous = centralBankJsonDeserialized.Valute.EUR.Previous
            };

            CNY cny = new CNY()
            {
                NumCode = centralBankJsonDeserialized.Valute.CNY.NumCode,
                CharCode = centralBankJsonDeserialized.Valute.CNY.CharCode,
                Nominal = centralBankJsonDeserialized.Valute.CNY.Nominal,
                Name = centralBankJsonDeserialized.Valute.CNY.Name,
                Value = centralBankJsonDeserialized.Valute.CNY.Value,
                Previous = centralBankJsonDeserialized.Valute.CNY.Previous
            };

            connection.InsertRecordValute(jsonTime, usd.NumCode, usd.CharCode, usd.Nominal, usd.Name,
                usd.Value, usd.Previous);

            connection.InsertRecordValute(jsonTime, eur.NumCode, eur.CharCode, eur.Nominal, eur.Name,
                eur.Value, eur.Previous);

            connection.InsertRecordValute(jsonTime, cny.NumCode, cny.CharCode, cny.Nominal, cny.Name,
                cny.Value, cny.Previous);

        }
    }
}
