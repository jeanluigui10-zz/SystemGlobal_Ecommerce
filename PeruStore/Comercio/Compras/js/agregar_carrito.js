'use strict';
let agregarCarritoJs = null;

$(function () {
    agregarCarritoJs = new AgregarCarritoJs("~/Comercio/Compras/MiCarrito.aspx/");
    agregarCarritoJs.Fn_Iniciar();
});

class AgregarCarritoJs {

    constructor(metodosPagina) {
        this.urlAgregarCarrito = metodosPagina + "AgregarCarrito";
    }


    Fn_Iniciar() {
        agregarCarritoJs.Fn_Eventos();
    }

    Fn_Eventos() {
        try {

            $(".addToCart").on('click', function (event) {



            });

        } catch (exception) {
            //Fn_Mensaje('e', 'No se pudo agregar al carrito.');
            console.log(exception);
        }
    }




}