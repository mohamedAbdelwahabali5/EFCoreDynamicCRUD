using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Product
    {
        public int Code { get; set; }
        public string? Name { get; set; }
        public string? PdtDescription { get; set; }
        public string? Vendor {  get; set; }
        public int? Scale { get; set; }
        public int? BuyPrice { get; set; }
        public int? QtylnStock { get; set; }
        public string? MSRP { get; set; }


        /* Start Product-ProductLine RelationShip */
        public int ProductLineId { get; set; }
        public ProductLine ProductLine { get; set; }
        /* End Product-ProductLine RelationShip */

        /* Start Product-Order_Product RelationShip */
        public ICollection<Order_Product> Order_Products { get; set; }= new HashSet<Order_Product>();
        /* End Product-Order_Product RelationShip */

    }
}
