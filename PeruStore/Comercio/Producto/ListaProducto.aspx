﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="ListaProducto.aspx.cs" Inherits="PeruStore.Comercio.Producto.ListaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="../js/listaProductosPorCategoria.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- Main Container  -->
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Smartphone & Tablets</a></li>
        </ul>

        <div class="row">
            <!--Left Part Start -->
            <div class="col-sm-4 col-md-3 content-aside" id="column-left">
                <div class="module category-style">
                    <h3 class="modtitle">Categories</h3>
                    <div class="modcontent">
                        <div class="box-category">
                            <ul id="cat_accordion" class="list-group">
                                <li class="hadchild"><a href="category.html" class="cutom-parent">Smartphone & Tablets</a>   <span class="button-view  fa fa-plus-square-o"></span>
                                    <ul style="display: block;">
                                        <li><a href="category.html">Men's Watches</a></li>
                                        <li><a href="category.html">Women's Watches</a></li>
                                        <li><a href="category.html">Kids' Watches</a></li>
                                        <li><a href="category.html">Accessories</a></li>
                                    </ul>
                                </li>
                                <li class="hadchild"><a class="cutom-parent" href="category.html">Electronics</a>   <span class="button-view  fa fa-plus-square-o"></span>
                                    <ul style="display: none;">
                                        <li><a href="category.html">Cycling</a></li>
                                        <li><a href="category.html">Running</a></li>
                                        <li><a href="category.html">Swimming</a></li>
                                        <li><a href="category.html">Football</a></li>
                                        <li><a href="category.html">Golf</a></li>
                                        <li><a href="category.html">Windsurfing</a></li>
                                    </ul>
                                </li>
                                <li class="hadchild"><a href="category.html" class="cutom-parent">Shoes</a>   <span class="button-view  fa fa-plus-square-o"></span>
                                    <ul style="display: none;">
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                    </ul>
                                </li>
                                <li class="hadchild"><a href="category.html" class="cutom-parent">Watches</a>  <span class="button-view  fa fa-plus-square-o"></span>
                                    <ul style="display: none;">
                                        <li><a href="category.html">Men's Watches</a></li>
                                        <li><a href="category.html">Women's Watches</a></li>
                                        <li><a href="category.html">Kids' Watches</a></li>
                                        <li><a href="category.html">Accessories</a></li>
                                    </ul>
                                </li>
                                <li class="hadchild"><a href="category.html" class="cutom-parent">Jewellery</a>    <span class="button-view  fa fa-plus-square-o"></span>
                                    <ul style="display: none;">
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                        <li><a href="category.html">Sub Categories</a></li>
                                    </ul>
                                </li>
                                <li class=""><a href="category.html" class="cutom-parent">Health &amp; Beauty</a>  <span class="dcjq-icon"></span></li>
                                <li class=""><a href="category.html" class="cutom-parent">Kids &amp; Babies</a>    <span class="dcjq-icon"></span></li>
                                <li class=""><a href="category.html" class="cutom-parent">Sports</a>  <span class="dcjq-icon"></span></li>
                                <li class=""><a href="category.html" class="cutom-parent">Home &amp; Garden</a><span class="dcjq-icon"></span></li>
                                <li class=""><a href="category.html" class="cutom-parent">Wines &amp; Spirits</a>  <span class="dcjq-icon"></span></li>
                            </ul>
                        </div>


                    </div>
                </div>
            </div>
            <!--Left Part End -->

            <!--Middle Part Start-->
            <div id="content" class="col-md-9 col-sm-8">
                <div class="products-category">
                    <h3 class="title-category">Accessories</h3>
                    <div class="category-derc">
                        <div class="row">
                            <div class="col-sm-12">
                                <div class="banners">
                                    <div>
                                        <a href="#">
                                            <img src="/Template/image/catalog/demo/category/img-cate.jpg" alt="img cate"><br>
                                        </a>
                                    </div>
                                </div>

                            </div>
                        </div>
                    </div>
                    <!-- Filters -->
                    <div class="product-filter product-filter-top filters-panel">
                        <div class="row">
                            <div class="col-md-5 col-sm-3 col-xs-12 view-mode">

                                <div class="list-view">
                                    <button class="btn btn-default grid active" type="button" data-view="grid" data-toggle="tooltip" data-original-title="Grid"><i class="fa fa-th"></i></button>
                                    <button class="btn btn-default list" type="button" data-view="list" data-toggle="tooltip" data-original-title="List"><i class="fa fa-th-list"></i></button>
                                </div>

                            </div>
                            <div class="short-by-show form-inline text-right col-md-7 col-sm-9 col-xs-12">
                                <div class="form-group short-by">
                                    <label class="control-label" for="input-sort">Sort By:</label>
                                    <select id="input-sort" class="form-control"
                                        onchange="location = this.value;">
                                        <option value="" selected="selected">Default</option>
                                        <option value="">Name (A - Z)</option>
                                        <option value="">Name (Z - A)</option>
                                        <option value="">Price (Low &gt; High)</option>
                                        <option value="">Price (High &gt; Low)</option>
                                        <option value="">Rating (Highest)</option>
                                        <option value="">Rating (Lowest)</option>
                                        <option value="">Model (A - Z)</option>
                                        <option value="">Model (Z - A)</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label class="control-label" for="input-limit">Show:</label>
                                    <select id="input-limit" class="form-control" onchange="location = this.value;">
                                        <option value="" selected="selected">15</option>
                                        <option value="">25</option>
                                        <option value="">50</option>
                                        <option value="">75</option>
                                        <option value="">100</option>
                                    </select>
                                </div>
                            </div>
                            <!-- <div class="box-pagination col-md-3 col-sm-4 col-xs-12 text-right">
