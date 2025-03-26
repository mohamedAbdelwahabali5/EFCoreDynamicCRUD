using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int? Status { get; set; }
        public string? Commentes { get; set; }

        /* Start Order-Order_Product RelationShip */
        public ICollection<Order_Product> Order_Products { get; set; } = new HashSet<Order_Product>();
        /* End Order-Order_Product RelationShip */

        /* Start Order-Customer RelationShip */
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        /* End Order-Customer RelationShip */
    }
}
