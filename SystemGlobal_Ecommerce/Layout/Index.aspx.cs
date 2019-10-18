using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using xAPI.BL.Resource;
using xAPI.Entity;
using xAPI.Entity.Order;
using xAPI.Library.Base;
using xAPI.Library.General;
using xSystem_Maintenance.src.app_code;
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
            List<AppResource> lst = new List<AppResource>();

            DataTable dt = ResourceBL.Instance.AppResource_GetByAplicationID(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new AppResource()
                        {
                            Id = Convert.ToInt32(item["ID"]),
                            FileName = item["FILENAME"].ToString(),
                            Name = item["NAME"].ToString(),
                            UnitPrice = Convert.ToDecimal(item["UnitPrice"]),
                            DOCTYPE = item["DOCTYPE"].ToString(),
                            Category = item["RESOURCE_CATEGORY_NAME"].ToString(),
                            FileDescription = item["DESCRIPTION"].ToString(),
                            NameResource = Config.Impremtawendomain + item["NAMERESOURCE"].ToString(),
                            Status = Convert.ToInt32(item["STATUS"])
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
                AppResource obj = null;
                BaseEntity entity = new BaseEntity();
                Int32 ProductId = objProd["ProductId"];
                obj = ResourceBL.Instance.AppResource_GetByID(ref entity, ProductId);

                if (entity.Errors.Count == 0)
                {
                    if(obj != null)
                    {
                        List<OrderDetail> Detail = new List<OrderDetail>()
                        {
                            new OrderDetail() { Product = obj }
                        };
                        OrderHeader orderHeader = BaseSession.SsOrderxCore;
                        orderHeader.ListOrderDetail = Detail;
                        BaseSession.SsOrderxCore = orderHeader;
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
    }
}