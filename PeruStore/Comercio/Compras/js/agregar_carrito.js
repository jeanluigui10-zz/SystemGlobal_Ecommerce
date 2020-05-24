'use strict';
let agregarCarritoJs = null;

$(function () {
    agregarCarritoJs = new AgregarCarritoJs("./Compras/MiCarrito.aspx/");
    agregarCarritoJs.Fn_Iniciar();
});

class AgregarCarritoJs {

    constructor(metodosPagina) {
        this.urlAgregarCarrito = metodosPagina + "AgregarCarrito";
        this.urlObtenerCarrito = metodosPagina + "ObtenerCarrito";
    }


    Fn_Iniciar() {
        agregarCarritoJs.Fn_Eventos();
    }

    Fn_Eventos() {
        try {

            $(".addToCart").on('click', function (event) {
                agregarCarritoJs.Fn_AgregarCarrito($(this));
            });

        } catch (exception) {
            console.log(exception);
        }
    }

    Fn_AgregarCarrito($btnAgregar) {
        try {
            var _idProductoCifrado = $btnAgregar.attr("data-code");
            var _nombreProducto = $btnAgregar.attr("data-nombre");

            var success = function (objRespuesta) {

                let metodoRespuesta = objRespuesta.d;
                if (metodoRespuesta.CodigoRespuesta === EnumCodigoRespuesta.Exito) {
                    var mensajeHtml = '<h3>¡<strong>' + _nombreProducto + '</strong> agregado al <a href="#" style="text-decoration: underline;">carrito de compras</a>!</h3>';
                    Fn_Success_Notice('Producto agregado al carrito', mensajeHtml);
                    agregarCarritoJs.Fn_DibujarCarrito_Flotante(metodoRespuesta.Datos);
                }
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // agregar alert box aqui
            };

            fn_Ajax(agregarCarritoJs.urlAgregarCarrito, '{ idProductoCifrado: "' + _idProductoCifrado + '"}', success, error);
        } catch (e) {
            // agregar alert box aqui
            console.log(exception);
        }
    }

    Fn_DibujarCarrito_Flotante(ordenCabecera) {
        try {
            // organizar data aqui
            if (ordenCabecera !== undefined && ordenCabecera !== null) {
                let detalleLista = { Datos: ordenCabecera.OrdenDetalleLista };
                var detalleHtml = Fn_CargarTemplate('orden-detalle', detalleLista);

                $("#tbDetalle tbody").html(detalleHtml);

                $("#tdTotal").html(ordenCabecera.Total);
                $(".items_cart").html(ordenCabecera.OrdenDetalleLista.length);
            }

        } catch (exception) {
            console.log(exception);
        }
    }


}