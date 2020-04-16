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
         Fn_ListCategory($("#<%=hfCategory.ClientID%>").val());
         
     }

     function Fn_ListCategory(dataCategory) {
         var glancedata = dataCategory;
         try {
             var objCategory = $.parseJSON(glancedata);
             var object = {};
             object.request = objCategory;
             var item = fn_LoadTemplates("datatable-Category", object);
             $("#DivListCategory").html(item);
         }
         catch (e) {
             fn_message('e', 'An error occurred while loading data...');
         }

     }
     function Fn_ListProducts(data) {
         var glancedata = data;
         try {
             obj = $.parseJSON(glancedata);
             for (var i = 0; i < obj.length; i++) {
                 var uniteprice = parseFloat(obj[i].UnitPrice);
                 obj[i].UnitPrice = uniteprice.toFixed(2);
             }
             var object = {};
             object.request = obj;
             var item = fn_LoadTemplates("datatable-Products", object);
             $("#DivProduct").html(item);
         }
         catch (e) {
             fn_message('e', 'An error occurred while loading data...');
         }
     }

     function Fn_LoadProduct_ByCategory(CategoryId) {
         success = function (response) {
             var lstProducts = response.d;
             try {
                 if (lstProducts != null) {
                     $("#DivProduct").empty();
                     Fn_ListProducts(lstProducts)
                     } else {
                         fn_message('e', 'An error occurred while loading data...');
                     }
             } catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
             $("#tbOrderDataTable").find(".loader_fb_16x16").remove();
         };

         error = function (xhr, ajaxOptions, thrownError) {
             $("#tbOrderDataTable").find(".loader_fb_16x16").remove();
         };
         fn_callmethod("Products.aspx/Products_ByCategory", '{CategoryId: "' + CategoryId + '"}', success, error);
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
						<h3 class="tt-collapse-title">ORDERNAR POR</h3>
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
						<h3 class="tt-collapse-title">Categorías de Productos</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-row" id="DivListCategory">
							</ul>
						</div>
					</div>
					<div class="tt-collapse open">
						<h3 class="tt-collapse-title">FILTRO POR PRECIO</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-row">
								<li class="active"><a href="#">$0 — $50</a></li>
								<li><a href="#">$50 — $100</a></li>
								<li><a href="#">$100 — $150</a></li>
								<li><a href="#">$150 —  $200</a></li>
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
							<h1 class="tt-title" style="display:none">
								MUJER <span class="tt-title-total">(69)</span>
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

						<div class="tt-product-listing row" id="DivProduct">
                                  <div class="tt-product thumbprod-center">
                                  </div>
						</div>

						<div class="text-center tt_product_showmore">
							<a href="#" class="btn btn-border">VER MÁS</a>
							<div class="tt_item_all_js">
								<a href="#" class="btn btn-border01">NO HAY MÁS ARTÍCULOS PARA MOSTRAR</a>
							</div>
						</div>
					</div>
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
<asp:HiddenField runat="server" ID="hfCategory" />

<script type="text/x-handlebars-template" id="datatable-Products">
    {{# each request}}
    <div class="col-6 col-md-4 tt-col-item">
        <div class="tt-product thumbprod-center">
            <div class="tt-image-box">
                <a href="#" class="tt-btn-quickview" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" data-fileDescription="{{FileDescription}}"  data-tooltip="Quick View" data-tposition="left"></a>
                <a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
                <a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
                <a href="#"<%--href="ProductSelected.aspx?p={{Id}}"--%>>
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

    <script type="text/x-handlebars-template" id="datatable-Category">
	       {{# each request}}
            <li style="cursor:pointer"><a onclick="Fn_LoadProduct_ByCategory('{{Id}}')">{{Name}}</a></li>
	       {{/each}}
</script>

</asp:Content>
