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

        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

}
