using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.Model.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public decimal ActualPrice { get; set; }
        public double Quontity { get; set; }
        public Guid CategoryId { get; set; }
        public Guid SubCategoryId { get; set; }
    }
}
