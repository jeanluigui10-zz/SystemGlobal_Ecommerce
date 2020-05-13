using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.Services;
//using xss.ChatFrontEnd.Entity;
//using xss.ChatFrontEnd.Library;
//using xss.ChatFrontEnd.src.app_code;
//using xss.Logger.Enums;
//using xss.Logger.Factory;
//using xss.Logger.Interfaces;
namespace PeruStore.Chat.src.control.Chat
{
    public partial class ucWebMethodChat : System.Web.UI.Page
    {
        //private static readonly ILoggerHandler log = LoggerFactory.Get(EnumLayerIdentifier.Presentation);

        /*************** ucAdminSkill ***************/

        //#region WebMethod of ucAdminSkill
        //[WebMethod]
        //public static List<SkillAgent> Get_ByParameters(string perspectiveid, string agentid, string moduleid, string languageid)
        //{
        //    ObjectResultList<SkillAgent> resultList = new ObjectResultList<SkillAgent>();
        //    ResultSkillReport result = new ResultSkillReport
        //    {
        //        Result = "NoOk"
        //    };

        //    try
        //    {
        //        SkillAgentFilter param = new SkillAgentFilter();

        //        param.PerspectiveId = string.IsNullOrEmpty(perspectiveid) ? Convert.ToInt16(0) : Convert.ToInt16(perspectiveid);
        //        param.AgentId = string.IsNullOrEmpty(agentid) ? Convert.ToInt16(0) : Convert.ToInt16(agentid);
        //        param.ModuleId = string.IsNullOrEmpty(moduleid) ? Convert.ToInt16(0) : Convert.ToInt16(moduleid);
        //        param.LanguageId = string.IsNullOrEmpty(languageid) ? Convert.ToInt16(0) : Convert.ToInt16(languageid);

        //        ObjectRequest<SkillAgentFilter> objectRequest = new ObjectRequest<SkillAgentFilter>();

        //        objectRequest.SenderObject = param;

        //        resultList = RequestService.ExecuteList<SkillAgent, SkillAgentFilter>(xConfig.ApiChatService.GetListSkillByAgent, "POST", objectRequest);

