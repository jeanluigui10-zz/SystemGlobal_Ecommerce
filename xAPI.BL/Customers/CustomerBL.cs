using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Dao.Customers;
using xAPI.Entity.Customers;
using xAPI.Library.Base;

namespace xAPI.BL.Customers
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
        public Customer ValidateLogin_Customer(ref BaseEntity objBase, Customer obj)
        {
            objBase = new BaseEntity();
            Customer objCustomer = null;
            try
            {
                if (obj != null)
                {
                    objCustomer = CustomerDAO.Instance.Customer_ValidatebyUsernameAndPassword(ref objBase, obj);

                }
            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return objCustomer;
        }
    }
}
