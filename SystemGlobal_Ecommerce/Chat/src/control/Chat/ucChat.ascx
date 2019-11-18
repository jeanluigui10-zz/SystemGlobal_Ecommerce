<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChat.ascx.cs" Inherits="SystemGlobal_Ecommerce.Chat.src.control.Chat.ucChat" %>

<script type="text/javascript">
    var Counter;
    $(function () {

        //--js Chat---//
        $.support.cors = true;

        $.connection.hub.url = "<%=SystemGlobal_Ecommerce.Chat.src.app_code.xConfig.url_apichat + "signalr/"%>";

        Counter = $.connection.counterHub;

        $.connection.hub.start().done(function () {

        });
        $.connection.hub.disconnected(function () {
            setTimeout(function () {
                $.connection.hub.start();
            }, 5000); // Restart connection after 5 seconds.
        });
        Counter.client.receivedFromManager = function (obj) {

            try {

                $("input[id$=ChatId]").val(obj.ChatId);
                $("input[id$=AgentToken]").val(obj.AgentToken);
                $("input[id$=UserToken]").val(obj.UserToken);

                if (obj.IsSendUser == 0) {

                    lstMessageManager = [];
                    lstMessageManager.push({
                        message: obj.Message,
                        accountAgentName: (obj.AccountAgentName == undefined || obj.AccountAgentName == "") ? "" : obj.AccountAgentName
                    });
                    $("#divConversation").append(fn_LoadTemplates("messageManager", { lstMessageManager }));
                    $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                } else {
                    lstMessageUser = [];
                    lstMessageUser.push({
                        message: obj.Message,
                        username: (obj.UserName == undefined || obj.UserName == "") ? "" : obj.UserName
                    });
                    $("#divConversation").append(fn_LoadTemplates("messageUser", { lstMessageUser }));
                    $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                }

                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }

        };

        Counter.client.chatManagerDisconnect = function (msg) {
            try {
                var html = '';
                html += ' <div class="direct-chat-msg right">                                                                                ';
                html += '   <div class="direct-chat-info clearfix">                                                                          ';
                html += '     <span class="direct-chat-name pull-right">' + 'Desconectado' + '</span>                                                      ';
                    html += '     <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>                                       ';
                    html += '   </div>                                                                                                           ';
                    html += '  <div class="" style="background: red;text-align: center;">                                                                                    ';
                    html += '   <span style=" color: white;"> ' + 'En estos momentos no hay un agente disponible.' + '</span>                                                                                  ';
                    //html += '   <a style="color: white;cursor:pointer;" onclick="Fn_InitChatFilter();"> ' + 'Click here.' + '</a>  ';
                html += '   </div>                                                                                                           ';
                html += ' </div>                                                                                                             ';

                $("input[id$=ChatId]").val("0");
                $("input[id$=AgentToken]").val("");
                $("input[id$=ManagerToken]").val("");
                $("#divConversation").append(html);
                $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                //$("#message").prop('disabled', true);
                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }


        };
        Counter.client.chatManagerNoFoundAgentBySkills = function (msg) {
            try {
                var html = '';
                html += ' <div class="direct-chat-msg right">                                                                                ';
                html += '   <div class="direct-chat-info clearfix">                                                                          ';
                html += '     <span class="direct-chat-name pull-right">' + 'Disconnected' + '</span>                                                      ';
                    html += '     <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>                                       ';
                    html += '   </div>                                                                                                           ';
                    html += '  <div class="" style="background: red;text-align: center;">                                                                                    ';
                    html += '   <span style=" color: white;"> ' + 'At this time our agents are not available, you may be interested in looking for agents in another language.' + '</span>   ';
                    //html += '   <a style="color: white;cursor:pointer;" onclick="Fn_InitChatFilter();"> ' + 'Click here.' + '</a>  ';
                html += '   </div>                                                                                                           ';
                html += ' </div>                                                                                                             ';

                $("input[id$=ChatId]").val("0");
                $("input[id$=AgentToken]").val("");
                $("#divConversation").append(html);
                $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                $("#message").prop('disabled', true);
                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }


        };
        Counter.client.serverOrderDisconnect = function (msg) {

            try {
                var html = '';
                html += ' <div class="direct-chat-msg right">                                                                                ';
                html += '   <div class="direct-chat-info clearfix">                                                                          ';
                html += '     <span class="direct-chat-name pull-right">' + 'Desconectado' + '</span>                                                      ';
                    html += '     <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>                                       ';
                    html += '   </div>                                                                                                           ';
                    html += '  <div class="" style="background: gray;text-align: center;">                                                                                    ';
                    html += '   <span style=" color: white;"> ' + 'Thanks bye.' + '</span>   ';
                    //html += '   <a style="color: white;cursor:pointer;" onclick="Fn_InitChatFilter();"> ' + 'Click here.' + '</a>  ';
                html += '   </div>                                                                                                           ';
                html += ' </div>                                                                                                             ';

                $("input[id$=ChatId]").val("0");
                $("input[id$=AgentToken]").val("");
                $("input[id$=ManagerToken]").val("");
                $("#divConversation").append(html);
                $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                $("#message").prop('disabled', true);
                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }

        };

        Counter.client.messageTransferSuccessToAgent = function () {
            try {
                var html = '';
                html += ' <div class="direct-chat-msg right">                                                                                ';
                html += '   <div class="direct-chat-info clearfix">                                                                          ';
                html += '     <span class="direct-chat-name pull-right">' + 'Transfer' + '</span>                                                      ';
                    html += '     <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>                                       ';
                    html += '   </div>                                                                                                           ';
                    html += '  <div class="" style="background:green;text-align: center;">                                                                                    ';
                    html += '   <span style=" color: white;"> ' + 'You have been transferred to another agent for your attention.' + '</span>      ';
                html += '   </div>                                                                                                           ';
                html += ' </div>                                                                                                             ';
                $("#divConversation").append(html);
                $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }
        };
        Counter.client.messagePosessionChatToAgent = function (ManagerToken) {
            try {
                var html = '';
                html += ' <div class="direct-chat-msg right">                                                                                ';
                html += '   <div class="direct-chat-info clearfix">                                                                          ';
                html += '     <span class="direct-chat-name pull-right">' + 'Transfer' + '</span>                                                      ';
                    html += '     <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>                                       ';
                    html += '   </div>                                                                                                           ';
                    html += '  <div class="" style="background:orange;text-align: center;">                                                                                    ';
                    html += '   <span style=" color: white;"> ' + 'Your attention will be attended by Manager.' + '</span>      ';
                html += '   </div>                                                                                                           ';
                html += ' </div>                                                                                                             ';
                $("input[id$=ManagerToken]").val(ManagerToken);
                $("#divConversation").append(html);
                $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }
        };

        Counter.client.messageTransferChatToManager = function (ManagerToken) {
            try {
                var html = '';
                html += ' <div class="direct-chat-msg right">                                                                                ';
                html += '   <div class="direct-chat-info clearfix">                                                                          ';
                html += '     <span class="direct-chat-name pull-right">' + 'Transfer>' + '</span>                                                      ';
                html += '     <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>                                       ';
                html += '   </div>                                                                                                           ';
                html += '  <div class="" style="background:GoldenRod;text-align: center;">                                                                                    ';
                html += '   <span style=" color: white;"> ' + 'Your attention will be attended by Manager.' + '</span>      ';
                html += '   </div>                                                                                                           ';
                html += ' </div>                                                                                                             ';
                $("input[id$=ManagerToken]").val(ManagerToken);
                $("#divConversation").append(html);
                $("#divConversation").scrollTop($("#divConversation")[0].scrollHeight);
                $("#loader").css('display', 'none');
            } catch (e) {
                $("#loader").css('display', 'none');
            }
        };


        $("#btnLateral").on("click", function () {
            $("#formChat").removeClass("hide");
        });

        $('#message').keypress(function (e) {
            var key = e.which;
            if (key == 13) {
                Fn_SendMessage();
            }
        });

        $("input[id$=message]").keyup(function () {
            if ($(this).val().trim().length <= 0) {
                $("#sendmessage").prop('disabled', true);
            }
            else {
                $("#sendmessage").removeAttr("disabled");
            }
        });
    });
    //--End js Chat---//

    /*Chat*/
    function Fn_SendMessage() {
        if ($("#message").val().trim() == "" || $("#username").val().trim() == "") {
            return false;
        }
        if ($("#username").val().trim() == "") {
            $("#username").attr('disabled', 'false');
        }
        var messageText = $("#message").val();
        var template = $("input[id$=hfHtmlTemplate]").val();
        var TemplateWithMsg = template.replace("{D_MESSAGE}", messageText);
        var EmailToText = $("input[id$=hfEmailTo]").val();
        var SubjectText = "New message chat";

        var obj = {
            ChatId: $("input[id$=ChatId]").val(),
            ModuleAppId: "1",
            UserName: $("#username").val(),
            UserEmail: "",
            Message: $("#message").val(),
            DateMessage: "",
            AgentToken: $("input[id$=AgentToken]").val(),
            DistributorId: $("input[id$=hfUserId]").val(), <%--<%=xss.ChatFrontEnd.src.app_code.BaseSession.SsDistributor.Id%>,--%>
            ChatBySkillModuleId: $("select[id$=ddlModule] option:selected").val(),
            ChatBySkillLanguageId: $("select[id$=ddlLanguage] option:selected").val(),
            TemplateHtml: TemplateWithMsg,
            Subject: SubjectText,
            Emailto: EmailToText,
            ManagerToken: $("input[id$=ManagerToken]").val(),
        };
        $("#loader").css('display', 'block');
        Counter.server.sendToManager(obj);

        $("#message").val("").focus();
    }

    //function Fn_InitChat() {

    //    $("#loader").css('display', 'block');
    //    setTimeout(function () { $("#loader").fadeOut(1500); }, 1500);
    //    setTimeout(function () { $("#divInitChat").fadeOut(1500); }, 1500);
    //    setTimeout(function () { $("#username").fadeIn(1500); }, 1500);
    //    setTimeout(function () { $("#divFooterChat").fadeIn(1500); }, 1500);
    //    $("#message").prop('disabled', false);
    //    $("#message").val("").focus();
    //}
    function Fn_InitChatFilter() {
        setTimeout(function () { $("#divInitChat").fadeIn(1500); }, 1500);
        setTimeout(function () { $("#username").fadeOut(1500); }, 1500);
        setTimeout(function () { $("#divFooterChat").fadeOut(1500); }, 1500);
        $("#divConversation").empty();
    }
    function Fn_CloseModal() {
        //$("input[id$=ChatId]").val("0");
        //$("input[id$=AgentToken]").val("");

        $("#formChat").addClass("hide");
    }
        /*End Chat*/