        //        result.Data = resultList.Elements;
        //        result.Result = "Ok";
        //    }
        //    catch (Exception ex)
        //    {
        //        resultList = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return resultList.Elements;

        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> SkillCreate_WithModule(SkillAgentModule objSkill, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectResult<Boolean> resultExist = new ObjectResult<Boolean>();

        //    try
        //    {
        //        SkillAgentModule param = new SkillAgentModule();

        //        param.AgentId = String.IsNullOrEmpty(objSkill.AgentId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.AgentId);
        //        param.ModuleId = String.IsNullOrEmpty(objSkill.ModuleId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.ModuleId);
        //        param.SkillLevel = String.IsNullOrEmpty(objSkill.SkillLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.SkillLevel);
        //        param.PriorityLevel = String.IsNullOrEmpty(objSkill.PriorityLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.PriorityLevel);
        //        param.StatusId = Convert.ToInt16(EnumStatus.Enabled);
        //        param.CreateBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //        ObjectRequest<SkillAgentModule> objectRequest = new ObjectRequest<SkillAgentModule>();

        //        objectRequest.SenderObject = param;

        //        resultExist = RequestService.Execute<Boolean, SkillAgentModule>(xConfig.ApiChatService.ValidateSkillByAgentModule, "POST", objectRequest);

        //        if (resultExist != null && resultExist.Data == true)
        //        {
        //            if (resultExist.Id == 1)
        //            {
        //                result.Message = "Ok";
        //                result.Id = resultExist.Id;
        //                result.Data = resultExist.Data;
        //                return result;
        //            }
        //            else
        //            {
        //                result = RequestService.Execute<Boolean, SkillAgentModule>(xConfig.ApiChatService.CreateSkillModule, "POST", objectRequest);
        //                if (result != null && result.Data == true)
        //                {
        //                    result.Message = "Ok";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}


        //[WebMethod]
        //public static ObjectResult<Boolean> SkillModify_WithModule(SkillAgentModule objSkill, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();

        //    try
        //    {
        //        SkillAgentModule param = new SkillAgentModule();

        //        param.AgentId = String.IsNullOrEmpty(objSkill.AgentId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.AgentId);
        //        param.ModuleId = String.IsNullOrEmpty(objSkill.ModuleId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.ModuleId);
        //        param.SkillLevel = String.IsNullOrEmpty(objSkill.SkillLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.SkillLevel);
        //        param.PriorityLevel = String.IsNullOrEmpty(objSkill.PriorityLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.PriorityLevel);
        //        param.CreateBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //        ObjectRequest<SkillAgentModule> objectRequest = new ObjectRequest<SkillAgentModule>();

        //        objectRequest.SenderObject = param;

        //        result = RequestService.Execute<Boolean, SkillAgentModule>(xConfig.ApiChatService.UpdateSkillModule, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> SkillCreate_WithLanguage(SkillAgentLanguage objSkill, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectResult<Boolean> resultExist = new ObjectResult<Boolean>();
        //    try
        //    {
        //        SkillAgentLanguage param = new SkillAgentLanguage();

        //        param.AgentId = String.IsNullOrEmpty(objSkill.AgentId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.AgentId);
        //        param.LanguageId = String.IsNullOrEmpty(objSkill.LanguageId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.LanguageId);
        //        param.SkillLevel = String.IsNullOrEmpty(objSkill.SkillLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.SkillLevel);
        //        param.PriorityLevel = String.IsNullOrEmpty(objSkill.PriorityLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.PriorityLevel);
        //        param.StatusId = Convert.ToInt16(EnumStatus.Enabled);
        //        param.CreateBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //        ObjectRequest<SkillAgentLanguage> objectRequest = new ObjectRequest<SkillAgentLanguage>();

        //        objectRequest.SenderObject = param;

        //        resultExist = RequestService.Execute<Boolean, SkillAgentLanguage>(xConfig.ApiChatService.ValidateSkillByAgentLanguage, "POST", objectRequest);

        //        if (resultExist != null && resultExist.Data == true)
        //        {
        //            if (resultExist.Id == 1)
        //            {
        //                result.Message = "Ok";
        //                result.Id = resultExist.Id;
        //                result.Data = resultExist.Data;
        //                return result;
        //            }
        //            else
        //            {
        //                result = RequestService.Execute<Boolean, SkillAgentLanguage>(xConfig.ApiChatService.CreateSkillLanguage, "POST", objectRequest);
        //                if (result != null && result.Data == true)
        //                {
        //                    result.Message = "Ok";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> SkillModify_WithLanguage(SkillAgentLanguage objSkill, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();

        //    try
        //    {
        //        SkillAgentLanguage param = new SkillAgentLanguage();

        //        param.AgentId = String.IsNullOrEmpty(objSkill.AgentId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.AgentId);
        //        param.LanguageId = String.IsNullOrEmpty(objSkill.LanguageId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.LanguageId);
        //        param.SkillLevel = String.IsNullOrEmpty(objSkill.SkillLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.SkillLevel);
        //        param.PriorityLevel = String.IsNullOrEmpty(objSkill.PriorityLevel.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.PriorityLevel);
        //        param.CreateBy = sessionUserId; /*BaseSession.SsUser.ID*/;
        //        ObjectRequest<SkillAgentLanguage> objectRequest = new ObjectRequest<SkillAgentLanguage>();

        //        objectRequest.SenderObject = param;

        //        result = RequestService.Execute<Boolean, SkillAgentLanguage>(xConfig.ApiChatService.UpdateSkillLanguage, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> SkillDelete_WithModule(SkillAgentModule objSkill, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();

        //    try
        //    {
        //        SkillAgentModule param = new SkillAgentModule();

        //        param.AgentId = String.IsNullOrEmpty(objSkill.AgentId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.AgentId);
        //        param.ModuleId = String.IsNullOrEmpty(objSkill.ModuleId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.ModuleId);
        //        param.StatusId = Convert.ToInt16(EnumStatus.Disabled);
        //        param.CreateBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //        ObjectRequest<SkillAgentModule> objectRequest = new ObjectRequest<SkillAgentModule>();

        //        objectRequest.SenderObject = param;

        //        result = RequestService.Execute<Boolean, SkillAgentModule>(xConfig.ApiChatService.ChangeStateSkillModule, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> SkillDelete_WithLanguage(SkillAgentLanguage objSkill, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();

        //    try
        //    {
        //        SkillAgentLanguage param = new SkillAgentLanguage();

        //        param.AgentId = String.IsNullOrEmpty(objSkill.AgentId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.AgentId);
        //        param.LanguageId = String.IsNullOrEmpty(objSkill.LanguageId.ToString()) ? Convert.ToInt16(0) : Convert.ToInt16(objSkill.LanguageId);
        //        param.StatusId = Convert.ToInt16(EnumStatus.Disabled);
        //        param.CreateBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //        ObjectRequest<SkillAgentLanguage> objectRequest = new ObjectRequest<SkillAgentLanguage>();

        //        objectRequest.SenderObject = param;

        //        result = RequestService.Execute<Boolean, SkillAgentLanguage>(xConfig.ApiChatService.ChangeStateSkillLanguage, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}
        //#endregion

        ///*************** ucReportConversation ***************/

        //#region WebMethods of ucReportConversation
        //[WebMethod]
        //public static object ExecuteReportChatMessage(String objParameters, String markets, String agents)
        //{
        //    JavaScriptSerializer srParm = new JavaScriptSerializer();
        //    srParametersFilterChat objParm = srParm.Deserialize<srParametersFilterChat>(objParameters);

        //    #region GetMarkets
        //    JavaScriptSerializer sr = new JavaScriptSerializer();
        //    List<String> listMarketsString = sr.Deserialize<List<String>>(markets);
        //    List<Int32> listMarketInt = new List<Int32>();
        //    if (listMarketsString.Count > 0)
        //    {
        //        if (listMarketsString[0].ToString().Equals("multiselect-all")) { listMarketsString.RemoveAt(0); }
        //        listMarketInt = listMarketsString.Select(Int32.Parse).ToList();
        //    }
        //    #endregion

        //    #region GetAgents
        //    JavaScriptSerializer srAgent = new JavaScriptSerializer();
        //    List<String> listAgentsString = srAgent.Deserialize<List<String>>(agents);
        //    List<Int32> listAgentInt = new List<Int32>();
        //    if (listAgentsString.Count > 0)
        //    {
        //        if (listAgentsString[0].ToString().Equals("multiselect-all")) { listAgentsString.RemoveAt(0); }
        //        listAgentInt = listAgentsString.Select(Int32.Parse).ToList();
        //    }
        //    #endregion

        //    ConversationResponseEntity objConversation = new ConversationResponseEntity();
        //    objConversation.DateStart = objParm.DateStart;
        //    objConversation.DateEnd = objParm.DateEnd;
        //    objConversation.Distributorid = objParm.Distributorid;
        //    objConversation.UserName = objParm.UserName;
        //    objConversation.ListIdsMarkets = listMarketInt.Count == 0 ? listMarketInt = null : listMarketInt;
        //    objConversation.ListIdsAgents = listAgentInt.Count == 0 ? listAgentInt = null : listAgentInt;
        //    ObjectResultList<ConversationResponseEntity> result;

        //    try
        //    {
        //        var objectRequest = new ObjectRequest<ConversationResponseEntity>()
        //        {
        //            SenderObject = objConversation
        //        };

        //        result = RequestService.ExecuteList<ConversationResponseEntity, ConversationResponseEntity>(xConfig.ApiChatService.GetListConversationByFilter
        //            , "POST"
        //            , objectRequest);

        //        return result.Elements;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Save(EnumLogLevel.Fatal, ex);
        //        return null;
        //    }
        //}
        //#endregion

        ///*************** ucUserRolChat ***************/

        //[WebMethod]
        //public static object GetListUsersRoleType(String objParameters)
        //{
        //    JavaScriptSerializer srParm = new JavaScriptSerializer();
        //    UserRoleType objUserRoleType = srParm.Deserialize<UserRoleType>(objParameters);

        //    ObjectResultList<UserRoleType> result;

        //    try
        //    {
        //        var objectRequest = new ObjectRequest<UserRoleType>()
        //        {
        //            SenderObject = objUserRoleType
        //        };

        //        result = RequestService.ExecuteList<UserRoleType, UserRoleType>(xConfig.ApiChatService.GetListUsersRoleType, "POST", objectRequest);

        //        return result.Elements;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Save(EnumLogLevel.Fatal, ex);
        //        return null;
        //    }
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> CreateUsersRoleType(UserRoleType obj, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectResult<Boolean> resultExist = new ObjectResult<Boolean>();
        //    ObjectRequest<UserRoleType> objectRequest = new ObjectRequest<UserRoleType>();
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            obj.StatusId = Convert.ToInt16(EnumStatus.Enabled);
        //            obj.CreatedBy = sessionUserId; /*BaseSession.SsUser.ID;*/ 
        //            objectRequest.SenderObject = obj;
        //        }

        //        resultExist = RequestService.Execute<Boolean, UserRoleType>(xConfig.ApiChatService.ValidateUsersRoleType, "POST", objectRequest);

        //        if (resultExist != null && resultExist.Data == true)
        //        {
        //            if (resultExist.Id == 1)
        //            {
        //                result.Message = "Ok";
        //                result.Id = resultExist.Id;
        //                result.Data = resultExist.Data;
        //                return result;
        //            }
        //            else
        //            {
        //                result = RequestService.Execute<Boolean, UserRoleType>(xConfig.ApiChatService.CreateUsersRoleType, "POST", objectRequest);
        //                if (result != null && result.Data == true)
        //                {
        //                    result.Message = "Ok";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> UpdateUsersRoleType(UserRoleType obj, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectRequest<UserRoleType> objectRequest = new ObjectRequest<UserRoleType>();
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            obj.StatusId = Convert.ToInt16(EnumStatus.Enabled);
        //            obj.UpdatedBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //            objectRequest.SenderObject = obj;
        //        }

        //        result = RequestService.Execute<Boolean, UserRoleType>(xConfig.ApiChatService.UpdateUsersRoleType, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> DeleteUsersRoleType(UserRoleType obj)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectRequest<UserRoleType> objectRequest = new ObjectRequest<UserRoleType>();
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            objectRequest.SenderObject = obj;
        //        }
        //        result = RequestService.Execute<Boolean, UserRoleType>(xConfig.ApiChatService.DeleteUsersRoleType, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        ///*************** ucUsersAssignmentChat ***************/

        //[WebMethod]
        //public static object GetListUserAccountGroup(String objParameters)
        //{
        //    JavaScriptSerializer srParm = new JavaScriptSerializer();
        //    UserAccountGroups objUserRoleType = srParm.Deserialize<UserAccountGroups>(objParameters);

        //    ObjectResultList<UserAccountGroups> result;

        //    try
        //    {
        //        var objectRequest = new ObjectRequest<UserAccountGroups>()
        //        {
        //            SenderObject = objUserRoleType
        //        };

        //        result = RequestService.ExecuteList<UserAccountGroups, UserAccountGroups>(xConfig.ApiChatService.GetListUserAccountGroup, "POST", objectRequest);

        //        return result.Elements;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Save(EnumLogLevel.Fatal, ex);
        //        return null;
        //    }
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> CreateUserAccountGroup(UserAccountGroups obj, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectResult<Boolean> resultExist = new ObjectResult<Boolean>();
        //    ObjectRequest<UserAccountGroups> objectRequest = new ObjectRequest<UserAccountGroups>();
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            obj.StatusId = Convert.ToInt16(EnumStatus.Enabled);
        //            obj.CreatedBy = sessionUserId; /*BaseSession.SsUser.ID;*/
        //            objectRequest.SenderObject = obj;
        //        }

        //        resultExist = RequestService.Execute<Boolean, UserAccountGroups>(xConfig.ApiChatService.ValidateUserAccountGroup, "POST", objectRequest);

        //        if (resultExist != null && resultExist.Data == true)
        //        {
        //            if (resultExist.Id == 1)
        //            {
        //                result.Message = "Ok";
        //                result.Id = resultExist.Id;
        //                result.Data = resultExist.Data;
        //                return result;
        //            }
        //            else
        //            {
        //                result = RequestService.Execute<Boolean, UserAccountGroups>(xConfig.ApiChatService.CreateUserAccountGroup, "POST", objectRequest);
        //                if (result != null && result.Data == true)
        //                {
        //                    result.Message = "Ok";
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> UpdateUserAccountGroup(UserAccountGroups obj, Int32 sessionUserId)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectResult<Boolean> resultExist = new ObjectResult<Boolean>();
        //    ObjectRequest<UserAccountGroups> objectRequest = new ObjectRequest<UserAccountGroups>();
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            obj.StatusId = Convert.ToInt16(EnumStatus.Enabled);
        //            obj.UpdatedBy = sessionUserId; ; /*BaseSession.SsUser.ID*/; 
        //            objectRequest.SenderObject = obj;
        //        }
        //        resultExist = RequestService.Execute<Boolean, UserAccountGroups>(xConfig.ApiChatService.ValidateUserAccountGroup, "POST", objectRequest);
        //        if (resultExist != null && resultExist.Data == true)
        //        {
        //            if (resultExist.Id == 1)
        //            {
        //                result.Message = "Ok";
        //                result.Id = resultExist.Id;
        //                result.Data = resultExist.Data;
        //                return result;
        //            }
        //            else
        //            {
        //                result = RequestService.Execute<Boolean, UserAccountGroups>(xConfig.ApiChatService.UpdateUserAccountGroup, "POST", objectRequest);
        //                if (result != null && result.Data == true)
        //                {
        //                    result.Message = "Ok";
        //                }
        //            }
        //        }



        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

        //[WebMethod]
        //public static ObjectResult<Boolean> DeleteUserAccountGroup(UserAccountGroups obj)
        //{
        //    ObjectResult<Boolean> result = new ObjectResult<Boolean>();
        //    ObjectRequest<UserAccountGroups> objectRequest = new ObjectRequest<UserAccountGroups>();
        //    try
        //    {
        //        if (obj != null)
        //        {
        //            objectRequest.SenderObject = obj;
        //        }
        //        result = RequestService.Execute<Boolean, UserAccountGroups>(xConfig.ApiChatService.DeleteUserAccountGroup, "POST", objectRequest);
        //        if (result != null && result.Data == true)
        //        {
        //            result.Message = "Ok";
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result = null;
        //        log.Save(EnumLogLevel.Fatal, ex);
        //    }

        //    return result;
        //}

    }
}