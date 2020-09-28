using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Customers;
using xAPI.Entity.Customers;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class InformationEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (BaseSession.SsOrderxCore.Customer != null && BaseSession.SsOrderxCore.Customer.ID > 0)
                {
                    LoadDocument();
                    SetData();

                }
                else
                {
                    LoadDocument();
                }
            }
        }

        #region SetData
        private void SetData()
        {
            try
            {
                Customer obj = null;
                Int32 customerId = BaseSession.SsOrderxCore.Customer.ID;
                BaseEntity objEntity = new BaseEntity();
                obj = CustomerBL.Instance.Customer_GetInformation_ById(ref objEntity, customerId);
                txtUsername.Value = obj.Username.ToString();
                if (objEntity.Errors.Count == 0) { 
                    if (obj != null)
                    {
                        SetControls(obj);
                    }
                }
                else
                {
                    Message(EnumAlertType.Error, "An error occurred while loading data");
                }
            }
            catch (Exception)
            {
                Message(EnumAlertType.Error, "Ocurrió un error al cargar la data.");
            }

        }
     
        private void SetControls(Customer objCustomer)
        {
            try
            {
                txtName.Value = objCustomer.FirstName;
                txtApePater.Value = objCustomer.LastNamePaternal;
                txtApeMater.Value = objCustomer.LastNameMaternal;
                txtCellPhone.Value = objCustomer.CellPhone;
                txtEmail.Value = objCustomer.Email;
                txtAddressEdit.Value = objCustomer.address.Address1;
                txtDocumentNumber.Value = objCustomer.NumberDocument;
                ddlTypeDocument.SelectedValue = objCustomer.DocumentType.ToString();
            }
            catch (Exception ex)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }
        #endregion
        private void LoadDocument()
        {
            try
            {
                BaseEntity objEntity = new BaseEntity();
                DataTable dt = new DataTable();
                dt = CustomerBL.Instance.Customer_Load_TypeDocument(ref objEntity);

                if (dt != null && objEntity.Errors.Count == 0)
                {
                    ddlTypeDocument.DataSource = dt;
                    ddlTypeDocument.DataTextField = "Name";
                    ddlTypeDocument.DataValueField = "ID";
                    ddlTypeDocument.DataBind();

                    ddlTypeDocument.Items.Insert(0, new ListItem("Tipo de Documento", "-1"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static Object Customer_Update_Perfil(srCustomer obj)
        {
            Boolean success;
            try
            {
                BaseEntity objEntity = new BaseEntity();
                Int32 idCustomer = BaseSession.SsOrderxCore.Customer == null ? 0 : BaseSession.SsOrderxCore.Customer.ID;

                    Customer objCustomer = new Customer
                    {
                        ID = Convert.ToInt32(idCustomer),
                        FirstName = obj.FirstName.ToString(),
                        LastNamePaternal = obj.LastNamePaternal.ToString(),
                        LastNameMaternal = obj.LastNameMaternal.ToString(),
                        DocumentType = Convert.ToInt32(obj.DocumentType),
                        NumberDocument = obj.NumberDocument.ToString(),
                        CellPhone = obj.CellPhone.ToString(),
                        Email = obj.Email.ToString()
                    };

                    success = CustomerBL.Instance.Customer_Perfil_Update(ref objEntity, objCustomer);
                    BaseSession.SsOrderxCore.Customer = objCustomer;
                    if (objEntity.Errors.Count == 0)
                    {
                        if (success)
                        {
                            return new { Result = "Ok", Msg = "Se guardo correctamente." };
                        }
                        else
                        {
                            return new { Result = "NoOk", Msg = "Hubo Un error al guardar." };
                        }
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error al guardar." };
                    }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error al guardar" };
            }
        }

        [WebMethod]
        public static Object Customer_Update_Address(srCustomer obj)
        {
            Boolean success;
            try
            {
                BaseEntity objEntity = new BaseEntity();
                Int32 idCustomer = BaseSession.SsOrderxCore.Customer == null ? 0 : BaseSession.SsOrderxCore.Customer.ID;

                    Customer objCustomer = new Customer
                    {
                        ID = Convert.ToInt32(idCustomer),
                    };
                    objCustomer.address.Address1 = obj.Address1;
                    
                    success = CustomerBL.Instance.Customer_Update_Address(ref objEntity, objCustomer);
                    BaseSession.SsOrderxCore.Customer = objCustomer;
                    if (objEntity.Errors.Count == 0)
                    {
                        if (success)
                        {
                            return new { Result = "Ok", Msg = "Se actualizó correctamente." };
                        }
                        else
                        {
                            return new { Result = "NoOk", Msg = "Hubo Un error al guardar." };
                        }
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error al guardar" };
                    }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error al guardar" };
            }
        }

        [WebMethod]
        public static Object Customer_Update_Password(srCustomer obj)
        {
            Boolean success;
            try
            {
                BaseEntity objEntity = new BaseEntity();
                Int32 idCustomer = BaseSession.SsOrderxCore.Customer == null ? 0 : BaseSession.SsOrderxCore.Customer.ID;

                Customer objCustomer = new Customer
                {
                    ID = Convert.ToInt32(idCustomer),
                    Password = Encryption.Encrypt(obj.Password.ToString()),
                    PasswordNew = Encryption.Encrypt(obj.PasswordNew.ToString())
                };

                success = CustomerBL.Instance.Customer_Update_Password(ref objEntity, objCustomer); 

                if (objEntity.Errors.Count == 0)
                {
                    if (success)
                    {
                            return new { Result = "Ok", Msg = "Se actualizó correctamente." };
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "Contraseña actual incorrecta." };
                    }
                }
                else
                {
                    return new { Result = "NoOk", Msg = "A ocurrido un error al guardar" };
                }
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error al guardar" };
            }
        }
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }
    }
}