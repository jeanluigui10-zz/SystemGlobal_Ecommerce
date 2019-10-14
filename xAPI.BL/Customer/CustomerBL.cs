using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.BL.Customer
{
    public class CustomerBL
    {
        #region Singleton
        private static CustomerBL instance = null;
        public static CustomerBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerBL();
                return instance;
            }
        }
        #endregion

    }
}
