let listaProductoJS = null;

$(function () {
    listaProductoJS = new ListaProducto("");
    listaProductoJS.Fn_Iniciar();
});
class ListaProducto {

    constructor() {
            
    }

    Fn_Iniciar() {
        listaProductoJS.Fn_Cargar();
    }

    Fn_Cargar() {
        try {
            let listaproducto = JSON.parse($("input[id$=_hfListaProducto]").val());
            if (listaproducto === undefined || listaproducto === null) {
                Fn_Mensaje('e', "Ocurrio un error al cargar lista de productos.");
            } else {
                var htmlProducto = Fn_CargarTemplate("handlebarProducto", listaproducto);
                $("#dvProductos").html(htmlProducto);
            }
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

}