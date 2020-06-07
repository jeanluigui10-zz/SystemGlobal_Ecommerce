<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="ClienteLogin.aspx.cs" Inherits="PeruStore.AdminCliente.ClienteLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main Container  -->
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Cuenta</a></li>
            <li><a href="#">Login</a></li>
        </ul>
        <div id="divMensaje"></div>
        <div class="row">
            <div id="content" class="col-sm-12">
                <div class="page-login">

                    <div class="account-border">
                        <div class="row">
                            <div class="col-sm-6 new-customer">
                                <div class="well">
                                    <h2><i class="fa fa-file-o" aria-hidden="true"></i>Cliente Nuevo</h2>
                                    <p>Al crear una cuenta, podrá comprar más rápido, estar al día sobre el estado de un pedido y realizar un seguimiento de los pedidos que haya realizado anteriormente.</p>
                                </div>
                                <div class="bottom-form">
                                    <a href="#" class="btn btn-default pull-right">Continuar</a>
                                </div>
                            </div>
                            <div class="col-sm-6 customer-login">
                                <div class="well">
                                    <h2><i class="fa fa-file-text-o" aria-hidden="true"></i>SOY CLIENTE</h2>
                                    <p><strong>Soy cliente Recurrente</strong></p>
                                    <div class="form-group">
                                        <label class="control-label " for="txtCorreo">Correo Electrónico</label>
                                        <input type="text" id="txtCorreo" name="email" placeholder="Ejemplo: noah@mail.com" class="form-control" />
                                    </div>
                                    <div class="form-group">
                                        <label class="control-label " for="input-password">Password</label>
                                        <input type="password" id="txtContrasenha" name="password" placeholder="Password" class="form-control" />
                                    </div>
                                </div>
                                <div class="bottom-form">
                                    <input type="button" id="idResetearPassword" value="Recuperar Password" class="forgot" />
                                    <input type="button" id="btnLogin" value="Iniciar Sesión" class="btn btn-default pull-right" />
                                </div>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>
    <!-- //Main Container -->

    <script src="js/ClienteLogin.js"></script>
</asp:Content>
