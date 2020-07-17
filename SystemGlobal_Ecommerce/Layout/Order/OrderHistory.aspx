<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Order.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var idSelected = "";
        var obj;
        var table;
        var rows_selected = [];
        var isTooltip = false;
        $(function () {
            Fn_init();
        });

        function Fn_init() {
            Fn_content();
        }

        function Fn_content() {
            Fn_LoadTableHistory($("#<%=hfOrderHistory.ClientID%>").val());
        }

        function Fn_LoadTableHistory(data) {
            var glancedata = data;
            try {
                obj = $.parseJSON(glancedata);
                var object = {};
                object.request = obj;
                if (object.request.length > 0) {
                    var item = fn_LoadTemplates("datatable-orderHistory", object);
                    $("#tbBodyOrderHistory").html(item);
                } else {
                    $("#divNotSearchData").attr("style","block");
                    $("#tbBodyOrderHistory").html($("#NotDataSerachDiv").html());
                }
            }
            catch (e) {
                fn_message('e', 'Ocurrió un error al cargar la data...');
            }
        }

        function fn_viewDetail(OrderId) {
           
        }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:HiddenField runat="server" ID="hfOrderHistory" />
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
                                        <th></th>
                                    </tr>
                                </thead>
                                <tbody style="text-align: center" id="tbBodyOrderHistory">
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <tr id="NotDataSerachDiv">
        <td>
            <div>
                <div id="divNotSearchData" class="container-indent nomargin" style="display:none">
                    <div class="tt-empty-search">
                        <span class="tt-icon icon-g-48"></span>
                        <h1 class="tt-title">No se encontraron ordenes generadas</h1>
                        <a href="/Layout/ProductsList.aspx" class="btn">Empezar a comprar</a>
                    </div>
                </div>
            </div>
        </td>
    </tr>
   

    <script type="text/x-handlebars-template" id="datatable-orderHistory">
        {{# each request}}
        <tr>
            <td>#{{LegacyNumber}}</td>
            <td>{{OrderDate}}</td>
            <td>{{OrderStatus}}</td>
            <td>{{OrderProgress}}</td>
            <td>{{Total}}</td>
            <td><a onclick="fn_viewDetail('{{IdOrderEncrypt}}')">Ver detalle</a></td>
        </tr>
        {{/each}}
    </script>
</asp:Content>
