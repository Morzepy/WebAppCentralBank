using Npgsql;
using WebAppCentralBank.Models.Parse.JsonObject;

namespace WebAppCentralBank.Models.DataBase
{
    public class DataBaseContext
    {
        const string DBCONNECTIONSTRING = "Server=localhost;Port=5432;User Id=postgres;Password=rootroot;Database=appCBank";
        private NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(DBCONNECTIONSTRING);
        }

        /// <summary>
        /// Writing all currency data to the database
        /// </summary>
        /// <param name="Date"></param>
        /// <param name="NumCode"></param>
        /// <param name="CharCode"></param>
        /// <param name="Nominal"></param>
        /// <param name="Name"></param>
        /// <param name="Value"></param>
        /// <param name="Previous"></param>
        public void InsertRecordValute(DateTime Date, int NumCode, string CharCode,
            int Nominal, string Name, decimal Value, decimal Previous)
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                string query = @"insert into public.""Currency"" (date,numcode,charcode,nominal,name,value,previous) values(@Date,
                    @NumCode,@CharCode, @Nominal,@Name,@Value,@Previous)";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("Date", Date);
                cmd.Parameters.AddWithValue("NumCode", NumCode);
                cmd.Parameters.AddWithValue("CharCode", CharCode);
                cmd.Parameters.AddWithValue("Nominal", Nominal);
                cmd.Parameters.AddWithValue("Name", Name);
                cmd.Parameters.AddWithValue("Value", Value);
                cmd.Parameters.AddWithValue("Previous", Previous);

                connection.Open();
                int n = cmd.ExecuteNonQuery();
                if (n == 1)
                {
                    Console.WriteLine("Record Inserted");
                }
                connection.Close();
            }
        }

        /// <summary>
        /// Getting the date and time of the last record
        /// </summary>
        /// <returns>DateTime</returns>
        public DateTime SelectLastRecordDateTime()
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT date FROM public.""Currency"" ORDER BY ""ID"" DESC LIMIT 1;";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                DateTime date = new DateTime();
                // cmd.Parameters.AddWithValue("date", date);
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    date = reader.GetDateTime(0);
                }

                connection.Close();
                return date;

            }
        }

        /// <summary>
        /// Getting currency data from the database
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="likeValue"></param>
        /// <returns></returns>
        public ICurrency SelectLastRecordCurrency(ICurrency currency, string likeValue)
        {
            using (NpgsqlConnection connection = GetConnection())
            {
                connection.Open();
                string query = @"SELECT charcode,nominal,name,value,previous FROM public.""Currency"" WHERE ""charcode"" LIKE @title ORDER BY ""ID"" DESC LIMIT 1 ;";
                NpgsqlCommand cmd = new NpgsqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@title", likeValue);

                var reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    currency.Nominal = reader.GetInt32(0);
                    currency.Name = reader.GetString(1);
                    currency.Value = reader.GetDecimal(2);
                    currency.Previous = reader.GetDecimal(3);
                }
                connection.Close();

                return currency;

            }
        }
    }
}
