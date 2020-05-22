<%@ Page Title="" Language="C#" MasterPageFile="~/HomePage.Master" AutoEventWireup="true" CodeBehind="ClienteRegistro.aspx.cs" Inherits="PeruStore.AdminCliente.ClienteRegistro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
	<!-- Main Container  -->
	<div class="main-container container">
		<ul class="breadcrumb">
			<li><a href="#"><i class="fa fa-home"></i></a></li>
			<li><a href="#">Cuenta</a></li>
			<li><a href="#">Registro</a></li>
		</ul>
		
	     <div id="divMensaje"></div>
		<div class="row">
			<div id="content" class="col-sm-12">
				<h2 class="title">Registrar Cuenta</h2>
				<p>Si ya tiene una cuenta con nosotros, inicie sesión en la página de <a href="#">Inicio de sesión</a>.</p>
				<div class="form-horizontal account-register clearfix">
					<fieldset id="account">
						<legend>Datos Personales</legend>
						<div class="form-group required" style="display: none;">
							<label class="col-sm-2 control-label">Customer Group</label>
							<div class="col-sm-10">
								<div class="radio">
									<label>
										<input type="radio" name="customer_group_id" value="1" checked="checked"> Default
									</label>
								</div>
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtNombreCliente">Nombres</label>
							<div class="col-sm-10">
								<input type="text" name="Nombres" value="" placeholder="Nombres" id="txtNombreCliente" class="form-control">
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtApellPaterno">Apellido Paterno</label>
							<div class="col-sm-10">
								<input type="text" name="Apellido Paterno" value="" placeholder="Apellido Paterno" id="txtApellPaterno" class="form-control">
							</div>
						</div>
                             <div class="form-group required">
							<label class="col-sm-2 control-label" for="txtApellMaterno">Apellido Materno</label>
							<div class="col-sm-10">
								<input type="text" name="Apellido Materno" value="" placeholder="Apellido Materno" id="txtApellMaterno" class="form-control">
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtCorreo">Correo Electrónico</label>
							<div class="col-sm-10">
								<input type="email" name="Correo Electrónico" value="" placeholder="Ejemplo: noah@mail.com " id="txtCorreo" class="form-control">
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtCelular">Celular</label>
							<div class="col-sm-10">
								<input type="text" name="Celular" value="" placeholder="Celular" id="txtCelular" class="form-control input-number" maxlength="9">
							</div>
						</div>
					    <div class="form-group">
							<label class="col-sm-2 control-label" for="txtTelefono">Teléfono</label>
							<div class="col-sm-10">
								<input type="text" name="Teléfono" value="" placeholder="Teléfono" id="txtTelefono" class="form-control input-number" maxlength="9">
							</div>
						</div>
					</fieldset>

					<fieldset id="address">
						<legend>Dirección</legend>						
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtDireccionPrincipal">Dirección Principal</label>
							<div class="col-sm-10">
								<input type="text" name="Dirección_1" value="" placeholder="Dirección Principal" id="txtDireccionPrincipal" class="form-control">
							</div>
						</div>
						<div class="form-group">
							<label class="col-sm-2 control-label" for="txtDireccionSecundaria">Dirección Secundaria</label>
							<div class="col-sm-10">
								<input type="text" name="Dirección_2" value="" placeholder="Dirección Secundaria" id="txtDireccionSecundaria" class="form-control">
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="ddlRegion">Region</label>
							<div class="col-sm-10">
								<select name="region" id="ddlRegion" class="form-control">
									
								</select>
							</div>
						</div>
					    <div class="form-group required">
							<label class="col-sm-2 control-label" for="ddlProvincia">Provincia</label>
							<div class="col-sm-10">
								<select name="provincia" id="ddlProvincia" class="form-control">
									
								</select>
							</div>
						</div>
					    <div class="form-group required">
							<label class="col-sm-2 control-label" for="ddlDistrito">Distrito</label>
							<div class="col-sm-10">
								<select name="distrito" id="ddlDistrito" class="form-control">
									
								</select>
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtCodigoPostal">Código Postal</label>
							<div class="col-sm-10">
								<input type="text" name="Codigo Postal" value="" placeholder="Ejemplo: 06000" id="txtCodigoPostal" class="form-control input-number" maxlength="5" >
							</div>
						</div>
						
					</fieldset>

					<fieldset>
						<legend>Password</legend>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtContrasenha">Password</label>
							<div class="col-sm-10">
								<input type="password" name="Contrasenha" value="" placeholder="Password" id="txtContrasenha" class="form-control">
							</div>
						</div>
						<div class="form-group required">
							<label class="col-sm-2 control-label" for="txtContrasenhaConfirm">Confirmación de Password</label>
							<div class="col-sm-10">
								<input type="password" name="Contrasenhaconfirm" value="" placeholder="Confirmación de Password" id="txtContrasenhaConfirm" class="form-control">
							</div>
						</div>
					</fieldset>
				     <div class="center">
							<input type="button" value="Registrar" class="btn btn-primary" id="btnRegistrarCliente">
					</div>				    
				</div>
			</div>
		</div>
	</div>
	<!-- //Main Container -->

    <style type="text/css"> 
	   div.center {
		  text-align: center;
	   }
    </style>
    <script src="js/ClienteRegistro.js"></script>

</asp:Content>
