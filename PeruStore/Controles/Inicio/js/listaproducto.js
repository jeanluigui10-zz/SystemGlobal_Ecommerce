let listaProductoJS = null;

$(function () {
    listaProductoJS = new ListaProducto("");
    listaProductoJS.Fn_Iniciar();
    Fn_Render_Lista_Producto_Tab_1();
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
                Fn_Mensaje('e', "Ocurrio un error al cargar lista de productos.", "header");
            } else {
                var htmlProducto = Fn_CargarTemplate("handlebarProducto", listaproducto);
                $("#dvProductos").html(htmlProducto);
            }
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.", "header");
        }
    }

}