using Newtonsoft.Json;
using System.Net;
using WebAppCentralBank.Models.Parse;
using WebAppCentralBank.Models.DataBase;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Models
{
    static class Parsing
    {
        private const string PATHJSONCBRF = "https://www.cbr-xml-daily.ru/daily_json.js";

        /// <summary>
        /// Parsing of exchange rate data from the Central Bank
        /// </summary>
        /// <returns>string</returns>
        static private string GetJsonCBRF()
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
        static private void SaveJsonCBRF(string fileName, string json)
        {
            File.WriteAllText(fileName, json);
        }

        /// <summary>
        /// Writing data to the database
        /// </summary>
        /// <param name="connection"></param>
        static public void WritingData(DataBaseContext connection)
        {
            string js = GetJsonCBRF();
            string fileName = "JsonCBRF.json";
            SaveJsonCBRF(fileName, js);

            Root centralBankJsonDeserialized = JsonConvert.DeserializeObject<Root>(js);

            DateTime jsonTime = Convert.ToDateTime(centralBankJsonDeserialized?.Date);

            USD usdJson = new USD(centralBankJsonDeserialized.Valute.USD.NumCode,
                                  centralBankJsonDeserialized.Valute.USD.CharCode,
                                  centralBankJsonDeserialized.Valute.USD.Nominal,
                                  centralBankJsonDeserialized.Valute.USD.Name,
                                  centralBankJsonDeserialized.Valute.USD.Value,
                                  centralBankJsonDeserialized.Valute.USD.Previous);

                EUR eurJson = new EUR(centralBankJsonDeserialized.Valute.EUR.NumCode,
                                  centralBankJsonDeserialized.Valute.EUR.CharCode,
                                  centralBankJsonDeserialized.Valute.EUR.Nominal,
                                  centralBankJsonDeserialized.Valute.EUR.Name,
                                  centralBankJsonDeserialized.Valute.EUR.Value,
                                  centralBankJsonDeserialized.Valute.EUR.Previous);

                GBP gbpJson = new GBP(centralBankJsonDeserialized.Valute.GBP.NumCode,
                                  centralBankJsonDeserialized.Valute.GBP.CharCode,
                                  centralBankJsonDeserialized.Valute.GBP.Nominal,
                                  centralBankJsonDeserialized.Valute.GBP.Name,
                                  centralBankJsonDeserialized.Valute.GBP.Value,
                                  centralBankJsonDeserialized.Valute.GBP.Previous);

                TRY tryJson = new TRY(centralBankJsonDeserialized.Valute.TRY.NumCode,
                                  centralBankJsonDeserialized.Valute.TRY.CharCode,
                                  centralBankJsonDeserialized.Valute.TRY.Nominal,
                                  centralBankJsonDeserialized.Valute.TRY.Name,
                                  centralBankJsonDeserialized.Valute.TRY.Value,
                                  centralBankJsonDeserialized.Valute.TRY.Previous);

                CNY cnyJson = new CNY(centralBankJsonDeserialized.Valute.CNY.NumCode,
                                  centralBankJsonDeserialized.Valute.CNY.CharCode,
                                  centralBankJsonDeserialized.Valute.CNY.Nominal,
                                  centralBankJsonDeserialized.Valute.CNY.Name,
                                  centralBankJsonDeserialized.Valute.CNY.Value,
                                  centralBankJsonDeserialized.Valute.CNY.Previous);

                connection.InsertRecordValute(jsonTime, usdJson.NumCode, usdJson.CharCode, usdJson.Nominal, usdJson.Name,
                    usdJson.Value, usdJson.Previous);

                connection.InsertRecordValute(jsonTime, eurJson.NumCode, eurJson.CharCode, eurJson.Nominal, eurJson.Name,
                    eurJson.Value, eurJson.Previous);

                connection.InsertRecordValute(jsonTime, gbpJson.NumCode, gbpJson.CharCode, gbpJson.Nominal, gbpJson.Name,
                    gbpJson.Value, gbpJson.Previous);

                connection.InsertRecordValute(jsonTime, tryJson.NumCode, tryJson.CharCode, tryJson.Nominal, tryJson.Name,
                    tryJson.Value, tryJson.Previous);

                connection.InsertRecordValute(jsonTime, cnyJson.NumCode, cnyJson.CharCode, cnyJson.Nominal, cnyJson.Name,
                    cnyJson.Value, cnyJson.Previous);
        }
        
    }
}
