using System;
using System.Web.UI;
using xAPI.Library.Base;
//using xss.ChatFrontEnd.Bl;
//using xss.ChatFrontEnd.Entity;
//using xss.ChatFrontEnd.Library;
using SystemGlobal_Ecommerce.Chat.src.app_code;
//using xss.Enumeration;
//using xss.Logger.Enums;
//using xss.Logger.Factory;
//using xss.Logger.Interfaces;
//using xss.Utils.Enums;

namespace SystemGlobal_Ecommerce.Chat.src.control.Chat
{
    public partial class ucChat : System.Web.UI.UserControl
    {
        //private static readonly ILoggerHandler log = LoggerFactory.Get(EnumLayerIdentifier.Presentation);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //LoadDropDownLists();
            }
        }

        public void Get_LoadTemplate(String fullName, String emailTo)
        {
            //BaseEntity objBase = new BaseEntity();
            //int IdTemplate = EmailTemplateManagmentBl.Instance.EmailTemplateManagment_GetIdbyCulture(ref objBase, (int)EnumTemplatePurpose.NewMessageChat, EnumHandler.GetValueById(typeof(EnumLanguageSession), (short)EnumLanguageSession.United_States), (short)EnumLanguageSession.United_States);
            //EmailTemplateManagment objTemplate = EmailTemplateManagmentBl.Instance.EmailTemplateManagment_GetDataTemplateById(ref objBase, IdTemplate);
            //if (objTemplate != null && objBase.Errors.Count == 0)
            //{
            //    hfHtmlTemplate.Value = objTemplate.Mail.Replace("{D_NAME}", fullName);
            //    hfEmailTo.Value = emailTo;
            //}
        }

        public void SetUserId(Int32 userId)
        {
            this.hfUserId.Value = userId.ToString();
        }

        public void SetUserFullName(String fullName)
        {
            this.hfFullName.Value = fullName.ToString();
        }

        //public void SetLanguageDefault(String languageId)
        //{
        //        ddlLanguage.SelectedValue = languageId;            
        //}

        //private void LoadDropDownLists()
        //{
        //    try
        //    {
        //        ObjectResultList<EntityMaster> lstModule = new ObjectResultList<EntityMaster>();
        //        ObjectResultList<EntityMaster> lstLanguage = new ObjectResultList<EntityMaster>();

        //        ObjectRequest<EntityMasterEnum> moduleEnum = new ObjectRequest<EntityMasterEnum>() { SenderObject = EntityMasterEnum.Module };
        //        ObjectRequest<EntityMasterEnum> languageEnum = new ObjectRequest<EntityMasterEnum>() { SenderObject = EntityMasterEnum.Language };

        //        lstModule = RequestService.ExecuteList<EntityMaster, EntityMasterEnum>(xConfig.ApiSearchMaster.GetListByEntityName, "POST", moduleEnum);
        //        lstLanguage = RequestService.ExecuteList<EntityMaster, EntityMasterEnum>(xConfig.ApiSearchMaster.GetListByEntityName, "POST", languageEnum);

        //        if (lstModule != null && lstModule.Elements != null && lstModule.Elements.Count > 0)
        //        {
        //            ddlModule.DataSource = lstModule.Elements;
        //            ddlModule.DataTextField = "EntityMasterName";
        //            ddlModule.DataValueField = "EntityMasterId";
        //            ddlModule.DataBind();


        //            ddlModule.SelectedValue = Convert.ToString((Int16)EnumModule.xBackoffice);


        //        }

        //        if (lstLanguage != null && lstLanguage.Elements != null && lstLanguage.Elements.Count > 0)
        //        {
        //            ddlLanguage.DataSource = lstLanguage.Elements;
        //            ddlLanguage.DataTextField = "EntityMasterName";
        //            ddlLanguage.DataValueField = "EntityMasterId";
        //            ddlLanguage.DataBind();

        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }
        //}

        
    }
}