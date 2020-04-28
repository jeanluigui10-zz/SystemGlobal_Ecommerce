﻿<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="ProductSelected.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.ProductSelected" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">

        $(function () {
            Fn_init();
        });

        function Fn_init() {
            Fn_content();
        }

        function Fn_content() {
            Fn_ListProductSelected_Content($("#<%=hfProduct.ClientID%>").val());
            Fn_ListProductSelected($("#<%=hfProduct.ClientID%>").val());
        }

        function Fn_ListProductSelected_Content(dataContent) {
            var glancedata = dataContent;
            try {
                var objContent = $.parseJSON(glancedata);
                for (var i = 0; i < objContent.length; i++) {
                    var uniteprice = objContent[i].UnitPrice;
                    objContent[i].UnitPrice = uniteprice;
                }
                var objectContent = {};
                objectContent.request = objContent;
                var itemContent = fn_LoadTemplates("datatable-ProductSelectedContent", objectContent);
                $("#DivProductSelectedContent").html(itemContent);
            }
            catch (e) {
                fn_message('e', 'An error occurred while loading data...');
            }
        }

        function Fn_ListProductSelected(data) {
            var glancedata = data;
            try {
                var obj = $.parseJSON(glancedata);
                for (var i = 0; i < obj.length; i++) {
                    var uniteprice = obj[i].UnitPrice;
                    obj[i].UnitPrice = uniteprice;
                }
                var object = {};
                object.request = obj;
                var item = fn_LoadTemplates("datatable-ProductSelected", object);
                $("#DivProductSelected").html(item);
            }
            catch (e) {
                fn_message('e', 'An error occurred while loading data...');
            }
        }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
<div id="loader-wrapper">
	<div id="loader">
		<div class="dot"></div>
		<div class="dot"></div>
		<div class="dot"></div>
		<div class="dot"></div>
		<div class="dot"></div>
		<div class="dot"></div>
		<div class="dot"></div>
	</div>
</div>
<div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Canastón</a></li>
			<li><a href="listing-left-column.html">Productos</a></li>
			<li>Producto</li>
		</ul>
	</div>
</div>
<div id="tt-pageContent">
	<div class="container-indent">
		<!-- mobile product slider  -->
		<div class="tt-mobile-product-layout visible-xs">
			<div class="tt-mobile-product-slider arrow-location-center slick-animated-show-js">
				<div><img src="../Files/images/product/product-01.jpg" alt=""></div>
				<div><img src="../Files/images/product/product-01-02.jpg" alt=""></div>
				<div><img src="../Files/images/product/product-01-03.jpg" alt=""></div>
				<div><img src="../Files/images/product/product-01-04.jpg" alt=""></div>
				<div>
					<div class="embed-responsive embed-responsive-16by9">
						<iframe class="embed-responsive-item" src="" allowfullscreen></iframe>
					</div>
				</div>
				<div>
					<div class="tt-video-block">
						<a href="#" class="link-video"></a>
						<video class="movie" src="" poster="video/video_img.jpg"></video>
					</div>
				</div>
			</div>
		</div>
		<!-- /mobile product slider  -->
	    <div id="DivProductSelectedContent">
		
		   </div>
	</div>
	<div class="container-indent wrapper-social-icon">
		<div class="container">
			<ul class="tt-social-icon justify-content-center">
				<li><a class="icon-g-64" href="http://www.facebook.com/"></a></li>
				<li><a class="icon-h-58" href="http://www.facebook.com/"></a></li>
				<li><a class="icon-g-66" href="http://www.twitter.com/"></a></li>
				<li><a class="icon-g-67" href="http://www.google.com/"></a></li>
				<li><a class="icon-g-70" href="https://instagram.com/"></a></li>
			</ul>
		</div>
	</div>
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
			<div class="tt-block-title text-left">
				<h3 class="tt-title-small">PRODUCTO RELACIONADO</h3>
			</div>
			<div id="DivProductSelected" class="tt-carousel-products row arrow-location-right-top tt-alignment-img tt-layout-product-item slick-animated-show-js">
				<div class="tt-product thumbprod-center">
                    </div>
			</div>
		</div>
	</div>
