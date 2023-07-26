namespace WebAppCentralBank.Models.Parse.JsonObject
{
    public class TRY : ICurrency
    {
        public int NumCode { get; set; }
        public string CharCode { get; set; }
        public int Nominal { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }

        public TRY() { }

        public TRY(int NumCode, string CharCode, int Nominal)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
        }

        public TRY(int NumCode, string CharCode, int Nominal, string Name)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
        }

        public TRY(int NumCode, string CharCode, int Nominal, string Name, decimal Value)
        {
            this.NumCode = NumCode;
            this.CharCode = CharCode;
            this.Nominal = Nominal;
            this.Name = Name;
            this.Value = Value;
        }
        public TRY(int NumCode, string CharCode, int Nominal, string Name, decimal Value, decimal Previous)
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
