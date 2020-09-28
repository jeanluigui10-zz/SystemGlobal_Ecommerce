<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Review.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Review" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <!-- Incluyendo .js de Culqi JS -->
    <script src="https://checkout.culqi.com/js/v3"></script>
   <%-- <script>Culqi.publicKey = 'pk_test_e10ed06809bfa78c' </script>--%>
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
     <script type="text/javascript">
	    $(function () {
             Fn_ValidatePay(); 
	    });

         function Fn_ValidatePay() {
             $("#BtnOpenPay").on("click", function (e) {

                 var success = function (asw) {
				 if (asw.d.Result == "Ok") {
					var objPay = JSON.parse(asw.d.objPaymentInfo);
					Culqi.publicKey = objPay.Public_Key;

					Culqi.settings({
					    title: objPay.StoreName,
					    currency: objPay.Currency,
					    description: objPay.CustomerName,
					    amount: objPay.OrderTotal
					});

					Culqi.options({
					    style: {
						   logo: objPay.Logo
					    }
					});

					Culqi.open();
					e.preventDefault();
					//alert(objPay.outcome.user_message);
				 } else {
					if (asw.d.Result == "NoOk") {
                             fn_message("i", asw.d.Msg);
					}
				 }
                 };
                 var error = function (xhr, ajaxOptions, thrownError) {
                     console.log(Culqi.error);
                     alert(Culqi.error.user_message);
                 };

                 fn_callmethod("Review.aspx/OpenPay", "", success, error);
            });
          }

         function culqi() {
             if (Culqi.token) { // ¡Objeto Token creado exitosamente!
			  var token = Culqi.token.id;
                 var pay_email = Culqi.token.email;
                 objpayinfo = {
				 token_created: token,
                     email: pay_email
                  }
                 var success = function (asw) {
				 if (asw != null) {
					var objPay = JSON.parse(asw.d);
					if (objPay.object == "charge") {
					    fn_message("s", objPay.outcome.user_message);
					} else {
                             fn_message("i", objPay.user_message);
					}
                     }
                 };
			  var error = function (xhr, ajaxOptions, thrownError) {
                     console.log(Culqi.error);
                     alert(Culqi.error.user_message);
                 };

                 var senddata = { q: objpayinfo };

                 fn_callmethod("Review.aspx/Culqui_CreateCharge", JSON.stringify(senddata), success, error);
                 
                 //alert('Se ha creado un token:' + token);
                 //En esta linea de codigo debemos enviar el "Culqi.token.id"
                 //hacia tu servidor con Ajax
             } else { // ¡Hubo algún problema!
                 // Mostramos JSON de objeto error en consola
                 console.log(Culqi.error);
                 alert(Culqi.error.user_message);
             }
         }

     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Mickypepa</a></li>
			<li>Productos Seleccionados</li>
		</ul>
	</div>
</div>

<div id="tt-pageContent">
	<div class="container-indent">
		<div class="container">
			<h1 class="tt-title-subpages noborder">Mis Productos</h1>
		     <div id="message_row"></div>
			<div class="row">
				<div class="col-sm-12 col-xl-8">
					<div class="tt-shopcart-table">
						<table id="tblCarrito">
				      <thead>
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
                            
								<br>
								<br>
<%--								    <label for="s_username" style=" font-family: Hind, sans-serif; font-size: 24px; font-weight: bold;" class="col-md-12 font-lato-h4">Seleccione método de pago *</label>--%>
								    <div class="col-md-12">
									   <div id="divCardOptions">
										  <div id="divPayment" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 font-lato-h4" runat="server" clientidmode="static">
									
										  </div>
										  <br />
										   <%--<asp:LinkButton ID="btnGeneratePedido" type="button" CssClass="btn"  runat="server" OnClick="btnPayment_Click" style="font-weight: bold; color:black" hidden>ENVIAR PEDIDO</asp:LinkButton>--%>
										 <button id="BtnOpenPay" type="button" class="mb-xs mt-xs mr-xs btn btn-lg btn btn-border" hidden >Ir a pagar</button>
<%--										  <asp:Button ID="BtnOpenPay" runat="server" class="mb-xs mt-xs mr-xs btn btn-lg btn btn-border" Text="Ir a pagar" hidden />--%>
								   <%-- <img id="paymentimage" src="../Files/images/slides/01/metodosDePago.jpeg" style="width:25%; margin-left:50%">--%>
									   </div>
								    </div>
					</div>
				    <%--MethodPayment--%>

				</div>
				<div class="col-sm-12 col-xl-4" style="background: #e9eaea;">
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
								</div>
								
						</div>
					
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

</asp:Content>
