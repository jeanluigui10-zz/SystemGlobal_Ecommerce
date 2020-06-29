<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Order.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="loader-wrapper">
        <div class="loading-content">
            <div class="loading-dots">
                <i></i>
                <i></i>
                <i></i>
                <i></i>
            </div>
        </div>
    </div>

    <div class="tt-breadcrumb">
        <div class="container">
            <ul>
                <li><a href="index.html">Canastón</a></li>
                <li>Mi Historial de ordenes</li>
            </ul>
        </div>
    </div>
    <div id="tt-pageContent">
        <div class="container-indent">
            <div class="container container-fluid-custom-mobile-padding">
                <h1 class="tt-title-subpages noborder">MIS ORDENES</h1>
                <div class="tt-shopping-layout">
                    <div class="tt-wrapper">
                        <h3 class="tt-title">HISTORIAL DE ORDENES</h3>
                        <div class="tt-table-responsive">
                            <table class="tt-table-shop-01">
                                <thead>
                                    <tr>
                                        <th>Nro Orden</th>
                                        <th>Fecha de Compra</th>
                                        <th>Estado de Pago</th>
                                        <th>Estado de la orden</th>
                                        <th>Monto Total</th>
                                    </tr>
                                </thead>
                                <tbody style="text-align: center">
                                    <tr>
                                        <td>#001</td>
                                        <td>November 20. 2016</td>
                                        <td>Processing</td>
                                        <td>Processing</td>
                                        <td>$40 fot 1 item</td>
                                        <td><a href="shopping_order.html">Ver Detalle</a></td>
                                    </tr>
                                     <tr>
                                        <td>#001</td>
                                        <td>November 20. 2016</td>
                                        <td>Processing</td>
                                        <td>Processing</td>
                                        <td>$40 fot 1 item</td>
                                        <td><a href="shopping_order.html">Ver Detalle</a></td>
                                    </tr>
                                    <tr>
                                        <td>#001</td>
                                        <td>November 20. 2016</td>
                                        <td>Processing</td>
                                        <td>Processing</td>
                                        <td>$40 fot 1 item</td>
                                        <td><a href="shopping_order.html">Ver Detalle</a></td>
                                    </tr>
                                     <tr>
                                        <td>#001</td>
                                        <td>November 20. 2016</td>
                                        <td>Processing</td>
                                        <td>Processing</td>
                                        <td>$40 fot 1 item</td>
                                        <td><a href="shopping_order.html">Ver Detalle</a></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
