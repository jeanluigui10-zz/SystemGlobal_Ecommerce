using System;
using System.Data;
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
        public int vsId
        {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default(int); }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SetQuery();
                SetData();
                LoadDocument();
            }
        }
        #region SetQuery
        private void SetQuery()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["q"]))
            {
                ltTitle.InnerText = "Editar Información";
                String id = Encryption.Decrypt(Request.QueryString["q"]);
                if (!String.IsNullOrEmpty(id))
                {
                    vsId = Convert.ToInt32(id);
                    hfCustomerId.Value = id;
                }
                else
                {
                    //GoBack();
                }
            }
            else
            {
                ltTitle.InnerText = "Registrarme";
            }
        }
        #endregion
        #region SetData
        private void SetData()
        {
            try
            {
                if (vsId > 0)
                {
                    Customer obj = null;
                    BaseEntity entity = new BaseEntity();
                    obj = CustomerBL.Instance.Customer_GetInformation_ById(ref entity, vsId);
                    
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
            }
            catch (Exception)
            {
                Message(EnumAlertType.Error, "An error occurred while loading data");
            }

        }
        private void SetControls()
        {
            hfCustomerId.Value = String.Empty;
            txtNombre.Value  = String.Empty;
            txtApellidoPaterno.Value = String.Empty;
            txtApellidoMaterno.Value = String.Empty;
            txtNumberoDocumento.Value = String.Empty;
            txtCelular.Value = String.Empty;
            txtCorreo.Value = String.Empty;
            txtAddress1.Value = String.Empty;
            txtPassword.Value = String.Empty;
        }
        private void SetControls(Customer objCustomer)
        {
            try
            {
                hfCustomerId.Value = objCustomer.ID.ToString();
                txtNombre.Value = objCustomer.FirstName;
                txtApellidoPaterno.Value = objCustomer.LastNamePaternal;
                txtApellidoMaterno.Value = objCustomer.LastNameMaternal;
                txtNumberoDocumento.Value = objCustomer.NumberDocument;
                txtCelular.Value = objCustomer.CellPhone;
                txtCorreo.Value = objCustomer.Email;
                txtAddress1.Value = objCustomer.address.Address1;
                txtPassword.Value = objCustomer.Password;

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
            String msg = String.Empty;
            String msgError = String.Empty;
            try
            {
                BaseEntity objEntity = new BaseEntity();

                Boolean ExistEmail = CustomerBL.Instance.Customer_Validate_ExistEmail(ref objEntity, obj.Email);

                if (!ExistEmail)
                {
                    Customer objCustomer = new Customer
                    {
                        ID = String.IsNullOrEmpty(obj.Id) ? 0 : Convert.ToInt32(obj.Id),
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
                            return new { Result = "Ok", Msg = "Se registró correctamente!" };
                        }
                        else
                        {
                            return new { Result = "NoOk", Msg = "Hubo Un error al registrar." };
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