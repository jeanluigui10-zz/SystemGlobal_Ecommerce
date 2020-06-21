<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Index" %>
<%@ Import Namespace="SystemGlobal_Ecommerce.src.app_code" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <script type="text/javascript">

         $(function () {
             fn_init();
             $('.slick-slider').slick('refresh');
         });

         function fn_init() {
             fn_content();
         }
         function fn_content() {
             Fn_ListProducts($("#<%=hfData.ClientID%>").val());
         }

         function Fn_ListProducts(data) {
             var glancedata = data;
             try {
                 obj = $.parseJSON(glancedata);
                 for (var i = 0; i < obj.length; i++) {
                     var uniteprice = obj[i].UnitPrice;
                     obj[i].UnitPrice = uniteprice;
                 }
                 var object = {};
                 object.request = obj;
                 var item = fn_LoadTemplates("datatable-resources", object);
                 $("#ListProductHome").html(item);
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
         }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="tt-pageContent">

     <div class="container">
		<div class="mainSlider-layout">
			<div class="loading-content">
				<div class="loading-dots">
					<i></i>
					<i></i>
					<i></i>
					<i></i>
				</div>
			</div>
			<div class="mainSliderSlick arrow-slick-main" style="height: fit-content !important">
				<div class="tt-slick-main-item">
					<img src="/Files/images/slides/slick-slider/slide-01.jpg" alt="">
					<div class="tt-description tt-point-h-c">
						<div class="tt-description-wrapper">
							<div class="tt-title-small"><span class="tt-base-color">Multipurpose</span></div>
							<div class="tt-title-large"><span class="tt-white-color">Premium<br>Html Template</span></div>
							<p>
								<span class="tt-white-color">30 skins, powerful features, great support, exclusive offer</span>
							</p>
							<div class="tp-caption1-wd-4"><a href="<%=Page.ResolveUrl("~/Layout/ProductsList.aspx") %>" style="font-weight:bold !important; color:black !important" class="btn btn-xl" data-text="ARMA TU PEDIDO!">ARMA TU PEDIDO!</a></div>
						</div>
					</div>
				</div>
				<div class="tt-slick-main-item">
					<img src="/Files/images/slides/slick-slider/slide-02.jpg" alt="">
					<div class="tt-description tt-point-h-r">
						<div class="tt-description-wrapper">
							<div class="tt-title-small"><span class="tt-base-color">Ready To</span></div>
							<div class="tt-title-large"><span class="tt-white-color">Use Unique<br>Demos</span></div>
							<p>
								<span class="tt-white-color">Optimized for speed, website that sells</span>
							</p>
							<div class="tp-caption1-wd-4"><a href="<%=Page.ResolveUrl("~/Layout/ProductsList.aspx") %>" style="font-weight:bold !important; color:black !important" class="btn btn-xl" data-text="ARMA TU PEDIDO!">ARMA TU PEDIDO!</a></div>
						</div>
					</div>
				</div>
				<div class="tt-slick-main-item">
					<img src="/Files/images/slides/slick-slider/slide-03.jpg" alt="">
					<div class="tt-description tt-point-h-r">
						<div class="tt-description-wrapper">
							<div class="tt-title-small"><span class="tt-base-color">Oberlo</span></div>
							<div class="tt-title-large">Find Products for<br>Shop Store</div>
							<p>
								Oberlo<br> allows you to easily import dropshipped products directly into your ecommerce store
							</p>
							<div class="tp-caption1-wd-4"><a href="<%=Page.ResolveUrl("~/Layout/ProductsList.aspx") %>" style="font-weight:bold !important; color:black !important" class="btn btn-xl" data-text="ARMA TU PEDIDO!">ARMA TU PEDIDO!</a></div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	
     <div class="container-indent">
            <div class="container">
                <div class="row tt-services-listing">
                    <div class="col-xs-12 col-md-6 col-lg-3">
                        <a href="#" class="tt-services-block">
                            <div class="tt-col-icon">
                                <i class="icon-f-48"></i>
                            </div>
                            <div class="tt-col-description">
                                <h4 class="tt-title">ENVIO</h4>
                                <p>Lo enviamos a la puerta de tu casa</p>
                            </div>
                        </a>
                    </div>
                    <div class="col-xs-12 col-md-6 col-lg-3">
                        <a href="#" class="tt-services-block">
                            <div class="tt-col-icon">
                                <i class="icon-f-35"></i>
                            </div>
                            <div class="tt-col-description">
                                <h4 class="tt-title">SOPORTE</h4>
                                <p>Contáctenos las 24 horas del día, los 7 días de la semana.</p>
                            </div>
                        </a>
                    </div>
                    <div class="col-xs-12 col-md-6 col-lg-3">
                        <a href="#" class="tt-services-block">
                            <div class="tt-col-icon">
                                <i class="icon-e-09"></i>
                            </div>
                            <div class="tt-col-description">
                                <h4 class="tt-title">PROMOCIONES</h4>
                                <p>Las mejores ofertas en productos de primera necesidad.</p>
                            </div>
                        </a>
                    </div>
                    <div class="col-xs-12 col-md-6 col-lg-3">
                        <a href="faq.html" class="tt-services-block">
                            <div class="tt-col-icon">
                                <i class="icon-f-77"></i>
                            </div>
                            <div class="tt-col-description">
                                <h4 class="tt-title">100% PAGO SEGURO</h4>
                                <p>Aseguramos el pago seguro con Culqui</p>
                            </div>
                        </a>
                    </div>
                </div>
            </div>
     </div>
	   
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
			<div class="tt-block-title">
				<h2 class="tt-title">TE RECOMENDAMOS ESTOS PRODUCTOS</h2>
				<div class="tt-description">Realiza tu compra!</div>
			</div>
			<div class="row tt-layout-product-item" id="ListProductHome" style="margin-top:-75px">
				   <div class="col-6 col-md-4 col-lg-3">
					<div class="tt-product thumbprod-center">
			
					</div>
				</div>
			</div>
		</div>
	</div>	
    
	<div class="container-indent" >
		<div class="container container-fluid-custom-mobile-padding">
			<div class="tt-block-title">
				<h1 class="tt-title">NUESTRAS CATEGORÍAS</h1>
				<div class="tt-description">No esperes más elige una!</div>
			</div>
			<div id="divSliderCategory" class="tt-carousel-products row arrow-location-tab arrow-location-tab01 tt-alignment-img tt-collection-listing slick-animated-show-js">
			</div>
		</div>
	</div>

     <div class="container-indent1">
		<div class="container-fluid-custom container-fluid-custom-mobile-padding">
			<div class="tt-block-title text-left">
				<h2 class="tt-title"></h2>
			</div>
			<div class="tt-tab-wrapper">
				<ul class="nav nav-tabs tt-tabs-default" role="tablist">
					<li class="nav-item">
						<a class="nav-link active" data-toggle="tab" href="#tt-tab01-01">Los más vendidos</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" data-toggle="tab" href="#tt-tab01-02">Ofertas</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" data-toggle="tab" href="#tt-tab01-03">Más vistos</a>
					</li>
					<li class="nav-item">
						<a class="nav-link" data-toggle="tab" href="#tt-tab01-04">Recién llegados</a>
					</li>
				</ul>
				<div class="tab-content">
					<div class="tab-pane active" id="tt-tab01-01">
						<div class="tt-carousel-products row arrow-location-tab tt-alignment-img tt-layout-product-item slick-animated-show-js"  data-item="6">
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-20.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-20-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
										<div class="tt-countdown_box">
											<div class="tt-countdown_inner">
												<div class="tt-countdown"
													data-date="2018-11-01"
													data-year="Yrs"
													data-month="Mths"
													data-week="Wk"
													data-day="Day"
													data-hour="Hrs"
													data-minute="Min"
													data-second="Sec"></div>
											</div>
										</div>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$12
										</div>
										<div class="tt-option-block">
											<ul class="tt-options-swatch">
												<li><a class="options-color tt-color-bg-01" href="#"></a></li>
												<li><a class="options-color tt-color-bg-02" href="#"></a></li>
											</ul>
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-02.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-02-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$124
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-22.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-22-01.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$12
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-24.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-24-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-sale">Sale 15%</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#" tabindex="0">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$12
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-17.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-17-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$12
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-05.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-05-02.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-sale">Sale 15%</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#" tabindex="0">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$12
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-25.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-25-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-price">
											$12
										</div>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="tab-pane" id="tt-tab01-02">
						<div class="tt-carousel-products row arrow-location-tab tt-alignment-img tt-layout-product-item slick-animated-show-js"  data-item="6">
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-24.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-24-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-sale">Sale 15%</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-17.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-17-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-20.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-20-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-02.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-02-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-22.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-22-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-41.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-41-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-28.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-28-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="tab-pane" id="tt-tab01-03">
						<div class="tt-carousel-products row arrow-location-tab tt-alignment-img tt-layout-product-item slick-animated-show-js"  data-item="6">
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-02.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-02-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-22.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-22-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-24.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-24-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-sale">Sale 15%</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-17.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-17-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-20.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-20-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-41.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-41-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-sale">Sale 15%</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-28.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-28-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
						</div>
					</div>
					<div class="tab-pane" id="tt-tab01-04">
						<div class="tt-carousel-products row arrow-location-tab tt-alignment-img tt-layout-product-item slick-animated-show-js"  data-item="6">
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-22.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-22-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-02.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-02-02.jpg" alt=""></span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-24.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-24-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-sale">Sale 15%</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-20.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-20-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-17.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-17-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-32.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-32-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
											</div>
										</div>
									</div>
								</div>
							</div>
							<div class="col-2 col-md-4 col-lg-3">
								<div class="tt-product thumbprod-center">
									<div class="tt-image-box">
										<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"	data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
										<a href="product.html">
											<span class="tt-img"><img src="/Files/images/product/product-11.jpg" alt=""></span>
											<span class="tt-img-roll-over"><img src="/Files/images/product/product-11-01.jpg" alt=""></span>
											<span class="tt-label-location">
												<span class="tt-label-new">New</span>
											</span>
										</a>
									</div>
									<div class="tt-description">
										<div class="tt-row">
											<ul class="tt-add-info">
												<li><a href="#">T-SHIRTS</a></li>
											</ul>
											<div class="tt-rating">
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star"></i>
												<i class="icon-star-half"></i>
												<i class="icon-star-empty"></i>
											</div>
										</div>
										<h2 class="tt-title"><a href="product.html">Flared Shift Dress</a></h2>
										<div class="tt-product-inside-hover">
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-addtocart thumbprod-button-bg" data-toggle="modal" data-target="#modalAddToCartProduct">ADD TO CART</a>
											</div>
											<div class="tt-row-btn">
												<a href="#" class="tt-btn-quickview" data-toggle="modal" data-target="#ModalquickView"></a>
												<a href="#" class="tt-btn-wishlist"></a>
												<a href="#" class="tt-btn-compare"></a>
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
	  
</div>
    
 
 <asp:HiddenField runat="server" ID="hfData" />
    <script type="text/x-handlebars-template" id="datatable-resources">
        {{# each request}}
            <div class="col-6 col-md-4 col-lg-3">
					<div class="tt-product thumbprod-center">
						<div class="tt-image-box aline">
							<a class="tt-btn-quickview view-to-cart-mp" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" data-fileDescription="{{Description}}"  data-tooltip="Vista rápida" data-tposition="left"></a>
							<%--<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>--%>
							<%--<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>--%>
							<a style="display:flex;align-items:center;position:relative">
								<span class="tt-img"><img src="{{NameResource}}" data-src="{{NameResource}}" alt=""></span>
								<span class="tt-img-roll-over"><img src="{{NameResource}}" data-src="{{NameResource}}" alt=""></span>
							</a>
						</div>
						<div class="tt-description">
							<div class="tt-row">
								<ul class="tt-add-info">
									<li><a href="#">{{Category}}</a></li>
								</ul>
								<div class="tt-rating">
									<i class="icon-star"></i>
									<i class="icon-star"></i>
									<i class="icon-star"></i>
									<i class="icon-star"></i>
									<i class="icon-star"></i>
								</div>
							</div>
							<h2 class="tt-title"><a>{{Name}}</a>&nbsp;<a>{{UniMed}}</a></h2>
					          <h4 class="tt-title-small"><a>{{Brand}}</a></h4>
                                  <div class="tt-price">
                                      <span class="new-price">S/.{{PriceOffer}}</span>
                                      <span class="old-price">S/.{{UnitPrice}}</span>
                                  </div>

                                  <div class="tt-product-inside-hover">
								<div class="tt-row-btn">                           
									<a class="tt-btn-addtocart thumbprod-button-bg add-to-cart-mp" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" style="cursor:pointer">Agregar producto</a>
								</div>
								<div class="tt-row-btn">
									<a href="#" class="tt-btn-quickview view-to-cart-mp" data-productid="{{Id}}" data-toggle="modal" data-target="#ModalquickView"></a>
									<a href="#" class="tt-btn-wishlist"></a>
									<a href="#" class="tt-btn-compare"></a>
								</div>
							</div>
						</div>
					</div>
				</div>
        {{/each}}
    </script>

        <script type="text/x-handlebars-template" id="datatable-CategorySliderMaster">
	       {{# each request}}
         <div class="col-2 col-md-4 col-lg-3">
             <a href="/Layout/ProductsList.aspx?category={{Id}}" class="tt-collection-item">
                 <div class="tt-image-box">
                     <img src="/Files/images/product/product-20.jpg" alt="">
                 </div>
                 <div class="tt-description">
                     <h2 class="tt-title">{{Name}}</h2>
                     <ul class="tt-add-info">
                         <li>45 PRODUCTS</li>
                     </ul>
                 </div>
             </a>
         </div>
	       {{/each}}
    </script>

</asp:Content>
