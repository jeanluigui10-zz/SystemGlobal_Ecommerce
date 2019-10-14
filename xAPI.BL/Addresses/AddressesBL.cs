using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.BL.Addresses
{
    public class AddressesBL
    {
        #region Singleton
        private static AddressesBL instance = null;
        public static AddressesBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new AddressesBL();
                return instance;
            }
        }
        #endregion
    }
}
