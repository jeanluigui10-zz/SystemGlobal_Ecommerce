<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="PeruStore.Comercio.Ordenes.Historico" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/historico.js?a=1"></script>
    <link rel="stylesheet" href="css/historico.css?a=1"/>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="main-container container contenedor-historico">
		<ul class="breadcrumb">
			<li><a href="/Comercio/Inicio.aspx"><i class="fa fa-home"></i></a></li>
			<li><a href="/Comercio/Ordenes/Historico.aspx">Historial de Ordenes</a></li>
		</ul>
		<div class="row">
		     <div id="contenedor_mensaje"></div>
			<div id="content" class="col-sm-9">
				<h2 class="title">Historial de Ordenes</h2>
				<div class="table-responsive">
					<table class="table table-bordered table-hover" id="tbHistorico">
						<thead>
							<tr>
								<td class="text-center">ID Orden</td>
								<td class="text-center">Cant.</td>
								<td class="text-center">Estado</td>
								<td class="text-center">Fecha Orden</td>
								<td class="text-right">Total</td>
								<td></td>
							</tr>
						</thead>
						<tbody>
						</tbody>
					</table>
				</div>
			</div>
		</div>
	</div>

    <asp:HiddenField ID="hfOrdenHistorico" runat="server" />

    <script type="text/x-handlebars-template" id="historico-template">
        {{# each Datos}}
           <tr>
			<td class="text-center">{{IdOrden}}</td>
			<td class="text-center">{{Cantidad}}</td>
			<td class="text-center">{{Estado}}</td>
			<td class="text-center">{{FechaOrden}}</td>
			<td class="text-right">{{TotalOrden}}</td>
		    <td class="text-center"><a class="btn btn-info" title="" data-toggle="tooltip" href="/Comercio/Ordenes/Informacion.aspx?o={{IdOrdenCifrado}}" data-original-title="Ver Detalle"><i class="fa fa-eye"></i></a>
           </tr>
        {{/each}}
    </script>

</asp:Content>
