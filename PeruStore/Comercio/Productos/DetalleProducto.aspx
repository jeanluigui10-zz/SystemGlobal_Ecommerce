<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="PeruStore.Comercio.Productos.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<link href="../../Template/js/minicolors/miniColors.css" rel="stylesheet" />--%>
    <script type="text/javascript" src="js/detalleproducto.js"></script>
    <%--<script src="../../Template/js/minicolors/jquery.miniColors.min.js"></script>--%>
    <%--<script type="text/javascript" src="/Template/js/themejs/libs.js"></script>--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Main Container  -->
    <div class="main-container container">
        <ul class="breadcrumb">
            <li><a href="#"><i class="fa fa-home"></i></a></li>
            <li><a href="#">Smartphone & Tablets</a></li>
            <li><a href="#">Chicken swinesha</a></li>

        </ul>

        <div class="row">

            <!--Left Part Start -->
            <aside class="col-sm-4 col-md-3 content-aside" id="column-left">
                <div class="module banner-left hidden-xs ">
                    <div class="banner-sidebar banners">
                        <div>
                            <a title="Banner Image" href="#">
                                <img src="/Template/image/catalog/banners/banner-sidebar.jpg" alt="Banner Image">
                            </a>
                        </div>
                    </div>
                </div>
            </aside>
            <!--Left Part End -->

            <!--Middle Part Start-->
            <div id="content" class="col-md-9 col-sm-8">

                <div class="product-view row">
                    <div class="left-content-product">

                        <div class="content-product-left class-honizol col-md-5 col-sm-12 col-xs-12">
                            <div class="large-image  " id="prodImagenPrincipal">
                            </div>
                            <a class="thumb-video pull-left" href="https://www.youtube.com/watch?v=HhabgvIIXik"><i class="fa fa-youtube-play"></i></a>

                            <div id="thumb-slider" class="yt-content-slider full_slider owl-drag" data-rtl="yes" data-autoplay="no" data-autoheight="no" data-delay="4" data-speed="0.6" data-margin="10" data-items_column0="4" data-items_column1="3" data-items_column2="4" data-items_column3="1" data-items_column4="1" data-arrows="yes" data-pagination="no" data-lazyload="yes" data-loop="no" data-hoverpause="yes">
                            </div>

                        </div>

                        <div class="content-product-right col-md-7 col-sm-12 col-xs-12">
                            <div class="title-product">
                                <h1 id="prodNombre">-</h1>
                            </div>
                            <!-- Review ---->
                            <div class="box-review form-group">
                                <div class="ratings">
                                    <div class="rating-box">
                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                        <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                    </div>
                                </div>

                                <a class="reviews_button" href="" onclick="$('a[href=\'#tab-review\']').trigger('click'); return false;">0 opiniones</a>	| 
								<a class="write_review_button" href="" onclick="$('a[href=\'#tab-review\']').trigger('click'); return false;">Escribe una reseña</a>
                            </div>

                            <div class="product-label form-group">
                                <div class="product_page_price price" itemprop="offerDetails" itemscope="" itemtype="http://data-vocabulary.org/Offer">
                                    <span id="prodPrecioNew" class="price-new" itemprop="price">S/0.00</span>
                                    <span class="price-old" id="prodPrecioAntiguo">S/.0.00</span>
                                </div>
                                <div class="stock"><span>Disponibilidad:</span> <span class="status-stock">En Stock</span></div>
                            </div>

                            <div class="product-box-desc">
                                <div class="inner-box-desc">
                                    <div class="reward"><span>Precio: </span><a href="#" id="prodPrecioDesc">-</a>		</div>
                                    <div class="brand"><span>Marca: </span><a href="#" id="prodMarca">-</a>		</div>
                                    <div class="model"><span>Código de Producto: </span><a href="#" id="prodSku">-</a>		</div>
                                </div>
                            </div>


                            <div id="product">
                                <h4>Opciones Disponibles</h4>
                                <div class="image_option_type form-group required">
                                    <label class="control-label">Colores</label>
                                    <ul class="product-options clearfix" id="input-option231">
                                    </ul>
                                </div>

                                <div class="box-checkbox form-group required">
                                    <label class="control-label">Tallas</label>
                                    <!-- Example split danger button -->

                                    <div id="input-option232">
                                        <div class="dropdown">
                                            <button id="btnTallas" class="btn btn-primary dropdown-toggle" type="button" data-toggle="dropdown" style="background: #f4a137; border: 0">
                                            <span class="caret"></span>
                                            </button>
                                            <ul class="dropdown-menu" style="padding-left: 10px" id="ddlTallas">
                                            </ul>
                                        </div>
                                    </div>
                                </div>

                                <div class="form-group box-info-product">
                                    <div class="option quantity">
                                        <div class="input-group quantity-control" unselectable="on" style="-webkit-user-select: none;">
                                            <label>Cantidad</label>
                                            <input class="form-control" type="text" name="quantity"
                                                value="1">
                                            <input type="hidden" name="product_id" value="50">
                                            <span class="input-group-addon product_quantity_down">−</span>
                                            <span class="input-group-addon product_quantity_up">+</span>
                                        </div>
                                    </div>
                                    <div class="cart">
                                        <input type="button" data-toggle="tooltip" title="" value="AÑADIR AL CARRITO" data-loading-text="Loading..." id="button-cart" class="btn btn-mega btn-lg" onclick="cart.add('42', '1');" data-original-title="Add to Cart">
                                    </div>
                                    <div class="add-to-links wish_comp">
                                        <ul class="blank list-inline">
                                            <li class="wishlist">
                                                <a class="icon" data-toggle="tooltip" title=""
                                                    onclick="wishlist.add('50');" data-original-title="Add to Wish List"><i class="fa fa-heart"></i>
                                                </a>
                                            </li>
                                            <li class="compare">
                                                <a class="icon" data-toggle="tooltip" title=""
                                                    onclick="compare.add('50');" data-original-title="Compare this Product"><i class="fa fa-exchange"></i>
                                                </a>
                                            </li>
                                        </ul>
                                    </div>

                                </div>

                            </div>
                            <!-- end box info product -->

                        </div>

                    </div>
                </div>
                <!-- Product Tabs -->
                <div class="producttab ">
                    <div class="tabsslider  vertical-tabs col-xs-12">
                        <ul class="nav nav-tabs col-lg-2 col-sm-3">
                            <li class="active"><a data-toggle="tab" href="#tab-1">Descripción</a></li>
                            <li class="item_nonactive"><a data-toggle="tab" href="#tab-review">Comentarios (0)</a></li>
                            <li class="item_nonactive"><a data-toggle="tab" href="#tab-4">Etiquetas</a></li>
                            <li class="item_nonactive"><a data-toggle="tab" href="#tab-5">Pestaña personalizada</a></li>
                        </ul>
                        <div class="tab-content col-lg-10 col-sm-9 col-xs-12" id="prodDescripcionlarga">

                            <div id="tab-review" class="tab-pane fade">
                                <div id="review">
                                    <table class="table table-striped table-bordered">
                                        <tbody>
                                            <tr>
                                                <td style="width: 50%;"><strong>Super Administrator</strong></td>
                                                <td class="text-right">29/07/2015</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2">
                                                    <p>Best this product opencart</p>
                                                    <div class="ratings">
                                                        <div class="rating-box">
                                                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                            <span class="fa fa-stack"><i class="fa fa-star fa-stack-1x"></i><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                            <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-1x"></i></span>
                                                        </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                    <div class="text-right"></div>
                                </div>
                                <h2 id="review-title">Write a review</h2>
                                <div class="contacts-form">
                                    <div class="form-group">
                                        <span class="icon icon-user"></span>
                                        <input type="text" name="name" class="form-control" value="Your Name" onblur="if (this.value == '') {this.value = 'Your Name';}" onfocus="if(this.value == 'Your Name') {this.value = '';}">
                                    </div>
                                    <div class="form-group">
                                        <span class="icon icon-bubbles-2"></span>
                                        <textarea class="form-control" name="text" onblur="if (this.value == '') {this.value = 'Your Review';}" onfocus="if(this.value == 'Your Review') {this.value = '';}">Your Review</textarea>
                                    </div>
                                    <span style="font-size: 11px;"><span class="text-danger">Note:</span>						HTML is not translated!</span>

                                    <div class="form-group">
                                        <b>Rating</b> <span>Bad</span>&nbsp;
										<input type="radio" name="rating" value="1">
                                        &nbsp;
										<input type="radio" name="rating"
                                            value="2">
                                        &nbsp;
										<input type="radio" name="rating"
                                            value="3">
                                        &nbsp;
										<input type="radio" name="rating"
                                            value="4">
                                        &nbsp;
										<input type="radio" name="rating"
                                            value="5">
                                        &nbsp;<span>Good</span>

                                    </div>
                                    <div class="buttons clearfix"><a id="button-review" class="btn buttonGray">Continue</a></div>
                                </div>
                            </div>
                            <div id="tab-4" class="tab-pane fade">
                                <a href="#">Monitor</a>,
								<a href="#">Apple</a>
                            </div>
                            <div id="tab-5" class="tab-pane fade">
                                <h3 class="custom-color">Take a trivial example which of us ever undertakes</h3>
                                <p>
                                    Lorem ipsum dolor sit amet, consetetur
									sadipscing elitr, sed diam nonumy eirmod
									tempor invidunt ut labore et dolore
									magna aliquyam erat, sed diam voluptua.
									At vero eos et accusam et justo duo
									dolores et ea rebum. Stet clita kasd
									gubergren, no sea takimata sanctus est
									Lorem ipsum dolor sit amet. Lorem ipsum
									dolor sit amet, consetetur sadipscing
									elitr, sed diam nonumy eirmod tempor
									invidunt ut labore et dolore magna aliquyam
									erat, sed diam voluptua.
                                </p>
                                <p>
                                    At vero eos et accusam et justo duo dolores
									et ea rebum. Stet clita kasd gubergren,
									no sea takimata sanctus est Lorem ipsum
									dolor sit amet. Lorem ipsum dolor sit
									amet, consetetur sadipscing elitr.
                                </p>
                                <ul class="marker-simple-list two-columns">
                                    <li>Nam liberempore</li>
                                    <li>Cumsoluta nobisest</li>
                                    <li>Eligendptio cumque</li>
                                    <li>Nam liberempore</li>
                                    <li>Cumsoluta nobisest</li>
                                    <li>Eligendptio cumque</li>
                                </ul>
                                <p>
                                    Sed diam nonumy eirmod tempor invidunt
									ut labore et dolore magna aliquyam erat,
									sed diam voluptua. At vero eos et accusam
									et justo duo dolores et ea rebum. Stet
									clita kasd gubergren, no sea takimata
									sanctus est Lorem ipsum dolor sit amet.
                                </p>
                            </div>
                        </div>
                    </div>
                </div>
                <!-- //Product Tabs -->

                <!-- PRODUCTOS RELACIONADOS -->
                <div class="related titleLine products-list grid module ">
                    <h3 class="modtitle">PRODUCTOS RELACIONADOS  </h3>

                    <div class="releate-products yt-content-slider products-list" data-rtl="no" data-loop="yes" data-autoplay="no" data-autoheight="no" data-autowidth="no" data-delay="4" data-speed="0.6" data-margin="30" data-items_column0="5" data-items_column1="3" data-items_column2="3" data-items_column3="2" data-items_column4="1" data-arrows="yes" data-pagination="no" data-lazyload="yes" data-hoverpause="yes">
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Pastrami bacon">
                                                <img src="/Template/image/catalog/demo/product/320/9.jpg" class="img-1 img-responsive" alt="Pastrami bacon">
                                                <img src="/Template/image/catalog/demo/product/320/2.jpg" class="img-2 img-responsive" alt="Pastrami bacon">
                                            </a>
                                        </div>

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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                                            </div>
                                            <h4><a href="product.html" title="Pastrami bacon" target="_self">Pastrami bacon</a></h4>
                                            <div class="price">$42.00</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Chicken swinesha">
                                                <img src="/Template/image/catalog/demo/product/320/8.jpg" class="img-1 img-responsive" alt="image">
                                                <img src="/Template/image/catalog/demo/product/320/3.jpg" class="img-2 img-responsive" alt="image">
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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                            </div>
                                            <div class="price">
                                                <span class="price-new">$46.00</span>
                                                <span class="price-old">$55.00</span>
                                            </div>
                                            <h4><a href="product.html" title="Chicken swinesha" target="_self">Chicken swinesha</a></h4>

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Kielbasa hamburg">
                                                <img src="/Template/image/catalog/demo/product/320/5.jpg" class="img-1 img-responsive" alt="Pastrami bacon">
                                                <img src="/Template/image/catalog/demo/product/320/6.jpg" class="img-2 img-responsive" alt="Pastrami bacon">
                                            </a>
                                        </div>
                                        <div class="box-label"><span class="label-product label-new">New </span></div>
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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                            </div>

                                            <h4><a href="product.html" title="Kielbasa hamburg" target="_self">Kielbasa hamburg</a></h4>
                                            <div class="price">$55.00</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Sausage cowbee">
                                                <img src="/Template/image/catalog/demo/product/320/7.jpg" class="img-1 img-responsive" alt="image">
                                                <img src="/Template/image/catalog/demo/product/320/4.jpg" class="img-2 img-responsive" alt="image">
                                            </a>
                                        </div>

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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                            </div>

                                            <h4><a href="product.html" title="Sausage cowbeea" target="_self">Sausage cowbee</a></h4>
                                            <div class="price">$60.00</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Kielbasa hamburg">
                                                <img src="/Template/image/catalog/demo/product/320/2.jpg" class="img-1 img-responsive" alt="Pastrami bacon">
                                                <img src="/Template/image/catalog/demo/product/320/6.jpg" class="img-2 img-responsive" alt="Pastrami bacon">
                                            </a>
                                        </div>

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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                                            </div>

                                            <h4><a href="product.html" title="Drumstick tempor" target="_self">Drumstick tempor</a></h4>
                                            <div class="price">$75.00</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Balltip nullaelit">
                                                <img src="/Template/image/catalog/demo/product/320/8.jpg" class="img-1 img-responsive" alt="image">
                                                <img src="/Template/image/catalog/demo/product/320/2.jpg" class="img-2 img-responsive" alt="image">
                                            </a>
                                        </div>
                                        <div class="box-label"><span class="label-product label-new">New </span></div>
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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                            </div>

                                            <h4><a href="product.html" title="Balltip nullaelit" target="_self">Balltip nullaelit</a></h4>
                                            <div class="price">$80.00</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="item">
                            <div class="item-inner product-layout transition product-grid">
                                <div class="product-item-container">
                                    <div class="left-block">
                                        <div class="product-image-container second_img">
                                            <a href="product.html" target="_self" title="Lamboudin ribeye">
                                                <img src="/Template/image/catalog/demo/product/320/3.jpg" class="img-1 img-responsive" alt="image">
                                                <img src="/Template/image/catalog/demo/product/320/9.jpg" class="img-2 img-responsive" alt="image">
                                            </a>
                                        </div>

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
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                <span class="fa fa-stack"><i class="fa fa-star-o fa-stack-2x"></i></span>
                                            </div>

                                            <h4><a href="product.html" title="Lamboudin ribeye" target="_self">Lamboudin ribeye</a></h4>
                                            <div class="price">$63.00</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <!-- end Related  Products-->
            </div>






        </div>


    </div>
    <!--Middle Part End-->

    <asp:HiddenField ID="_hfProduct" runat="server" />
    <script type="text/x-handlebars-template" id="handlebarImagenPrincipal">
        {{# each ObjetoWithImagePrincipal}}
        <img itemprop="image" class="product-image-zoom" src="{{NombreRecurso}}" data-zoom-image="{{NombreRecurso}}" title="{{ArchivoNombre}}" alt="{{ArchivoNombre}}">
        {{/each}}
    </script>
    <script type="text/x-handlebars-template" id="handlebarListaImagenes">
        {{# each ObjetoWithListImagen}}
        <a data-index="{{@index}}" class="img thumbnail " data-image="{{NombreRecurso}}" title="{{ArchivoNombre}}">
            <img src="{{NombreRecurso}}" title="{{ArchivoNombre}}" alt="{{ArchivoNombre}}">
        </a>
        {{/each}}
    </script>
    <script type="text/x-handlebars-template" id="handlebarListaTalla">
        {{# each ObjetoWithListTalla}}
             <li><a href="#">{{DescripcionTalla}}</a></li>
        {{/each}}
    </script>
    <script type="text/x-handlebars-template" id="handlebarListaColor">
        {{# each ObjetoWithListColor}}
                  <li class="radio">
                      <label>
                          <input class="image_radio" type="radio" name="{{IdColor}}" value="{{IdColor}}">
                          <label style="height: 30px; background:{{DescripcionColor}}" class="img-thumbnail icon icon-color"></label>
                          <i class="fa fa-check"></i>
                          <label></label>
                      </label>
                  </li>

        {{/each}}
             <li class="selected-option"></li>
    </script>
</asp:Content>
