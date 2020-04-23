using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Product;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce.Layout
{
    public partial class ProductSelected : System.Web.UI.Page
    {
        public int VsId
        {
            get { return ViewState["ID"] != null ? (int)ViewState["ID"] : default; }
            set { ViewState["ID"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadData();
            }
        }
        private void LoadData()
        {
            SetQuery();
            SetData();
        }

        private void SetQuery()
        {
            if (!String.IsNullOrEmpty(Request.QueryString["p"]))
            {
                String id = Encryption.Decrypt(Request.QueryString["p"]);
                if (!String.IsNullOrEmpty(id))
                {
                    VsId = Convert.ToInt32(id);
                }
                else
                {
                    GoBack();
                }
            }
        }
        public void GoBack()
        {
            Response.Redirect("ProductSelected.aspx");
        }

        private void SetData()
        {
            BaseEntity objEntity = new BaseEntity();
            List<srProducts> lst = new List<srProducts>();
            try
            {
                if (VsId > 0)
                {
                    DataTable dt = ProductBL.Instance.Product_GetList(ref objEntity);
                    if (objEntity.Errors.Count == 0)
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
                                    Category = item["Resource_Category_Name"].ToString(),
                                    NameResource = item["NameResource"].ToString(),
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
                        this.Message(EnumAlertType.Success, objEntity.Errors[0].MessageClient);
                    }

                    if (objEntity.Errors.Count <= 0)
                    {
                        if (lst != null)
                        {
                            JavaScriptSerializer serializer = new JavaScriptSerializer();
                            String sJSON = serializer.Serialize(lst);
                            hfProduct.Value = sJSON.ToString();
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                this.Message(EnumAlertType.Error, "An error occurred while loading data");
            }
        }

        public void Message(EnumAlertType type, string message)
        {
            String script = @"<script type='text/javascript'>fn_message('" + type.GetStringValue() + "', '" + message + "');</script>";
            Page.ClientScript.RegisterStartupScript(typeof(Page), "message", script);

        }
    }
}