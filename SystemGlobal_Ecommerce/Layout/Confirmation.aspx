<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Confirmation.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Confirmation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

 <style type="text/css">
	    .font-lato-h4 {
    color: #7e7e7e !important;
    font-size: 18px;
    font-weight: bold !important;
 }

    </style>
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
             $("#SearchIdMaster").attr("hidden", true);
             Fn_ListProductsShopCart($("#<%=hfData.ClientID%>").val());    
             Fn_Get_MessageWhatsapp($("#<%=hfData.ClientID%>").val());
         }

         function Fn_Get_MessageWhatsapp(data) {
             var glancedata = data;
             try {
                 obj = $.parseJSON(glancedata);
                 
                 if (obj != "" || obj != undefined) {
                     var messagewsp = "https://api.whatsapp.com/send?phone=51989659008&text=Hola tienda 'El Canastón' 🏪 acabo de hacer mi pedido! Mi nombre es " + obj.CustomerName.toString() + " 👦 👩 y Mi Orden es N° " + obj.LegacyNumber.toString() +". Mis productos son ";
                    
                     var messagewsp2 = "";
                     var count = 0;
                     if (obj.Detail != null) {
                         for (var i = 0; i < obj.Detail.length; i++) {
                             count++
                             //messagewsp2 += ' PRODUCTO '+ count +': (' + obj.Detail[i].Product.ProductName + "," + obj.Detail[i].Quantity + "," + "S/." + obj.Detail[i].TotalPrice.toFixed(2) + ') || ';   
                             messagewsp2 += '🍗PRODUCTO '+ count +': (' + " Nombre: "+ obj.Detail[i].Product.ProductName + "," + " Cantidad: " + obj.Detail[i].Quantity +') || ';   
                         }
                         var AddressCustomer = " 💒 Mi dirección es " + obj.AddressCustomer;
                         var PaymentTypeName = " 💰 y pagaré mediante " + obj.PaymentTypeName;
                         var thanks = " ...Gracias! "
                     }
                     var wspMessageGlobal = messagewsp + messagewsp2 + AddressCustomer + PaymentTypeName + thanks;
                     $("#WhatsappTextId").attr("href", wspMessageGlobal);
                 } 
             }
             catch (e) {
                 fn_message('e', 'An error occurred while loading data...');
             }
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
             //$(".tt-cart-total-price").text("S/." + obj.SubTotal);
             $("#idSubTotalRight").text("S/." + obj.SubTotal);
             $("#idDeliveryTotalRight").text("S/." + obj.DeliveryTotal);
             $("#idTotalRigth").text("S/." + obj.Ordertotal);
             $("#idPaymentTypeName").text(obj.PaymentTypeName);
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
			<h1 class="tt-title-subpages noborder" id="lblMessageConfirm" runat="server" style="font-size: x-large;font-weight: bold;color: green; text-transform: uppercase;"></h1>
		     <div id="" class="font-lato-h4">
                                 <p>
                                     Se ha creado una orden para
                                     <span id="lblFullName" runat="server" style="text-transform: uppercase"></span>
                                 </p>
                                 <p style="margin:8px 0 0 0px">
                                     <span>Tu orden se ha completado.</span>
                                 </p>
                                 <p style="margin: 8px 0 0 0px">
                                     Si deseas también envianos un Whatssap de tu pedido:
                                      <img border="0" alt="whatsapp" src="https://rawcdn.githack.com/rafaelbotazini/floating-whatsapp/3d18b26d5c7d430a1ab0b664f8ca6b69014aed68/whatsapp.svg" width="80" height="80" style="border-radius:50%">
                                     <a id="WhatsappTextId" class="btn btn-primary" target="_blank" style="background: #01e675; font-weight: bold; margin-left:1%">Enviar Whatsapp!</a>
                                     
                                 </p>
                                 <p style="margin:8px 0 0 0px">
                                     <h3 style="font-weight: 400;" class="heading" id="lblLegacyNumber" runat="server"></h3>
                                 </p>
                               
                             </div>
              <div class="row">
				<div class="col-sm-12 col-xl-8">
					<div class="tt-shopcart-table">
                            
						<table id="tblCarrito">
                                   <thead class="col-sm-12 col-xl-8">
                                <tr>
                                    <th style="text-align:right"></th>
                                    <th style="text-align:right">Producto</th>
                                    <th style="text-align:right"></th>
                                    <th style="text-align: left !important;">Precio</th>
                                    <th style="text-align:right">Cantidad</th>
                                    <th style="text-align: center !important;">Subtotal</th>
							 <th style="text-align:center"></th>
                                </tr>
                            </thead>
							<tbody id="tblBodyTableConfirm" style="background: whitesmoke;">
								
							</tbody>
						</table>
						
					</div>
				</div>
				<div class="col-sm-12 col-xl-4">
				    <div class="tt-shopcart-wrapper form-default" style="border: 10px solid rgb(220, 220, 220);">
                        <h2 style="padding: 0% 0;font-size: 24px;line-height: 0px;font-weight: bold;font-family: sans-serif;">Orden Recibida</h2>
                        <div class="tt-shopcart-box tt-boredr-large">
                            <div id="ContentPlaceHolder1_ContentPlaceHolder3_div_payment_card" class="span4">
                                <p>
                                    <strong class="muted" style="font-weight: bold;">Detalle de la orden </strong>
                                    <br>
                                </p>
						  <div style="margin: 0;color: #727478;font-size: 13px;padding-left: 10px;">SubTotal: 
							 <span id="idSubTotalRight" style="float: right;"></span>
						  </div>
						  <div style="margin: 0;color: #727478;font-size: 13px;padding-left: 10px;">Delivery : 
							 <span id="idDeliveryTotalRight" style="float: right;"></span>
						  </div>
						  <div style="margin: 0;color: #727478;font-size: 13px;padding-left: 10px;">Monto Total : 
							 <span id="idTotalRigth" style="float: right;"></span>
						  </div>
                                <div style="margin: 0;color: #727478;font-size: 13px;padding-left: 10px;">Método de Pago seleccionado : 
							 <span id="idPaymentTypeName" style="float: right;"></span>
						  </div>
                                 <div style="margin: 0;color: #727478;font-size: 13px;padding-left: 10px;">Método de Envío : 
							 <span style="float: right;">Estándar</span>
						  </div>
                            </div>
					   
                            <div class="span4">
                                <p><strong class="muted" style="font-weight: bold;" >Dirección de Entrega</strong></p>
                                <address  id="lblAddressConfirm" runat="server"></address>
                            </div>
                            <div class="span4">
                                <p><strong class="muted" style="font-weight: bold;">Cliente</strong></p>
                                <address id="lblFullNameCustomer" runat="server"></address>
                            </div>
                             <div class="span4">
                                <p><strong class="muted" style="font-weight: bold;">DNI</strong></p>
                                <address id="lblDNI" runat="server"></address>
                            </div>
                             <div class="span4">
                                <p><strong class="muted" style="font-weight: bold;">Teléfono</strong></p>
                                <address id="lblPhoneNumber" runat="server"></address>
                            </div>
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
											<a href="#">{{Product.ProductName}}</a>											
										</h2>
                                                 <h2 class="tt-title" style="color: #617aa4;font-size: 14px;">
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
									<td style="text-align:center !important">
										<div class="tt-price subtotal" id="idSubTotalProduct_{{Product.ProductId}}">
											S/.{{TotalPrice}}
										</div>
									</td>
								</tr>
        {{/each}}
    </script>


</asp:Content>
