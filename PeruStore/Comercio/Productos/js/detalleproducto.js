'use strict';
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
            if (detalleProducto === undefined || detalleProducto === null || detalleProducto.Datos.length == 0) {
                Fn_Mensaje('e', "Ocurrio un error al cargar detalle de producto.");
            } else {
                for (var i = 0; i < detalleProducto.Datos.length; i++) {
                    $("#prodnombre").text(detalleProducto.Datos[i].Productonombre);
                    $("#prodprecio").text("S/." + detalleProducto.Datos[i].Precio);
                    $("#proddescripcionlarga").text("detalleProducto.Datos[i].ProductoDescripcionLarga");
                }
            }

        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

}