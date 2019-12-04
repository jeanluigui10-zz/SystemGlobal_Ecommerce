<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Index" %>
<%@ Import Namespace="xSystem_Maintenance.src.app_code" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">

         $(function () {
             fn_init();
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
                     obj[i].UnitPrice = uniteprice.toFixed(2);
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
	<div class="container-indent nomargin">
		<div class="container-fluid">
			<div class="row">
				<div class="slider-revolution revolution-default">
					<div class="tp-banner-container">
						<div class="tp-banner revolution">
							<ul>
								<li data-thumb="/Files/images/slides/01/imprenta7.jpg" data-transition="fade" data-slotamount="1" data-masterspeed="1000" data-saveperformance="off"  data-title="Slide">
									<img src="/Files/images/slides/01/imprenta7.jpg"  alt="slide1"  data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" >
									<div class="tp-caption tp-caption1 lft stb"
										data-x="center"
										data-y="center"
										data-hoffset="0"
										data-voffset="0"
										data-speed="600"
										data-start="900"
										data-easing="Power4.easeOut"
										data-endeasing="Power4.easeIn">
										<div class="tp-caption1-wd-1 tt-base-color">De multiples diseños</div>
										<div class="tp-caption1-wd-2">Exclusivos<br></div>
										<div class="tp-caption1-wd-3">Los mejores Diseños</div>
										<div class="tp-caption1-wd-4"><a href="<%=Page.ResolveUrl("~/Layout/Quotation.aspx") %>" target="_blank" class="btn btn-xl" style="background-color:orange!important" data-text="SOLICITAR COTIZACIÓN!">SOLICITAR COTIZACIÓN!</a></div>
									</div>
								</li>
								<li data-thumb="/Files/images/slides/01/imprenta6.jpg" data-transition="fade" data-slotamount="1" data-masterspeed="1000" data-saveperformance="off"  data-title="Slide">
									<img src="/Files/images/slides/01/imprenta6.jpg"  alt="slide1"  data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" >
									<div class="tp-caption tp-caption1 lft stb"
										data-x="center"
										data-y="center"
										data-hoffset="0"
										data-voffset="0"
										data-speed="600"
										data-start="900"
										data-easing="Power4.easeOut"
										data-endeasing="Power4.easeIn">
										<div class="tp-caption1-wd-1 tt-white-color">Todo listo</div>
										<div class="tp-caption1-wd-2 tt-white-color">Usa nuestra<br>Tienda</div>
										<div class="tp-caption1-wd-3 tt-white-color">Compras faciles y rapidas</div>
										<div class="tp-caption1-wd-4"><a href="<%=Page.ResolveUrl("~/Layout/Quotation.aspx") %>" target="_blank" class="btn btn-xl" style="background-color:orange!important" data-text="SOLICITAR COTIZACIÓN!">SOLICITAR COTIZACIÓN!</a></div>
									</div>
								</li>
								<li data-thumb="/Files/images/slides/01/imprenta3.jpg" data-transition="fade" data-slotamount="1" data-masterspeed="1000" data-saveperformance="off"  data-title="Slide">
									<img src="/Files/images/slides/01/imprenta3.jpg"  alt="slide1"  data-bgposition="center center" data-bgfit="cover" data-bgrepeat="no-repeat" >									
									<div class="tp-caption tp-fade fadeout fullscreenvideo"
										data-x="0"
										data-y="0"
										data-speed="600"
										data-start="0"
										data-easing="Power4.easeOut"
										data-endspeed="1500"
										data-endeasing="Power4.easeIn"
										data-autoplay="true"
										data-autoplayonlyfirsttime="false"
										data-nextslideatend="true"
										data-forceCover="1"
										data-dottedoverlay="twoxtwo"
										data-aspectratio="16:9">
						
									</div>
									<div class="tp-caption  tp-fade"
										data-x="right"
										data-y="bottom"
										data-voffset="-60"
										data-hoffset="-90"
										data-speed="600"
										data-start="900"
										data-easing="Power4.easeOut"
										data-endeasing="Power4.easeIn">
										<div class="video-play">
											<a class="icon-f-29 btn-play" href="#"></a>
											<a class="icon-f-28 btn-pause" href="#"></a>
										</div>
									</div>
									<!-- TEXT -->
									<div class="tp-caption lfb lft text-center"
										data-x="center"
										data-y="center"
										data-voffset="-20"
										data-hoffset="0"
										data-speed="600"
										data-start="900"
										data-easing="Power4.easeOut"
										data-endeasing="Power4.easeIn">
										<div class="tp-caption1-wd-1 tt-base-color">Bienvenido</div>
										<div class="tp-caption1-wd-2 tt-white-color">Busca tus Diseños<br>Tienda</div>
										<div class="tp-caption1-wd-3 tt-white-color">Para el mejor comercio electronico</div>
										<div class="tp-caption1-wd-4"><a href="<%=Page.ResolveUrl("~/Layout/Quotation.aspx") %>" target="_blank" class="btn btn-xl" style="background-color:orange!important" data-text="SOLICITAR COTIZACIÓN!">SOLICITAR COTIZACIÓN!</a></div>
									</div>
								</li>
							</ul>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
			<div class="tt-block-title">
				<h2 class="tt-title">LOS MEJORES DISEÑOS</h2>
				<div class="tt-description">VENTA SUPERIOR EN ESTA SEMANA</div>
			</div>
			<div class="row tt-layout-product-item" id="ListProductHome">
				   <div class="col-6 col-md-4 col-lg-3">
					<div class="tt-product thumbprod-center">
			
					</div>
				</div>
			</div>
		</div>
	</div>
	
	<div class="container-indent">
		<div class="container-fluid">
			<div class="tt-block-title">
				<h2 class="tt-title"><a target="_blank" href="https://www.instagram.com/wokieeshop/">@ Argos</a> Diseño</h2>
				<div class="tt-description">INSTAGRAM</div>
			</div>
			<%--<div class="row">
				<div id="instafeed" class="instafeed-fluid"
					data-accessToken="8626857013.dd09515.0fcd8351c65140d48f5a340693af1c3f"
					data-clientId="dd095157744c4bd0a67181fc4906e5b6"
					data-userId="8626857013"
					data-limitImg="6">
				</div>
			</div>--%>
		</div>
	</div>
	<div class="container-indent">
		<div class="container">
			<div class="row tt-services-listing">
				<div class="col-xs-12 col-md-6 col-lg-4">
					<a href="#" class="tt-services-block">
						<div class="tt-col-icon">
							<i class="icon-f-48"></i>
						</div>
						<div class="tt-col-description">
							<h4 class="tt-title">ENVIO</h4>
							<p>Envío gratis en todos los pedidos</p>
						</div>
					</a>
				</div>
				<div class="col-xs-12 col-md-6 col-lg-4">
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
				<div class="col-xs-12 col-md-6 col-lg-4">
					<a href="#" class="tt-services-block">
						<div class="tt-col-icon">
							<i class="icon-e-09"></i>
						</div>
						<div class="tt-col-description">
							<h4 class="tt-title">PROMOCIONES</h4>
							<p>Las mejores ofertas.</p>
						</div>
					</a>
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
							<a class="tt-btn-quickview view-to-cart-mp" <%--data-toggle="modal" data-target="#ModalquickView"--%> data-productid="{{Id}}" data-productname="{{Name}}" data-srcimg="{{NameResource}}" data-unitprice="{{UnitPrice}}" data-fileDescription="{{FileDescription}}"  data-tooltip="Quick View" data-tposition="left"></a>
							<a href="#" class="tt-btn-wishlist" data-tooltip="Add to Wishlist" data-tposition="left"></a>
							<a href="#" class="tt-btn-compare" data-tooltip="Add to Compare" data-tposition="left"></a>
							<a href="#" style="display:flex;align-items:center;position:relative">
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
							<h2 class="tt-title"><a href="#">{{Name}}</a></h2>
							<div class="tt-price">
								S/.{{UnitPrice}}
							</div>  
                           <%-- <% if (BaseSession.SsOrderxCore.Customer != null)
                                  {
                            %>--%>
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
                            <%--  <% 
                                }
                              %>--%>
						</div>
					</div>
				</div>
        {{/each}}
    </script>
</asp:Content>
