<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="ProductsList.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.ProductsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
 <script type="text/javascript">
     $(function () {
	    fn_init();
	    //contraer y expandir subcategorias
         $('.tt-collapse').click(function () {
             $(this).children().find('li').toggle("fast");
             if ($(this).hasClass("tt-collapse open"))
             {
                 $(this).removeClass();
                 $(this).addClass("tt-collapse");
             } else {
                 $(this).removeAttr("style");
                 $(this).removeClass();
                 $(this).addClass("tt-collapse open");

             }
             
         }); 
     });

     function fn_init() {
         fn_content();
     }
     function fn_content() {
         Fn_ListProducts($("#<%=hfProducts.ClientID%>").val());

         if ($("#<%=hfQueryCategory.ClientID%>").val() != "") {
             Fn_LoadProduct_BySubCategory($("#<%=hfQueryCategory.ClientID%>").val());
         }   
     }

     function Fn_ListProducts(data) {
         var glancedata = data;
         try {
             obj = $.parseJSON(glancedata);
             var object = {};
             object.request = obj;
             var item = fn_LoadTemplates("datatable-Products", object);
             $("#DivProduct").html(item);
             $("#lblListSubCategory").text("");
             $("#lblListSubCategory").text(obj[0].SubCategoryName);
         }
         catch (e) {
             fn_message('e', 'An error occurred while loading data...');
         }
     }

     function Fn_LoadProduct_BySubCategory(SubCategoryId) {
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
         fn_callmethod("ProductsList.aspx/Products_BySubCategory", '{SubCategoryId: "' + SubCategoryId + '"}', success, error);
     }

 </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
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
			<li><a href="/Index.aspx">Canastón</a></li>
			<li>Productos</li>
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

					<div id="DivListCategoryName">
						
					</div>

					<div class="tt-collapse open" style="display:none;">
						<h3 class="tt-collapse-title">Filtro por precio (S/.)</h3>
						<div class="tt-collapse-content">
							<ul class="tt-list-row">
								<li class="active"><a href="#">0 — 5</a></li>
								<li><a href="#">0 — 10</a></li>
								<li><a href="#">10 — 20</a></li>
							</ul>
						</div>
					</div>
				
					<div class="tt-content-aside">
						<a href="listing-left-column.html" class="tt-promo-03">
							<%--<img src="images/custom/listing_promo_img_07.jpg" alt="">--%>
						</a>
					</div>
				</div>
				<div class="col-md-12 col-lg-9 col-xl-9">
					<div class="content-indent container-fluid-custom-mobile-padding-02">
						<div class="tt-filters-options">
							<h1 class="tt-title" id="lblListSubCategory">
								MUJER <span class="tt-title-total">(69)</span>
							</h1>
							<div class="tt-btn-toggle">
								<a href="#">Filtro</a>
							</div>
							<div class="tt-sort">
								<select>
									<option value="Default Sorting">Ordernar por:</option>
									<option value="Default Sorting">Menor precio</option>
									<option value="Default Sorting">Mayor precio</option>
								</select>
							</div>
							<div class="tt-quantity">
								<a href="#" class="tt-col-one" data-value="tt-col-one"></a>
								<a href="#" class="tt-col-two" data-value="tt-col-two"></a>
								<a href="#" class="tt-col-three" data-value="tt-col-three"></a>
								<a href="#" class="tt-col-four" data-value="tt-col-four"></a>
								<a href="#" class="tt-col-six" data-value="tt-col-six"></a>
							</div>
							<a href="#" class="tt-grid-switch icon-h-43"></a>
						</div>

						<div class="tt-product-listing row tt-col-four" id="DivProduct">
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

<asp:HiddenField runat="server" ID="hfProducts" />
<asp:HiddenField runat="server" ID="hfCategory" />
<asp:HiddenField runat="server" ID="hfQueryCategory" />

<script type="text/x-handlebars-template" id="datatable-Products">
    {{# each request}}
    <div class="col-6 col-md-4 tt-col-item">
        <div class="tt-product thumbprod-center">
            <div class="tt-image-box">
                <a class="tt-btn-quickview view-to-cart-mp" data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" data-fileDescription="{{Description}}"  data-tooltip="Vista rápida" data-tposition="left"></a>
                <a <%--href="ProductSelected.aspx?p={{Id}}"--%>>
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
                        <a href="#" class="tt-btn-quickview view-to-cart-mp" data-toggle="modal" data-productid="{{Id}}" data-target="#ModalquickView"></a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    {{/each}}
</script>



   

</asp:Content>
