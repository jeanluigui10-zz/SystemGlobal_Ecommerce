<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="SystemGlobal_Ecommerce.Layout.Support.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../../Content/bootstrap.css" rel="stylesheet" />
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?sensor=false"></script>    
    <script src="../../Files/js/map-init.js"></script>
    <script src="../../Files/external/panelmenu/panelmenu.js"></script>

    <script src="../../Files/external/form/jquery.form-init.js"></script>

	<script type="text/javascript">
       
        $(function () {
           
        });
       
        function Fn_ValidateInformation() {

            if (!fn_validateform('divInformation')) {
                event.preventDefault();
                return false;
            }
          
            obj = {
                    FirstName: $("input[id$=txtNombre]").val().trim(),
					CellPhone: $("input[id$=txtTelefono]").val().trim(),
					Email: $("input[id$=txtCorreo]").val().trim(),
					Subject: $("input[id$=txtAsunto]").val().trim(),
	                Message: $("textarea[id$=txtMensaje]").val()
                }

            var success = function (asw) {

                if (asw != null) {
                        if (asw.d.Result == "Ok") {
                            $("#modalConfirmacion").modal('show');
                            Fn_Limpiar();
                        } 
                        else {
                            fn_message("e", asw.d.Msg);
                        }
                }
            }

            var error = function (xhr, ajaxOptions, thrownError) {
                fn_message('e', 'A ocurrido un error en el guardado de los datos.');
            };
            
            var data = { obj: obj };
            fn_callmethod("Contact.aspx/Customer_Subject", JSON.stringify(data), success, error);
        }
          
        function Fn_Limpiar() {
            $("input[id$=txtNombre]").val("");
            $("input[id$=txtCorreo]").val("");
            $("input[id$=txtAsunto]").val("");
            $("input[id$=txtTelefono]").val("");
            $("textarea[id$=txtMensaje]").val("");
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

	<!-- stuck nav -->
	<div class="tt-stuck-nav">
		<div class="container">
			<div class="tt-header-row ">
				<div class="tt-stuck-parent-menu"></div>
				<div class="tt-stuck-parent-search tt-parent-box"></div>
				<div class="tt-stuck-parent-cart tt-parent-box"></div>
				<div class="tt-stuck-parent-account tt-parent-box"></div>
				<div class="tt-stuck-parent-multi tt-parent-box"></div>
			</div>
		</div>
	</div>

<div class="tt-breadcrumb">
	<div class="container">
		<ul>
			<li><a href="/Index.aspx">Mickypepa</a></li>
			<li>Contáctanos</li>
		</ul>
	</div>
</div>
<div id="message_row"></div>
<div id="tt-pageContent">
	<div class="container-indent" style="display:none">
		<div class="container">
			<div class="contact-map">
				<div id="map"></div>
			</div>
		</div>
	</div>
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
			<div class="tt-contact02-col-list">
				<div class="row">
					<div class="col-sm-12 col-md-4 ml-sm-auto mr-sm-auto">
						<div class="tt-contact-info">
							<i class="tt-icon icon-f-93"></i>
							<h6 class="tt-title">TENEMOS UN CHAT!</h6>
							<address id="lblContactPhone" runat="server">
								+777 2345 7885:<br>
								+777 2345 7886
							</address>
						</div>
					</div>
					<div class="col-sm-6 col-md-4">
						<div class="tt-contact-info">
							<i class="tt-icon icon-f-24"></i>
							<h6 class="tt-title">VISITA NUESTRA UBICACIÓN</h6>
							<address id="lblContactAddress" runat="server">
								Actualmente no esta disponible por el covid-19<br>
							</address>
						</div>
					</div>
					<div class="col-sm-6 col-md-4">
						<div class="tt-contact-info">
							<i class="tt-icon icon-f-92"></i>
							<h6 class="tt-title">HORARIO DE ATENCIÓN</h6>
							<address id="lblContactAttentionHours" runat="server">
								7 Dias a la semana<br>
								de 10 AM a 6 PM
							</address>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>
	<div class="container-indent">
		<div class="container container-fluid-custom-mobile-padding">
				<div class="row" id="divInformation">
					<div class="col-md-6">
						<div class="form-group">
							<input type="text" name="name"   class="form-control validate[required,custom[onlyLetterSp]]" id="txtNombre" runat="server" placeholder="Ingrese su Nombre">
						</div>
						<div class="form-group">
							<input type="text" name="phone"   class="form-control validate[required,custom[onlyNumberSp]]" id="txtTelefono" runat="server" placeholder="Ingrese su Teléfono">
						</div>
						<div class="form-group">
							<input type="text" name="email"  class="form-control validate[required]" runat="server" id="txtCorreo" placeholder="Ingrese su Correo">
						</div>
						<div class="form-group">
							<input type="text" name="name"   class="form-control validate[required]" id="txtAsunto" runat="server" placeholder="Asunto">
						</div>
					</div>
					<div class="col-md-6">
						<div class="form-group">
							<textarea rows="7" name="name"   class="form-control validate[required]" id="txtMensaje" runat="server" placeholder="Ingrese su mensaje"></textarea>
						</div>
					</div>
				</div>
				<div class="text-center">
					<button type="button" id="btnEnviar"  class="btn" onclick="Fn_ValidateInformation(event);">Enviar Mensaje</button>
				</div>
		</div>
	</div>
</div>
	<!-- Modal -->
<div class="modal fade" id="modalConfirmacion" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
  <div class="modal-dialog modal-footer" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLongTitle">Mensaje Enviado</h5>
        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
          <span aria-hidden="true">&times;</span>
        </button>
      </div>
      <div class="modal-body" style="color:forestgreen">
        Se envio correctamente, nos comunicaremos contigo en menos de 24 Horas!
      </div>
    </div>
  </div>
</div>

</asp:Content>
