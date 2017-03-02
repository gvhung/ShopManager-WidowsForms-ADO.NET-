using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.Model.Entities
{
    public class DefectedProduct
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid RealizationId { get; set; }
        public  int Quantity { get; set; }
    }
}