<ul class="pagination">
<li class="active"><span>1</span></li>
<li><a href="">2</a></li><li><a href="">&gt;</a></li>
<li><a href="">&gt;|</a></li>
</ul>
</div> -->
                        </div>
                    </div>

                    <!-- //end Filters -->
                    <!--changed listings-->
                    <div class="products-list row nopadding-xs so-filter-gird grid" id="divListaProductosPorCategoria">

                    </div>

                    <!--// End Changed listings-->
                    <!-- Filters -->
                    <div class="product-filter product-filter-bottom filters-panel">
                        <div class="row">
                            <div class="col-sm-6 text-left"></div>
                            <div class="col-sm-6 text-right">Showing 1 to 15 of 15 (1 Pages)</div>
                        </div>
                    </div>
                    <!-- //end Filters -->

                </div>

            </div>


            <!--Middle Part End-->
        </div>
    </div>
    <!-- //Main Container -->
    <asp:HiddenField ID="hfDatosProductosPorCategoria" runat="server" />
    <script type="text/x-handlebars-template" id="handlebards-listaProductoxCategoria">
        {{# each request}}
        <div class="product-layout col-lg-15 col-md-4 col-sm-6 col-xs-12">
            <div class="product-item-container">
                <div class="left-block">
                    <div class="product-image-container second_img">
                        <a href="product.html" target="_self" title="{{ProductoNombre}}">
                            <img src="{{NombreRecurso}}" class="img-1 img-responsive" alt="image">
                            <img src="{{NombreRecurso}}" class="img-2 img-responsive" alt="image">
                        </a>
                    </div>
                    <div class="box-label"><span class="label-product label-sale">-16% </span></div>
                    <div class="button-group so-quickview cartinfo--left">
                        <button type="button" class="addToCart btn-button" title="Agregar al carrito" onclick="cart.add('60 ');">
                            <i class="fa fa-shopping-basket"></i>
                            <span>Agregar al carrito </span>
                        </button>
                        <button type="button" class="wishlist btn-button" title="Agregar a lista de deseos" onclick="wishlist.add('60');">
                            <i class="fa fa-heart"></i><span>Agregar a lista de deseos</span>
                        </button>
                        <button type="button" class="compare btn-button" title="Compara este producto" onclick="compare.add('60');">
                            <i class="fa fa-refresh"></i><span>Compara este producto</span>
                        </button>
                        <!--quickview-->
                        <a class="iframe-link btn-button quickview quickview_handler visible-lg" href="quickview.html" title="Vista rápida" data-fancybox-type="iframe"><i class="fa fa-eye"></i><span>Vista rápida</span></a>
                        <!--end quickview-->
                    </div>
                </div>
                <div class="right-block">
                    <div class="caption">
                        <div class="rating">
                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                        </div>
                        <h4><a href="product.html" title="{{ProductoNombre}}" target="_self">{{ProductoNombre}}</a></h4>
                        {{#ifEquals Esoferta true}}
                        <div class="price">
                            <span class="price-new">{{Simbolo}}{{PrecioOferta}}</span>
                            <span class="price-old">{{Simbolo}}{{Precio}}</span>
                        </div>
                        {{else}}
                        <div class="price">
                            <span class="price-new">{{Simbolo}}{{Precio}}</span>
                        </div>
                        {{/ifEquals}}
                        <div class="description item-desc">
                            <p>
                                {{ProductoDescripcionLarga}}
                            </p>
                        </div>
                        <div class="list-block hidden">
                            <button class="addToCart btn-button" type="button" title="Add to Cart" onclick="cart.add('101', '1');">
                                <i class="fa fa-shopping-basket"></i>
                            </button>
                            <button class="wishlist btn-button" type="button" title="Add to Wish List" onclick="wishlist.add('101');">
                                <i class="fa fa-heart"></i>
                            </button>
                            <button class="compare btn-button" type="button" title="Compare this Product" onclick="compare.add('101');">
                                <i class="fa fa-refresh"></i>
                            </button>
                            <!--quickview-->
                            <a class="iframe-link btn-button quickview quickview_handler visible-lg" href="quickview.html" title="Quick view" data-fancybox-type="iframe"><i class="fa fa-eye"></i></a>
                            <!--end quickview-->
                        </div>
                    </div>
                </div>
            </div>
        </div>

        {{/each}}
    </script>

</asp:Content>
