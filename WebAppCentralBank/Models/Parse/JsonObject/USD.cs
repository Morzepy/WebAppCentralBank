﻿namespace WebAppCentralBank.Models.Parse.JsonObject
{
    /// <summary>
    /// Currency USD
    /// </summary>
    public class USD : ICurrency
    {
        public DateTime dateTimeDB { get; set; }
        public int NumCode { get; set; }
        public string? CharCode { get; set; }
        public int Nominal { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public decimal Previous { get; set; }
    }
}