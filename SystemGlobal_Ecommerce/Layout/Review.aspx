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
         }

         function Fn_ListProductsShopCart(data) {
             var glancedata = data;
             try {
                 obj = $.parseJSON(glancedata);
                 var object = {};
                 object.request = obj.Detail;
                 var item = fn_LoadTemplates("datatable-shopcart", object);
                 $("#tblBodyTable").html(item);
                 CalculateReview(obj);
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
         }

         function CalculateReview(obj) {
             if (obj.Detail != null) { 
                 for (var i = 0; i < obj.Detail.length; i++) {
                 $('#unitPriceProduct_' + obj.Detail[i].Product.ProductId).text("S/." + obj.Detail[i].Product.UnitPrice.toFixed(2));
                 $('#uniPriceProd_' + obj.Detail[i].Product.ProductId).text("S/." + obj.Detail[i].Product.UnitPrice.toFixed(2));
                 $(".tt-cart-total-price").text("S/." + obj.SubTotal.toFixed(2));
                 $("#idSubTotalRight").text("S/." + obj.SubTotal.toFixed(2));
                 $("#idIGVRight").text("S/." + obj.IGV.toFixed(2));
                 $('#idSubTotalProduct_' + obj.Detail[i].Product.ProductId).text("S/." + obj.Detail[i].TotalPrice.toFixed(2));
                 $("#idTotalRigth").text("S/." + obj.Ordertotal.toFixed(2));
                 }
             }
         }
        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Canastón</a></li>
			<li>Productos Seleccionados</li>
		</ul>
	</div>
</div>
<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder">Tu lista de productos</h1>
			<div class="row">
				<div class="col-sm-12 col-xl-8">
					<div class="tt-shopcart-table">
						<table id="tblCarrito">
						     <thead>
                                <tr>
                                    <th style="text-align:right"></th>
                                    <th style="text-align:right">Producto</th>
                                    <th style="text-align:right"></th>
                                    <th style="text-align: left !important;">Precio</th>
                                    <th style="text-align:right">Cantidad</th>
                                    <th style="text-align: right !important;">Subtotal</th>
							 <th style="text-align:right"></th>
                                </tr>
                            </thead>
							<tbody id="tblBodyTable">
								
							</tbody>
						</table>
						<div class="tt-shopcart-btn">
							<div class="col-left">
								<a class="btn-link" href="ProductsList.aspx"><i class="icon-e-19"></i>CONTINUAR COMPRANDO</a>
							</div>

							<div class="col-right">
								<a class="btn-link" href="#"><i class="icon-h-02"></i>LIMPIAR CARRITO DE COMPRAS</a>
							</div>
						</div>
					</div>
				</div>
				<div class="col-sm-12 col-xl-4">
					<div class="tt-shopcart-wrapper form-default">
						<div class="tt-shopcart-box">
							<h4 class="tt-title">
								DIRECCIÓN DE ENTREGA
							</h4>
							<p> Av. España Nº 1344 - Trujillo</p>
							
								<div class="form-group">
									<label for="address_country">DEPARTAMENTO <sup>*</sup></label>
									<select id="address_country" class="form-control" disabled>
										<option>Peru</option>
										<%--<option>Belgium</option>
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
										<option>United Kingdom</option>--%>
									</select>
								</div>
								<div class="form-group">
									<label for="address_province">PROVINCIA <sup>*</sup></label>
									<select id="address_province" class="form-control">
										<option>Trujillo</option>
									</select>
								</div>
								<div class="form-group">
									<label for="address_zip">DISTRITO <sup>*</sup></label>
                                            <select id="address_zip" class="form-control" disabled>
										<option>Trujillo</option>
									</select>
									<%--<input type="text" name="name" class="form-control" id="address_zip" placeholder="Zip/Postal Code">--%>
								</div>
								<%--<a href="#" class="btn btn-border">CALCULATE SHIPPING</a>
								<p>
									There is one shipping rate available for Alabama, Tanzania, United Republic Of.
								</p>
								<ul class="tt-list-dot list-dot-large">
									<li><a href="#">International Shipping at $20.00</a></li>
								</ul>--%>
							
						</div>
						<%--<div class="tt-shopcart-box">
							<h4 class="tt-title">
								NOTE
							</h4>
							<p>Add special instructions for your order...</p>
							
								<textarea class="form-control" rows="7"></textarea>
						
						</div>--%>
						<div class="tt-shopcart-box tt-boredr-large">
							<table class="tt-shopcart-table01">
								<tbody>
									<tr>
										<th>SubTotal</th>
										<td id="idSubTotalRight">S/. 0.00</td>
									</tr>
                                            <tr>
										<th>Igv</th>
										<td id="idIGVRight">S/. 0.00</td>
									</tr>
								</tbody>
								<tfoot>
									<tr>
										<th>Total</th>
										<td id="idTotalRigth">S/. 0.00</td>
									</tr>
								</tfoot>
							</table>
                                  <!-- PayPal Logo --><table border="0" cellpadding="10" cellspacing="0" align="center"><tr><td align="center"></td></tr><tr><td align="center"><a href="https://www.paypal.com/webapps/mpp/paypal-popup" title="How PayPal Works" onclick="javascript:window.open('https://www.paypal.com/webapps/mpp/paypal-popup','WIPaypal','toolbar=no, location=no, directories=no, status=no, menubar=no, scrollbars=yes, resizable=yes, width=1060, height=700'); return false;"><img src="https://www.paypalobjects.com/webstatic/mktg/logo/AM_mc_vs_dc_ae.jpg" border="0" alt="PayPal Acceptance Mark" style="width: 100%"></a></td></tr></table><!-- PayPal Logo -->
                                  <%--<asp:Button 
                                        ID="btnPayment" 
                                        runat="server" 
                                        Text="Pagar" 
                                        OnClick="btnPayment_Click"
                                        Font-Bold="true"
                                        Height="45"
                                        Width="100%"
                                        style="background: #2879fe; color:white"
                                        />--%>
						    <a class="btn btn-primary"  href="https://api.whatsapp.com/send?phone=51989659008&text=Hola tienda ''El Canastón'' acabo de hacer mi pedido!" id="order-now" target="_blank" style="background:green">Ordenar Pedido</a>
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
												<div class="tt-price" id="unitPriceProduct_{{Product.ProductId}}">
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
										<div class="tt-price" id="uniPriceProd_{{Product.ProductId}}">
											S/.{{Product.UnitPrice}}
										</div>
									</td>
									<td>
										<div class="detach-quantity-desctope">
											<div class="tt-input-counter style-01">
												<span class="minus-btn"></span>
												<input type="text" value="{{Quantity}}" size="100" data-productid="{{Product.ProductId}}">
												<span class="plus-btn"></span>
											</div>
										</div>
									</td>
									<td>
										<div class="tt-price subtotal" id="idSubTotalProduct_{{Product.ProductId}}">
											S/.{{TotalPrice}}
										</div>
									</td>
								</tr>
        {{/each}}
    </script>


</asp:Content>
