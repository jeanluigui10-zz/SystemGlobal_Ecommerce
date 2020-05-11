<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
       
        $(function () {
           // fn_init();
        });
        function fn_init() {
            fn_bind();
        }

        function fn_bind() {
            Fn_content();
        }
          
        function Fn_ValidateInformation() {

            if (!fn_validateform('divInformation')) {
                event.preventDefault();
                return false;
            }
           
            if ($("select[id$=ddlTipoDocumento] option:selected").val() == undefined || $("select[id$=ddlTipoDocumento] option:selected").val() == -1) {
                fn_message('i', 'Seleccione Tipo de Documento');
                return;
            }
          
            obj = {
                    Id: $("#hfCustomerId").val(),
                    FirstName: $("input[id$=txtNombre]").val().trim(),
                    LastNamePaternal: $("input[id$=txtApellidoPaterno]").val().trim(),
                    LastNameMaternal: $("input[id$=txtApellidoMaterno]").val().trim(),
                    Address1: $("input[id$=txtAddress1]").val().trim(),
                    NumberDocument: $("input[id$=txtNumberoDocumento]").val().trim(),
                    CellPhone: $("input[id$=txtCelular]").val().trim(),
                    Password: $("input[id$=txtPassword]").val().trim(),
                    Email: $("input[id$=txtCorreo]").val().trim(),
                    DocumentType: $("select[id$=ddlTipoDocumento] option:selected").val()
                }

            var success = function (asw) {

                if (asw != null) {
                    if (asw.d.Result != "NoOkEmail") {
                        if (asw.d.Result == "Ok") {
                            fn_message("s", asw.d.Msg);
                            Fn_Limpiar();
                        } else if (asw.d.Result == "OkUpdate") {
                            fn_message("s", asw.d.Msg);
                        }
                        else {
                            fn_message("e", asw.d.Msg);
                        }
                    } else {
                        fn_message("i", asw.d.Msg);
                    }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error en el guardado de los datos.');
            };
            
            var data = { obj: obj };
            fn_callmethod("Information.aspx/Customer_Save", JSON.stringify(data), success, error);
        }
          
        function Fn_Limpiar() {
            $("input[id$=txtNombre]").val("");
            $("input[id$=txtApellidoPaterno]").val("");
            $("input[id$=txtApellidoMaterno]").val("");
            $("input[id$=txtNumberoDocumento]").val("");
            $("input[id$=txtCelular]").val("");
            $("input[id$=txtCorreo]").val("");
            $("input[id$=txtAddress1]").val("");
            $("input[id$=txtPassword]").val("");
          }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField ID="hfCustomerId" runat="server" />
    <div class="tt-breadcrumb" style="margin-top:0.5%">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Inicio</a></li>
			<li>Create una cuenta</li>
		</ul>
	</div>
</div>

    <div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 id="ltTitle" runat="server" class="tt-title-subpages noborder">Registrarme</h1>
        
			<div class="tt-login-form">
				<div class="row justify-content-center">
					<div class="col-md-8 col-lg-6">
						<div class="tt-item">
							<h2 class="tt-title">Información Personal</h2>
                                       
							<div class="form-default">
                                     
								<div id="divInformation">
                                          <div id="message_row"></div>
									<div class="form-group">
										<label for="loginInputName">Nombre *</label>
										<div class="tt-required">* Campos Requeridos</div>
										<input type="text" name="name"   class="form-control validate[required]" id="txtNombre" runat="server" placeholder="Ingrese su Nombre">
									</div>
									<div class="form-group">
										<label for="loginAPaterno">Apellido Paterno *</label>
										<input type="text" name="apellidoPaterno"   class="form-control validate[required]" runat="server" id="txtApellidoPaterno" placeholder="Ingrese su Apellido Paterno">
									</div>
                                            <div class="form-group">
										        <label for="loginAMaterno">Apellido Materno *</label>
										        <input type="text" name="apellidoMaterno"   class="form-control validate[required]" runat="server" id="txtApellidoMaterno" placeholder="Ingrese su Apellido Materno">
									        </div>
                                            <div class="form-group">
										<asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
										<p></p>
                                                <input type="text" name="tipodocumento"  class="form-control validate[required]" runat="server" id="txtNumberoDocumento" placeholder="Ingrese su Documento">
									</div>
                                             <div class="form-group">
										<label for="loginDescription">Dirección de entrega *</label>
										<input type="text" name="Address1"  class="form-control validate[required]" runat="server" id="txtAddress1" placeholder="Ingrese su Dirección...">
									</div>
                                            
                                    <div class="form-group">
										<label for="loginCelular">Celular/Whatsapp *</label>
										<input type="text" name="celular"  class="form-control validate[required]" runat="server" id="txtCelular" placeholder="Ingrese su Celular / Whatssap">
									</div>
									<div class="form-group">
										<label for="loginInputEmail">Correo/Nombre de Usuario *</label>
										<input type="text" name="email"  class="form-control validate[required]" runat="server" id="txtCorreo" placeholder="Ingrese su Correo / Nombre un usuario">
									</div>
									<div class="form-group">
										<label for="loginInputPassword">Contraseña *</label>
										<input type="password" name="passowrd"  class="form-control validate[required]" runat="server" id="txtPassword" placeholder="Ingrese su Contraseña">
									</div>
									<div class="row">
										<div class="col-auto">
											<div class="form-group">
												<%--<button class="btn btn-border" type="button" onclick="Fn_Registro()">Registrarse</button>--%>
                                                            <button type="button" id="btnUpload" class="btn btn-border" onclick="Fn_ValidateInformation(event);">Registrarse</button>
											</div>
										</div>
										<div class="col-auto align-self-center">
											<div class="form-group">
												<ul class="additional-links">
													<li>ó <a href="<%=Page.ResolveUrl("~/Layout/Index.aspx") %>">Volver a la Tienda</a></li>
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
</div>

</asp:Content>
