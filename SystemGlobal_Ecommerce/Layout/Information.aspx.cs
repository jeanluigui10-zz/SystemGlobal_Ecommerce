using System;
using System.Data;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Customers;
using xAPI.Entity.Customers;
using xAPI.Library.Base;
using xSystem_Maintenance.src.app_code;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Information : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDocument();

            }
        }

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
        public static Object Cliente_Registro(Customer obj)
        {
            Boolean success;
            String msg = String.Empty;
            String msgError = String.Empty;
            try
            {

                BaseEntity objEntity = new BaseEntity();
                obj.FirstName = obj.FirstName;
                obj.LastNamePaternal = obj.LastNamePaternal;
                obj.LastNameMaternal = obj.LastNameMaternal;
                obj.DocumentType = obj.DocumentType;
                obj.NumberDocument = obj.NumberDocument;
                obj.CellPhone = obj.CellPhone;
                obj.Email = obj.Email;
                obj.Password = obj.Password;

                obj.CreatedDate = DateTime.Now;
                obj.CreatedBy = BaseSession.SsUser.Id_Usuario;
                
                success = CustomerBL.Instance.Customer_Save(ref objEntity, obj);
                 

                if (objEntity.Errors.Count == 0)
                {
                    if (success)
                    {
                        return new { Result = "Ok", Msg = "Registro Correcto!" };
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
            catch (Exception ex)
            {
                return new { Result = "NoOk", Msg = "A ocurrido un error realizando transaccion" };
            }
        }
    }
}