</div>

<a href="#" class="tt-back-to-top">VOLVER ARRIBA</a>

<!-- modal (quickViewModal) -->
<div class="modal  fade"  id="ModalquickView" tabindex="-1" role="dialog" aria-label="myModalLabel" aria-hidden="true">
	<div class="modal-dialog modal-lg">
		<div class="modal-content ">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="icon icon-clear"></span></button>
			</div>
			<div class="modal-body">
				<div class="tt-modal-quickview desctope">
					<div class="row">
						<div class="col-12 col-md-5 col-lg-6">
							<div class="tt-mobile-product-slider arrow-location-center">
								<div><img src="images/loader.svg" data-src="../Files/images/product/product-01.jpg" alt=""></div>
								<div><img src="images/loader.svg" data-src="../Files/images/product/product-01-02.jpg" alt=""></div>
								<div><img src="images/loader.svg" data-src="../Files/images/product/product-01-03.jpg" alt=""></div>
								<div><img src="images/loader.svg" data-src="../Files/images/product/product-01-04.jpg" alt=""></div>
								<div>
									<div class="tt-video-block">
										<a href="#" class="link-video"></a>
										<video class="movie" src="" poster="video/video_img.jpg"></video>
									</div>
								</div>
							</div>
						</div>
						<div class="col-12 col-md-7 col-lg-6">
							<div class="tt-product-single-info">
								<div class="tt-add-info">
									<ul>
										<li><span>SKU:</span> 001</li>
										<li><span>Availability:</span> 40 in Stock</li>
									</ul>
								</div>
								<h2 class="tt-title">Cotton Blend Fleece Hoodie</h2>
								<div class="tt-price">
									<span class="new-price">$29</span>
									<span class="old-price"></span>
								</div>
								<div class="tt-review">
									<div class="tt-rating">
										<i class="icon-star"></i>
										<i class="icon-star"></i>
										<i class="icon-star"></i>
										<i class="icon-star"></i>
										<i class="icon-star"></i>
									</div>
									<a href="#">(1 Customer Review)</a>
								</div>
								<div class="tt-wrapper">
									Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
								</div>
								<div class="tt-swatches-container">
									<div class="tt-wrapper">
										<div class="tt-title-options">SIZE</div>
										<div class="form-default">
											<div class="form-group">
												<select class="form-control">
													<option>21</option>
													<option>25</option>
													<option>36</option>
												</select>
											</div>
										</div>
									</div>
									<div class="tt-wrapper">
										<div class="tt-title-options">COLOR</div>
										<div class="form-default">
											<div class="form-group">
												<select class="form-control">
													<option>Red</option>
													<option>Green</option>
													<option>Brown</option>
												</select>
											</div>
										</div>
									</div>
									<div class="tt-wrapper">
										<div class="tt-title-options">TEXTURE:</div>
										<ul class="tt-options-swatch options-large">
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="images/loader.svg" data-src="images/custom/texture-img-01.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li class="active"><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="images/loader.svg" data-src="images/custom/texture-img-02.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="images/loader.svg" data-src="images/custom/texture-img-03.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="images/loader.svg" data-src="images/custom/texture-img-04.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="images/loader.svg" data-src="images/custom/texture-img-05.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
										</ul>
									</div>
								</div>
								<div class="tt-wrapper">
									<div class="tt-row-custom-01">
										<div class="col-item">
											<div class="tt-input-counter style-01">
												<span class="minus-btn"></span>
												<input type="text" value="1" size="5">
												<span class="plus-btn"></span>
											</div>
										</div>
										<div class="col-item">
											<a class="btn btn-lg"><i class="icon-g-48"></i>Agregar Producto</a>
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
<!-- modalVideoProduct -->
<div class="modal fade"  id="modalVideoProduct" tabindex="-1" role="dialog" aria-label="myModalLabel" aria-hidden="true">
	<div class="modal-dialog modal-video">
		<div class="modal-content ">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="icon icon-clear"></span></button>
			</div>
			<div class="modal-body">
				<div class="modal-video-content">

				</div>
			</div>
		</div>
	</div>
