using System;


namespace ShopManager.Model.Entities
{
    public class Sale
    {
        public Guid RealizationId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int Quontity { get; set; }
        public decimal Income { get; set; }
        public DateTime Date { get; set; }
        public string Seller { get; set; }
    }
}
