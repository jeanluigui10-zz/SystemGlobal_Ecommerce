<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCarritoFlotante.ascx.cs" Inherits="PeruStore.Controles.Inicio.ucCarritoFlotante" %>

<div class="middle3 col-lg-3 col-md-3">                    
    <!--cart-->
    <div class="shopping_cart">
        <div id="cart" class="btn-shopping-cart">

            <a data-loading-text="Loading... " class="btn-group top_cart dropdown-toggle" data-toggle="dropdown" aria-expanded="true">
                <div class="shopcart">
                    <span class="icon-c">
                    <i class="fa fa-shopping-bag"></i>
                    </span>
                    <div class="shopcart-inner">
                        <p class="text-shopping-cart">
                            Mis Compras - 
                        </p>

                        <span class="total-shopping-cart cart-total-full">
                            <span class="items_cart" id="lblitems">0</span><span class="items_carts" id="lblmonto"> S/ 0.00</span>
                        </span>
                    </div>
                </div>
            </a>

            <ul class="dropdown-menu pull-right shoppingcart-box" role="menu">
                <li class="cart-options1">
                    <p class="text-center empty">¡Tu carrito de compras está vacío!</p>
                </li>
                <li class="cart-options2 hidden">
                    <table class="table table-striped" id="tbDetalle">
                        <tbody>
                        </tbody>
                    </table>
                </li>
                <li class="cart-options2 hidden">
                    <div>
                        <table class="table table-bordered">
                            <tbody>
                                <tr>
                                    <td class="text-left"><strong>Total</strong>
                                    </td>
                                    <td class="text-right" id="tdTotal">0</td>
                                </tr>
                            </tbody>
                        </table>
                        <p class="text-right"> <a class="btn view-cart" href="#"><i class="fa fa-shopping-cart"></i>Ver Carrito</a>&nbsp;&nbsp;&nbsp; <a class="btn btn-mega checkout-cart" href="#"><i class="fa fa-share"></i>Pagar</a> 
                        </p>
                    </div>
                </li>
            </ul>
        </div>

    </div>
    <!--//cart-->

    <ul class="wishlist-comp hidden-md hidden-sm hidden-xs">
<%--        <li class="compare hidden-xs"><a href="#" class="top-link-compare" title="Compare "><i class="fa fa-refresh"></i></a>
        </li>--%>
        <li class="wishlist hidden-xs"><a href="#" id="wishlist-total" class="top-link-wishlist" title="Lista de deseos(0)"><i class="fa fa-heart"></i></a>
        </li>
    </ul>
</div>

<script type="text/x-handlebars-template" id="orden-detalle">
    {{# each Datos}}
        <tr>
            <td class="text-center" style="width:70px">
                <a href="product.html">
                    <img src="{{NombreRecurso}}" style="width:70px" class="preview">
                </a>
            </td>
            <td class="text-left"> <a class="cart_product_name" href="#">{{ProductoNombre}}</a> 
            </td>
            <td class="text-center">x{{Cantidad}}</td>
            <td class="text-center">{{Total}}</td>
            <td class="text-right">
                <a href="product.html" class="fa fa-edit"></a>
            </td>
            <td class="text-right">
                <a class="fa fa-times fa-delete"></a>
            </td>
        </tr>
    {{/each}}
</script>
    


