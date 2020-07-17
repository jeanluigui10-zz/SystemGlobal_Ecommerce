using System;
using System.Data;
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
    public partial class Information : System.Web.UI.Page
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
                else {
                    LoadDocument();
                    ltTitle.InnerText = "Registrarme";
                    SetControls();
                }
            }
        }

        #region SetData
        private void SetData()
        {
            try
            {
                    ltTitle.InnerText = "Editar Información";
                    Customer obj = null;
                    Int32 customerId = BaseSession.SsOrderxCore.Customer.ID;
                    BaseEntity entity = new BaseEntity();
                    obj = CustomerBL.Instance.Customer_GetInformation_ById(ref entity, customerId);
                    
                    if (entity.Errors.Count == 0)
                        if (obj != null)
                        {
                            SetControls(obj);
                        }
                        else
                        {
                            SetControls();
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
        private void SetControls()
        {
            txtNombre.Value  = String.Empty;
            txtApellidoPaterno.Value = String.Empty;
            txtApellidoMaterno.Value = String.Empty;
            txtNumberoDocumento.Value = String.Empty;
            txtCelular.Value = String.Empty;
            txtCorreo.Value = String.Empty;
            txtAddress1.Value = String.Empty;
            txtPassword.Value = String.Empty;
            ddlTipoDocumento.SelectedValue = "-1";
        }
        private void SetControls(Customer objCustomer)
        {
            try
            {
                txtNombre.Value = objCustomer.FirstName;
                txtApellidoPaterno.Value = objCustomer.LastNamePaternal;
                txtApellidoMaterno.Value = objCustomer.LastNameMaternal;
                txtNumberoDocumento.Value = objCustomer.NumberDocument;
                txtCelular.Value = objCustomer.CellPhone;
                txtCorreo.Value = objCustomer.Email;
                txtAddress1.Value = objCustomer.address.Address1;
                txtPassword.Value = objCustomer.Password;
                ddlTipoDocumento.SelectedValue = objCustomer.DocumentType.ToString();

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
                    ddlTipoDocumento.DataSource = dt;
                    ddlTipoDocumento.DataTextField = "Name";
                    ddlTipoDocumento.DataValueField = "ID";
                    ddlTipoDocumento.DataBind();

                    ddlTipoDocumento.Items.Insert(0, new ListItem("Tipo de Documento", "-1"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [WebMethod]
        public static Object Customer_Save(srCustomer obj)
        {
            Boolean success;
            try
            {
                BaseEntity objEntity = new BaseEntity();
                Int32 idCustomer = BaseSession.SsOrderxCore.Customer == null ? 0 : BaseSession.SsOrderxCore.Customer.ID;
                Boolean ExistEmail = CustomerBL.Instance.Customer_Validate_ExistEmail(ref objEntity, obj.Email, idCustomer);

                if (!ExistEmail)
                {
                    Customer objCustomer = new Customer
                    {
                        ID = Convert.ToInt32(idCustomer),
                        FirstName = obj.FirstName.ToString(),
                        LastNamePaternal = obj.LastNamePaternal.ToString(),
                        LastNameMaternal = obj.LastNameMaternal.ToString(),
                        DocumentType = Convert.ToInt32(obj.DocumentType),
                        NumberDocument = obj.NumberDocument.ToString(),
                        CellPhone = obj.CellPhone.ToString(),
                        Email = obj.Email.ToString(),
                        Password = obj.Password.ToString()
                    };
                    objCustomer.address.Address1 = obj.Address1.ToString();

                    success = CustomerBL.Instance.Customer_Save(ref objEntity, objCustomer);

                    if (objEntity.Errors.Count == 0)
                    {
                        if (success)
                        {
                            if (objCustomer.ID == 0)
                            {
                                return new { Result = "Ok", Msg = "Se guardo correctamente!" };
                            }
                            else
                            {
                                return new { Result = "OkUpdate", Msg = "Se actualizó correctamente!" };
                            }
                           
                        }
                        else
                        {
                            return new { Result = "NoOk", Msg = "Hubo Un error al guardar." };
                        }
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
                    }
                }
                else {
                    return new { Result = "NoOkEmail", Msg = "El Correo/Nombre de Usuario ya existe" };
                }                
            }
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
            }
        }
        public void Message(EnumAlertType type, string message)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "message", @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>", false);
        }

    }
}