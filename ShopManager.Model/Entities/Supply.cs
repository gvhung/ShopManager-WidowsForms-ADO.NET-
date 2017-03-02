using System;

namespace ShopManager.Model.Entities
{
    public class Supply
    {
        public Guid Id { get; set; }
        public DateTime Date{ get; set; }
        public Guid ProductId{ get; set; }
        public int Quantity{ get; set; }
        public decimal Price{ get; set; }
        public Guid SupplierId { get; set; }
}
}
