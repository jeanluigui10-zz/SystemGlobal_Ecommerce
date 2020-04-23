using System;
using System.Web;
using System.Web.Configuration;

namespace SystemGlobal_Ecommerce.Chat.src.app_code
{
    public class xConfig
    {
        //public static String Signalrhubs { get; set; } = "signalr/hubs";
        public static String url_apichat { get { return WebConfigurationManager.AppSettings["url_apichat"]; } }

        public static String RedirectChatModule { get { return HttpUtility.UrlDecode(WebConfigurationManager.AppSettings["Domain_ChatModule"]); } }
        public static String ChatModuleId { get { return HttpUtility.UrlDecode(WebConfigurationManager.AppSettings["ChatModuleId"]); } }

        public static class ApiChatService
        {
            public static String UrlApiChatService { get { return WebConfigurationManager.AppSettings["url_apichatservice"]; } }

            public static String GetReport
            {
                get { return UrlApiChatService + "api/Conversation/GetReport/"; }
            }

            public static String GetListConversationByReport
            {
                get { return UrlApiChatService + "api/Conversation/GetListConversationByReport/"; }
            }
            public static String GetListSkillByAgent
            {
                get { return UrlApiChatService + "api/SkillAgent/GetListSkillByAgent/"; }

            }
            public static String UpdateSkillModule
            {
                get { return UrlApiChatService + "api/SkillAgent/UpdateSkillModule/"; }

            }
            public static String UpdateSkillLanguage
            {
                get { return UrlApiChatService + "api/SkillAgent/UpdateSkillLanguage/"; }

            }
            public static String CreateSkillModule
            {
                get { return UrlApiChatService + "api/SkillAgent/CreateSkillModule/"; }

            }
            public static String CreateSkillLanguage
            {
                get { return UrlApiChatService + "api/SkillAgent/CreateSkillLanguage/"; }

            }
            public static String ValidateSkillByAgentModule
            {
                get { return UrlApiChatService + "api/SkillAgent/ValidateSkillByAgentModule/"; }

            }
            public static String ValidateSkillByAgentLanguage
            {
                get { return UrlApiChatService + "api/SkillAgent/ValidateSkillByAgentLanguage/"; }

            }

            public static String ChangeStateSkillModule
            {
                get { return UrlApiChatService + "api/SkillAgent/ChangeStateSkillModule/"; }

            }

            public static String ChangeStateSkillLanguage
            {
                get { return UrlApiChatService + "api/SkillAgent/ChangeStateSkillLanguage/"; }

            }
            public static String GetListConversationByFilter
            {
                get { return UrlApiChatService + "api/Conversation/GetListConversationByFilter/"; }
            }

            /*Services UserRolType*/
            public static String GetListUsersRoleType
            {
                get { return UrlApiChatService + "api/UserRol/GetListUsersRoleType/"; }
            }

            public static String CreateUsersRoleType
            {
                get { return UrlApiChatService + "api/UserRol/CreateUsersRoleType/"; }

            }
            public static String UpdateUsersRoleType
            {
                get { return UrlApiChatService + "api/UserRol/UpdateUsersRoleType/"; }

            }
            public static String DeleteUsersRoleType
            {
                get { return UrlApiChatService + "api/UserRol/DeleteUsersRoleType/"; }

            }
            public static String ValidateUsersRoleType
            {
                get { return UrlApiChatService + "api/UserRol/ValidateUsersRoleType/"; }

            }
            /*Services UserAccountGroup*/
            public static String GetListUserAccountGroup
            {
                get { return UrlApiChatService + "api/UserAccount/GetListUserAccountGroup/"; }
            }

            public static String CreateUserAccountGroup
            {
                get { return UrlApiChatService + "api/UserAccount/CreateUserAccountGroup/"; }

            }
            public static String UpdateUserAccountGroup
            {
                get { return UrlApiChatService + "api/UserAccount/UpdateUserAccountGroup/"; }

            }
            public static String DeleteUserAccountGroup
            {
                get { return UrlApiChatService + "api/UserAccount/DeleteUserAccountGroup/"; }

            }
            public static String ValidateUserAccountGroup
            {
                get { return UrlApiChatService + "api/UserAccount/ValidateUserAccountGroup/"; }

            }
        }


        public static class ApiSearchMaster
        {
            public static String UrlApiSearchMaster { get { return WebConfigurationManager.AppSettings["url_apisearchmaster"]; } }

            public static String GetList
            {
                get { return UrlApiSearchMaster + "api/ManagerMasterEntity/SearchMasterGetList/"; }
            }
            public static String GetListByEntityName
            {
                get { return UrlApiSearchMaster + "api/ManagerMasterEntity/GetListByEntityName/"; }

            }
        }

    }

    

}
