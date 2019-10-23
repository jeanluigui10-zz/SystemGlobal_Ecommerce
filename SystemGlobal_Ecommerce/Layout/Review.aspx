<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">

         $(function () {
             fn_init();
         });

         function fn_init() {
             fn_content();
         }
         function fn_content() {
             Fn_ListProductsShopCart($("#<%=hfData.ClientID%>").val());
             Fn_ListProductsShopCartHeader($("#<%=hfData.ClientID%>").val());
         }

         function Fn_ListProductsShopCart(data) {
             var glancedata = data;
             try {
                 obj = $.parseJSON(glancedata);
                 var object = {};
                 object.request = obj.Detail;
                 var item = fn_LoadTemplates("datatable-shopcart", object);
                 $("#tblBodyTable").html(item);
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
         }
         function Fn_ListProductsShopCartHeader(data) {
             var glancedata = data;
             try {
                 obj = $.parseJSON(glancedata);
                 var object = {};
                 object.request = obj.Detail;
                 var item = fn_LoadTemplates("datatable-shopcartHeader", object);
                 $("#lstCartView").html(item);
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="index.html">Incio</a></li>
			<li>Carrito de compas</li>
		</ul>
	</div>
</div>
<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder">CARRITO DE COMPRAS</h1>
			<div class="row">
				<div class="col-sm-12 col-xl-8">
					<div class="tt-shopcart-table">
						<table id="tblCarrito">
							<tbody id="tblBodyTable">
								
							</tbody>
						</table>
						<div class="tt-shopcart-btn">
							<div class="col-left">
								<a class="btn-link" href="Index.aspx"><i class="icon-e-19"></i>CONTINUAR COMPRANDO</a>
							</div>
							<div class="col-right">
								<a class="btn-link" href="#"><i class="icon-h-02"></i>LIMPIAR CARRITO DE COMPRAS</a>
								<a class="btn-link" href="#"><i class="icon-h-48"></i>ACTUALIZAR CARRITO</a>
							</div>
						</div>
					</div>
				</div>
				<div class="col-sm-12 col-xl-4">
					<div class="tt-shopcart-wrapper">
						<div class="tt-shopcart-box">
							<h4 class="tt-title">
								ESTIMATE SHIPPING AND TAX
							</h4>
							<p>Enter your destination to get a shipping estimate.</p>
							
								<div class="form-group">
									<label for="address_country">COUNTRY <sup>*</sup></label>
									<select id="address_country" class="form-control">
										<option>Austria</option>
										<option>Belgium</option>
										<option>Cyprus</option>
										<option>Croatia</option>
										<option>Czech Republic</option>
										<option>Denmark</option>
										<option>Finland</option>
										<option>France</option>
										<option>Germany</option>
										<option>Greece</option>
										<option>Hungary</option>
										<option>Ireland</option>
										<option>France</option>
										<option>Italy</option>
										<option>Luxembourg</option>
										<option>Netherlands</option>
										<option>Poland</option>
										<option>Portugal</option>
										<option>Slovakia</option>
										<option>Slovenia</option>
										<option>Spain</option>
										<option>United Kingdom</option>
									</select>
								</div>
								<div class="form-group">
									<label for="address_province">STATE/PROVINCE <sup>*</sup></label>
									<select id="address_province" class="form-control">
										<option>State/Province</option>
									</select>
								</div>
								<div class="form-group">
									<label for="address_zip">ZIP/POSTAL CODE <sup>*</sup></label>
									<input type="text" name="name" class="form-control" id="address_zip" placeholder="Zip/Postal Code">
								</div>
								<a href="#" class="btn btn-border">CALCULATE SHIPPING</a>
								<p>
									There is one shipping rate available for Alabama, Tanzania, United Republic Of.
								</p>
								<ul class="tt-list-dot list-dot-large">
									<li><a href="#">International Shipping at $20.00</a></li>
								</ul>
							
						</div>
						<div class="tt-shopcart-box">
							<h4 class="tt-title">
								NOTE
							</h4>
							<p>Add special instructions for your order...</p>
							
								<textarea class="form-control" rows="7"></textarea>
						
						</div>
						<div class="tt-shopcart-box tt-boredr-large">
							<table class="tt-shopcart-table01">
								<tbody>
									<tr>
										<th>SUBTOTAL</th>
										<td>$324</td>
									</tr>
								</tbody>
								<tfoot>
									<tr>
										<th>GRAND TOTAL</th>
										<td>$324</td>
									</tr>
								</tfoot>
							</table>
							<a href="#" class="btn btn-lg"><span class="icon icon-check_circle"></span>PROCEED TO CHECKOUT</a>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
     <asp:HiddenField runat="server" ID="hfData" />
    <script type="text/x-handlebars-template" id="datatable-shopcart">
        {{# each request}}
            <tr>
									<td>
										<a href="#" class="tt-btn-close"></a>
									</td>
									<td>
										<div class="tt-product-img">
											<img src="{{Product.NameResource}}" data-src="{{Product.NameResource}}" alt="">
										</div>
									</td>
									<td>
										<h2 class="tt-title">
											<a href="#" style="color: #007bff;">{{Product.ProductName}}</a>											
										</h2>
                                                 <h2 class="tt-title" style="color: #777777;font-size: 14px;">
											{{Product.Category}}										
										</h2>
                                                 
										<ul class="tt-list-parameters">
											<li>
												<div class="tt-price">
													S/.{{Product.UnitPrice}}
												</div>
											</li>
											<li>
												<div class="detach-quantity-mobile"></div>
											</li>
											<li>
												<div class="tt-price subtotal">
													S/.{{TotalPrice}}
												</div>
											</li>
										</ul>
									</td>
									<td>
										<div class="tt-price">
											S/.{{Product.UnitPrice}}
										</div>
									</td>
									<td>
										<div class="detach-quantity-desctope">
											<div class="tt-input-counter style-01">
												<span class="minus-btn"></span>
												<input type="text" value="{{Quantity}}" size="100">
												<span class="plus-btn"></span>
											</div>
										</div>
									</td>
									<td>
										<div class="tt-price subtotal">
											S/.{{TotalPrice}}
										</div>
									</td>
								</tr>
        {{/each}}
    </script>


</asp:Content>
