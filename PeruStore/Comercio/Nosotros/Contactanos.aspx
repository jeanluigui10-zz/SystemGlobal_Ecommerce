<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="PeruStore.Comercio.Nosotros.Contactanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        $(function () {

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
            <li><a href="#">Page</a></li>
            <li><a href="#">Contact us</a></li>
        </ul>

        <div class="row">
            <div id="content" class="col-sm-12">
                <div class="page-title">
                    <h2>Contact Us</h2>
                </div>


                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2948.8442639328655!2d-71.10008329902021!3d42.34584359264178!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x89e379f63dc43ccb%3A0xa15d5aa87d0f0c12!2s4+Yawkey+Way%2C+Boston%2C+MA+02215!5e0!3m2!1sen!2s!4v1475081210943" width="100%" height="350" frameborder="0" style="border:0" allowfullscreen></iframe>
                <div class="info-contact clearfix">
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
                                        <div class="invalid-feedback">Por favor inserte un Nombre válido</div>
                                    </div>
                                </div>
                                <div class="form-group required">
                                    <label class="col-sm-2 control-label" for="input-correo">Correo Electronico</label>
                                    <div class="col-sm-10">
                                        <input type="text" name="correo" runat="server" id="txtEmail" class="form-control" required>
                                        <div class="invalid-feedback">Por favor inserte un Correo Electronico válido</div>
                                    </div>
                                </div>
                                <div class="form-group required">
                                    <label class="col-sm-2 control-label" for="input-consulta">Consulta</label>
                                    <div class="col-sm-10">
                                        <textarea name="consulta" rows="10" id="txtConsulta" runat="server" class="form-control" required></textarea>
                                        <div class="invalid-feedback">Por favor inserte una Consulta válida.</div>
                                    </div>
                                </div>
                            </fieldset>
                            <div class="buttons">
                                <div class="pull-right">
                                    <input  class="btn btn-warning" type="submit" id="btnEnviar" value="Enviar"/>
                                    <asp:Button CssClass="hidden" runat="server" ID="btnEnviarHiden" ClientIDMode="Static" OnClick="btnEnviar_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
