using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFProject.Models
{
    public class Office
    {
        public int Code { get; set; }
        public string? City { get; set; }
        public string? Phone { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }
        public int? PostalCode { get; set; }
        public string? Ternitory { get; set; }

        /* Start Office-Employee RelationShip */
        public ICollection<Employee> Employees { get; set; }= new HashSet<Employee>();
        /* End Office-Employee RelationShip */
    }
}
