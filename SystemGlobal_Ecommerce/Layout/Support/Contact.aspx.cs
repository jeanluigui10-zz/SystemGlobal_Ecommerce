using System;
using System.Web.Services;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Customers;
using xAPI.Entity.Customers;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout.Support
{
    public partial class Contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        [WebMethod]
        public static Object Customer_Subject(srCustomer obj)
        {
            Boolean success;
            try
            {
                BaseEntity objEntity = new BaseEntity();
                    Customer objCustomer = new Customer
                    {
                        FirstName = obj.FirstName.ToString(),
                        Email = obj.Email.ToString(),
                        CellPhone = obj.CellPhone.ToString(),
                        Subject = obj.Subject.ToString(),
                        Message = obj.Message.ToString()
                    };

                    success = CustomerBL.Instance.Customer_Subject(ref objEntity, objCustomer);

                    if (objEntity.Errors.Count == 0)
                    {
                        if (success)
                        {
                                return new { Result = "Ok", Msg = "Se envio correctamente, nos comunicaremos contigo en menos de 24Hrs!" };
                        }
                        else
                        {
                            return new { Result = "NoOk", Msg = "Hubo un error al guardar." };
                        }
                    }
                    else
                    {
                        return new { Result = "NoOk", Msg = "A ocurrido un error guardando informacion" };
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