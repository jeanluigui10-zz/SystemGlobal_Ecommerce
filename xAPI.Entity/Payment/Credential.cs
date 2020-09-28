using System;

namespace xAPI.Entity.Payment
{
    public class Credential
    {
        public String MerchantName { get; set; }
        public String Currency { get; set; }
        public String Public_Key { get; set; }
        public String Secret_Key { get; set; }
    }
}
