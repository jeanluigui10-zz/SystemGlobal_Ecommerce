'use strict';
let agregarCarritoJs = null;

$(function () {
    agregarCarritoJs = new AgregarCarritoJs("/Comercio/Compras/MiCarrito.aspx/");
    agregarCarritoJs.Fn_Iniciar();
});

class AgregarCarritoJs {

    constructor(metodosPagina) {
        this.urlAgregarDetalle = metodosPagina + "AgregarDetalle";
        this.urlObtenerOrden = metodosPagina + "ObtenerOrden";
        this.urlRemoverDetalle = metodosPagina + "RemoverDetalle";
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

            $("#tbDetalleFlotante").on('click', '.removeItemFlotante', function (event) {
                agregarCarritoJs.Fn_RemoverDetalle($(this).closest("tr"));
            });

        } catch (exception) {
            // agregar alert aqui
        }
    }

    Fn_AgregarCarrito($btnAgregar) {
        try {
            $btnAgregar.addClass("loading").addClass("disabled");

            var _idProductoCifrado = $btnAgregar.attr("data-code");
            var _nombreProducto = $btnAgregar.attr("data-nombre");

            var success = function (objRespuesta) {

                let metodoRespuesta = objRespuesta.d;
                if (metodoRespuesta.CodigoRespuesta === EnumCodigoRespuesta.Exito) {
                    var mensajeHtml = '<h3>¡<strong>' + _nombreProducto + '</strong> agregado al <a href="#" style="text-decoration: underline;">carrito de compras</a>!</h3>';
                    Fn_Success_Notice('Producto agregado al carrito', mensajeHtml);
                    agregarCarritoJs.Fn_ObtenerCarrito();
                }
                $btnAgregar.removeClass("loading").removeClass("disabled");
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // agregar alert box aqui
                $btnAgregar.removeClass("loading").removeClass("disabled");
            };

            fn_Ajax(agregarCarritoJs.urlAgregarDetalle, '{ idProductoCifrado: "' + _idProductoCifrado + '"}', success, error);
        } catch (e) {
            // agregar alert box aqui
            $btnAgregar.removeClass("loading").removeClass("disabled");
        }
    }

    Fn_ObtenerCarrito() {
        try {

            var success = function (objRespuesta) {
                let ordenCabecera = objRespuesta.d;
                if (ordenCabecera !== null && ordenCabecera !== undefined) {
                    agregarCarritoJs.Fn_Dibujar_CarritoFlotante(ordenCabecera.Datos);
                    agregarCarritoJs.Fn_Dibujar_CarritoPrincipal(ordenCabecera.Datos);
                }
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // agregar alert box aqui
            };

            fn_Ajax(agregarCarritoJs.urlObtenerOrden, '{}', success, error);
        } catch (e) {
            // agregar alert box aqui
        }
    }

    Fn_Dibujar_CarritoFlotante(ordenCabecera) {
        try {
            // organizar data aqui
            if (ordenCabecera !== undefined && ordenCabecera !== null) {

                if (ordenCabecera.OrdenDetalle.length > 0) {
                    let detalleLista = { Datos: ordenCabecera.OrdenDetalle };
                    var detalleHtml = Fn_CargarTemplate('orden-detalle', detalleLista);

                    $("#tbDetalleFlotante tbody").html(detalleHtml);
                    $(".cart-options2").removeClass("hidden");
                    $(".cart-options1").addClass("hidden");
                } else {
                    $(".cart-options2").addClass("hidden");
                    $(".cart-options1").removeClass("hidden");
                }

                $("#tdTotal").html(ordenCabecera.Total);
                $(".items_cart").html(ordenCabecera.Articulos);
                $("#lblmonto").html(ordenCabecera.Total);
            }

        } catch (exception) {
            console.log(exception);
        }
    }

    Fn_Dibujar_CarritoPrincipal(ordenCabecera) {
        try {
            // organizar data aqui
            if (ordenCabecera !== undefined && ordenCabecera !== null) {

                if (ordenCabecera.OrdenDetalle.length > 0) {
                    let detalleLista = { Datos: ordenCabecera.OrdenDetalle };
                    var detalleHtml = Fn_CargarTemplate('orden-detalleprincipal', detalleLista);

                    $("#tbDetallePrincipal tbody").html(detalleHtml);
                    //$(".cart-options2").removeClass("hidden");
                    //$(".cart-options1").addClass("hidden");
                } // else {
                //    $(".cart-options2").addClass("hidden");
                //    $(".cart-options1").removeClass("hidden");
                //}

                //$("#tdTotal").html(ordenCabecera.Total);
                //$(".items_cart").html(ordenCabecera.Articulos);
                //$("#lblmonto").html(ordenCabecera.Total);
            }

        } catch (exception) {
            console.log(exception);
        }
    }

    Fn_RemoverDetalle($detalle) {
        try {

            var _idProductoCifrado = $detalle.attr('data-code');
            var _nombreProducto = $detalle.attr('data-nombre');

            var succes = function (objRespuesta) {

                let metodoRespuesta = objRespuesta.d;
                if (metodoRespuesta.CodigoRespuesta === EnumCodigoRespuesta.Exito) {
                    var mensajeHtml = '<h3>¡<strong>' + _nombreProducto + '</strong> removido del <a href="#" style="text-decoration: underline;">carrito de compras</a>!</h3>';
                    Fn_Success_Notice('Producto removido del carrito', mensajeHtml);
                    agregarCarritoJs.Fn_ObtenerCarrito();
                }
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // agregar alert box aqui
            };

            fn_Ajax(agregarCarritoJs.urlRemoverDetalle, '{ idProductoCifrado:"' + _idProductoCifrado + '" }', succes, error);

        } catch (e) {
            // agregar alert aqui
        }
    }


}