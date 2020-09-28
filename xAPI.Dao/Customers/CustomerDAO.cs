using System;
using System.Data;
using System.Data.SqlClient;
using xAPI.Entity.Customers;
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

        #region Methods
        public DataTable Customer_Load_TypeDocument(ref BaseEntity objEntity)
        {
            DataTable dt = new DataTable();
            SqlCommand ObjCmd = null;
            try
            {
                ObjCmd = new SqlCommand("Customer_List_TypeDocument_Sp", clsConnection.GetConnection())
                {
                    CommandType = CommandType.Text,
                    CommandTimeout = 0
                };
                dt.Load(ObjCmd.ExecuteReader());

            }
            catch (Exception exception)
            {
                objEntity.Errors.Add(new BaseEntity.ListError(exception, "An error occurred  deleting a resource."));
            }
            finally
            {
                clsConnection.DisposeCommand(ObjCmd);
            }
            return dt;
        }
        
        public Boolean Customer_Save(ref BaseEntity objEntity, Customer obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Customer_Save_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter parmIdPedidoOut = cmd.Parameters.Add("@AddressId", SqlDbType.Int);
                parmIdPedidoOut.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@idCustomer", obj.ID);
                cmd.Parameters.AddWithValue("@Name", obj.FirstName);
                cmd.Parameters.AddWithValue("@LastNamePaternal", obj.LastNamePaternal);
                cmd.Parameters.AddWithValue("@LastNameMaternal", obj.LastNameMaternal);
                cmd.Parameters.AddWithValue("@Address1", obj.address.Address1);
                cmd.Parameters.AddWithValue("@DocumentType", obj.DocumentType);
                cmd.Parameters.AddWithValue("@NumberDocument", obj.NumberDocument);
                cmd.Parameters.AddWithValue("@CellPhone", obj.CellPhone);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                cmd.Parameters.AddWithValue("@Username", obj.Username);                
                cmd.Parameters.AddWithValue("@Password", obj.Password);

                cmd.ExecuteNonQuery();
                success = true;
                if (!cmd.Parameters["@AddressId"].Value.ToString().Equals(String.Empty))
                    obj.address.ID= Convert.ToInt32(cmd.Parameters["@AddressId"].Value);
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
        public Boolean Customer_Perfil_Update(ref BaseEntity objEntity, Customer obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Customer_PerfilUpdate_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCustomer", obj.ID);
                cmd.Parameters.AddWithValue("@Name", obj.FirstName);
                cmd.Parameters.AddWithValue("@LastNamePaternal", obj.LastNamePaternal);
                cmd.Parameters.AddWithValue("@LastNameMaternal", obj.LastNameMaternal);
                cmd.Parameters.AddWithValue("@DocumentType", obj.DocumentType);
                cmd.Parameters.AddWithValue("@NumberDocument", obj.NumberDocument);
                cmd.Parameters.AddWithValue("@CellPhone", obj.CellPhone);
                cmd.Parameters.AddWithValue("@Email", obj.Email);
                success = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al actualizar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public Boolean Customer_Update_Password(ref BaseEntity objEntity, Customer obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Customer_PasswordUpdate_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCustomer", obj.ID);
                cmd.Parameters.AddWithValue("@Password", obj.Password);
                cmd.Parameters.AddWithValue("@PasswordNew", obj.PasswordNew);
                success = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al actualizar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }
        
        public Boolean Customer_Update_Address(ref BaseEntity objEntity, Customer obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("Customer_AddressUpdate_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idCustomer", obj.ID);
                cmd.Parameters.AddWithValue("@Address1", obj.address.Address1);
                success = cmd.ExecuteNonQuery() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

        public Boolean Customer_Validate_ExistUsername(ref BaseEntity objEntity, String username, Int32 idCustomer)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
               
                cmd = new SqlCommand("Customer_Validate_ExistUser_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter outputParam = cmd.Parameters.Add("@exist", SqlDbType.Bit);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@idCustomer", idCustomer);
                cmd.ExecuteNonQuery();
                success = Convert.ToBoolean(cmd.Parameters["@exist"].Value);

            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar Usuario not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
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
                ObjCmd.Parameters.AddWithValue("@Username", obj.Username);
                ObjCmd.Parameters.AddWithValue("@Password", obj.Password);
                dr = ObjCmd.ExecuteReader();
                if (dr.Read())
                {
                    objCustomer = new Customer();
                    objCustomer.ID = dr.GetColumnValue<Int32>("CustomerId");
                    objCustomer.FirstName = dr.GetColumnValue<String>("FirstName");
                    objCustomer.LastNamePaternal = dr.GetColumnValue<String>("LastNamePaternal");
                    objCustomer.LastNameMaternal = dr.GetColumnValue<String>("LastNameMaternal");
                    objCustomer.DocumentType = dr.GetColumnValue<Int32>("DocumentType");
                    objCustomer.NumberDocument = dr.GetColumnValue<String>("NumberDocument");
                    objCustomer.CellPhone = dr.GetColumnValue<String>("CellPhone");
                    objCustomer.Email = dr.GetColumnValue<String>("Email");
                    objCustomer.Username = dr.GetColumnValue<String>("Username");
                    objCustomer.Password = dr.GetColumnValue<String>("Password");
                    objCustomer.Status = dr.GetColumnValue<Int32>("Status");
                    objCustomer.address.Address1 = dr.GetColumnValue<String>("Address1");
                    objCustomer.address.ID = dr.GetColumnValue<Int32>("AddressId");
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
        public Customer Customer_GetInformation_ById(ref BaseEntity objBase, Int32 CustomerId)
        {
            SqlCommand ObjCmd = null;
            Customer objCustomer = null;
            SqlDataReader dr = null;
            try
            {
                ObjCmd = new SqlCommand("Customer_GetInformation_ById_Sp", clsConnection.GetConnection());
                ObjCmd.CommandType = CommandType.StoredProcedure;
                ObjCmd.Parameters.AddWithValue("@customerId", CustomerId);
                dr = ObjCmd.ExecuteReader();
                if (dr.Read())
                {
                    objCustomer = new Customer();
                    objCustomer.ID = dr.GetColumnValue<Int32>("CustomerId");
                    objCustomer.FirstName = dr.GetColumnValue<String>("FirstName");
                    objCustomer.LastNamePaternal = dr.GetColumnValue<String>("LastNamePaternal");
                    objCustomer.LastNameMaternal = dr.GetColumnValue<String>("LastNameMaternal");
                    objCustomer.DocumentType = dr.GetColumnValue<Int32>("DocumentType");
                    objCustomer.NumberDocument = dr.GetColumnValue<String>("NumberDocument");
                    objCustomer.CellPhone = dr.GetColumnValue<String>("CellPhone");
                    objCustomer.Email = dr.GetColumnValue<String>("Email");
                    objCustomer.Username = dr.GetColumnValue<String>("Username");
                    objCustomer.Password = dr.GetColumnValue<String>("Password");
                    objCustomer.Status = dr.GetColumnValue<Int32>("Status");
                    objCustomer.address.Address1 = dr.GetColumnValue<String>("Address1");
                    objCustomer.address.ID = dr.GetColumnValue<Int32>("AddressId");
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
        public Boolean Customer_Subject(ref BaseEntity objEntity, Customer obj)
        {
            SqlCommand cmd = null;
            Boolean success = false;
            try
            {
                cmd = new SqlCommand("CustomerContact_Save_Sp", clsConnection.GetConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Name", obj.FirstName);
                cmd.Parameters.AddWithValue("@email", obj.Email);
                cmd.Parameters.AddWithValue("@cellphone", obj.CellPhone);                
                cmd.Parameters.AddWithValue("@subject", obj.Subject);
                cmd.Parameters.AddWithValue("@message", obj.Message);

                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception ex)
            {
                success = false;
                objEntity.Errors.Add(new BaseEntity.ListError(ex, "Ocurrio un error al registrar Asunto not found."));
            }
            finally
            {
                clsConnection.DisposeCommand(cmd);
            }
            return success;
        }

    }
}
