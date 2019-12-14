using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.Entity.Order;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

//Paypal
using PayPal.Api;
using PayPal.Sample.Utilities;
using PayPal.Sample;
using System.Globalization;
using xAPI.BL.Order;
using xAPI.Entity;
using xAPI.Library.Base;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (!String.IsNullOrEmpty(Request.Params["paymentId"]) && !String.IsNullOrEmpty(Request.Params["PayerID"])) 
                {
                    Paypal_Async_Transaction(Request.Params["paymentId"].ToString(), Request.Params["PayerID"].ToString());
                }

                if (!String.IsNullOrEmpty(Request.Params["ordid"]))
                {
                    String idOrder = Request.Params["ordid"].ToString();
                    Cotization_ByOrderId(Encryption.Decrypt(idOrder));
                }
                else
                {
                    LoadData();
                }
            }
        }

        private void Paypal_Async_Transaction(String PaymentId, String PayerId)
        {
            APIContext ApiContext = Configuration.GetAPIContext();
            //Usando la información de la redirección, previa configuracion para pagar
            var paymentExecution = new PaymentExecution() { payer_id = PayerId };
            var payment = new Payment() { id = PaymentId };

            // Ejecuta el pago.
            var response = payment.Execute(ApiContext, paymentExecution);

            if (response != null)
            {
                if (Convert.ToString(response.state) == "approved")
                {
                    OrderHeader objOrder = BaseSession.SsOrderxCore;
                    objOrder.Status = (Int32)EnumStatus.Enabled;
                    SaveOrder(objOrder);

                    String Auth = PaymentId;
                    String TransactionId = Convert.ToString(response.transactions[0].related_resources[0].sale.id);
                    String Message = response.state;
                }
            }
        }

        private void SaveOrder(OrderHeader objOrder)
        {
            try
            {
                BaseEntity objBase = new BaseEntity();
                tBaseDetailOrderList objListDetail = new tBaseDetailOrderList();

                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    objListDetail.Add(new tBaseDetailOrder()
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.Id,
                        Price = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        Quantity = objOrder.ListOrderDetail[i].Quantity,
                        CreatedBy = objOrder.Customer.CustomerId,
                        UpdatedBy = objOrder.Customer.CustomerId,
                        Status = Convert.ToByte(EnumStatus.Enabled)
                    });
                }
                objOrder.IsCotization = 0;
                objOrder.Description = String.Empty;
                Boolean success;
                if (objOrder.OrderId > 0)
                {
                     success = OrderBL.Instance.Update_Pedido(ref objBase, ref objOrder);

                }
                else
                {
                    success = OrderBL.Instance.Insertar_Pedido(ref objBase, ref objOrder, objListDetail);
                }
                if (success) 
                {
                    //Ok
                    Response.Redirect("Confirmation.aspx", true);
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

        private void LoadData()
        {
            if (BaseSession.SsOrderxCore != null && BaseSession.SsOrderxCore.ListOrderDetail != null && BaseSession.SsOrderxCore.ListOrderDetail.Count > 0) 
            {
                OrderHeader objOrder = BaseSession.SsOrderxCore;
                List<Object> lstDetail = new List<Object>();
                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    Object objProduct = new
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.Id,
                        ProductName = objOrder.ListOrderDetail[i].Product.Name,
                        Category = objOrder.ListOrderDetail[i].Product.Category,
                        UnitPrice = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        NameResource = objOrder.ListOrderDetail[i].Product.NameResource
                    };
                    Object Detail = new
                    {
                        Product = objProduct,
                        Quantity = objOrder.ListOrderDetail[i].Quantity,
                        TotalPrice = objOrder.ListOrderDetail[i].Totalprice,
                    };

                    lstDetail.Add(Detail);
                }

                Object OrderHeader = new
                {
                    Ordertotal = objOrder.Ordertotal,
                    SubTotal = objOrder.SubTotal,
                    IGV = objOrder.IGV,
                    CustomerId = objOrder.Customer.CustomerId,
                    CustomerName = objOrder.Customer.FullName,
                    Detail = lstDetail
                };
                
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(OrderHeader);
                  hfData.Value = sJSON.ToString();

            }
        }

        [WebMethod]
        public static Object CartProduct_UpdateQuantity(dynamic data)
        {
            Object objReturn = new { Result = "NoOk" };
            try
            {
                String ProductId = data["ProductId"];
                String Quantity = data["ProductQuantity"];

                if (!Int32.TryParse(ProductId, out int productid) || productid < 0)
                {
                    return objReturn = new { Result = "NoOk", Message = "Producto Incorrecto." };
                }
                if (!Int32.TryParse(Quantity, out int quantity) || quantity < 0)
                {
                    return objReturn = new { Result = "NoOk", Message ="Cantidad Incorrecta." };
                }

                OrderHeader ObjOrderHeader = BaseSession.SsOrderxCore;
               
                var ProductExist = ObjOrderHeader.ListOrderDetail.Any(p => p.Product.Id == productid);
                if (!ProductExist)
                {
                    objReturn = new
                    {
                        Result = "NoOk",
                        Msg = "El producto no se encuentra agregado.",
                        OrderHeader = ""
                    };

                }
                else
                {
                    OrderDetail DetailSelect = new OrderDetail();
                    for (int i = 0; i < ObjOrderHeader.ListOrderDetail.Count; i++)
                    {
                        if (ObjOrderHeader.ListOrderDetail[i].Product.Id == productid)
                        {
                            ObjOrderHeader.ListOrderDetail[i].Quantity = quantity;
                            ObjOrderHeader.CalculateTotalPricexProduct(ObjOrderHeader.ListOrderDetail[i]);
                            DetailSelect = ObjOrderHeader.ListOrderDetail[i];
                        }
                    }

                    ObjOrderHeader.CalculateTotals();

                    BaseSession.SsOrderxCore = ObjOrderHeader;

                    Object OrderHeader = new
                    {
                        Ordertotal = ObjOrderHeader.Ordertotal,
                        SubTotal = ObjOrderHeader.SubTotal,
                        IGV = ObjOrderHeader.IGV,
                        CustomerId = ObjOrderHeader.Customer.CustomerId,
                        CustomerName = ObjOrderHeader.Customer.FullName,
                        Detail = DetailSelect
                    };

                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(OrderHeader);

                    objReturn = new
                    {
                        Result = "Ok",
                        Msg = "Cantidad actualizada correctamente.",
                        OrderHeader = sJSON.ToString()
                    };
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
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

        protected void btnPayment_Click(object sender, EventArgs e)
        {
            OrderHeader objOrder = BaseSession.SsOrderxCore;
            if (objOrder != null && objOrder.ListOrderDetail != null && objOrder.ListOrderDetail.Count > 0)
            {
                PayPal_SendOrder(objOrder);
            }
            else
            {
                GoBack();
            }
        }

        private void GoBack()
        {
            Response.Redirect("~/Layout/Index.aspx");
        }

        private void PayPal_SendOrder(OrderHeader objOrder)
        {         
                var apiContext = Configuration.GetAPIContext();

                var payer = new Payer() { payment_method = "paypal" };
                
                RedirectUrls responseUrls = Get_UrlRedirect();
                ItemList responseItems = Get_Items(objOrder);
                Details responseDetail = Get_DetailsPay(objOrder);
                Amount resposeAmount = Get_AmountTotals(objOrder, responseDetail);
                List<Transaction> responseTransaction = Get_Transaction(resposeAmount, responseItems);
                Payment responsePayment = Get_PaymentOrder(apiContext, responseTransaction, responseUrls, payer);

            if (responsePayment != null) 
            {
                var links = responsePayment.links.GetEnumerator();
                while (links.MoveNext())
                {
                    var link = links.Current;
                    if (link.rel.ToLower().Trim().Equals("approval_url"))
                    {
                        Response.Redirect(link.href, true);
                    }
                }
            }
                   
         }

        private Payment Get_PaymentOrder(APIContext apiContext,List<Transaction> responseTransaction, RedirectUrls responseUrls, Payer payer)
        {
            var payment = new Payment()
            {
                intent = "sale",
                payer = payer,
                transactions = responseTransaction,
                redirect_urls = responseUrls
            };

            Payment objPayment = payment.Create(apiContext);
            return objPayment;
        }

        private List<Transaction> Get_Transaction(Amount resposeAmount, ItemList responseItems)
        {
            var transactionList = new List<Transaction>();

            transactionList.Add(new Transaction()
            {
                description = "Transaccion de la orden de compra.",
                invoice_number = Common.GetRandomInvoiceNumber(),
                amount = resposeAmount,
                item_list = responseItems
            });
            return transactionList;
        }

        private Amount Get_AmountTotals(OrderHeader objOrder, Details detailTotal)
        {
            var amount = new Amount()
            {
                currency = "USD",
                total = Convert.ToString(objOrder.Ordertotal, CultureInfo.InvariantCulture),
                details = detailTotal
            };
            return amount;
        }

        private Details Get_DetailsPay(OrderHeader objOrder)
        {
            var details = new Details()
            {
                tax = Convert.ToString(objOrder.IGV, CultureInfo.InvariantCulture),
                shipping = "0",
                subtotal = Convert.ToString(objOrder.SubTotal, CultureInfo.InvariantCulture)
            };
            return details;
        }

        private ItemList Get_Items(OrderHeader objOrder)
        {
            var itemList = new ItemList();
            var items = new List<Item>();
            for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
            {
                var item = new Item()
                {
                    name = objOrder.ListOrderDetail[i].Product.Name,
                    currency = "USD",
                    price = Convert.ToString(objOrder.ListOrderDetail[i].Product.UnitPrice, CultureInfo.InvariantCulture),
                    quantity = Convert.ToString(objOrder.ListOrderDetail[i].Quantity),
                    sku = Convert.ToString(objOrder.ListOrderDetail[i].Product.Id)
                };
                items.Add(item);
            }
            itemList.items = items;
            return itemList;
        }

        private RedirectUrls Get_UrlRedirect()
        {
           
            // Estas URL determinarán cómo se redirige al usuario desde PayPal una vez que han aprobado o cancelado el pago.
            var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Layout/Review.aspx?";
            var guid = Convert.ToString((new Random()).Next(100000));
            var redirectUrl = baseURI + "guid=" + guid;
            var redirUrls = new RedirectUrls()
            {
                cancel_url = redirectUrl + "&cancel=true",
                return_url = redirectUrl
            };
            return redirUrls;
        }

        private void Cotization_ByOrderId(String OrderId)
        {
            BaseEntity objBase = new BaseEntity();
            OrderHeader objOrder = OrderBL.Instance.Order_GetBy_OrderId(ref objBase, Convert.ToInt32(OrderId));
            if (objOrder != null && objOrder.ListOrderDetail != null && objOrder.ListOrderDetail.Count > 0)
            {
                List<Object> lstDetail = new List<Object>();
                for (int i = 0; i < objOrder.ListOrderDetail.Count; i++)
                {
                    Object objProduct = new
                    {
                        ProductId = objOrder.ListOrderDetail[i].Product.Id,
                        ProductName = objOrder.ListOrderDetail[i].Product.Name,
                        Category = objOrder.ListOrderDetail[i].Product.Category,
                        UnitPrice = objOrder.ListOrderDetail[i].Product.UnitPrice,
                        NameResource = Config.Impremtawendomain + objOrder.ListOrderDetail[i].Product.NameResource
                    };
                    Object Detail = new
                    {
                        Product = objProduct,
                        Quantity = objOrder.ListOrderDetail[i].Quantity,
                        TotalPrice = objOrder.ListOrderDetail[i].Totalprice,
                    };

                    lstDetail.Add(Detail);
                }

                Object OrderHeader = new
                {
                    Ordertotal = objOrder.Ordertotal,
                    SubTotal = objOrder.SubTotal,
                    IGV = objOrder.IGV,
                    CustomerId = objOrder.Customer.CustomerId,
                    CustomerName = objOrder.Customer.FullName,
                    Detail = lstDetail
                };
                objOrder.OrderId = Convert.ToInt32(OrderId);
                BaseSession.SsOrderxCore = objOrder;
               JavaScriptSerializer serializer = new JavaScriptSerializer();
                String sJSON = serializer.Serialize(OrderHeader);
                hfData.Value = sJSON.ToString();

            }
        }

    }
}
    