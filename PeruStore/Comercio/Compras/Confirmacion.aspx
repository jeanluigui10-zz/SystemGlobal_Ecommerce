<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Confirmacion.aspx.cs" Inherits="PeruStore.Comercio.Compras.Confirmacion" %>
<%@ Register Src="~/Controles/Compras/ucCarritoPrincipal.ascx" TagPrefix="uc1" TagName="ucCarritoPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/confirmacion.css" rel="stylesheet" />
    <script type="text/javascript">
        $(function () {
            $(".cart-total-amounts").find("div").css("padding", "0px");

        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="/Comercio/Inicio.aspx"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Confirmar Compra</a></li>

        </ul>

        <div class="row">
            <div id="content" class="col-sm-12">
                <h2 class="title">Confirmar Compra</h2>
                <div class="so-onepagecheckout row">
                    <div class="col-left col-sm-3">
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-user"></i>Información Personal</h4>
                            </div>
                            <div class="panel-body">
                                <fieldset id="account">
                                    <div class="form-group required">
                                        <label for="input-payment-firstname" class="control-label">Nombre</label>
                                        <input type="text" class="form-control" id="input-payment-firstname" placeholder="Nombre" value="">
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-lastname" class="control-label">Apellidos</label>
                                        <input type="text" class="form-control" id="input-payment-lastname" placeholder="Apellidos" value="">
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-email" class="control-label">E-Mail</label>
                                        <input type="text" class="form-control" id="input-payment-email" placeholder="E-Mail" value="">
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-telephone" class="control-label">Celular</label>
                                        <input type="text" class="form-control" id="input-payment-telephone" placeholder="Celular" value="">
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                        <div class="panel panel-default">
                            <div class="panel-heading">
                                <h4 class="panel-title"><i class="fa fa-book"></i>Dirección</h4>
                            </div>
                            <div class="panel-body">
                                <fieldset id="address" class="required">
                                    <div class="form-group">
                                        <label for="input-payment-company" class="control-label">Direción</label>
                                        <input type="text" class="form-control" id="input-payment-company" placeholder="Dirección" value="">
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-city" class="control-label">Referencia</label>
                                        <input type="text" class="form-control" id="input-payment-city" placeholder="Referencia" value="">
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-postcode" class="control-label">Código Postal</label>
                                        <input type="text" class="form-control" id="input-payment-postcode" placeholder="Código Postal" value="">
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-country" class="control-label">Región</label>
                                        <select class="form-control" id="input-payment-country">
                                            <option value="0">--- Seleccione --- </option>
                                        </select>
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-zone" class="control-label">Provincia</label>
                                        <select class="form-control" id="input-payment-zone">
                                            <option value="0">--- Seleccione --- </option>
                                        </select>
                                    </div>
                                    <div class="form-group required">
                                        <label for="input-payment-zone" class="control-label">Distrito</label>
                                        <select class="form-control" id="input-payment-dtro">
                                            <option value="0">--- Seleccione --- </option>
                                        </select>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="col-right col-sm-9">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="panel panel-default no-padding">
                                    <div class="col-sm-6 checkout-shipping-methods">
                                        <div class="panel-heading">
                                            <h4 class="panel-title"><i class="fa fa-truck"></i> Entrega</h4>
                                        </div>
                                        <div class="panel-body ">
                                            <p>Por favor selecciones si desea retirar en tienda o se le envie los producto(s).</p>
                                            <div class="radio">
                                                <label>
                                                    <input type="radio" checked="checked">
                                                    Retiro en tienda - S/ 0.00</label>
                                            </div>
                                            <div class="radio">
                                                <label>
                                                    <input type="radio">
                                                    Envío - S/ 7.50</label>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="col-sm-6  checkout-payment-methods">
                                        <div class="panel-heading">
                                            <h4 class="panel-title"><i class="fa fa-credit-card"></i> Método de Pago</h4>
                                        </div>
                                        <div class="panel-body">
                                            <p>Por favor selecciones su método de pago.</p>
                                            <div class="radio">
                                                <label>
                                                    <input type="radio" checked="checked">Pago contra entrega</label>
                                            </div>

                                            <div class="radio">
                                                <label>
                                                    <input type="radio">Tarjeta crédito/débito</label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-sm-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><i class="fa fa-ticket"></i>¿Tienes un cupón de descuento?</h4>
                                    </div>
                                    <div class="panel-body row">
                                        <div class="col-sm-12">
                                            <div class="input-group">
                                                <input type="text" class="form-control" id="input-coupon" placeholder="Ingrese su código aquí" value="">
                                                <span class="input-group-btn">
                                                    <input type="button" class="btn btn-primary" data-loading-text="Loading..." id="button-coupon" value="Aplicar cupón">
                                                </span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="col-sm-12">
                                <div class="panel panel-default">
                                    <div class="panel-heading">
                                        <h4 class="panel-title"><i class="fa fa-shopping-cart"></i>Carrito de compras</h4>
                                    </div>
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <uc1:ucCarritoPrincipal runat="server" id="ucCarritoPrincipal" />
                                        </div>
                                        <br>
                                        <label class="control-label" for="confirm_agree">
                                            <input type="checkbox" checked="checked" required="" class="validate required" id="confirm_agree">
                                            <span>He leído y acepto los <a class="agree" href="#"><b>Términos &amp; condiciones</b></a></span>
                                        </label>
                                        <div class="buttons">
                                            <div class="pull-right">
                                                <input type="button" class="btn btn-primary" id="button-confirm" value="Confirmar Compra">
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
