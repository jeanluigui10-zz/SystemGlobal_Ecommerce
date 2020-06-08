<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCarritoPrincipal.ascx.cs" Inherits="PeruStore.Controles.Compras.ucCarritoPrincipal" %>
<table class="table table-bordered" id="tbDetallePrincipal">
    <thead>
        <tr>
        <td class="text-center">Imagen</td>
        <td class="text-left">Nombre del Producto</td>
        <td class="text-left">Código</td>
        <td class="text-left">Cantidad</td>
        <td class="text-right">Precio Unitario</td>
        <td class="text-right">Total</td>
        </tr>
    </thead>
    <tbody>
    </tbody>
</table>
<div class="cart-total-amounts">
    <div class="col-sm-6 col-sm-offset-6">
        <table class="table table-bordered">
            <tbody>
                <tr>
                    <td class="text-right">
                        <strong>Subtotal:</strong>
                    </td>
                    <td class="text-right">$168.71</td>
                </tr>
                <tr>
                    <td class="text-right">
                        <strong>Envío:</strong>
                    </td>
                    <td class="text-right">$4.69</td>
                </tr>
                <tr>
                    <td class="text-right">
                        <strong>Impuesto (18%):</strong>
                    </td>
                    <td class="text-right">$5.62</td>
                </tr>
                <tr>
                    <td class="text-right">
                        <strong>Descuento:</strong>
                    </td>
                    <td class="text-right">$4.69</td>
                </tr>
                <tr>
                    <td class="text-right">
                        <strong>Total:</strong>
                    </td>
                    <td class="text-right">$213.70</td>
                </tr>
            </tbody>
        </table>
    </div>
</div>
<asp:HiddenField ID="hfEsCarritoPrincipal" runat="server" Value="1" />
<script type="text/x-handlebars-template" id="orden-detalleprincipal">
    {{# each Datos}}  
	   <tr data-code="{{IdProductoCifrado}}" data-nombre="{{ProductoNombre}}">
	   <td class="text-center"><a href="#"><img style="width:70px;" src="{{NombreRecurso}}" title="{{ProductoNombre}}" class="img-thumbnail" /></a></td>
	   <td class="text-left" style="max-width:250px;">
		  <a href="#">{{ProductoNombre}}</a>
	   </td>
	   <td class="text-left">{{ProductoCodigo}}</td>
	   <td class="text-left" style="width:200px;"><div class="input-group btn-block quantity">
		  <input type="text" value="{{Cantidad}}" class="form-control input-number inputQuantity" maxlength="4" />
		  <span class="input-group-btn">
		  <button type="button" data-toggle="tooltip" title="Actualizar" class="btn btn-primary updateCart"><i class="fa fa-clone"></i></button>
		  <button type="button" data-toggle="tooltip" title="Remover" class="btn btn-danger removeDetail" onClick=""><i class="fa fa-times-circle"></i></button>
		  </span></div></td>
	   <td class="text-right">{{Precio}}</td>
	   <td class="text-right">{{Total}}</td>
	   </tr> 
    {{/each}}
</script>