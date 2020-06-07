<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="PeruStore.Comercio.Nosotros.Contactanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(function () {

            $("#contentMap").html('<iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3949.7256370597356!2d-79.04550998525674!3d-8.129390394148007!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x91ad3d1321f4884f%3A0x4e87062165a7df3!2sUniversidad%20C%C3%A9sar%20Vallejo!5e0!3m2!1ses-419!2spe!4v1590202020898!5m2!1ses-419!2spe" width="600" height="450" frameborder="0" style="border:0;" allowfullscreen="" aria-hidden="false" tabindex="0"></iframe><div class="info-contact clearfix">');
            $("#contentMap iframe").css("width", "100%");

            $("#btnEnviar").on("click", function (event) {
                var btnGuardar = document.getElementById("btnEnviarHiden");
                btnGuardar.click();
                event.preventDefault();
            });
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Contáctanos</a></li>
        </ul>

        <div class="row">
            <div id="content" class="col-sm-12">
                <div id="contenedor_mensaje"></div>
                <div class="page-title">
                    <h2>Contáctanos</h2>
                </div>
                    <div id="contentMap">
                    </div>
                    <div class="col-lg-4 col-sm-4 col-xs-12 info-store">
                        <div class="row">
                            <div class="name-store">
                                <h3>PeruStore</h3>
                            </div>
                            <address>
                                <div class="address clearfix form-group">
                                    <div class="icon">
                                        <i class="fa fa-home"></i>
                                    </div>
                                    <div class="text">Urb los jazmines #123</div>
                                </div>
                                <div class="phone form-group">
                                    <div class="icon">
                                        <i class="fa fa-phone"></i>
                                    </div>
                                    <div class="text">Teléfono : 0123456789</div>
                                </div>
                                <div class="comment">
                                    Descripcion de la tienda
                                </div>
                            </address>
                        </div>
                    </div>
                    <div class="col-lg-8 col-sm-8 col-xs-12 contact-form">
                        <div class="form-horizontal">
                            <fieldset>
                                <legend>Contactáctanos</legend>
                                <div class="form-group required">
                                    <label class="col-sm-2 control-label" for="input-nombre">Nombre</label>
                                    <div class="col-sm-10">
                                        <input type="text" name="nombre" class="form-control" runat="server" id="txtNombre" required/>
                                        <div class="invalid-feedback">Por favor ingrese un Nombre válido</div>
                                    </div>
                                </div>
                                <div class="form-group required">
                                    <label class="col-sm-2 control-label" for="input-correo">Correo Electronico</label>
                                    <div class="col-sm-10">
                                        <input type="text" name="correo" runat="server" id="txtEmail" class="form-control" required>
                                        <div class="invalid-feedback">Por favor ingrese un Correo Electronico válido</div>
                                    </div>
                                </div>
                                <div class="form-group required">
                                    <label class="col-sm-2 control-label" for="input-consulta">Consulta</label>
                                    <div class="col-sm-10">
                                        <textarea name="consulta" rows="10" id="txtConsulta" runat="server" class="form-control" required></textarea>
                                        <div class="invalid-feedback">Por favor ingrese una Consulta válida.</div>
                                    </div>
                                </div>
                            </fieldset>
                            <div class="buttons">
                                <div class="pull-right">
                                    <input  class="btn btn-primary" type="submit" id="btnEnviar" value="Enviar"/>
                                    <asp:Button CssClass="hidden" runat="server" ID="btnEnviarHiden" ClientIDMode="Static" OnClick="btnEnviar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
</asp:Content>
