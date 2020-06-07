<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="MiCarrito.aspx.cs" Inherits="PeruStore.Comercio.Compras.MiCarrito" %>
<%@ Register Src="~/Controles/Compras/ucCarritoPrincipal.ascx" TagPrefix="uc1" TagName="ucCarritoPrincipal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/calcular_envio.js"></script>
    <script type="text/javascript">
        $(function () {
            var totalComprasHtml = $(".cart-total-amounts").html();
            $("#cart-content-totals").html(totalComprasHtml);
        });
    </script>

    <style type="text/css">
         .cart-total-amounts{
             display:none;
         }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Carrito de compras</a></li>
        </ul>

        <div class="row">
            <!--Middle Part Start-->
            <div id="content" class="col-sm-12">
                <h2 class="title">Carrito de compras</h2>
                <div class="table-responsive form-group">
                    <uc1:ucCarritoPrincipal runat="server" ID="ucCarritoPrincipal" />
                </div>
                <h3 class="subtitle no-margin">¿Que te gustaría hacer después?</h3>
                <p>Seleccione si tiene un cupón de descuento o si desea estimar el costo de envío.</p>
                <div class="panel-group" id="accordion">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a href="#collapse-shipping" class="accordion-toggle collapsed" data-toggle="collapse" data-parent="#accordion" aria-expanded="false">Estimar envío 							
							<i class="fa fa-caret-down"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse-shipping" class="panel-collapse collapse in" aria-expanded="true">
                            <div class="panel-body">
                                <p>Ingrese su dirección para calcular el costo de envío.</p>
                                <div class="form-horizontal">
                                    <div class="form-group required">
                                        <label class="col-sm-2 control-label" for="input-country">Región</label>
                                        <div class="col-sm-10">
                                            <select id="cboRegion" class="form-control" runat="server">
                                            </select>
                                        </div>
                                    </div>
                                    <div class="form-group required">
                                        <label class="col-sm-2 control-label" for="input-provincia">Provincia</label>
                                        <div class="col-sm-10">
                                            <select id="cboProvincia" class="form-control">
                                                <option value="0">--- Seleccione ---</option>
                                            </select>
                                        </div>
                                    </div>

                                    <div class="form-group required">
                                        <label class="col-sm-2 control-label" for="input-distrito">Distrito</label>
                                        <div class="col-sm-10">
                                            <select id="cboDistrito" class="form-control">
                                                <option value="0">--- Seleccione ---</option>
                                            </select>
                                        </div>
                                    </div>
                                    <button type="button" id="button-quote" data-loading-text="Loading..." class="btn btn-primary">Calcular envío</button>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4 class="panel-title">
                                <a href="#collapse-coupon" class="accordion-toggle" data-toggle="collapse" data-parent="#accordion" aria-expanded="true">Usar código de cupón 							
							<i class="fa fa-caret-down"></i>
                                </a>
                            </h4>
                        </div>
                        <div id="collapse-coupon" class="panel-collapse collapse" aria-expanded="false" style="height: 0px;">
                            <div class="panel-body">
                                <label class="col-sm-2 control-label" for="input-coupon">Ingrese su cupón aquí</label>
                                <div class="input-group">
                                    <input type="text" name="coupon" value="" placeholder="Ingrese su cupón aquí" id="input-coupon" class="form-control">
                                    <span class="input-group-btn">
                                        <input type="button" value="Aplicar Cupón" id="button-coupon" data-loading-text="Loading..." class="btn btn-primary"></span>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="row" id="cart-content-totals">
                </div>
                <div class="buttons">
                    <div class="pull-left"><a href="/Comercio/Inicio.aspx" class="btn btn-primary">Continuar comprando</a></div>
                    <div class="pull-right"><a href="/Comercio/Compras/Confirmacion.aspx" class="btn btn-primary">pagar</a></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

