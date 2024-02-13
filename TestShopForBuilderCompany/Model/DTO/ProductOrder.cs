using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopForBuilderCompany.Model.DTO
{
    internal class ProductOrder
    {
        public int ClientId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime DateInOrder { get; set; }
    }
}
