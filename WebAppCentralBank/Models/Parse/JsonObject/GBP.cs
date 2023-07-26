namespace WebAppCentralBank.Models.Parse.JsonObject
{
    /// <summary>
    /// Currency GBP
    /// </summary>
    public class GBP : ICurrency
    {

        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
        public GBP() { }
        public GBP(int NumCode, string CharCode, int Nominal)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
        }
        public GBP(int NumCode, string CharCode, int Nominal, string Name)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
        }
        public GBP(int NumCode, string CharCode, int Nominal, string Name, decimal Value)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
            this.Value = Value;
        }
        public GBP(int NumCode, string CharCode, int Nominal, string Name, decimal Value, decimal Previous)
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
