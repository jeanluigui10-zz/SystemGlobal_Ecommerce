'use strict';
let listaProductosPorCategoriaJs = null;

$(function () {
    listaProductosPorCategoriaJs = new ListaProductosPorCategoriaJs();
    listaProductosPorCategoriaJs.Fn_Iniciar();
});

class ListaProductosPorCategoriaJs {

    constructor() {
    }

    Fn_Iniciar() {

        if ($("input[id$=hfDatosProductosPorCategoria]").val() !== undefined) {
            listaProductosPorCategoriaJs.Fn_Cargar();
        }
    }

    Fn_Cargar() {
        try {
            listaProductosPorCategoriaJs.Fn_ListarProductosPorCategoria($("input[id$=hfDatosProductosPorCategoria]").val());
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

    Fn_ListarProductosPorCategoria(datosProductos) {
        var objdatosProductos = datosProductos;
        try {
            var objProductos = $.parseJSON(objdatosProductos);
            var object = {};
            object.request = objProductos;
            var item = Fn_CargarTemplate("handlebards-listaProductoxCategoria", object);
            $("#divListaProductosPorCategoria").html(item);
        }
        catch (e) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        }
    }
}