</script>

<%--Desing Chat Style--%>

<div class="row bootstrap snippets hide chat-container" id="formChat">
    <div class="col-md-12">
        <div class="box box-primary direct-chat direct-chat-primary" style="box-shadow: 0 3px 6px rgba(0,0,0,0.16), 0 3px 6px rgba(0,0,0,0.23)">
            <div class="box-header with-border">
                <h3 class="box-title">Chat</h3>
                <input type="text" id="username" name="message" autocomplete="off" value="<%=this.hfFullName.Value%>" placeholder="Escriba su nombre ..." class="form-control" />
                <div class="box-tools pull-right">
                    <i class="fa fa-times" type="button" onclick="Fn_CloseModal();" data-widget="remove" style="cursor: pointer;"></i>
                </div>
            </div>
            <div class="box-body">
       <%--         <div style="text-align: center" id="divInitChat">
                    <h3 class="box-title" style="font-size: 20px;">Select Language and Module</h3>
                    <div class="cotainer">
                        <div class="row justify-content-center">
                            <div class="col-md-10">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="form-group row" style="margin-top: 10px;">
                                            <label for="email_address" class="col-md-4 col-form-label text-md-right">Language:</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlLanguage" class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="form-group row" style="margin-top: 10px;">
                                            <label for="password" class="col-md-4 col-form-label text-md-right">Q.A.:</label>
                                            <div class="col-md-8">
                                                <asp:DropDownList ID="ddlModule" class="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <button id="btnInit" type="button" onclick="Fn_InitChat();" class="btn btn-primary btn-flat" style="margin-top: 10px;">Start</button>
                </div>--%>

                <div id="loader" style="display: none"></div>
                <div class="direct-chat-messages" id="divConversation">
                </div>
            </div>
            <div class="box-footer"  id="divFooterChat">
                <div class="input-group">
                    <input type="text" id="message" name="message" placeholder="Write your message..." class="form-control" />
                    <span class="input-group-btn">
                        <button id="sendmessage" disabled type="button" onclick="Fn_SendMessage();" class="btn btn-primary btn-flat">Send</button>
                    </span>
                </div>
            </div>
        </div>
    </div>
