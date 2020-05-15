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
            if (detalleProducto === undefined || detalleProducto === null) {
            } else {
            }

        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

}