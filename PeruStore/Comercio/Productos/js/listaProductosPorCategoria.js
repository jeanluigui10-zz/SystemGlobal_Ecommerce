'use strict';
let listaProductosPorCategoriaJs = null;

$(function () {
    listaProductosPorCategoriaJs = new ListaProductosPorCategoriaJs();
    listaProductosPorCategoriaJs.Fn_Iniciar();
});

function Fn_ListarProductosPorCategoria(IdCategoria, CategoriaNombre) {
    var success = function (asw) {
        try {
            var objProductos = $.parseJSON(asw.d);
            var object = {};
            object.request = objProductos;
            var item = Fn_CargarTemplate("handlebards-listaProductoxCategoria", object);
            $("#divListaProductosPorCategoria").html(item);
            $("#lblTitleCategoria").text(CategoriaNombre);
        }
        catch (e) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        }
    };
    var error = function (jqXHR, textStatus, errorThrown) {
        Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
    };
    fn_Ajax("ListaProducto.aspx/ProductosPor_Categoria", '{IdCategoria: "' + IdCategoria + '"}', success, error);
}

class ListaProductosPorCategoriaJs {

    constructor() {
    }

    Fn_Iniciar() {

        if ($("input[id$=hfDatosProductosPorCategoria]").val() !== undefined || $("input[id$=hfDatosCategoriasLista]").val() !== undefined) {
            listaProductosPorCategoriaJs.Fn_Cargar();
        }
    }

    Fn_Cargar() {
        try {
            listaProductosPorCategoriaJs.Fn_ListarCategorias_Carga($("input[id$=hfDatosCategoriasLista]").val());
            listaProductosPorCategoriaJs.Fn_ListarProductosPorCategoria_Carga($("input[id$=hfDatosProductosPorCategoria]").val());
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

    Fn_ListarCategorias_Carga(dataCategoria) {
        var objCategoria = dataCategoria;
        try {
            var objCategory = $.parseJSON(objCategoria);
            var object = {};
            object.request = objCategory;
            var itemp = Fn_CargarTemplate("handlebards-listaCategorias", object);
            $("#cat_accordion").html(itemp);

            for (var i = 0; i < objCategory.length; i++) {
                listaProductosPorCategoriaJs.Fn_CargarSubCategorias(objCategory[i].IdCategoria);
            }
        }
        catch (e) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        }
    }

    Fn_CargarSubCategorias(IdCategoria) {
        var success = function (asw) {
            try {
                if (asw.d !== null) {
                    var objsubCategoria = $.parseJSON(asw.d);
                    var objectS = {};
                    objectS.request = objsubCategoria;
                    var item = Fn_CargarTemplate("handlebards-listaSubCategorias", objectS);
                    $("#Categoria_" + objsubCategoria[0].IdCategoria).html(item);
                }
            } catch (e) {
                Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
            }
        };
        var error = function (jqXHR, textStatus, errorThrown) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        };
        fn_Ajax("/WebMethodPaginaMaestra/PaginaMaestra.aspx/SubCategoria_Lista_PorIdCategoria", '{IdCategoria: "' + IdCategoria + '"}', success, error);
    }

    Fn_ListarProductosPorCategoria_Carga(datosProductos) {
        var objdatosProductos = datosProductos;
        try {
            var objProductos = $.parseJSON(objdatosProductos);
            var object = {};
            object.request = objProductos;
            var item = Fn_CargarTemplate("handlebards-listaProductoxCategoria", object);
            $("#divListaProductosPorCategoria").html(item);
            $("#lblTitleCategoria").text(object.request[0].CategoriaNombre);
        }
        catch (e) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        }
    }

   
}