</div>
<button type="button" class="botonF1" id="btnLateral" style="display: inline-block; margin-right: 2px !important; display: inline-block; top: 34% !important; right: 0 !important; width: 50px !important; height: 50px !important; z-index: 1">
    <img id="imgLateral" src="../../../../src/images/support-icon.png" style="width: 32px;" />
</button>
<input type="hidden" id="ChatId" value="0" />
<input type="hidden" id="AgentToken" value="0" />
<input type="hidden" id="UserToken" value="" />
<input type="hidden" id="hfUserId" value="0" runat="server" />
<input type="hidden" id="hfFullName" value="" runat="server" />
<input type="hidden" id="hfHtmlTemplate" value="" runat="server" />
<input type="hidden" id="hfEmailTo" value="" runat="server" />
<input type="hidden" id="ManagerToken" value="" />
<%--End Desing Chat Style--%>

<script type="text/x-handlebars-template" id="messageManager">
    {{# each lstMessageManager}}
        <div class="direct-chat-msg">
            <div class="direct-chat-info clearfix">
                <span class="direct-chat-name pull-left">{{accountAgentName}}</span>
                <span class="direct-chat-timestamp pull-right"><%: DateTime.Now.ToString("HH:mm") %></span>
            </div>
            <img class="direct-chat-img" src="https://www.whittierfirstday.org/wp-content/uploads/default-user-image-e1501670968910.png" alt="Message User Image">
            <div class="direct-chat-text" style="word-wrap: break-word">
                {{message}}
            </div>
        </div>

    {{/each}}
</script>

<script type="text/x-handlebars-template" id="messageUser">
    {{# each lstMessageUser}}
        <div class="direct-chat-msg right">
            <div class="direct-chat-info clearfix">
                <span class="direct-chat-name pull-right">{{username}}</span>
                <span class="direct-chat-timestamp pull-left"><%: DateTime.Now.ToString("HH:mm") %></span>
            </div>
            <img class="direct-chat-img" src="https://png.pngtree.com/png-vector/20190710/ourlarge/pngtree-user-vector-avatar-png-image_1541962.jpg" alt="Message User Image">
            <div class="direct-chat-text" style="word-wrap: break-word">
                {{message}}
            </div>
        </div>
    {{/each}}
</script>
