<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="InformationEdit.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.InformationEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript">
    $(function () {
             fn_init();
         });

         function fn_init() {
             fn_content();
         }

         function fn_content() {
             Fn_FirstLoadSection('perfil');
        }

        function Fn_FirstLoadSection(loadSection) {
            if (loadSection == 'perfil') {
                $("#DivMyPerfil").slideDown("slow");
                $("#DivMyPerfil").css('display', 'block');   
            }
        }

        function Fn_ShowSection(valSection) {

            if (valSection == 'perfil') {
                $("#DivMyAddress").css('display', 'none');
                $("#DivMyPassword").css('display', 'none');

                $("#DivMyPerfil").slideDown("slow");
                $("#DivMyPerfil").css('display', 'block');
                
            }
            if (valSection == 'address') {
                $("#DivMyPerfil").css('display', 'none');
                $("#DivMyPassword").css('display', 'none');

                $("#DivMyAddress").slideDown("slow");
                $("#DivMyAddress").css('display', 'block');
               
            }
            if (valSection == 'password') {
                $("#DivMyPerfil").css('display', 'none');
                $("#DivMyAddress").css('display', 'none');

                $("#DivMyPassword").slideDown("slow");
                $("#DivMyPassword").css('display', 'block');
            }
        }

        function Fn_ValidatePerfil() {
            if (!fn_validateform('DivMyPerfil')) {
                event.preventDefault();
                return false;
            }

            if ($("select[id$=ddlTypeDocument] option:selected").val() == undefined || $("select[id$=ddlTypeDocument] option:selected").val() == -1) {
                fn_message('i', 'Seleccione Tipo de Documento');
                return;
            }

            obj = {
                FirstName: $("input[id$=txtName]").val().trim(),
                LastNamePaternal: $("input[id$=txtApePater]").val().trim(),
                LastNameMaternal: $("input[id$=txtApeMater]").val().trim(),
                NumberDocument: $("input[id$=txtDocumentNumber]").val().trim(),
                CellPhone: $("input[id$=txtCellPhone]").val().trim(),
                Email: $("input[id$=txtEmail]").val().trim(),
                DocumentType: $("select[id$=ddlTypeDocument] option:selected").val()
            }

            var success = function (asw) {
                if (asw != null) {
                        if (asw.d.Result == "Ok") {
                            fn_message("s", asw.d.Msg);
                        }
                        else {
                            fn_message("i", asw.d.Msg);
                        }
                    } else {
                        fn_message("i", asw.d.Msg);
                    }
                }
            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error en el guardado de los datos.');
            };

            var data = { obj: obj };
            fn_callmethod("InformationEdit.aspx/Customer_Update_Perfil", JSON.stringify(data), success, error);
        }

        function Fn_ValidateAddress() {
            if (!fn_validateform('DivMyAddress')) {
                event.preventDefault();
                return false;
            }

            obj = {
                Address1: $("input[id$=txtAddressEdit]").val().trim(),
            }
            var success = function (asw) {
                if (asw != null) {
                        if (asw.d.Result == "Ok") {
                            fn_message("s", asw.d.Msg);
                        } 
                        else {
                            fn_message("i", asw.d.Msg);
                        }
                } else {
                    fn_message("i", asw.d.Msg);
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error en el guardado de los datos.');
            };

            var dataAddress = { obj: obj };
            fn_callmethod("InformationEdit.aspx/Customer_Update_Address", JSON.stringify(dataAddress), success, error);
        }

        function Fn_ValidatePassword() {
            if (!fn_validateform('DivMyPassword')) {
                event.preventDefault();
                return false;
            }

            obj = {
                Password: $("input[id$=txtPassword]").val().trim(),
                PasswordNew: $("input[id$=txtPasswordNew]").val().trim(),
            }
            var success = function (asw) {
                if (asw != null) {
                    if (asw.d.Result == "Ok") {
                        fn_message("s", asw.d.Msg);
                    }
                    else {
                        fn_message("i", asw.d.Msg);
                    }
                } else {
                    fn_message("i", asw.d.Msg);
                }
            }
            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error en el guardado de los datos.');
            };

            var dataAddress = { obj: obj };
                fn_callmethod("InformationEdit.aspx/Customer_Update_Password", JSON.stringify(dataAddress), success, error);
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Inicio</a></li>
			<li>Mi Cuenta</li>
		</ul>
	</div>
</div>

    <div id="tt-pageContent">
        <div class="container-indent">
            <div class="container">
                <div class="row">
                    <div class="col-md-4 col-lg-3 col-xl-3 leftColumn aside">
                        <div class="tt-btn-col-close">
                            <a href="#">Cerrar</a>
                        </div>
                        <div class="tt-collapse open tt-filter-detach-option">
                            <div class="tt-collapse-content">
                                <div class="filters-mobile">
                                    <div class="filters-row-select">
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div id="DivMyAccount">
                            <div class="tt-collapse open">
                                <div class="tt-collapse-title" onclick="Fn_ShowSection('perfil')">Mi Perfil</div>
                                <ul class="tt-list-row">
                                </ul>
                            </div>
                            <div class="tt-collapse open">
                                <div class="tt-collapse-title" onclick="Fn_ShowSection('address')">Cambiar dirección de entrega</div>
                                <ul class="tt-list-row">
                                </ul>
                            </div>
                            <div class="tt-collapse open">
                                <div class="tt-collapse-title" onclick="Fn_ShowSection('password')">Cambiar contraseña</div>
                                <ul class="tt-list-row">
                                </ul>
                            </div>
                        </div>

                        <div class="tt-content-aside">
                            <a href="listing-left-column.html" class="tt-promo-03"></a>
                        </div>
                    </div>
                    <div class="col-md-12 col-lg-9 col-xl-9">
                        <div class="content-indent container-fluid-custom-mobile-padding-02">
                            <div class="tt-filters-options">
                                <div class="tt-btn-toggle">
                                    <a href="#">Configuración de cuenta</a>
                                </div>
                            </div>

                            <div id="message_row"></div>

                            <div id="DivUsername">
                                    <div class="form-group">
                                        <label for="loginDescription">Usuario</label>
                                        <input type="text" name="username" class="form-control validate[required]" runat="server" id="txtUsername" readonly>
                                    </div>
                            </div>

                            <div id="DivMyPerfil" style="display:none">
                                <div class="form-default">
                                    <div class="form-group">
                                        <label for="loginInputName">Nombre *</label>
                                        <div class="tt-required">* Campos Requeridos</div>
                                        <input type="text" name="name" class="form-control validate[required,custom[onlyLetterSp]]" id="txtName" runat="server" placeholder="Ingrese su Nombre" >
                                    </div>
                                    <div class="form-group">
                                        <label for="loginAPaterno">Apellido Paterno *</label>
                                        <input type="text" name="apellidoPaterno" class="form-control validate[required,custom[onlyLetterSp]]" runat="server" id="txtApePater" placeholder="Ingrese su Apellido Paterno">
                                    </div>
                                    <div class="form-group">
                                        <label for="loginAMaterno">Apellido Materno *</label>
                                        <input type="text" name="apellidoMaterno" class="form-control validate[required,custom[onlyLetterSp]]" runat="server" id="txtApeMater" placeholder="Ingrese su Apellido Materno">
                                    </div>
                                    <div class="form-group">
                                        <label for="loginAMaterno">Documento *</label>
                                        <asp:DropDownList ID="ddlTypeDocument" runat="server" CssClass="form-control"></asp:DropDownList>
                                        <p></p>
                                        <input type="text" name="tipodocumento" class="form-control validate[required,custom[onlyNumberSp]]" runat="server" id="txtDocumentNumber" placeholder="Ingrese su Documento">
                                    </div>
                                    <div class="form-group">
                                        <label for="loginCellPhone">Celular *</label>
                                        <input type="text" name="celular" class="form-control validate[required,custom[onlyNumberSp]]" runat="server" id="txtCellPhone" placeholder="Ingrese su Celular / Whatssap">
                                    </div>
                                    <div class="form-group">
                                        <label for="loginEmail">Email *</label>
                                        <input type="text" name="Email" class="form-control validate[required]" runat="server" id="txtEmail" placeholder="Ingrese su Correo">
                                    </div>
                                    <div class="row">
                                        <div class="col-auto">
                                            <div class="form-group">
                                                <button type="button" id="btnUpdateMyPerfil" class="btn btn-border" onclick="Fn_ValidatePerfil(event);">Guardar configuración</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="DivMyAddress" style="display:none">
                                <div class="form-default">
                                    <div class="form-group">
                                        <label for="loginDescription">Dirección de entrega *</label>
                                        <div class="tt-required">* Campos Requeridos</div>
                                        <input type="text" name="AddressEdit1" class="form-control validate[required]" runat="server" id="txtAddressEdit" placeholder="Ingrese su dirección">
                                    </div>
                                    <div class="row">
                                        <div class="col-auto">
                                            <div class="form-group">
                                                <button type="button" id="btnUpdateMyAddress" class="btn btn-border" onclick="Fn_ValidateAddress(event);">Confirmar nueva dirección</button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div id="DivMyPassword" style="display:none">
                                <div class="form-default">
                                      <div class="form-group">
                                        <label for="loginDescription">Contraseña Actual *</label>
                                        <div class="tt-required">* Campos Requeridos</div>
                                        <input type="password" name="password" class="form-control validate[required]" runat="server" id="txtPassword" placeholder="Ingrese su contraseña actual">
                                    </div>
                                    <div class="form-group">
                                        <label for="loginDescription">Nueva contraseña *</label>
                                        <input type="password" name="passwordNew" class="form-control validate[required]" runat="server" id="txtPasswordNew" placeholder="Ingrese su nueva contraseña">
                                    </div>
                                    <div class="row">
                                        <div class="col-auto">
                                            <div class="form-group">
                                                <button type="button" id="btnUpdateMyPassword" class="btn btn-border" onclick="Fn_ValidatePassword(event);">Confirmar nueva contraseña</button>
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
