<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucProductoLista.ascx.cs" Inherits="PeruStore.Controles.Inicio.ucProductoLista" %>
   <script src="../Controles/Inicio/js/listaproducto.js"></script>
   <script src="../Controles/Inicio/js/listado_producto_render_tab_1.js"></script>

<div class="col-lg-8 col-md-8 col-sm-12 col-xs-12">
    <!-- Listing tabs -->
    <div class="module listingtab-layout2">
        <h3 class="modtitle"><span>Best seller</span></h3>
        <div id="so_listing_tabs_1" class="so-listing-tabs first-load">
            <div class="loadeding"></div>
            <div class="ltabs-wrap">
                <div class="ltabs-tabs-container" data-rtl="yes" data-delay="300" data-duration="600" data-effect="starwars" data-ajaxurl="" data-type_source="0" data-lg="4" data-md="3" data-sm="2" data-xs="1" data-margin="30">
                    <!--Begin Tabs-->
                    <div class="ltabs-tabs-wrap">
                        <span class="ltabs-tab-selected">Bathroom</span> <span class="ltabs-tab-arrow">▼</span>
                        <div class="item-sub-cat">
                            <ul class="ltabs-tabs cf">
                                <li class="ltabs-tab tab-sel" data-category-id="20" data-active-content=".items-category-20"><span class="ltabs-tab-label">Accessories</span> </li>
                                <li class="ltabs-tab " data-category-id="18" data-active-content=".items-category-18"><span class="ltabs-tab-label">Fashion</span> </li>
                                <li class="ltabs-tab " data-category-id="25" data-active-content=".items-category-25"><span class="ltabs-tab-label">Electronics</span> </li>
                            </ul>
                        </div>
                    </div>
                    <!-- End Tabs-->
                </div>

                <div class="ltabs-items-container products-list grid">
                    <!--Begin Items-->
                    <div class="ltabs-items ltabs-items-selected items-category-20" data-total="16">
                        <div class="ltabs-items-inner ltabs-slider" id="dvProductos">

