'use strict';
let agregarCarritoJs = null;

$(function () {
    agregarCarritoJs = new AgregarCarritoJs("/Comercio/Compras/MiCarrito.aspx/");
    agregarCarritoJs.Fn_Iniciar();
});

class AgregarCarritoJs {

    constructor(metodosPagina) {
        this.urlAgregarCarrito = metodosPagina + "AgregarCarrito";
        this.urlObtenerCarrito = metodosPagina + "ObtenerCarrito";
    }


    Fn_Iniciar() {
        agregarCarritoJs.Fn_Eventos();
        agregarCarritoJs.Fn_ObtenerCarrito();
    }

    Fn_Eventos() {
        try {

            $(".addToCart").on('click', function (event) {
                agregarCarritoJs.Fn_AgregarCarrito($(this));
            });

        } catch (exception) {
            // agregar alert aqui
        }
    }

    Fn_AgregarCarrito($btnAgregar) {
        try {
            $btnAgregar.addClass("loading");

            var _idProductoCifrado = $btnAgregar.attr("data-code");
            var _nombreProducto = $btnAgregar.attr("data-nombre");
            
            var success = function (objRespuesta) {

                let metodoRespuesta = objRespuesta.d;
                if (metodoRespuesta.CodigoRespuesta === EnumCodigoRespuesta.Exito) {
                    var mensajeHtml = '<h3>¡<strong>' + _nombreProducto + '</strong> agregado al <a href="#" style="text-decoration: underline;">carrito de compras</a>!</h3>';
                    Fn_Success_Notice('Producto agregado al carrito', mensajeHtml);
                    agregarCarritoJs.Fn_ObtenerCarrito();
                }
                $btnAgregar.removeClass("loading");
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // agregar alert box aqui
                $btnAgregar.removeClass("loading");
            };

            fn_Ajax(agregarCarritoJs.urlAgregarCarrito, '{ idProductoCifrado: "' + _idProductoCifrado + '"}', success, error);
        } catch (e) {
            // agregar alert box aqui
            $btnAgregar.removeClass("loading");
        }
    }

    Fn_ObtenerCarrito() {
        try {

            var success = function (objRespuesta) {
                let ordenCabecera = objRespuesta.d;
                if (ordenCabecera !== null && ordenCabecera !== undefined) {
                    agregarCarritoJs.Fn_DibujarCarrito_Flotante(ordenCabecera.Datos);
                }
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // agregar alert box aqui
            };

            fn_Ajax(agregarCarritoJs.urlObtenerCarrito, '{}', success, error);
        } catch (e) {
            // agregar alert box aqui
        }
    }


    Fn_DibujarCarrito_Flotante(ordenCabecera) {
        try {
            // organizar data aqui
            if (ordenCabecera !== undefined && ordenCabecera !== null) {
                let detalleLista = { Datos: ordenCabecera.OrdenDetalle };
                var detalleHtml = Fn_CargarTemplate('orden-detalle', detalleLista);

                $("#tbDetalle tbody").html(detalleHtml);

                $("#tdTotal").html(ordenCabecera.Total);
                $(".items_cart").html(ordenCabecera.Articulos);
                $("#lblmonto").html(ordenCabecera.Total);

                $(".cart-options2").removeClass("hidden");
                $(".cart-options1").addClass("hidden");
            }

        } catch (exception) {
            console.log(exception);
        }
    }


}