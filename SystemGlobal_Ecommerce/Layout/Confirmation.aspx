<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         window.onload = function () {
             document.getElementById("divheader").style.display = "none";
             document.getElementById("btnLateral").style.display = "none";
             document.getElementById("converse-chat").style.display = "none";
             document.getElementById("divFooter").style.display = "none";
             document.getElementById("divFooter2").style.display = "none";
                          
                 <%--if ($("#<%=hfIsVisiableChatConfir.ClientID%>").val() != "") {
                      if ($("#<%=hfIsVisiableChatConfir.ClientID%>").val() == "1") {                                              //Chat en linea
                         $("#clgo").css("display", "none");
                         $("#btnLateral").css("display", "block");
                     } else {                                           //chat bot

                         $("#clgo").css("display", "block");
                         $("#btnLateral").css("display", "none");
                     }
                 }--%>
             
         }
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
                 var item = fn_LoadTemplates("datatable-shopcartConfirm", object);
                 $("#tblBodyTableConfirm").html(item);
                 CalculateConfirm(obj);
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
         }
         function CalculateConfirm(obj) {
             $(".tt-cart-total-price").text("S/." + obj.SubTotal);
             $("#idSubTotalRight").text("S/." + obj.SubTotal);
             $("#idDeliveryTotalRight").text("S/." + obj.DeliveryTotal);
             $("#idTotalRigth").text("S/." + obj.Ordertotal);
         }
        
    </script>
    <script type="text/javascript">
        (function (global) {

            if (typeof (global) === "undefined") {
                throw new Error("window is undefined");
            }

            var _hash = "!";
            var noBackPlease = function () {
                global.location.href += "#";

                // making sure we have the fruit available for juice (^__^)
                global.setTimeout(function () {
                    global.location.href += "!";
                }, 50);
            };

            global.onhashchange = function () {
                if (global.location.hash !== _hash) {
                    global.location.hash = _hash;
                }
            };

            global.onload = function () {
                noBackPlease();
            }

        })(window);
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder" id="lblMessageConfirm" runat="server" style="font-size: x-large;"></h1>
			<div class="row">
				<div class="col-sm-12 col-xl-8">
					<div class="tt-shopcart-table">
						<table id="tblCarrito">
							<tbody id="tblBodyTableConfirm">
								
							</tbody>
						</table>
						<%--<div class="tt-shopcart-btn">
							<div class="col-left">
								<a class="btn-link" href="Index.aspx"><i class="icon-e-19"></i>CONTINUAR COMPRANDO</a>
							</div>
							<div class="col-right">
								<a class="btn-link" href="#"><i class="icon-h-02"></i>LIMPIAR CARRITO DE COMPRAS</a>
								<a class="btn-link" href="#"><i class="icon-h-48"></i>ACTUALIZAR CARRITO</a>
							</div>
						</div>--%>
					</div>
				</div>
				<div class="col-sm-12 col-xl-4">
					<div class="tt-shopcart-wrapper form-default">
						<div class="tt-shopcart-box">
							<h4 class="tt-title">
								Dirección de entrega
							</h4>
							<p id="lblAddressConfirm" runat="server" style="font-size: large;"></p>
							
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
									<select id="address_province" class="form-control" disabled>
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
										<th>Delivery</th>
										<td id="idDeliveryTotalRight">S/. 0.00</td>
									</tr>
								</tbody>
								<tfoot>
									<tr>
										<th>Total</th>
										<td id="idTotalRigth">S/. 0.00</td>
									</tr>
								</tfoot>
							</table>
                                 
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
</div>
<%--     <asp:HiddenField runat="server" ID="hfIsVisiableChatConfir" />--%>
     <asp:HiddenField runat="server" ID="hfData" />
    <script type="text/x-handlebars-template" id="datatable-shopcartConfirm">
        {{# each request}}
            <tr>
									<td>
										<%--<a href="#" class="tt-btn-close"></a>--%>
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
                                                 <div class="tt-price">
                                                     <span class="new-price">S/.{{Product.UnitPrice}}</span>
                                                    <%-- <span class="old-price">S/.{{Product.UnitPrice}}</span>--%>
                                                 </div>
									</td>
									<td>
										<div class="detach-quantity-desctope">
											<div class="tt-input-counter style-01">
												<%--<span class="minus-btn"></span>--%>
												<input type="text" value="{{Quantity}}" size="100" data-productid="{{Product.ProductId}}" readonly="readonly">
												<%--<span class="plus-btn"></span>--%>
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
