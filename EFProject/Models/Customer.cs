using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Customer
    {
        /* Start Customer Properties */
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? FirstName { get; set; } 
        public string? LastName { get; set; }

        public string? Phone { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }

        public string? City { get; set; }
        public string? State { get; set; }

        public string? PostalCode { get; set; }
        public string? Country { get; set; }
        public decimal? CreditLimit { get; set; }
        /* End Customer Properties */


        /* Start Payment-Customer RelationShip */
        public  ICollection<Payment> payments { get; set; } = new HashSet<Payment>();
        /* End Payment-Customer RelationShip */


        /* Start Order-Customer RelationShip */
        public ICollection<Order> orders { get; set; }= new HashSet<Order>();
        /* End Order-Customer RelationShip */


        /* Start Employee-Customer RelationShip */
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }  
        /* End Employee-Customer RelationShip */

    }
}
