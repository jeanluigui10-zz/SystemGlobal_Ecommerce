<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Informacion.aspx.cs" Inherits="PeruStore.Comercio.Ordenes.Informacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="js/informacion.js?a=2"></script>
    <link href="css/informacion.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="main-container container">
		<ul class="breadcrumb">
			<li><a href="#"><i class="fa fa-home"></i></a></li>
			<li><a href="#">Información de la Orden</a></li>
		</ul>
		
		<div class="row">
		     <div id="contenedor_mensaje"></div>
			<div id="content" class="col-sm-9">
				<h2 class="title">Información</h2>

				<table class="table table-bordered table-hover" id="tbResumen">
					<thead>
						<tr>
							<td colspan="2" class="text-left">Detalle</td>
						</tr>
					</thead>
					<tbody>
					</tbody>
				</table>
				<table class="table table-bordered table-hover" id="tbDireccion">
					<thead>
						<tr>
							<td style="width: 100%; vertical-align: top;" class="text-left">Direccion de envío</td>
						</tr>
					</thead>
					<tbody>
					</tbody>
				</table>
				<div class="table-responsive">
					<table class="table table-bordered table-hover" id="tbDetalle">
						<thead>
							<tr>
								<td class="text-left">Producto</td>
								<td class="text-right">Cantidad</td>
								<td class="text-right">Precio</td>
								<td class="text-right">Total</td>
								<td style="width: 20px;"></td>
							</tr>
						</thead>
						<tbody>
						</tbody>
						<tfoot id="tfMontos">
						</tfoot>
					</table>
				</div>
				<h3>Historico</h3>
				<table class="table table-bordered table-hover" id="tbEstados">
					<thead>
						<tr>
							<td class="text-left">Fecha Orden</td>
							<td class="text-left">Estado</td>
						</tr>
					</thead>
					<tbody>
					</tbody>
				</table>
				<div class="buttons clearfix">
					<div class="pull-right"><a class="btn btn-primary" href="/Comercio/Ordenes/Historico.aspx">Volver</a>
					</div>
				</div>
			</div>
		</div>
	</div>
    <asp:HiddenField ID="hfCabeceraJson" runat="server" />
    <asp:HiddenField ID="hfDetalleJson" runat="server" />
    <asp:HiddenField ID="hfEstadosJson" runat="server" />

    <script type="text/x-handlebars-template" id="cabecera-resumen">
        {{# each cabecera}}
		  <tr>
			 <td style="width: 50%;" class="text-left"> <b>ID Orden:</b> #{{IdOrden}}
				<br>
				<b>Fecha Creación:</b> {{FechaOrden}}</td>
			 <td style="width: 50%;" class="text-left"> <b>Método Pago:</b> {{MetodoPago}}
				<br>
				<b>Tipo Entrega:</b> {{TipoEntrega}} </td>
		  </tr>
        {{/each}}
    </script>


    <script type="text/x-handlebars-template" id="cabecera-direccion">
        {{# each cabecera}}
    		  <tr>
			 <td class="text-left">{{DireccionEntrega}}
				<br><b>Código Postal:</b> {{Zip}}
				<br><b>Distrito / Ciudad:</b> {{Distrito}}
				<br><b>Provincia:</b> {{Provincia}}
				<br><b>Departamento:</b> {{Region}}
		  </tr>
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="cabecera-montos">
        {{# each cabecera}}
		  <tr>
			 <td colspan="2"></td><td class="text-right"><b>Sub-Total</b>
			 </td>
			 <td class="text-right">{{SubTotal}}</td><td></td>
		  </tr>
		  <tr class="tfoot-descuento">
			 <td colspan="2"></td><td class="text-right"><b>Descuento</b>
			 </td>
			 <td class="text-right">{{Descuento}}</td><td></td>
		  </tr>
		  <tr>
			 <td colspan="2"></td><td class="text-right"><b>Envío</b>
			 </td>
			 <td class="text-right">{{DeliveryTotal}}</td><td></td>
		  </tr>
		  <tr>
			 <td colspan="2"></td><td class="text-right"><b>IGV({{PorcentajeImpuesto}}%)</b>
			 </td>
			 <td class="text-right">{{Impuesto}}</td><td></td>
		  </tr>
		  <tr class="tfoot-total">
			 <td colspan="2"></td><td class="text-right"><b>Total</b>
			 </td>
			 <td class="text-right">{{TotalOrden}}</td><td></td>
		  </tr>
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="detalle">
        {{# each Datos}}
		  <tr>
			 <td class="text-left">{{NombreProducto}}</td>
			 <td class="text-right">{{Cantidad}}</td>
			 <td class="text-right">{{Precio}}</td>
			 <td class="text-right">{{Total}}</td>
			 <td style="white-space: nowrap;" class="text-right"> 
				<a class="btn btn-primary" title="" data-toggle="tooltip" data-placement="right" href="#" data-original-title="Volver a Comprar"><i class="fa fa-shopping-cart"></i></a>
			 </td>
		  </tr>
        {{/each}}
    </script>

    <script type="text/x-handlebars-template" id="estados">
        {{# each Datos}}
		  <tr>
			 <td class="text-left">{{FechaRegistro}}</td>
			 <td class="text-left">{{OrdenEstado}}</td>
		  </tr>
        {{/each}}
    </script>


</asp:Content>