</div>
<!-- modal (ModalSubsribeGood) -->
<div class="modal  fade"  id="ModalSubsribeGood" tabindex="-1" role="dialog" aria-label="myModalLabel" aria-hidden="true">
	<div class="modal-dialog modal-xs">
		<div class="modal-content ">
			<div class="modal-header">
				<button type="button" class="close" data-dismiss="modal" aria-hidden="true"><span class="icon icon-clear"></span></button>
			</div>
			<div class="modal-body">
				<div class="tt-modal-subsribe-good">
					<i class="icon-f-68"></i> You have successfully signed!
				</div>
			</div>
		</div>
	</div>
</div>
<asp:HiddenField runat="server" ID="hfProduct" />

     <script type="text/x-handlebars-template" id="datatable-ProductSelectedContent">
        {{# each request}}
         <div class="container container-fluid-mobile">
             <div class="row">
                 <div class="col-6 hidden-xs">
                     <div class="tt-product-vertical-layout">
                         <div class="tt-product-single-img">
                             <div>
                                 <button class="tt-btn-zomm tt-top-right"><i class="icon-f-86"></i></button>
                                 <img class="zoom-product" src='../Files/images/product/product-01.jpg' data-zoom-image="../Files/images/product/product-01.jpg" alt="">
                             </div>
                         </div>
                         <div class="tt-product-single-carousel-vertical">
                             <ul id="smallGallery" class="tt-slick-button-vertical  slick-animated-show-js">
                                 <li><a class="zoomGalleryActive" href="#" data-image="../Files/images/product/product-01.jpg" data-zoom-image="../Files/images/product/product-01.jpg">
                                     <img src="../Files/images/product/product-01.jpg" alt=""></a></li>
                                 <li><a href="#" data-image="../Files/images/product/product-01.jpg" data-zoom-image="../Files/images/product/product-01.jpg">
                                     <img src="../Files/images/product/product-01.jpg" alt=""></a></li>
                                 <li><a href="#" data-image="../Files/images/product/product-01.jpg" data-zoom-image="../Files/images/product/product-01.jpg">
                                     <img src="../Files/images/product/product-01.jpg" alt=""></a></li>
                                 <li><a href="#" data-image="../Files/images/product/product-01.jpg" data-zoom-image="../Files/images/product/product-01.jpg">
                                     <img src="../Files/images/product/product-01.jpg" alt=""></a></li>
                                 <li>
                                     <div class="video-link-product" data-toggle="modal" data-type="youtube" data-target="#modalVideoProduct" data-value="">
                                         <img src="../Files/images/product/product-small-empty.png" alt="">
                                         <div>
                                             <i class="icon-f-32"></i>
                                         </div>
                                     </div>
                                 </li>
                                 <li>
                                     <div class="video-link-product" data-toggle="modal" data-type="video" data-target="#modalVideoProduct" data-value="video/video.mp4" data-poster="video/video_img.jpg">
                                         <img src="../Files/images/product/product-small-empty.png" alt="">
                                         <div>
                                             <i class="icon-f-32"></i>
                                         </div>
                                     </div>
                                 </li>
                             </ul>
                         </div>
                     </div>
                 </div>

                 <div class="col-6">
                     <div class="tt-product-single-info">
                         <div class="tt-add-info">
                             <ul>
                                 <li><span>SKU:</span> 001</li>
                                 <li><span>Availability:</span> 40 in Stock</li>
                             </ul>
                         </div>
                         <h1 class="tt-title">{{Name}}</h1>
                         <div class="tt-price">
                             <span class="new-price">S/.{{UnitPrice}}</span>
                             <span class="old-price">S/.{{UnitPrice}}</span>
                         </div>
                         <div class="tt-review">
                             <div class="tt-rating">
                                 <i class="icon-star"></i>
                                 <i class="icon-star"></i>
                                 <i class="icon-star"></i>
                                 <i class="icon-star"></i>
                                 <i class="icon-star"></i>
                             </div>
                             <a class="product-page-gotocomments-js" href="#">(1 Customer Review)</a>
                         </div>
                         <div class="tt-wrapper">
                             {{FileDescription}}
                         </div>
                         <div class="tt-wrapper">
                             <div class="tt-countdown_box_02">
                                 <div class="tt-countdown_inner">
                                     <div class="tt-countdown"
                                         data-date="2018-11-01"
                                         data-year="Yrs"
                                         data-month="Mths"
                                         data-week="Wk"
                                         data-day="Day"
                                         data-hour="Hrs"
                                         data-minute="Min"
                                         data-second="Sec">
                                     </div>
                                 </div>
                             </div>
                         </div>
                         <div class="tt-wrapper">
                             <div class="tt-row-custom-01">
                                 <div class="col-item">
                                     <div class="tt-input-counter style-01">
                                         <span class="minus-btn"></span>
                                         <input type="text" value="1" size="5">
                                         <span class="plus-btn"></span>
                                     </div>
                                 </div>
                                 <div class="col-item">
                                     <a class="btn btn-lg add-to-cart-mp" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" style="cursor: pointer; color: white"><i class="icon-g-48" style="top: 3px; color: white"></i>Agregar Producto</a>
                                 </div>
                             </div>
                         </div>
                         <div class="tt-wrapper">
                             <ul class="tt-list-btn">
                                 <li><a class="btn-link" href="#"><i class="icon-n-072"></i>Agregar a lista de deseos</a></li>
                                 <li><a class="btn-link" href="#"><i class="icon-n-08"></i>Añadir a comparar</a></li>
                             </ul>
                         </div>
                         <div class="tt-wrapper">
                             <div class="tt-add-info">
                                 <ul>
                                     <li><span>Vendor:</span> Polo</li>
                                     <li><span>Product Type:</span> T-Shirt</li>
                                     <li><span>Tag:</span> <a href="#">T-Shirt</a>, <a href="#">Women</a>, <a href="#">Top</a></li>
                                 </ul>
                             </div>
                         </div>
                         <div class="tt-collapse-block">
                             <div class="tt-item">
                                 <div class="tt-collapse-title">DESCRIPTION</div>
                                 <div class="tt-collapse-content">
                                     Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum.

                                 </div>
                             </div>
                             <div class="tt-item">
                                 <div class="tt-collapse-title">ADDITIONAL INFORMATION</div>
                                 <div class="tt-collapse-content">
                                     <table class="tt-table-03">
                                         <tbody>
                                             <tr>
                                                 <td>Color:</td>
                                                 <td>Blue, Purple, White</td>
                                             </tr>
                                             <tr>
                                                 <td>Size:</td>
                                                 <td>20, 24</td>
                                             </tr>
                                             <tr>
                                                 <td>Material:</td>
                                                 <td>100% Polyester</td>
                                             </tr>
                                         </tbody>
                                     </table>
                                 </div>
                             </div>
                             <div class="tt-item">
                                 <div class="tt-collapse-title tt-poin-comments">REVIEWS (3)</div>
                                 <div class="tt-collapse-content">
                                     <div class="tt-review-block">
                                         <div class="tt-row-custom-02">
                                             <div class="col-item">
                                                 <h2 class="tt-title">1 REVIEW FOR VARIABLE PRODUCT
                                                 </h2>
                                             </div>
                                             <div class="col-item">
                                                 <a href="#">Write a review</a>
                                             </div>
                                         </div>
                                         <div class="tt-review-comments">
                                             <div class="tt-item">
                                                 <div class="tt-avatar">
                                                     <a href="#">
                                                         <img src="../Files/images/product/single/review-comments-img-01.jpg" alt=""></a>
                                                 </div>
                                                 <div class="tt-content">
                                                     <div class="tt-rating">
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                     </div>
                                                     <div class="tt-comments-info">
                                                         <span class="username">by <span>ADRIAN</span></span>
                                                         <span class="time">on January 14, 2017</span>
                                                     </div>
                                                     <div class="tt-comments-title">Very Good!</div>
                                                     <p>
                                                         Ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim.
                                                     </p>
                                                 </div>
                                             </div>
                                             <div class="tt-item">
                                                 <div class="tt-avatar">
                                                     <a href="#">
                                                         <img src="../Files/images/product/single/review-comments-img-02.jpg" alt=""></a>
                                                 </div>
                                                 <div class="tt-content">
                                                     <div class="tt-rating">
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                     </div>
                                                     <div class="tt-comments-info">
                                                         <span class="username">by <span>JESICA</span></span>
                                                         <span class="time">on January 14, 2017</span>
                                                     </div>
                                                     <div class="tt-comments-title">Bad!</div>
                                                     <p>
                                                         Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
                                                     </p>
                                                 </div>
                                             </div>
                                             <div class="tt-item">
                                                 <div class="tt-avatar">
                                                     <a href="#"></a>
                                                 </div>
                                                 <div class="tt-content">
                                                     <div class="tt-rating">
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                         <i class="icon-star"></i>
                                                     </div>
                                                     <div class="tt-comments-info">
                                                         <span class="username">by <span>ADAM</span></span>
                                                         <span class="time">on January 14, 2017</span>
                                                     </div>
                                                     <div class="tt-comments-title">Very Good!</div>
                                                     <p>
                                                         Diusmod tempor incididunt ut labore et dolore magna aliqua.
                                                     </p>
                                                 </div>
                                             </div>
                                         </div>
                                         <div class="tt-review-form">
                                             <div class="tt-message-info">
                                                 BE THE FIRST TO REVIEW <span>“BLOUSE WITH SHEER &AMP; SOLID PANELS”</span>
                                             </div>
                                             <p>Your email address will not be published. Required fields are marked *</p>
                                             <div class="tt-rating-indicator">
                                                 <div class="tt-title">
                                                     YOUR RATING *
                                                 </div>
                                                 <div class="tt-rating">
                                                     <i class="icon-star"></i>
                                                     <i class="icon-star"></i>
                                                     <i class="icon-star"></i>
                                                     <i class="icon-star"></i>
                                                     <i class="icon-star"></i>
                                                 </div>
                                             </div>
                                             <div class="form-default">
                                                 <div class="form-group">
                                                     <label for="inputName" class="control-label">YOUR NAME *</label>
                                                     <input type="email" class="form-control" id="inputName" placeholder="Enter your name">
                                                 </div>
                                                 <div class="form-group">
                                                     <label for="inputEmail" class="control-label">COUPONE E-MAIL *</label>
                                                     <input type="password" class="form-control" id="inputEmail" placeholder="Enter your e-mail">
                                                 </div>
                                                 <div class="form-group">
                                                     <label for="textarea" class="control-label">YOUR REVIEW *</label>
                                                     <textarea class="form-control" id="textarea" placeholder="Enter your review" rows="8"></textarea>
                                                 </div>
                                                 <div class="form-group">
                                                     <button type="submit" class="btn">SUBMIT</button>
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
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="datatable-ProductSelected">
    {{# each request}}
  <div class="col-2 col-md-4 col-lg-3">
        <div class="tt-product thumbprod-center">
            <div class="tt-image-box">
                <a href="#" class="tt-btn-quickview" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" data-fileDescription="{{Description}}"  data-tooltip="Quick View" data-tposition="left"></a>
               <%-- <a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>--%>
                <%--<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>--%>
                <a href="ProductSelected.aspx">
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
                <h2 class="tt-title"><a href="ProductSelected.aspx">{{Name}}</a></h2>
                <div class="tt-text-info">
                    Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
                </div>
                <div class="tt-price">
                    <span class="new-price">S/.{{UnitPrice}}</span>
                    <span class="old-price">S/.{{UnitPrice}}</span>
                </div>
                <div class="tt-product-inside-hover">
                    <div class="tt-row-btn">
                        <a class="tt-btn-addtocart thumbprod-button-bg add-to-cart-mp" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" style="cursor:pointer">Agregar producto</a>
                    </div>
                    <div class="tt-row-btn">
                        <a href="#" class="tt-btn-quickview" data-toggle="modal" data-productid="{{Id}}" data-target="#ModalquickView"></a>
                        <a href="#" class="tt-btn-wishlist"></a>
                        <a href="#" class="tt-btn-compare"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    {{/each}}
</script>

</asp:Content>