<%--                                  <div class="ltabs-item">
                                                <div class="item-inner product-layout transition product-grid">
                                                    <div class="product-item-container">
                                                        <div class="left-block">
                                                            <div class="product-image-container second_img">
                                                                <a href="product.html" target="_self" title="Pastrami bacon">
                                                                    <img src="/Template/image/catalog/demo/product/index2/270/1.jpg" class="img-1 img-responsive" alt="Pastrami bacon">
                                                                    <img src="/Template/image/catalog/demo/product/index2/270/10.jpg" class="img-2 img-responsive" alt="Pastrami bacon">
                                                                </a>
                                                            </div>
                                                            
                                                            <div class="button-group so-quickview cartinfo--left">
                                                                <button type="button" class="addToCart btn-button" title="Add to cart" onclick="cart.add('60 ');">  <i class="fa fa-shopping-basket"></i>
                                                                    <span>Add to cart </span>   
                                                                </button>
                                                                <button type="button" class="wishlist btn-button" title="Add to Wish List" onclick="wishlist.add('60');"><i class="fa fa-heart"></i><span>Add to Wish List</span>
                                                                </button>
                                                                <button type="button" class="compare btn-button" title="Compare this Product " onclick="compare.add('60');"><i class="fa fa-refresh"></i><span>Compare this Product</span>
                                                                </button>
                                                                <!--quickview-->                                                      
                                                                <a class="iframe-link btn-button quickview quickview_handler visible-lg" href="quickview.html" title="Quick view" data-fancybox-type="iframe"><i class="fa fa-eye"></i><span>Quick view</span></a>                                                        
                                                                <!--end quickview-->
                                                            </div>
                                                        </div>
                                                        <div class="right-block">
                                                            <div class="caption">
                                                                <div class="rating">    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                </div>
                                                                <h4><a href="product.html" title="Pastrami bacon" target="_self">Pastrami bacon</a></h4>
                                                                <div class="price">$42.00</div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>

                                                <div class="item-inner product-layout transition product-grid">
                                                    <div class="product-item-container">
                                                        <div class="left-block">
                                                            <div class="product-image-container second_img">
                                                                <a href="product.html" target="_self" title="Chicken swinesha">
                                                                    <img src="/Template/image/catalog/demo/product/index2/270/2.jpg" class="img-1 img-responsive" alt="image">
                                                                    <img src="/Template/image/catalog/demo/product/index2/270/9.jpg" class="img-2 img-responsive" alt="image">
                                                                </a>
                                                            </div>
                                                            <div class="box-label"> <span class="label-product label-sale"> -16% </span></div>
                                                            <div class="button-group so-quickview cartinfo--left">
                                                                <button type="button" class="addToCart btn-button" title="Add to cart" onclick="cart.add('60 ');">  <i class="fa fa-shopping-basket"></i>
                                                                    <span>Add to cart </span>   
                                                                </button>
                                                                <button type="button" class="wishlist btn-button" title="Add to Wish List" onclick="wishlist.add('60');"><i class="fa fa-heart"></i><span>Add to Wish List</span>
                                                                </button>
                                                                <button type="button" class="compare btn-button" title="Compare this Product " onclick="compare.add('60');"><i class="fa fa-refresh"></i><span>Compare this Product</span>
                                                                </button>
                                                                <!--quickview-->                                                      
                                                                <a class="iframe-link btn-button quickview quickview_handler visible-lg" href="quickview.html" title="Quick view" data-fancybox-type="iframe"><i class="fa fa-eye"></i><span>Quick view</span></a>                                                        
                                                                <!--end quickview-->
                                                            </div>
                                                        </div>
                                                        <div class="right-block">
                                                            <div class="caption">
                                                                <div class="rating">    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                    <span class="fa fa-stack"><i class="fa fa-star fa-stack-2x"></i></span>
                                                                </div>
                                                                <h4><a href="product.html" title="Chicken swinesha" target="_self">Chicken swinesha</a></h4>
                                                                <div class="price"> <span class="price-new">$46.00</span>
                                                                    <span class="price-old">$55.00</span>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                  </div>--%>
                             

                        </div>

                    </div>
                    <div class="ltabs-items items-category-18 grid" data-total="16">
                        <div class="ltabs-loading"></div>

                    </div>
                    <div class="ltabs-items  items-category-25 grid" data-total="16">
                        <div class="ltabs-loading"></div>
                    </div>
                    <!--End Items-->
                </div>

            </div>
        </div>
    </div>
    <!-- end Listing tabs -->

</div>


<asp:HiddenField ID="_hfListaProducto" runat="server" />
<script type="text/x-handlebars-template" id="handlebarProducto">
    {{# each Datos}}
           <div class="ltabs-item">
                                <div class="item-inner product-layout transition product-grid">
                                    <div class="product-item-container">
                                        <div class="left-block">
                                            <div class="product-image-container second_img">
                                                <a href="product.html" target="_self" title="Kielbasa hamburg">
                                                    <img src="/Template/image/catalog/demo/product/index2/270/3.jpg" class="img-1 img-responsive" alt="Pastrami bacon">
                                                    <img src="/Template/image/catalog/demo/product/index2/270/8.jpg" class="img-2 img-responsive" alt="Pastrami bacon">
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
                 <div class="item-inner product-layout transition product-grid">
                                    <div class="product-item-container">
                                        <div class="left-block">
                                            <div class="product-image-container second_img">
                                                <a href="product.html" target="_self" title="Kielbasa hamburg">
                                                    <img src="/Template/image/catalog/demo/product/index2/270/3.jpg" class="img-1 img-responsive" alt="Pastrami bacon">
                                                    <img src="/Template/image/catalog/demo/product/index2/270/8.jpg" class="img-2 img-responsive" alt="Pastrami bacon">
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
     {{/each}}


</script>

  