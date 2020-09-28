using System;
using xAPI.Entity.Addresses;
using xAPI.Library.Base;

namespace xAPI.Entity.Customers
{
    public class Customer : BaseEntity
    {
        public String FirstName { get; set; }
        public String LastNamePaternal { get; set; }
        public String LastNameMaternal { get; set; }
        public Int32 DocumentType { get; set; }
        public String NumberDocument { get; set; }
        public String CellPhone { get; set; }
        public String Email { get; set; }
        public String Username { get; set; }
        public String Message { get; set; }
        public String Password { get; set; }
        public String PasswordNew { get; set; }
        public String Subject { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public Int32 CreatedBy { get; set; }
        public Int32 UpdatedBy { get; set; }
        private String _estadodesc;
        public String EstadoDes
        {
            get
            {
                if (Status == 1) _estadodesc = "Activo"; else _estadodesc = "Inactivo";
                return _estadodesc;
            }
        }
        private String fullName;
        public String FullName
        {
            get
            {
                fullName = FirstName + " " + LastNamePaternal + " " + LastNameMaternal;
                return fullName;
            }
        }
        Address objAddress;
        public Address address
        {
            get
            {
                objAddress = objAddress ?? new Address();
                return objAddress;
            }
            set
            {
                objAddress = value;
            }
        }
    }
}
