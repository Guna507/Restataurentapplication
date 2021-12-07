using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restataurentapplication.Models
{
    public class OrderDetailsModel
    {
        public Int64 OrderDetailId { get; set; }
        public Int64 itemName { get; set; }

        public Int32 quantity { get; set; }

        public Int64 UnitPrice { get; set; }

        public Int64 Discount { get; set; }

        public Int64 Total { get; set; }

        public Int64 Status { get; set; }

        public Int64 CustomerId { get; set; }
    }
}
