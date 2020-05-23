﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="ListaProducto.aspx.cs" Inherits="PeruStore.Comercio.Producto.ListaProducto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style type="text/css">

  .products-list.grid .product-layout .product-item-container .left-block .button-group {
    padding: 0;
    position: absolute;
    z-index: 99;
    left: 10px;
    bottom: 35px; 
    background-color:green !important;
  }

    .products-list.grid .product-layout .product-item-container .left-block .button-group .btn-button.addToCart {
        transition-delay: 0.1s;
    }

    .products-list.grid .product-layout .product-item-container .left-block .button-group .btn-button {
        border: none;
        display: block;
        margin-top: 5px;
        padding: 0;
        background-color: #666;
        border-radius: 3px;
        color: #fff;
        width: 30px;
        height: 30px;
        line-height: 30px;
        transform: all 0.3s ease 0s;
        position: relative;
        transition: all 0.3s ease-in-out 0s;
        -moz-transition: all 0.3s ease-in-out 0s;
        -webkit-transition: all 0.3s ease-in-out 0s;
        -webkit-opacity: 0;
        -moz-opacity: 0;
        -ms-opacity: 0;
        -o-opacity: 0;
        opacity: 0;
        -webkit-transform: translate(-50px, 0px);
        -moz-transform: translate(-50px, 0px);
        -ms-transform: translate(-50px, 0px);
        -o-transform: translate(-50px, 0px);
        transform: translate(-50px, 0px);
    }
</style>
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
                    <h3 class="title-category ">Accessories</h3>
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
                    <div class="products-list row nopadding-xs so-filter-gird grid" id="divListaProducto">
                       
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

     <script type="text/x-handlebars-template" id="ListaProducto">
         {{# each request}}
         <div class="product-layout col-lg-15 col-md-4 col-sm-6 col-xs-12">
             <div class="product-item-container">
                 <div class="left-block">
                     <div class="product-image-container second_img">
                         <a href="product.html" target="_self" title="Chicken swinesha">
                             <img src="/Template/image/catalog/demo/product/funiture/1.jpg" class="img-1 img-responsive" alt="image">
                             <img src="/Template/image/catalog/demo/product/funiture/2.jpg" class="img-2 img-responsive" alt="image">
                         </a>
                     </div>
                     <div class="box-label"><span class="label-product label-sale">-16% </span></div>
                     <div class="button-group so-quickview cartinfo--left">
                         <button type="button" class="addToCart btn-button" title="Add to cart" onclick="cart.add('60 ');">
                             <i class="fa fa-shopping-basket"></i>
                             <span>Add to cart </span>
                         </button>
                         <button type="button" class="wishlist btn-button" title="Add to Wish List" onclick="wishlist.add('60');">
                             <i class="fa fa-heart"></i><span>Add to Wish List</span>
                         </button>
                         <button type="button" class="compare btn-button" title="Compare this Product " onclick="compare.add('60');">
                             <i class="fa fa-refresh"></i><span>Compare this Product</span>
                         </button>
                         <!--quickview-->
                         <a class="iframe-link btn-button quickview quickview_handler visible-lg" href="quickview.html" title="Quick view" data-fancybox-type="iframe"><i class="fa fa-eye"></i><span>Quick view</span></a>
                         <!--end quickview-->
                     </div>
                 </div>
                 <div class="right-block">
                     <div class="caption">
                         <div class="rating">
                             <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                             <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                             <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                             <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                             <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                         </div>
                         <h4><a href="product.html" title="Chicken swinesha" target="_self">Chicken swinesha</a></h4>
                         <div class="price">
                             <span class="price-new">$46.00</span>
                             <span class="price-old">$55.00</span>
                         </div>
                         <div class="description item-desc">
                             <p>Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum. Stet clita kasd gubergren, no sea takimata sanctus est . </p>
                         </div>
                     </div>
                 </div>
             </div>
         </div>
                    
         {{/each}}
    </script>
	
</asp:Content>