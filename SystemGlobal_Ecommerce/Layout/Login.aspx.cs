using System;
using System.Web.Services;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Customers;
using xAPI.Entity.Customers;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //imgLogin.ImageUrl  = Config.ProductDomainRutaLogin.ToString();
        }
               
        [WebMethod]
        public static Object LoginSecurity(dynamic objCust)
        {
            Object objReturn = new { Result = "NoOk" };
            BaseEntity objEntity = new BaseEntity();
            try
            {
                String username = objCust["Username"];
                String password = objCust["Password"];
                Customer obj = new Customer()
                {
                    Username = username,
                    Password = Encryption.Encrypt(password.ToString())
                }; 

                Customer objCustomer = CustomerBL.Instance.ValidateLogin_Customer(ref objEntity, obj);                
                if (objEntity.Errors.Count == 0)
                {
                    if (objCustomer != null)
                    {
                        if (objCustomer.Status == (Int32)EnumEsatado.Inactivo)
                        {
                            objReturn = new
                            {
                                Result = "NoOk",
                                Msg = "Cliente Inactivo"
                            };
                        }
                        else
                        {
                            if (objCustomer.Status == (Int32)EnumEsatado.Activo)
                            {
                                OrderHeader objOrder = BaseSession.SsOrderxCore;
                                objOrder.Customer = objCustomer;
                                objOrder.Address = objCustomer.address;
                                BaseSession.SsOrderxCore = objOrder;
                                objReturn = new
                                {
                                    Result = "Ok",
                                    Msg = "/Layout/Index.aspx"
                                };
                            }
                        }
                    }
                    else
                    {
                        objReturn = new
                        {
                            Result = "NoOk",
                            Msg = "Usuario ó Contraseña incorrecta"
                        };
                    }
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
                    Msg = "Ocurrio un error al intentar Iniciar Sesion."
                };
            }
            return objReturn;
        }
    }
}