using System;
using xAPI.Library.Base;

namespace xAPI.Entity.Merchant
{
    public class Merchants : BaseEntity
    {
        public Int32 MerchantId { get; set; }
        public String MerchantName { get; set; }
        public String MerchantWebService { get; set; }
        public Int32 MerchantStatus { get; set; }
        public Int32 isChecked { get; set; }
        public Byte GroupId { get; set; }
        public Byte InputType { get; set; }
        
    }
}
