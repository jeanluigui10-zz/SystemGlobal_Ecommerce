<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Information.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Information" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
          
        function Fn_Registro() {
                     
            if ($("input[id$=txtNombre]").val() == ""){
                fn_message('i', 'Ingrese su Nombre.', 'message_row');
                return;
            }
            if ($("input[id$=txtApellidoPaterno]").val() == ""){
                fn_message('i', 'Ingrese su Apellido Paterno.', 'message_row');
                return;
            }
            if ($("input[id$=txtApellidoMaterno]").val() == ""){
                fn_message('i', 'Ingrese su Apellido Materno.', 'message_row');
                return;
            }
            if ($("select[id$=ddlTipoDocumento] option:selected").val() == undefined || $("select[id$=ddlTipoDocumento] option:selected").val() == -1) {
                fn_message('i', 'Seleccione Tipo de Documento', 'message_row');
                return;
            }
            if ($("input[id$=txtNumberoDocumento]").val() == ""){
                fn_message('i', 'Ingrese Numero de documento', 'message_row');
                return;
            }

            if ($("input[id$=txtCorreo]").val() == "") {
                fn_message('i', 'Ingrese Correo Electronico/Nombre de Usuario', 'message_row');
                return;
            }

            if ($("input[id$=txtPassword]").val() == ""){
                fn_message('i', 'Ingrese su Contraseña', 'message_row');
                return;
            }
           
         

                obj = {
                    FirstName: $("input[id$=txtNombre]").val().trim(),
                    LastNamePaternal: $("input[id$=txtApellidoPaterno]").val().trim(),
                    LastNameMaternal: $("input[id$=txtApellidoMaterno]").val().trim(),
                    Description: $("input[id$=txtDescription]").val().trim(),
                    NumberDocument: $("input[id$=txtNumberoDocumento]").val().trim(),
                    CellPhone: $("input[id$=txtCelular]").val().trim(),
                    Password: $("input[id$=txtPassword]").val().trim(),
                    Email: $("input[id$=txtCorreo]").val().trim(),
                    DocumentType: $("select[id$=ddlTipoDocumento] option:selected").val()
                }

            var success = function (asw) {

                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                        Fn_Limpiar();
                    } else {
                        fn_message("e", asw.d.Msg);
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
            $("input[id$=txtContraseña]").val("");
            $("input[id$=txtCelular]").val("");
            $("input[id$=txtCorreo]").val("");
            $("input[id$=txtDescription]").val("");
            
          }

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="index.html">Home</a></li>
			<li>Create An Account</li>
		</ul>
	</div>
</div>

    <div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder">REGISTRATE</h1>
			<div class="tt-login-form">
				<div class="row justify-content-center">
					<div class="col-md-8 col-lg-6">
						<div class="tt-item">
							<h2 class="tt-title">INFORMACIÓN PERSONAL</h2>
							<div class="form-default">
                                <div id="message_row"></div>
								<div id="contactform" method="post" novalidate="novalidate">
									<div class="form-group">
										<label for="loginInputName">Nombre *</label>
										<div class="tt-required">* Campos Requeridos</div>
										<input type="text" name="name" class="form-control" id="txtNombre" placeholder="Ingrese su Nombre">
									</div>
									<div class="form-group">
										<label for="loginAPaterno">Apellido Paterno *</label>
										<input type="text" name="apellidoPaterno" class="form-control" id="txtApellidoPaterno" placeholder="Ingrese su Apellido Paterno">
									</div>
                                    <div class="form-group">
										<label for="loginAMaterno">Apellido Materno *</label>
										<input type="text" name="apellidoMaterno" class="form-control" id="txtApellidoMaterno" placeholder="Ingrese su Apellido Materno">
									</div>
                                    <div class="form-group">
										<asp:DropDownList ID="ddlTipoDocumento" runat="server" CssClass="form-control"></asp:DropDownList>
										<input type="text" name="tipodocumento" class="form-control" id="txtNumberoDocumento" placeholder="Ingrese su Documento">
									</div>
                                             <div class="form-group">
										<label for="loginDescription">Direccion </label>
										<input type="text" name="Description" class="form-control" id="txtDescription" placeholder="Ingrese su Direccion...">
									</div>
                                            
                                    <div class="form-group">
										<label for="loginCelular">Celular</label>
										<input type="text" name="celular" class="form-control" id="txtCelular" placeholder="Ingrese su Celular">
									</div>
									<div class="form-group">
										<label for="loginInputEmail">Correo/Nombre de Usuario *</label>
										<input type="text" name="email" class="form-control" id="txtCorreo" placeholder="Ingrese su Correo/Nombre un usuario">
									</div>
									<div class="form-group">
										<label for="loginInputPassword">Contraseña *</label>
										<input type="password" name="passowrd" class="form-control"id="txtPassword" placeholder="Ingrese su Contraseña">
									</div>
									<div class="row">
										<div class="col-auto">
											<div class="form-group">
												<button class="btn btn-border" type="button" onclick="Fn_Registro()">Registrarse</button>
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
