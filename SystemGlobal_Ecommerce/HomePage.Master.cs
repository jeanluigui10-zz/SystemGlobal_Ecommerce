using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Script.Serialization;
using SystemGlobal_Ecommerce.src.app_code;
using xAPI.BL.Category;
using xAPI.BL.Setting;
using xAPI.Entity.Order;
using xAPI.Entity.Store;
using xAPI.Library.Base;
using xAPI.Library.General;

namespace SystemGlobal_Ecommerce
{
    public partial class HomePage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (BaseSession.SsOrderxCore.Customer != null)
            {
                
                lblCuenta.Visible = true;
                lblCerrarSession.Visible = true;
                lblInicioSession.Visible = false;
                lblRegistrar.Visible = false;

                divOrderHistoryIcon.Visible = true;

                liOrderHistory.Visible = true;
                liOrderHistoryMobile.Visible = true;

                hrefCustomer.Attributes["href"] = "/Layout/InformationEdit.aspx";
                hrefOrderHistoryMobile.Attributes["href"] = "/Layout/Order/OrderHistory.aspx";
                hrefOrderHistory.Attributes["href"] = "/Layout/Order/OrderHistory.aspx";
            }
            else
            {
                lblInicioSession.Visible = true;
                lblRegistrar.Visible = true;
                lblCuenta.Visible = false;
                lblCerrarSession.Visible = false;

                divOrderHistoryIcon.Visible = false;

                liOrderHistory.Visible = false;
                liOrderHistoryMobile.Visible = false;

                hrefCustomer.Attributes["href"] = "/Layout/Information.aspx";
            }
            //Load_Settings();
            Load_StoreInformation();
            Load_Products();
            Load_Category();
            //if (BaseSession.SsOrderxCore.Customer != null && BaseSession.SsOrderxCore.Customer.CustomerId > 0)
            //{
            //    ucChat.SetUserId(BaseSession.SsOrderxCore.Customer.CustomerId);
            //    ucChat.SetUserFullName(BaseSession.SsOrderxCore.Customer.FirstName);
            //}
            //else
            //{
            //    Int32 codigoAleatorio = new Random().Next(1000, 2000);
            //    ucChat.SetUserId(codigoAleatorio);
            //    ucChat.SetUserFullName("");
            //}

        }
        public void Load_StoreInformation() 
        {
            BaseEntity objEntity = new BaseEntity();
            Store objStore = SettingBL.Instance.Store_GetInformation(ref objEntity);
           
            if (objEntity.Errors.Count == 0 )
            {
                lblAddressFooter.InnerText = "Dirección: " + objStore.Address.ToString();
                lblPhoneFooter.InnerText = objStore.Phone2.ToString() != "" ? "Teléfono: " + objStore.Phone1.ToString() + " - " + objStore.Phone2.ToString() : "Teléfono: " + objStore.Phone1.ToString();
                lblEmailFooter.InnerText = "Correo: " + objStore.Email.ToString();
                lblAttentionHoursFooter.InnerText = "Horario de atención: " + objStore.AttentionHours.ToString();
                lblRightsReservedFooter.InnerText = "© " + objStore.Name.ToString() + " " + objStore.Year + ", " + "Todos los derechos reservados";
                lblPhoneHeader.InnerText = objStore.Phone2.ToString() != "" ? objStore.Phone1.ToString() + " - " + objStore.Phone1.ToString() : objStore.Phone1.ToString();
               
                lblNoteDeliveryHeader.InnerText = objStore.NoteDelivery.ToString();

                lblFacebookHeader.Attributes["href"] = objStore.Facebook.ToString();
                lblInstagramHeader.Attributes["href"] = objStore.Instagram.ToString();
                lblYoutubeHeader.Attributes["href"] = objStore.Youtube.ToString();
                lblTwitterHeader.Attributes["href"] = objStore.Twitter.ToString();

                lblFacebookFooter.Attributes["href"] = objStore.Facebook.ToString();
                lblInstagramFooter.Attributes["href"] = objStore.Instagram.ToString();
                lblYoutubeFooter.Attributes["href"] = objStore.Youtube.ToString();
                lblTwitterFooter.Attributes["href"] = objStore.Twitter.ToString();

                lblPhoneMobile.InnerText = objStore.Phone2.ToString() != "" ? objStore.Phone1.ToString() + "-" + objStore.Phone2.ToString() : objStore.Phone1.ToString();
            }
        }
        private void Load_Category()
        {
            BaseEntity entity = new BaseEntity();
            List<srCategory> lst = new List<srCategory>();

            DataTable dt = CategoryBL.Instance.CategoryProduct_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lst.Add(new srCategory()
                        {
                            IdCategoryEncrypt = HttpUtility.UrlEncode(Encryption.Encrypt(item["ID"].ToString())),
                            IdCategory = item["ID"].ToString(),
                            Name = item["Name"].ToString()
                            //NameResource = Config.Impremtawendomain + item["NameResource"].ToString()
                        });
                    }
                }
               
            }
            if (entity.Errors.Count <= 0)
            {
                if (lst != null)
                {
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    String sJSON = serializer.Serialize(lst);
                    hfDataListCategory.Value = sJSON.ToString();
                }
            }
        }

        private void Load_Products()
        {
            OrderHeader orderHeader = BaseSession.SsOrderxCore;
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

                hfDataListProduct.Value = sJSON.ToString();
            }
        }
        //private void Load_Settings()
        //{
        //    BaseEntity objBase = new BaseEntity();
        //    DataTable dt = ResourceBL.Instance.Settings_GetAll(ref objBase);
        //    if (objBase.Errors.Count == 0)
        //    {
        //        if (dt != null)
        //        {
        //            foreach (DataRow item in dt.Rows)
        //            {
        //                hfIsVisiableChat.Value = item["ChatOnlineActive"].ToString();
        //            }
        //        }
        //    }
        //}
        protected void btnCloseSession_ServerClick(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("Index.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            BaseSession.Logout();
            Response.Redirect("~/Layout/Login.aspx", false);
        }
    }
}