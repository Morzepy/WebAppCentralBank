using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Models.Parse
{
    static class ConvertorList
    {
        static public List<string> ConvertListStringCurrency(ICurrency currency)
        {
            List<string> listCurrency = new List<string>();
            listCurrency.Add(currency.dateTimeDB.ToString());
            listCurrency.Add(";");
            listCurrency.Add(currency.NumCode.ToString());
            listCurrency.Add(";");
            listCurrency.Add(currency.CharCode.ToString());
            listCurrency.Add(";");
            listCurrency.Add(currency.Nominal.ToString());
            listCurrency.Add(";");
            listCurrency.Add(currency.Name.ToString());
            listCurrency.Add(";");
            listCurrency.Add(currency.Value.ToString());
            listCurrency.Add(";");
            listCurrency.Add(currency.Previous.ToString());
            return listCurrency;
        }
    }
}
