﻿'use strict';
let detalleproductoJS = null;


$(function () {

    detalleproductoJS = new DetalleProductoJS("");
    detalleproductoJS.Fn_Iniciar();

   
});

class DetalleProductoJS {

    constructor() {
    }


    Fn_Iniciar() {
        detalleproductoJS.Fn_Cargar();
    
    }

    Fn_Cargar() {
        try {

            let detalleProducto = JSON.parse($("input[id$=_hfProduct]").val());
            if (detalleProducto === undefined || detalleProducto === null || detalleProducto.Datos.length === 0) {
                Fn_Mensaje('e', "Ocurrio un error al cargar detalle de producto.");
            } else {
                if (detalleProducto.Datos.length > 0) {
                    for (var i = 0; i < detalleProducto.Datos.length; i++) {

                        $("#prodNombre").text(detalleProducto.Datos[i].ProductoNombre);
                        $("#prodPrecio").text(detalleProducto.Datos[i].Simbolo + detalleProducto.Datos[i].Precio);
                        $("#prodPrecioAntiguo").text(detalleProducto.Datos[i].Precio);
                        $("#prodPrecioDesc").text(detalleProducto.Datos[i].Precio);
                        $("#prodDescripcionlarga").append(detalleProducto.Datos[i].ProductoDescripcionLarga);
                        $("#prodSku").text(detalleProducto.Datos[i].Sku);
                        $("#prodMarca").text(detalleProducto.Datos[i].MarcaNombre);

                        var ObjectoLista = {};
                        ObjectoLista.ObjetoWithImagePrincipal = detalleProducto.Datos;
                        let htmlImagenPrincipal = Fn_CargarTemplate("handlebarImagenPrincipal", ObjectoLista);
                        $("#prodImagenPrincipal").html(htmlImagenPrincipal);
                        
                    }
                }
                if (detalleProducto.DetalleOferta.length > 0) {
                    for (var i = 0; i < detalleProducto.DetalleOferta.length; i++) {
                        $("#prodPrecioNew").text(detalleProducto.DetalleOferta[i].Simbolo + detalleProducto.DetalleOferta[i].Precio);
                    }
                }
                if (detalleProducto.DetalleImagen.length > 0) {
                    var ObjectoLista = {};
                    ObjectoLista.ObjetoWithListImagen = detalleProducto.DetalleImagen;
                    let htmlDetalleImagen = Fn_CargarTemplate("handlebarListaImagenes", ObjectoLista);
                    $("#thumb-slider").html(htmlDetalleImagen);
                }

               
            }
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }

    }
}