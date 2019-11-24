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
                LoadData();
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
                    String Auth = PaymentId;
                    String TransactionId = Convert.ToString(response.transactions[0].related_resources[0].sale.id);
                    String Message = response.state;
                }
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
            Response.Redirect("Index.aspx");
        }

        private void PayPal_SendOrder(OrderHeader objOrder)
        {
                //Pase un objeto `APIContext` para autenticar, la llamada y para enviar una identificación de solicitud única           
                var apiContext = Configuration.GetAPIContext();

                // Un recurso que representa a un pagador que financia un pago, metodo de pago es paypal
                var payer = new Payer() { payment_method = "paypal" };

                // Estas URL determinarán cómo se redirige al usuario desde PayPal una vez que han aprobado o cancelado el pago.
                var baseURI = Request.Url.Scheme + "://" + Request.Url.Authority + "/Layout/Confirmation.aspx?";
                var guid = Convert.ToString((new Random()).Next(100000));
                var redirectUrl = baseURI + "guid=" + guid;
                var redirUrls = new RedirectUrls()
                {
                    cancel_url = redirectUrl + "&cancel=true",
                    return_url = redirectUrl
                };
                
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


                    // Vamos a especificar detalles de un monto de pago.
                    var details = new Details()
                    {
                        tax = Convert.ToString(objOrder.IGV, CultureInfo.InvariantCulture),
                        shipping = "0",
                        subtotal = Convert.ToString(objOrder.SubTotal, CultureInfo.InvariantCulture)
                    };

                    // Especificar un monto de pago
                    var amount = new Amount()
                    {
                        currency = "USD",
                        total = Convert.ToString(objOrder.Ordertotal, CultureInfo.InvariantCulture), //El total debe ser igual a la suma de envío, impuestos y subtotal.
                        details = details
                    };

                    //Transaction 
                    var transactionList = new List<Transaction>();

                    //Lista de transaccion
                    transactionList.Add(new Transaction()
                    {
                        description = "Transaccion de la orden de compra.",
                        invoice_number = Common.GetRandomInvoiceNumber(),
                        amount = amount,
                        item_list = itemList
                    });

                    //Tipos e intenciones anteriores como `venta` o` autorizar`
                    var payment = new Payment()
                    {
                        intent = "sale",
                        payer = payer,
                        transactions = transactionList,
                        redirect_urls = redirUrls
                    };

                    // Crea un pago usando valid APIContext
                    var responsePayment = payment.Create(apiContext);

                    // Redirigir a paypal para aprobar pago.
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
}
    