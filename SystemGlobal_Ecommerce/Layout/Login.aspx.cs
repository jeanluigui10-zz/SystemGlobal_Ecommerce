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
          
        }
               
        [WebMethod]
        public static Object LoginSecurity(dynamic objCust)
        {
            Object objReturn = new { Result = "NoOk" };
            BaseEntity objBase = new BaseEntity();
            try
            {
                String email = objCust["Email"];
                String password = objCust["Password"];
                Customer obj = new Customer()
                {
                    Email = email,
                    Password = password
                }; 

                Customer objCustomer = CustomerBL.Instance.ValidateLogin_Customer(ref objBase, obj);
                
                if (objBase.Errors.Count == 0)
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
                            Msg = "Credenciales Incorrectas."
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