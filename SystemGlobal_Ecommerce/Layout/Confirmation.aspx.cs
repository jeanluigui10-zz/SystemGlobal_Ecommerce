using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using xAPI.Entity.Order;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;

using System.Globalization;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Confirmation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {               
                LoadData();
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
                    return objReturn = new { Result = "NoOk", Message = "Cantidad Incorrecta." };
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

     
       
    }
}