<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Incluyendo .js de Culqi JS -->
    <script src="https://checkout.culqi.com/v2"></script>

    <style type="text/css">
        #divPayment .rdbPayment label, #divPayment .chkPayment label, .TypeCC label {
            display: inline-block;
            margin-left: 7px;
            vertical-align: middle;
		  font-size: 16px;
        }
    </style>
   
     <script type="text/javascript">
         var $this = this;
         $(function () {

             Culqi.publicKey = 'pk_test_e10ed06809bfa78c';
             Culqi.init();

             //fn_init();

             PaymentOptions_Select($('.rdbPayment input[type=radio][name$=Payment]:checked'));

             $(".rdbPayment input[type=radio][name$=Payment]").change(function () {
                 PaymentOptions_Select($(this));
             });
             
             //$('#btn_pagar').on('click', function (e) {
             //    // Crea el objeto Token con Culqi JS
             //    Culqi.createToken();
             //    e.preventDefault();
             //});
         });
         function Fn_ValidateCard(e) {

             if (!fn_validateform('divPay')) {
                 e.preventDefault();
                 return false;
             }
             Culqi.createToken();
             e.preventDefault();
         }

     <%--    function fn_init() {
             fn_content();
         }
       function fn_content() {
             PaymentOptions_Select($('.rdbPayment input[type=radio][name$=Payment]:checked'));
        if ($("#<%=hfDataMethodPayment.ClientID%>").val() != "") {
                 Fn_ListMethodPayment($("#<%=hfDataMethodPayment.ClientID%>").val());
             }
             Fn_ListProductsShopCartHeader($("#<%=hfData.ClientID%>").val());       
         }--%>
         function PaymentOptions_Select($this) {
             //var deviceDataId = OpenPay.deviceData.setup($("form").attr("id"));
             PaymentId = $this[0].id;
             var paymenttype = PaymentId.replace("rdb", "");
             $("input[type=hidden][id$=hfPaymentType]").val(paymenttype);
         }
        
         function Fn_ListMethodPayment(dataPayment) {
             var glancedata = dataPayment;
             try {
                 var objCategory = $.parseJSON(glancedata);
                 var object = {};
                 object.request = objCategory;
                 var item = fn_LoadTemplates("datatable-MethodPayment", object);
                 $("#DivMethodPayment").html(item);
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
         }

         function culqi() {
             if (Culqi.token) { // ¡Objeto Token creado exitosamente!
                 var token = Culqi.token.id;
                 objpay = {
                     token_created: token,
                     email: $("input[name=email]").val(),

                  }
                 var success = function (asw) {
                     if (asw != null) {
                         if (asw.d.Result == "Ok") {
                             fn_message("s", asw.d.Msg);
                         } else {
                             fn_message('i', 'Ocurrio un error al guardar');
                         }
                     }
                 };
                 var error = function (xhr, ajaxOptions, thrownError) {
                     fn_message('e', 'Ocurrio un error al guardar');
                 };

                 var senddata = { q: objpay };

                 fn_callmethod("Review.aspx/Culqui_CreateCharge", JSON.stringify(senddata), success, error);
                 
                 //alert('Se ha creado un token:' + token);
                 //En esta linea de codigo debemos enviar el "Culqi.token.id"
                 //hacia tu servidor con Ajax
             } else { // ¡Hubo algún problema!
                 // Mostramos JSON de objeto error en consola
                 console.log(Culqi.error);
                 alert(Culqi.error.user_message);
             }
         };

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:HiddenField runat="server" ID="hfDataMethodPayment" />
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
			<h1 class="tt-title-subpages noborder">Mis Productos</h1>
			<div class="row">
				<div class="col-sm-12 col-xl-8">
					<div class="tt-shopcart-table">
						<table id="tblCarrito">
						     <thead class="col-sm-12 col-xl-8">
                                <tr>
                                    <th style="text-align:right"></th>
                                    <th style="text-align: right">Producto</th>
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
								<a class="btn-link tt-btn-delete-all" href="#"><input style="display: none" data-page="review-delete-all" data-productid="00"><i class="icon-h-02"></i>LIMPIAR CARRITO DE COMPRAS</a>
							</div>
						</div>
					</div>
				    <br><br>
				    <%--MethodPayment--%>
				    <div class="tt-shopcart-table">
								    <img id="paymentimage" src="http://elcanastonxcorporate.tk/Files/enterprise/methodPay/metodosDePago.jpeg" style="width:25%">
								<br>
								<br>
								    <label for="s_username" style=" font-family: Hind, sans-serif; font-size: 24px; font-weight: bold;" class="col-md-12 font-lato-h4">Seleccione método de pago *</label>
								    <div class="col-md-12">
									   <div id="divCardOptions">
										  <div id="divPayment" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 font-lato-h4" runat="server" clientidmode="static">
										 <%-- <div style="padding: 10px 0;" id="DivMethodPayment">
											 <div style="display: inline-block">
                                                             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="Contra Entrega" style="vertical-align: sub"><input id="" type="radio" name="Payment" data-id="" value="" checked="checked"><label for="">Contra Entrega</label></span>
                                                        </div>
											 <div style="display: inline-block">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="Plin" style="vertical-align: sub"><input id="" type="radio" name="Payment" data-id="" value=""><label for="">Plin</label></span>
                                                        </div>
                                                        <div style="display: inline-block">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="Yape" style="vertical-align: sub"><input id="" type="radio" name="Payment" data-id="" value=""><label for="">Yape</label></span>
                                                        </div>
                                                        <div style="display: inline-block">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="BBVA" style="vertical-align: sub"><input id="" type="radio" name="Payment" data-id="" value=""><label for="">BBVA</label></span>
                                                        </div>
                                                        <div style="display: inline-block">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="BCP" style="vertical-align: sub"><input id="" type="radio" name="Payment" data-id="" value=""><label for="">BCP</label></span>
                                                        </div>
                                                        <div style="display: inline-block">
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="Scotiabank" style="vertical-align: sub"><input id="" type="radio" name="Payment" data-id="" value=""><label for="">Scotiabank</label></span>
                                                        </div>
										  </div>--%>
										  </div>
										  <br />
										   <asp:LinkButton ID="btnGeneratePedido" type="button" CssClass="btn"  runat="server" OnClick="btnPayment_Click" style="font-weight: bold; color:black" hidden>ENVIAR PEDIDO</asp:LinkButton>
									   </div>
								    </div>
					</div>
				    <%--MethodPayment--%>

				      <%--Culqi--%>
                     <%--   <div id="divPay" class="tt-shopcart-table">
                             <div id="message_row"></div>
                            <div>
                                <div class="form-group">
                                    <label for="loginInputName">Correo Electrónico *</label>
                                    <input class="form-control" type="text" size="50" name="email" data-culqi="card[email]" id="card[email]">
                                </div>
                                <div class="form-group">
                                    <label for="loginAPaterno">Número de tarjeta *</label>
                                    <input class="form-control" type="text" size="20" data-culqi="card[number]" id="card[number]">
                                </div>
                                <div class="form-group">
                                    <label for="loginAMaterno">CVV *</label>
                                    <input class="form-control" type="text" size="4" data-culqi="card[cvv]" id="card[cvv]">
                                </div>

                                <div class="form-group">

                                    <label>Fecha expiración (MM/YYYY) </label>
                                    <div class="col-md-2" style="display: inline-flex;">
                                        <input class="form-control" size="2" data-culqi="card[exp_month]" id="card[exp_month]">
                                    </div>
                                    <span>/</span>
                                    <div class="col-md-2" style="display: inline-flex;">
                                        <input class="form-control" size="4" data-culqi="card[exp_year]" id="card[exp_year]">
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-auto">
                                    <div class="form-group">
                                        <button type="submit" id="btn_pagar"  onclick="Fn_ValidateCard(event);"class="btn" style="font-weight: bold; color:black">Pagar</button>
                                    </div>
                                </div>
                            </div>
                        </div>--%>

                 <%--culqi--%>


				</div>
				<div class="col-sm-12 col-xl-4">
					<div class="tt-shopcart-wrapper form-default">
						<div class="tt-shopcart-box">
                                  <a class="icon-f-74" style="font-size: xx-large;">
							   <span  runat="server" style="font-family: Hind, sans-serif; font-size: 24px;">DIRECCIÓN DE ENTREGA</span>
							   <span id="lblAddress1" runat="server" style="font-family: Hind, sans-serif; font-size: 24px; color:#2879fe"></span>
                                  </a>
							<br/>
						    <br/>
								<div class="form-group">
									<label for="address_country">DEPARTAMENTO <sup>*</sup></label>
									<select id="address_country" class="form-control" disabled>
										<option>La Libertad</option>
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
     <asp:HiddenField runat="server" ID="hfData" />
     <asp:HiddenField runat="server" ID="hfPaymentType" />
    
  <%--  <script type="text/x-handlebars-template" id="datatable-shopcart">
        {{# each request}}
            <tr id="item-reviewProduct-{{Product.ProductId}}" class="tt-item tt-item-product-delete-{{Product.ProductId}}">
									<td>
									    <span class="tt-btn-close" style="cursor:pointer"><input style="display:none" data-page="review" data-productid="{{Product.ProductId}}"></span>
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
												<input type="text" value="{{Quantity}}" size="100" data-productid="{{Product.ProductId}}" readonly="readonly">
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
--%>
    <%-- <script type="text/x-handlebars-template" id="datatable-MethodPayment">
	       {{# each request}}
	    <div style="display: inline-block">
           &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="{{MerchantName}}" style="vertical-align: sub"><input id="{{MerchantId}}" type="radio" name="Payment" data-id="{{MerchantId}}" value=""><label for="">Plin</label></span>
         </div>
        <%-- <div style="display: inline-block">
             &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;|&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<span class="rdbPayment" title="{{MerchantName}}" style="vertical-align: sub"><input id="{{MerchantId}}" type="radio" name="Payment" data-id="{{MerchantId}}" checked="checked"><label for="">{{MerchantName}}</label></span>
         </div>
	       {{/each}}
    </script>--%>
</asp:Content>
