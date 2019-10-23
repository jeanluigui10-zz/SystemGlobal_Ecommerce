<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script type="text/javascript">

        $(function () {
            //fn_init();
        });

        function Fn_LoginCustomer()
        {
            try {
                //var senddata = '{user:"' + $("input[id$=txtdni]").val() + '",password:"' + $("input[id$=txtpassword]").val() + '}';
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
                    //$('html, body').animate({ scrollTop: $('div[id$=divMessageTop]').offset().top }, 'fast');
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
			<li><a href="index.html">Inico</a></li>
			<li>Registro</li>
		</ul>
	</div>
   </div>
<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder" id="divMessageTop">YA REGISTRADO?</h1>
			<div class="tt-login-form">
				<div class="row">
					<div class="col-xs-12 col-md-6">
						<div class="tt-item">
							<h2 class="tt-title">NUEVO CLIENTE</h2>
							<p>
								Al crear una cuenta, podra pasar a visualizar nuestros diseños.
							</p>
							<div class="form-group">
								<a href="#" class="btn btn-top btn-border">CREATE AN ACCOUNT</a>
							</div>
						</div>
					</div>
					<div class="col-xs-12 col-md-6">
						<div class="tt-item">
							<h2 class="tt-title">LOGIN</h2>                                  
							Si tiene una cuenta con nosotros, inicie sesión.
							<div class="form-default form-top">
                                       <div id="message_row"></div>
									<div class="form-group">
										<label for="loginInputName">USUARIO *</label>
										<div class="tt-required">* Campos requeridos</div>
										<input type="text" runat="server" name="name" class="form-control" id="txtUsername" placeholder="Ingrese su Usuario">
									</div>
									<div class="form-group">
										<label for="loginInputEmail">PASSWORD *</label>
										<input runat="server" type="password" name="passowrd" class="form-control" id="txtPassowrd" placeholder="Ingrese su Password">
									</div>
									<div class="row">
										<div class="col-auto mr-auto">
											<div class="form-group">
												<button class="btn btn-border" type="button" runat="server"  onclick="Fn_LoginCustomer()">Ingresar</button>
											</div>
										</div>
										<div class="col-auto align-self-end">
											<div class="form-group">
												<ul class="additional-links">
													<li><a href="#">Perdiste tu Password?</a></li>
												</ul>
											</div>
										</div>
									</div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
</asp:Content>
