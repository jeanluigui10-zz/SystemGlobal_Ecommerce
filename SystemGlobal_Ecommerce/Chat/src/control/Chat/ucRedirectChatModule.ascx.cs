using System;
using System.Web;
using xAPI.Library.General;
using SystemGlobal_Ecommerce.Chat.src.app_code;
namespace SystemGlobal_Ecommerce.Chat.src.control.Chat
{
    public partial class ucRedirectChatModule : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String paramId = HttpUtility.UrlEncode(Encryption.Encrypt(hfUserId.Value.ToString()));
            String paramAppId = HttpUtility.UrlEncode(Encryption.Encrypt(xConfig.ChatModuleId));
            String paramRolId = HttpUtility.UrlEncode(Encryption.Encrypt("0"));

            panelChat.Attributes.Add("src", String.Format(xConfig.RedirectChatModule, paramId, paramAppId, paramRolId));
        }
        public void SetUserId(Int32 userId)
        {
            this.hfUserId.Value = userId.ToString();
        }

    }
}