<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="Historico.aspx.cs" Inherits="SystemGlobal_Ecommerce.Comercio.Ordenes.Historial" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="js/historico.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
	<div class="main-container container">
		<ul class="breadcrumb">
			<li><a href="/Comercio/Inicio.aspx"><i class="fa fa-home"></i></a></li>
			<li><a href="/Comercio/Ordenes/Historial.aspx">Historial de Ordenes</a></li>
		</ul>
		<div class="row">
		     <div id="contenedor_mensaje"></div>
			<div id="content" class="col-sm-9">
				<h2 class="title">Historial de Ordenes</h2>
				<div class="table-responsive">
					<table class="table table-bordered table-hover">
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

    <script type="text/x-handlebars-template" id="datatable-products">
        {{# each items}}
           <tr>
			<td></td>

           </tr>
        {{/each}}
    </script>

</asp:Content>
