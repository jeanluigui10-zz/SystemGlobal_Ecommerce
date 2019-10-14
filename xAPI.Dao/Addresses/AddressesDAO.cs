using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Dao.Addresses
{
    public class AddressesDAO
    {
        #region Singleton
        private static AddressesDAO instance = null;
        public static AddressesDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new AddressesDAO();
                return instance;
            }
        }
        #endregion
    }
}
