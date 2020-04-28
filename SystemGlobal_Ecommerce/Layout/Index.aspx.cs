using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Product;
using xAPI.Entity.Order;
using xAPI.Entity.Product;
using xAPI.Library.Base;
using xAPI.Library.General;
namespace SystemGlobal_Ecommerce.Layout
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
             
            }
        }

        private void LoadData(Boolean ShowMessage = false)
        {
            BaseEntity entity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();

            DataTable dt = ProductBL.Instance.Product_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    Int32 count = 0;
                    foreach (DataRow item in dt.Rows)
                    {
                        count++;
                        lst.Add(new srProducts()
                        {
                            isCheckbox = "1",
                            Id = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            Name = item["Name"].ToString(),
                            Description = item["Description"].ToString(),
                            DocType = item["DocType"].ToString(),
                            Brand = item["BrandName"].ToString(),
                            Category = item["Resource_Category_Name"].ToString(),
                            NameResource = Config.Impremtawendomain + item["NameResource"].ToString(),
                            UnitPrice = Convert.ToDecimal(item["UnitPrice"]).ToString(),
                            Stock = Convert.ToInt32(item["Stock"]).ToString(),
                            PriceOffer = Convert.ToDecimal(item["PriceOffer"]).ToString(),
                            UniMed = item["UniMed"].ToString(),
                            Status = Convert.ToInt16(item["Status"]) == (short)EnumStatus.Enabled ? "Activo" : "Inactivo",
                            Index = count.ToString()
                        });
                    }
                }
                else
                {
                    this.Message(EnumAlertType.Error, "An error occurred while loading data");
                }
            }
            else
            {
                this.Message(EnumAlertType.Success, entity.Errors[0].MessageClient);
            }

            if (entity.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfData.Value = sJSON.ToString();
                }
            }
        }

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);
        }

        [WebMethod]
        public static Object AddProduct(dynamic objProd)
        {
            Object objReturn = new { Result = "NoOk" };
            BaseEntity objBase = new BaseEntity();
            try
            {
                //if (BaseSession.SsOrderxCore.Customer == null || BaseSession.SsOrderxCore.Customer.CustomerId == 0)
                //{
                //    objReturn = new
                //    {
                //        Result = "NoOk",
                //        Msg = "/Layout/Login.aspx",
                //        Value = 0
                //    };
                //}
                //else
                //{
                    Products obj = null;
                    String ProductId = Encryption.Decrypt(HttpUtility.UrlDecode(objProd["ProductId"]));
                    obj = ProductBL.Instance.Products_GetList_ById_Ecommerce(ref objBase, Convert.ToInt32(ProductId));

                    if (objBase.Errors.Count == 0)
                    {
                        if (obj != null)
                        {
                            obj.NameResource = Config.Impremtawendomain + obj.NameResource;
                            OrderHeader orderHeader = BaseSession.SsOrderxCore;
                            var ProductExist = orderHeader.ListOrderDetail.Any(p => p.Product.ID == obj.ID);
                            if (ProductExist)
                            {
                                objReturn = new
                                {
                                    Result = "NoOk",
                                    Msg = "El producto ya se encuentra agregado.",
                                    Value = -1
                                };

                            }
                            else
                            {
                                OrderDetail Detalle = new OrderDetail()
                                {
                                    Product = obj,
                                    Quantity = 1,
                                };

                                orderHeader.ListOrderDetail.Add(Detalle);
                                Detalle.CalculateTotalPricexProduct();
                                orderHeader.CalculateTotals();

                                if (orderHeader != null && orderHeader.ListOrderDetail != null && orderHeader.ListOrderDetail.Count > 0)
                                {
                                    List<Object> lstDetail = new List<Object>();
                                    for (int i = 0; i < orderHeader.ListOrderDetail.Count; i++)
                                    {
                                        Object objProduct = new
                                        {
                                            ProductId = orderHeader.ListOrderDetail[i].Product.ID,
                                            ProductName = orderHeader.ListOrderDetail[i].Product.Name,
                                            Category = orderHeader.ListOrderDetail[i].Product.category.Name,
                                            UnitPrice = orderHeader.ListOrderDetail[i].Product.UnitPrice,
                                            NameResource = orderHeader.ListOrderDetail[i].Product.NameResource

                                        };
                                       
                                        Object Detail = new
                                        {
                                            Product = objProduct,
                                            Quantity = orderHeader.ListOrderDetail[i].Quantity,
                                            TotalPrice = orderHeader.ListOrderDetail[i].Totalprice,
                                        };

                                        lstDetail.Add(Detail);
                                    }

                                    Object OrderHeader = new
                                    {
                                        Ordertotal = orderHeader.Ordertotal,
                                        SubTotal = orderHeader.SubTotal,
                                        DeliveryTotal = orderHeader.DeliveryTotal,
                                        CustomerId = orderHeader.Customer == null ? 0 : orderHeader.Customer.ID,
                                        CustomerName = orderHeader.Customer == null ? "" : orderHeader.Customer.FullName,
                                        Detail = lstDetail
                                    };

                                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                                    String sJSON = serializer.Serialize(OrderHeader);

                                    BaseSession.SsOrderxCore = orderHeader;

                                    objReturn = new
                                    {
                                        Result = "Ok",
                                        Msg = "Agregado correctamente.",
                                        ListProductToCartHeader = sJSON.ToString()
                                    };
                                }
                            }
                        }
                        else
                        {
                            objReturn = new
                            {
                                Result = "NoOk",
                                Msg = "No se pudo agregar el producto."
                            };
                        }
                    }
                    else
                    {
                        objReturn = new
                        {
                            Result = "NoOk",
                            Msg = "Ocurrio un problema agregando el producto."
                        };
                    }
              //  }


            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
                    Msg = "Ocurrio un problema agregando el producto."
                };
            }
            return objReturn;
        }

        [WebMethod]
        public static Object ViewProduct(dynamic objProd)
        {
            Object objReturn = new { Result = "NoOk" };
            BaseEntity objBase = new BaseEntity();
            try
            {
                Products obj = null;
                String ProductId = Encryption.Decrypt(HttpUtility.UrlDecode(objProd["ProductId"]));
                obj = ProductBL.Instance.Products_GetList_ById_Ecommerce(ref objBase, Convert.ToInt32(ProductId));

                if (objBase.Errors.Count == 0)
                {
                    if (obj != null)
                    {
                        obj.NameResource = Config.Impremtawendomain + obj.NameResource;
                        Object objProduct = new
                        {
                            ProductId = HttpUtility.UrlEncode(Encryption.Encrypt(obj.ID.ToString())),
                            ProductName = obj.Name,
                            Category = obj.category.Name,
                            UnitPrice = obj.UnitPrice,
                            NameResource = obj.NameResource,
                            FileDescription = obj.Description, 
                            UniMed = obj.UniMed
                        };

                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        String sJSON = serializer.Serialize(objProduct);

                        objReturn = new
                        {
                            Result = "Ok",
                            Msg = "La informacion del producto se obtuvo correctamente.",
                            Product = sJSON.ToString()
                        };
                    }
                    else
                    {
                        objReturn = new
                        {
                            Result = "NoOk",
                            Msg = "No se puede ver detalle de producto."
                        };
                    }
                }
                else
                {
                    objReturn = new
                    {
                        Result = "NoOk",
                        Msg = "Ocurrio un problema obteniendo informacion del producto."
                    };
                }
            }
            catch (Exception ex)
            {
                objReturn = new
                {
                    Result = "NoOk",
                    Msg = "Ocurrio un problema obteniendo informacion del producto."
                };
            }
            return objReturn;
        }

    }
}