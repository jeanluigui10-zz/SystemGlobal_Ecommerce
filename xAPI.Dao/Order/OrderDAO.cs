using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace xAPI.Dao.Order
{
    public class OrderDAO
    {
        #region Singleton
        private static OrderDAO instance = null;
        public static OrderDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new OrderDAO();
                return instance;
            }
        }
        #endregion
    }
}
