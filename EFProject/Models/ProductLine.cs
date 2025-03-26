using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class ProductLine
    {
        public int Id { get; set; }
        public string? DescinText { get; set; }
        public string? DescinHTML { get; set; }
        public string? Image {  get; set; }


        /* Start ProductLine-Product RelationShip */
        public ICollection<Product> products { get; set; }

        /* End ProductLine-Product RelationShip */
    }
}
