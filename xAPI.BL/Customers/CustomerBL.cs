using System;
using System.Data;
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
        public Boolean Customer_Validate_ExistEmail(ref BaseEntity objEntity, String email, Int32 idCustomer) 
        {
            Boolean success = false;
            try
            {
                success = CustomerDAO.Instance.Customer_Validate_ExistEmail(ref objEntity, email, idCustomer);
            }
            catch (Exception ex)
            {
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }
            return success;
        }

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

        public Customer Customer_GetInformation_ById(ref BaseEntity objBase, Int32 CustomerId)
        {
            objBase = new BaseEntity();
            Customer objCustomer = null;
            try
            {
                    objCustomer = CustomerDAO.Instance.Customer_GetInformation_ById(ref objBase, CustomerId);

            }
            catch (Exception ex)
            {
                objBase.Errors.Add(new BaseEntity.ListError(ex, "An error occurred  on application level 2"));
            }

            return objCustomer;
        }
    }
}



