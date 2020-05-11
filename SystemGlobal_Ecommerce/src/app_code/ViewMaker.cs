using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using xAPI.BL.Merchant;
using xAPI.Entity.Merchant;
using xAPI.Library.Base;

namespace xOrders.src.app_code
{
    public class ViewMaker
    {
        private readonly Page page;
        private readonly Control wrapper;
        private Control control;
        public short identifier { get; set; }
        public Int32 MerchantDetailId { get; set; }
        private readonly CultureInfo culture;
        //public Merchants objPaymentMerchant { get; set; } = new Merchants();
        public List<Merchants> lstPaymentMerchant { get; set; } = new List<Merchants>();

 
        public ViewMaker(Page page, Control wrapper, List<string> containers)
        {
            this.page = page;
            this.wrapper = wrapper;
            this.GetControl(containers);
            this.culture = new CultureInfo("en-US");
        }

        public ViewMaker(Page page, Control wrapper, List<string> containers, CultureInfo culture)
        {
            this.page = page;
            this.wrapper = wrapper;
            this.GetControl(containers);
            this.culture = culture ?? new CultureInfo("en-US");
        }

        private void GetControl(List<string> containers)
        {
            if (containers == null || containers.Count <= 0)
		  {
			 return;
		  }

		  this.control = this.wrapper;
            foreach (string content in containers)
		  {
			 this.control = this.control.FindControl(content);
		  }
	   }

        #region Select Method Payment

