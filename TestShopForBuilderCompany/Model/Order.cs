using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopForBuilderCompany.Model
{
    internal class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public int CustomerId { get; set; }
        public Client Client { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
