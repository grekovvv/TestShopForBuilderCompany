using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestShopForBuilderCompany.Model
{
    internal class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateIn { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
