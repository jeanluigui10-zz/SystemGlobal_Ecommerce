using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Customers;
using xAPI.Entity.Security;
using xAPI.Library.Base;
using xAPI.Library.Connection;
using xAPI.Library.General;

namespace xAPI.Dao.Customers
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

        public Customer Customer_ValidatebyUsernameAndPassword(ref BaseEntity objBase, Customer obj)
        {
            SqlCommand ObjCmd = null;
            Customer objCustomer = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Customer_ValidateLogin_Sp", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@Email", obj.Email);
                ObjCmd.Parameters.AddWithValue("@Password", obj.Password);
                dr = ObjCmd.ExecuteReader();
                if (dr.Read())
                {
                    objCustomer = new Customer();
                    objCustomer.CustomerId = dr.GetColumnValue<Int32>("CustomerId");
                    objCustomer.FirstName = dr.GetColumnValue<String>("FirstName");
                    objCustomer.LastNamePaternal = dr.GetColumnValue<String>("LastNameMaternal");
                    objCustomer.LastNameMaternal = dr.GetColumnValue<String>("LastNamePaternal");
                    objCustomer.DocumentType = dr.GetColumnValue<String>("DocumentType");
                    objCustomer.NumberDocument = dr.GetColumnValue<String>("NumberDocument");
                    objCustomer.Email = dr.GetColumnValue<String>("Email");
                    objCustomer.Password = dr.GetColumnValue<String>("Password");
                    objCustomer.Status = dr.GetColumnValue<Byte>("Status");
                }
            }
            catch (Exception ex)
            {
                objCustomer = null;
                objBase.Errors.Add(new BaseEntity.ListError(ex, "User not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return objCustomer;
        }

    }
}
