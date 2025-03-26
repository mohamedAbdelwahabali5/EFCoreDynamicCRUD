using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Payment
    {
        /* Start Payment Properties */
        public string CheckNum { get; set; }
        public DateTime? PaymentDate { get; set; }
        public decimal? Amount { get; set; }
        /* End Payment Properties */



        /* Start Payment-Customer RelationShip */
        public int CustomerId { get; set; }
        public Customer Customer { get; set; } 

        /* End Payment-Customer RelationShip */

    }
}
