using Libreria.General;
using System;
using System.Web;
using PeruStore.Chat.src.app_code;
namespace PeruStore.Chat.src.control.Chat
{
    public partial class ucRedirectChatModule : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String paramId = HttpUtility.UrlEncode(Encriptador.Encriptar(hfUserId.Value.ToString()));
            String paramAppId = HttpUtility.UrlEncode(Encriptador.Encriptar(xConfig.ChatModuleId));
            String paramRolId = HttpUtility.UrlEncode(Encriptador.Encriptar("0"));

            panelChat.Attributes.Add("src", String.Format(xConfig.RedirectChatModule, paramId, paramAppId, paramRolId));
        }
        public void SetUserId(Int32 userId)
        {
            this.hfUserId.Value = userId.ToString();
        }

    }
}