        public ViewMaker GetMultipleMerchantSelected()
        {
            try
            {
                RadioButton radio = null;
                CheckBox check = null;

                lstPaymentMerchant = new List<Merchants>();

                foreach (Control c in this.control.Controls)
                {
                    if (c is Panel)
                    {
                        foreach (Control c2 in c.Controls)
                        {
                            if (c2 is Panel)
                            {
                                foreach (Control option in c2.Controls)
                                {
                                    if (option is RadioButton && ((RadioButton)option).Checked)
                                    {
                                        radio = (RadioButton)option;

                                        lstPaymentMerchant.Add(new Merchants
                                        {
                                            MerchantId = Convert.ToInt32(radio.Attributes["data-id"], CultureInfo.InvariantCulture),
                                            MerchantName = Convert.ToString(radio.Attributes["data-name"]),
                                            MerchantStatus = Convert.ToInt32(radio.Attributes["data-status"], CultureInfo.InvariantCulture),
                                            Name = radio.Text
                                        });
                                        break;
                                    }

                                    if (option is CheckBox && ((CheckBox)option).Checked)
                                    {
                                        check = (CheckBox)option;

                                        Decimal amount = 0;
                                        TextBox txt = (TextBox)option.Parent.FindControl($"txt{check.Text}");
                                        if (txt != null)
                                        {
                                            Decimal.TryParse(txt.Text, out amount);
                                        }

                                        lstPaymentMerchant.Add(new Merchants
                                        {
                                            MerchantId = Convert.ToInt32(radio.Attributes["data-id"], CultureInfo.InvariantCulture),
                                            MerchantName = Convert.ToString(radio.Attributes["data-name"]),
                                            MerchantStatus = Convert.ToInt32(radio.Attributes["data-status"], CultureInfo.InvariantCulture),
                                            Name = radio.Text
                                        });

                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return this;
        }

        public void BuildMultiplePaymentOptions()
        {
            if (control == null)
            {
                return;
            }

            try
            {
                //ServiceResponse<PaymentListMerchant> lstMerchants = MerchantBl.Instance.GetByMarketAndModule(
                //    (Int16)BaseSession.SsOrderxCore.Ordersource, BaseSession.SsOrderxCore.Marketid, BaseSession.SsOrderxCore.Orderdate);
                BaseEntity entity = new BaseEntity();
                List<Merchants> lstMerchants = new List<Merchants>();
                DataTable dt = MerchantBL.Instance.MethodPayment_GetList(ref entity);
                if (entity.Errors.Count == 0)
                {
                    if (dt != null)
                    {
                        foreach (DataRow item in dt.Rows)
                        {
                            lstMerchants.Add(new Merchants()
                            {
                                MerchantId = Convert.ToInt32(item["MerchantId"]),
                                MerchantName = item["MerchantName"].ToString(),
                                isChecked = Convert.ToInt32(item["isChecked"]),
                                GroupId = Convert.ToByte(item["GroupId"]),
                                InputType = Convert.ToByte(item["InputType"])
                            });
                        }
                    }

                }
                if (lstMerchants != null && lstMerchants.Count > 0)
                {
                    Int32 qtyGroupId = 0;
                    Int32 countGroupId = 1;
                    bool isFirst = true;
                    Panel groupPanel = new Panel();
                    List<Byte> lstGroupId = new List<Byte>();

                    foreach (Merchants item in lstMerchants)
                    {
                        Boolean isSelected = Convert.ToBoolean(item.isChecked);

                        dynamic inputType;
                        qtyGroupId = lstMerchants.Count(x => x.GroupId == item.GroupId);

                        if (!lstGroupId.Any(x => x == item.GroupId))
                        {
                            groupPanel = new Panel();
                            groupPanel.Attributes.Add("style", "padding: 10px 0;");
                            lstGroupId.Add(item.GroupId);
                            countGroupId = 1;
                            isFirst = true;
                        }

                        String strType;

                        if (item.InputType == 1)
                        {
                            RadioButton rb = new RadioButton();
                            inputType = (dynamic)rb;
                            inputType.GroupName = "Payment";
                            strType = "rdb";
                            inputType.Checked = isFirst || isSelected;
                        }
                        else
                        {
                            CheckBox cb = new CheckBox();
                            inputType = (dynamic)cb;
                            strType = "chk";
                            inputType.Checked = isSelected;
                        }

                        inputType.ID = $"{strType}{item.MerchantId}";
                        inputType.ClientIDMode = ClientIDMode.Static;
                        inputType.Attributes.Add("class", $"{strType}Payment");
                        inputType.Attributes.Add("style", "vertical-align: sub");
                        inputType.Attributes.Add("title", item.MerchantName);
                        inputType.Attributes.Add("data-id", item.MerchantId.ToString(CultureInfo.InvariantCulture));
                        inputType.Attributes.Add("data-name", item.MerchantName.ToString(CultureInfo.InvariantCulture));
                        inputType.Text = item.MerchantName;
                        inputType.EnableViewState = true;

                        Panel pnl = new Panel();
                        pnl.Attributes.Add("style", "display: inline-block");
                        if (!isFirst)
                        {
                            pnl.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                        }
                        pnl.Controls.Add(inputType);

                        groupPanel.Controls.Add(pnl);

                        if (countGroupId == qtyGroupId)
                        {
                            this.control.Controls.Add(groupPanel);
                        }

                        isFirst = false;
                        countGroupId++;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void BuildPaymentOptions()
        {
            if (control == null)
            {
                return;
            }

            BaseEntity entity = new BaseEntity();
            List<Merchants> lstMerchants = new List<Merchants>();
            DataTable dt = MerchantBL.Instance.MethodPayment_GetList(ref entity);
            if (entity.Errors.Count == 0)
            {
                if (dt != null)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        lstMerchants.Add(new Merchants()
                        {
                            MerchantId = Convert.ToInt32(item["MerchantId"]),
                            MerchantName = item["MerchantName"].ToString(),
                            isChecked = Convert.ToInt32(item["isChecked"]),
                            GroupId = Convert.ToByte(item["GroupId"]),
                        });
                    }
                }

            }
            bool isFirst = true;
            if (entity.Errors.Count <= 0 && lstMerchants != null && lstMerchants.Count > 0)
            {
                foreach (Merchants item in lstMerchants)
                {
                    RadioButton rb = new RadioButton
                    {
                        ID = "M" + item.MerchantId,

                        GroupName = "Payment",
                        ClientIDMode = ClientIDMode.Static
                    };
                    rb.Attributes.Add("class", "rdbPayment");
                    rb.Attributes.Add("style", "vertical-align: sub");
                    rb.Attributes.Add("title", item.MerchantName);
                    rb.Checked = isFirst;
                    rb.Text = item.MerchantName;
                    rb.EnableViewState = true;

                    Panel pnl = new Panel();
                    pnl.Attributes.Add("style", "display: inline-block");
                    if (!isFirst)
                    {
                        pnl.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
                    }
                    pnl.Controls.Add(rb);
                    this.control.Controls.Add(pnl);

                    if (isFirst)
                    {
                        isFirst = false;
                    }
                }
            }
        }
        #endregion

    }
}