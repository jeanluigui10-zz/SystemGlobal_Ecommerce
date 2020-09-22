<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
       <script type="text/javascript">
       
        function Fn_LoginCustomer()
        {
            try {
                var objCustomer = {
                    Email: $("input[id$=txtUsername]").val(),
                    Password: $("input[id$=txtPassowrd]").val()
                };
                var success = function (asw) {

                    if (asw.d != null)
                    {
                        if (asw.d.Result == "Ok")
                        {
                            window.location.href = asw.d.Msg;
                        }
                        else
                        {
                            if (asw.d.Result == "NoOk")
                            {
                                fn_message('i', asw.d.Msg);
                            }
                        }
                    }
                    else {
                        fn_message('e', 'Ocurrio un error al intentar Iniciar Sesion.', 'message_row');
                    }
                }
                var error = function (xhr, ajaxOptions, thrownError) {
                    fn_message('e', 'Ocurrio un error al enviar la data.', 'message_row');
                }
                var complete = function () {
                }
                fn_callmethodComplete("Login.aspx/LoginSecurity", JSON.stringify({ objCust: objCustomer }), success, error, complete);

            } catch (e)
            {
                fn_message('e', 'Ocurrio un error al enviar la data.', 'message_row');
            }
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Login</a></li>
			<li>Inicio de Sesión</li>
		</ul>
	</div>
   </div>
<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder" id="divMessageTop" style="font-weight: bold;">Bienvenido a Mickypepa</h1>
			<div class="tt-login-form">
				<div class="row" style="margin:auto">
				<%--	<div class="col-xs-12 col-md-6">
                             <div class="tt-item">
							<h2 class="tt-title">ERES NUEVO?</h2>
							<label class="tt-title">Registrandote podras crear tu lista y hacer tu pedido.</label>
						  <asp:Image ID="imgLogin" runat="server" class="col-xs-12 col-md-6"  style="border-radius: 50%;margin-left: 25%;" />
						</div>
					</div>--%>
					<%--<div  class="col-xs-12 col-md-6">--%>
						<div class="tt-item">
						    <p style="font-weight: bold;">Registrate si aun no tienes una cuenta con nosotros.</p>
							<h2 class="tt-title">Iniciar Sesión</h2>                                  
							<div class="form-default form-top">
                                       <div id="message_row"></div>
									<div class="form-group">
										<label for="loginInputName">Usuario *</label>
										<div class="tt-required">* Campos requeridos</div>
										<input type="text" runat="server" name="name" class="form-control" id="txtUsername" placeholder="Ingrese su Usuario">
									</div>
									<div class="form-group">
										<label for="loginInputEmail">Contraseña *</label>
										<input runat="server" type="password" name="passowrd" class="form-control" id="txtPassowrd" placeholder="Ingrese su Password">
									</div>
									<div class="form-group">
                                                  <button class="btn btn-border" type="button" onclick="Fn_LoginCustomer()">Ingresar</button>
                                                  <a href="<%=Page.ResolveUrl("~/Layout/Information.aspx") %>" class="btn btn-border">Registrate Aquí</a>

										<div class="col-auto align-self-end" style="display:none">
											<div class="form-group">
												<ul class="additional-links">
													<li><a href="#">Perdiste tu Contraseña?</a></li>
												</ul>
											</div>
										</div>
									</div>
							</div>
						</div>
					<%--</div>--%>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
