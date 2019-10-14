using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Entity.Customer
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public String FirstName { get; set; }
        public String LastNamePaternal { get; set; }
        public String LastNameMaternal { get; set; }
        public String DocumentType { get; set; }
        public String NumberDocument { get; set; }
        public String CellPhone { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }        
    }
}
