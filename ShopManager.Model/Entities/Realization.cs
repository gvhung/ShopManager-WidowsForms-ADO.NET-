using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManager.Model.Entities
{
    public class Realization
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set;}
        public decimal Income { get; set; }
        public Guid EmployeeId { get; set; }
    }
}
