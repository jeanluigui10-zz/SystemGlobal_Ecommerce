using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Dao.Customer
{
    public class CustomerDAO
    {
        #region Singleton
        private static CustomerDAO instance = null;
        public static CustomerDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new CustomerDAO();
                return instance;
            }
        }
        #endregion
    }
}
