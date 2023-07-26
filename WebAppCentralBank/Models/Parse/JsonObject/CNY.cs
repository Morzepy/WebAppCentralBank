namespace WebAppCentralBank.Models.Parse.JsonObject
{
    /// <summary>
    /// Currency CNY
    /// </summary>
    public class CNY : ICurrency
    {
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
        public CNY() { }
        public CNY(int NumCode, string CharCode, int Nominal)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
        }
        public CNY(int NumCode, string CharCode, int Nominal, string Name)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
        }
        public CNY(int NumCode, string CharCode, int Nominal, string Name, decimal Value)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
            this.Value = Value;
        }
        public CNY(int NumCode, string CharCode, int Nominal, string Name, decimal Value, decimal Previous)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
            this.Value = Value;
            this.Previous = Previous;
        }
    }
}
