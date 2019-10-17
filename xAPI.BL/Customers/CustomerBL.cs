using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using xAPI.Library.Base;
using xAPI.Entity.Customer;
using xAPI.Dao.Customers;

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

        #region Methods
        public DataTable Customer_Load_TypeDocument(ref BaseEntity objEntity)
        {
            return CustomerDAO.Instance.Customer_Load_TypeDocument(ref objEntity);
        }

        public Boolean Customer_Save(ref BaseEntity objEntity, Customer obj)
        {
            Boolean success = false;
            try
            {
                success = CustomerDAO.Instance.Customer_Save(ref objEntity, obj);
            }
            catch (Exception ex)
            {
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

        #endregion
    }
}
