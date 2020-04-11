<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Products" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <script type="text/javascript">

     $(function () {
         fn_init();
     });

     function fn_init() {
         fn_content();
     }
     function fn_content() {
         Fn_ListProducts($("#<%=hfProducts.ClientID%>").val());
     }

     function Fn_ListProducts(data) {
         var glancedata = data;
         try {
             obj = $.parseJSON(glancedata);
             for (var i = 0; i < obj.length; i++) {
                 var uniteprice = obj[i].UnitPrice;
                 obj[i].UnitPrice = uniteprice.toFixed(2);
             }
             var object = {};
             object.request = obj;
             var item = fn_LoadTemplates("datatable-Products", object);
             $("#ProductDiv").html(item);
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
			<li><a href="index.html">Home</a></li>
			<li>Listing</li>
		</ul>
	</div>
</div>
<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<div class="row">
				<div class="col-md-4 col-lg-3 col-xl-3 leftColumn aside">
					<div class="tt-btn-col-close">
						<a href="#">Close</a>
					</div>
					<div class="tt-collapse open tt-filter-detach-option">
						<div class="tt-collapse-content">
							<div class="filters-mobile">
								<div class="filters-row-select">

								</div>
							</div>
						</div>
					</div>
					<div class="tt-collapse open ">
						<h3 class="tt-collapse-title">SORT BY</h3>
						<div class="tt-collapse-content">
							<ul class="tt-filter-list">
								<li class="active">
									<a href="#">Shirts &amp; Tops</a>
								</li>
								<li>
									<a href="#">XS</a>
								</li>
								<li>
									<a href="#">White</a>
								</li>
							</ul>
							<a href="#" class="btn-link-02">Clear All</a>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">PRODUCT CATEGORIES</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-row">
								<li class="active"><a href="#">Dresses</a></li>
								<li><a href="#">Shirts &amp; Tops</a></li>
								<li><a href="#">Polo Shirts</a></li>
								<li><a href="#">Sweaters</a></li>
								<li><a href="#">Blazers &amp; Vests</a></li>
								<li><a href="#">Jackets &amp; Outerwear</a></li>
								<li><a href="#">Activewear</a></li>
								<li><a href="#">Pants</a></li>
								<li><a href="#">Jumpsuits &amp; Shorts</a></li>
								<li><a href="#">Jeans</a></li>
								<li><a href="#">Skirts</a></li>
								<li><a href="#">Swimwear</a></li>
							</ul>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">FILTER BY PRICE</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-row">
								<li class="active"><a href="#">$0 — $50</a></li>
								<li><a href="#">$50 — $100</a></li>
								<li><a href="#">$100 — $150</a></li>
								<li><a href="#">$150 —  $200</a></li>
							</ul>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">FILTER BY SIZE</h3>
						<div class="tt-collapse-content">
							<ul class="tt-options-swatch options-middle">
								<li><a href="#">4</a></li>
								<li class="active"><a href="#">6</a></li>
								<li><a href="#">8</a></li>
								<li><a href="#">10</a></li>
								<li><a href="#">12</a></li>
								<li><a href="#">14</a></li>
								<li><a href="#">16</a></li>
								<li><a href="#">18</a></li>
								<li><a href="#">20</a></li>
								<li><a href="#">22</a></li>
								<li><a href="#">24</a></li>
							</ul>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">FILTER BY COLOR</h3>
						<div class="tt-collapse-content">
							<ul class="tt-options-swatch options-middle">
								<li><a class="options-color tt-border tt-color-bg-08" href="#"></a></li>
								<li><a class="options-color tt-color-bg-09" href="#"></a></li>
								<li class="active"><a class="options-color tt-color-bg-10" href="#"></a></li>
								<li><a class="options-color tt-color-bg-11" href="#"></a></li>
								<li><a class="options-color tt-color-bg-12" href="#"></a></li>
								<li><a class="options-color tt-color-bg-13" href="#"></a></li>
								<li><a class="options-color tt-color-bg-14" href="#"></a></li>
								<li><a class="options-color tt-color-bg-15" href="#"></a></li>
								<li><a class="options-color tt-color-bg-16" href="#"></a></li>
								<li><a class="options-color tt-color-bg-17" href="#"></a></li>
								<li><a class="options-color tt-color-bg-18" href="#"></a></li>
								<li><a class="options-color" href="#">
									<span class="swatch-img">
										<img src="" alt="">
									</span>
									<span class="swatch-label color-black"></span>
								</a></li>
							</ul>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">VENDOR</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-row">
								<li><a href="#">Levi's</a></li>
								<li><a href="#">Gap</a></li>
								<li><a href="#">Polo</a></li>
								<li><a href="#">Lacoste</a></li>
								<li><a href="#">Guess</a></li>
							</ul>
							<a href="#" class="btn-link-02">+ More</a>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">SALE PRODUCTS</h3>
						<div class="tt-collapse-content">
							<div class="tt-aside">
								<a class="tt-item" href="ProductSelected.aspx">
									<div class="tt-img">
										<span class="tt-img-default"><img src="" data-src="../Files/images/product/product-01.jpg" alt=""></span>
										<span class="tt-img-roll-over"><img src="" data-src="../Files/images/product/product-01.jpg" alt=""></span>
									</div>
									<div class="tt-content">
										<h6 class="tt-title">Flared Shift Dress</h6>
										<div class="tt-price">
											<span class="sale-price">$14</span>
											<span class="old-price">$24</span>
										</div>
									</div>
								</a>
								<a class="tt-item" href="ProductSelected.aspx">
									<div class="tt-img">
										<span class="tt-img-default"><img src="" data-src="../Files/images/product/product-02.jpg" alt=""></span>
										<span class="tt-img-roll-over"><img src="" data-src="../Files/images/product/product-02-02.jpg" alt=""></span>
									</div>
									<div class="tt-content">
										<h6 class="tt-title">Flared Shift Dress</h6>
										<div class="tt-price">
											<span class="sale-price">$14</span>
											<span class="old-price">$24</span>
										</div>
									</div>
								</a>
								<a class="tt-item" href="ProductSelected.aspx">
									<div class="tt-img">
										<span class="tt-img-default"><img src="" data-src="../Files/images/product/product-03.jpg" alt=""></span>
										<span class="tt-img-roll-over"><img src="" data-src="../Files/images/product/product-03-02.jpg" alt=""></span>
									</div>
									<div class="tt-content">
										<h6 class="tt-title">Flared Shift Dress</h6>
										<div class="tt-price">
											<span class="sale-price">$14</span>
											<span class="old-price">$24</span>
										</div>
									</div>
								</a>
							</div>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">TAGS</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-inline">
								<li><a href="#">Dresses</a></li>
								<li><a href="#">Shirts &amp; Tops</a></li>
								<li><a href="#">Polo Shirts</a></li>
								<li><a href="#">Sweaters</a></li>
								<li><a href="#">Blazers</a></li>
								<li><a href="#">Vests</a></li>
								<li><a href="#">Jackets</a></li>
								<li><a href="#">Outerwear</a></li>
								<li><a href="#">Activewear</a></li>
								<li><a href="#">Pants</a></li>
								<li><a href="#">Jumpsuits</a></li>
								<li><a href="#">Shorts</a></li>
								<li><a href="#">Jeans</a></li>
								<li><a href="#">Skirts</a></li>
								<li><a href="#">Swimwear</a></li>
							</ul>
						</div>
					</div>
					<div class="tt-content-aside">
						<a href="listing-left-column.html" class="tt-promo-03">
							<img src="images/custom/listing_promo_img_07.jpg" alt="">
						</a>
					</div>
				</div>
				<div class="col-md-12 col-lg-9 col-xl-9">
					<div class="content-indent container-fluid-custom-mobile-padding-02">
						<div class="tt-filters-options">
							<h1 class="tt-title">
								WOMEN <span class="tt-title-total">(69)</span>
							</h1>
							<div class="tt-btn-toggle">
								<a href="#">FILTER</a>
							</div>
							<div class="tt-sort">
								<select>
									<option value="Default Sorting">Default Sorting</option>
									<option value="Default Sorting">Default Sorting 02</option>
									<option value="Default Sorting">Default Sorting 03</option>
								</select>
								<select>
									<option value="Show">Show</option>
									<option value="9">9</option>
									<option value="16">16</option>
									<option value="32">32</option>
								</select>
							</div>
							<div class="tt-quantity">
								<a href="#" class="tt-col-one" data-value="tt-col-one"></a>
								<a href="#" class="tt-col-two" data-value="tt-col-two"></a>
								<a href="#" class="tt-col-three" data-value="tt-col-three"></a>
								<a href="#" class="tt-col-four" data-value="tt-col-four" id="fourId"></a>
								<a href="#" class="tt-col-six" data-value="tt-col-six"></a>
							</div>
							<a href="#" class="tt-grid-switch icon-h-43"></a>
						</div>

						<div class="tt-product-listing row" id="ProductDiv">
                                  <div class="tt-product thumbprod-center">
                                  </div>
						</div>

						<div class="text-center tt_product_showmore">
							<a href="#" class="btn btn-border">LOAD MORE</a>
							<div class="tt_item_all_js">
								<a href="#" class="btn btn-border01">NO MORE ITEM TO SHOW</a>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<a href="#" class="tt-back-to-top">BACK TO TOP</a>

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
								<div><img src="" data-src="../Files/images/product/product-01.jpg" alt=""></div>
								<div><img src="" data-src="../Files/images/product/product-01-02.jpg" alt=""></div>
								<div><img src="" data-src="../Files/images/product/product-01-03.jpg" alt=""></div>
								<div><img src="" data-src="../Files/images/product/product-01-04.jpg" alt=""></div>
								<div>
									<div class="tt-video-block">
										<a href="#" class="link-video"></a>
										<video class="movie" src="video/video.mp4" poster="video/video_img.jpg"></video>
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
										<i class="icon-star-half"></i>
										<i class="icon-star-empty"></i>
									</div>
									<a href="#">(1 Customer Review)</a>
								</div>
								<div class="tt-wrapper">
									Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
								</div>
								<div class="tt-swatches-container">
									<div class="tt-wrapper">
										<div class="tt-title-options">SIZE</div>
										<form class="form-default">
											<div class="form-group">
												<select class="form-control">
													<option>21</option>
													<option>25</option>
													<option>36</option>
												</select>
											</div>
										</form>
									</div>
									<div class="tt-wrapper">
										<div class="tt-title-options">COLOR</div>
										<form class="form-default">
											<div class="form-group">
												<select class="form-control">
													<option>Red</option>
													<option>Green</option>
													<option>Brown</option>
												</select>
											</div>
										</form>
									</div>
									<div class="tt-wrapper">
										<div class="tt-title-options">TEXTURE:</div>
										<ul class="tt-options-swatch options-large">
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="" data-src="" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li class="active"><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="" data-src="images/custom/texture-img-02.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="" data-src="images/custom/texture-img-03.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="" data-src="images/custom/texture-img-04.jpg" alt="">
												</span>
												<span class="swatch-label color-black"></span>
											</a></li>
											<li><a class="options-color" href="#">
												<span class="swatch-img">
													<img src="" data-src="images/custom/texture-img-05.jpg" alt="">
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
											<a href="#" class="btn btn-lg"><i class="icon-f-39"></i>ADD TO CART</a>
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
    
<asp:HiddenField runat="server" ID="hfProducts" />
<script type="text/x-handlebars-template" id="datatable-Products">
    {{# each request}}
    <div class="col-6 col-md-4 tt-col-item">
        <div class="tt-product thumbprod-center">
            <div class="tt-image-box">
                <a href="#" class="tt-btn-quickview" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" data-fileDescription="{{FileDescription}}"  data-tooltip="Quick View" data-tposition="left"></a>
                <a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
                <a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
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
                        <i class="icon-star-half"></i>
                        <i class="icon-star-empty"></i>
                    </div>
                </div>
                <h2 class="tt-title"><a href="ProductSelected.aspx">{{Name}}</a></h2>
                <div class="tt-text-info">
                    Lorem ipsum dolor sit amet conse ctetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam.
                </div>
                <div class="tt-price">S/.{{UnitPrice}}</div>
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
