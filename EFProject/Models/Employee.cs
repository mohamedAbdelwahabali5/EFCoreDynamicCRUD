using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Extention { get; set; }
        public string? Email {  get; set; }
        public string? JopTitle { get; set; }

        /* Start Employee-Customer RelationShip */
        public ICollection<Customer> customers { get; set; }= new HashSet<Customer>();
        /* End Employee-Customer RelationShip */


        /* Start Self RelationShip */
        public int? ReportsTo { get; set; }
        public Employee Manager { get; set; }
        public ICollection<Employee> SubEmployees { get; set; } = new HashSet<Employee>();

        /* End Self RelationShip */

        /* Start Employee-Office RelationShip */
        public int OfficeId {  get; set; }
        public Office Office { get; set; }
        /* End Employee-Office RelationShip */
    }
}
