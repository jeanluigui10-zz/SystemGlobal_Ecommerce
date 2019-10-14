using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.BL.Order
{
    public class OrderBL
    {
        #region Singleton
        private static OrderBL instance = null;
        public static OrderBL Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderBL();
                return instance;
            }
        }
        #endregion
    }
}
