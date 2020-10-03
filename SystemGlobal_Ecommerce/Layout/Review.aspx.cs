using culqi.net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Order;
using xAPI.BL.Payment;
using xAPI.BL.Setting;
using xAPI.Entity;
using xAPI.Entity.Order;
using xAPI.Entity.Payment;
using xAPI.Entity.Store;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (BaseSession.SsOrderxCore.Customer == null || BaseSession.SsOrderxCore.Customer.ID == 0 && BaseSession.SsOrderxCore.ListOrderDetail != null)
                {
                    //BaseSession.Logout();
                    Response.Redirect("~/Layout/Information.aspx");
                    //Response.Redirect("~/Layout/Login.aspx");
                }
                else
                {
                    LoadData();
                }               
            }
        }

        private void LoadData()
        {
            if (BaseSession.SsOrderxCore != null && BaseSession.SsOrderxCore.ListOrderDetail != null && BaseSession.SsOrderxCore.ListOrderDetail.Count > 0) 
            {
                OrderHeader objOrder = BaseSession.SsOrderxCore;
                lblAddress1.InnerText = objOrder.Customer.address.Address1.ToString();
            }
            else
            {
                GoBack();
            }
        }

        [WebMethod]
        public static Object CartProduct_UpdateQuantity(dynamic data)
        {
            String Ok = "Ok";
            String NoOk = "NoOk";
            Object objReturn = new { Result = NoOk };
            try
            {
                String ProductId = data["ProductId"];
                String Quantity = data["ProductQuantity"];
                List<Object> lstItemsCount = new List<Object>();

                if (!Int32.TryParse(ProductId, out int productid) || productid < 0)
                {
                    return objReturn = new { Result = NoOk, Message = "Producto Incorrecto." };
                }
                if (!Int32.TryParse(Quantity, out int quantity) || quantity < 0)
                {
                    return objReturn = new { Result = NoOk, Message ="Cantidad Incorrecta." };
                }

                OrderHeader ObjOrderHeader = BaseSession.SsOrderxCore;
                var ProductExist = ObjOrderHeader.ListOrderDetail.Any(p => p.Product.ID == productid);
                if (!ProductExist && ProductId != "00")
                {
                    objReturn = new
                    {
                        Result = NoOk,
                        Msg = "El producto no se encuentra agregado.",
                        OrderHeader = ""
                    };

                }
                else
                {
                    OrderDetail DetailSelect = new OrderDetail();
                        for (int i = 0; i < ObjOrderHeader.ListOrderDetail.Count; i++)
                        {
                            if (ObjOrderHeader.ListOrderDetail[i].Product.ID == productid)
                            {
                                ObjOrderHeader.ListOrderDetail[i].Quantity = quantity;
                                ObjOrderHeader.CalculateTotalPricexProduct(ObjOrderHeader.ListOrderDetail[i]);
                                DetailSelect = ObjOrderHeader.ListOrderDetail[i];
                            }
                    }

                    //Remover toda la tabla
                    if (quantity == 0 && ProductId == "00")
                    {
                        ObjOrderHeader.ListOrderDetail = null;
                    }
                    //Remove producto seleccionado
                    if (quantity == 0 && ProductId != "00")
                    {
                        ObjOrderHeader.ListOrderDetail.Remove(ObjOrderHeader.ListOrderDetail.Single(p => p.Product.ID == productid));
                    }

                    ObjOrderHeader.CalculateTotals();
                    lstItemsCount.Add(ObjOrderHeader.ListOrderDetail);
                    BaseSession.SsOrderxCore = ObjOrderHeader;
                    DetailSelect.ProductId = Convert.ToInt32(ProductId);

                    Object OrderHeader = new
                    {
                        Ordertotal = ObjOrderHeader.Ordertotal,
                        SubTotal = ObjOrderHeader.SubTotal,
                        DeliveryTotal = ObjOrderHeader.DeliveryTotal,
                        CustomerId = ObjOrderHeader.Customer == null ? 0 : ObjOrderHeader.Customer.ID,
                        CustomerName = ObjOrderHeader.Customer == null ? "" : ObjOrderHeader.Customer.FullName,
                        Detail = DetailSelect,
                        lstItemsCount = lstItemsCount
                    };
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(OrderHeader);

                    objReturn = new
                    {
                        Result = Ok,
                        Msg = "Cantidad actualizada correctamente.",
                        OrderHeader = sJSON.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = NoOk,
                    Msg = "Ocurrio un problema actualizando la cantidad."
                };
            }
            return objReturn;
        }

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }

        private void GoBack()
        {
            Response.Redirect("~/Layout/Index.aspx");
        }

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            OrderHeader objOrder = BaseSession.SsOrderxCore;
            if (objOrder != null && objOrder.ListOrderDetail != null && objOrder.ListOrderDetail.Count > 0)
            {
                SaveOrder(objOrder);
            }
            else
            {
                GoBack();
            }
        }
        private void SaveOrder(OrderHeader objOrder)
        {
            try
            {
                BaseEntity objEntity = new BaseEntity();
                tBaseDetailOrderList objListDetail = new tBaseDetailOrderList();
              
                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    objListDetail.Add(new tBaseDetailOrder()
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.ID,
                        Price = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        Quantity = objOrder.ListOrderDetail[i].Quantity,
                        PriceOffer = objOrder.ListOrderDetail[i].Product.PriceOffer,
                        Status = Convert.ToByte(EnumStatus.Enabled)
                    });
                }

                Boolean success;
                if (objOrder.ID == 0)
                {
                        objOrder.Status = Convert.ToByte(EnumOrderStatus.PendienteEntrega);
                        objOrder.PaymentStatus = Convert.ToByte(EnumPaymentStatus.PendientePago);

                        success = OrderBL.Instance.Insertar_Pedido(ref objEntity, ref objOrder, objListDetail);
                        if (objEntity.Errors.Count == 0)
                        {
                            if (success)
                            {
                                Response.Redirect("Confirmation.aspx", false);
                            }
                            else {
                                this.Message(EnumAlertType.Info, "No se pudo guardar la Orden");
                                return;
                            }
                        }
                        else
                        {
                            this.Message(EnumAlertType.Info, objEntity.Errors[0].Error.Message);
                            return;
                        }
                }
                else
                {
                    this.Message(EnumAlertType.Info, "No se pudo guardar la Orden");
                }
            }
            catch (Exception ex)
            {
                this.Message(EnumAlertType.Error, "Ocurrio un error al guardar la Orden");
            }
        }

        [WebMethod]
        public static Object Culqui_CreateCharge(srPayCulqi q)
        {
            Security security = null;
            security = new Security();
            //security.public_key = "pk_test_e10ed06809bfa78c";
            security.secret_key = "sk_test_IVKPrHmdnGqKCcDs";
            OrderHeader objOrder = BaseSession.SsOrderxCore;

            try
            {
                String pay_token = q.token_created;
                String pay_email = q.email;

                Dictionary<string, object> metadata = new Dictionary<string, object>
                {
                {"order_id", "777"}
                };
                
                Dictionary<string, object> charge = new Dictionary<string, object>
                {
                {"amount", Convert.ToInt32(objOrder.Ordertotal) * 100},
                {"capture", true},
                {"currency_code", "PEN"},
                {"description", "Venta de prueba"},
                {"email", pay_email},
                {"installments", 0},
                {"metadata", metadata},
                {"source_id", pay_token}                
                };

                string charge_created = new Charge(security).Create(charge);
                return  charge_created;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        [WebMethod]
        public static Object OpenPay()
        {
            String Ok = "Ok";
            String NoOk = "NoOk";
            Object objReturn = new { Result = NoOk };
            try
            {
                BaseEntity objEntity = new BaseEntity();
                Store objStore = SettingBL.Instance.Store_GetInformation(ref objEntity);
                Credential objCredential = CredentialBL.Instance.Credential_GetInformation(ref objEntity);
                OrderHeader ObjOrderHeader = BaseSession.SsOrderxCore;

                if (ObjOrderHeader.Ordertotal <= 0)
                {
                    objReturn = new
                    {
                        Msg = "El monto total no puede ser cero ó la sesión terminó.",
                        Result = NoOk
                    };
                }
                else
                {
                    Object objPayment = new
                    {
                        StoreName = objStore.Name == null ? "" : objStore.Name.ToString(),
                        CustomerName = ObjOrderHeader.Customer == null ? "" : ObjOrderHeader.Customer.FullName.ToString(),
                        OrderTotal = Convert.ToInt32(ObjOrderHeader.Ordertotal) * 100,
                        Logo = objStore.Logo == null ? "" : objStore.Logo.ToString(),
                        Currency = objCredential.Currency == null ? "" : objCredential.Currency.ToString(),
                        Public_Key = objCredential.Public_Key == null ? "" : objCredential.Public_Key.ToString(),
                        Secret_Key = objCredential.Secret_Key == null ? "" : objCredential.Secret_Key.ToString()
                    };

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(objPayment);

                    objReturn = new
                    {
                        Result = Ok,
                        objPaymentInfo = sJSON.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Msg = "Ocurrió un error, intentalo nuevamente",
                    Result = NoOk
                };
            }
            return objReturn;
        }

    }
}
    