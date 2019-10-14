using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Library.Base;

namespace xAPI.Entity.Addresses
{
    public class Addresses : BaseEntity
    {
        public Int32 Id { get; set; }
        public Int32 CustomerId { get; set; }
        public String Address1 { get; set; }
        public String Address2 { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }

    
    }
}
