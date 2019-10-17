using System;
using System.Collections.Generic;
using System.Data;
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
    

