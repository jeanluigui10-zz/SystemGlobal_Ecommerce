'use strict';
let inicioJs = null;

$(function () {
    inicioJs = new InicioJs();
    inicioJs.Fn_Iniciar();
});

class InicioJs {

    constructor() {
    }

    Fn_Iniciar() { 

        if ($("input[id$=hfDataCategoriaMenu]").val() !== undefined && $("input[id$=hfDataCategoriaMenuSubMenu]").val() !== undefined) {
            inicioJs.Fn_Cargar();
        }
    }

    Fn_Cargar() {
        try {
            inicioJs.Fn_ListarCategoriaMenu_Left($("input[id$=hfDataCategoriaMenuSubMenu]").val());
            inicioJs.Fn_ListarCategoriaMenu($("input[id$=hfDataCategoriaMenu]").val());
            inicioJs.Fn_ListarCategoriaImagenDeslizante($("input[id$=hfDataCategoriaMenu]").val());
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

 Fn_ListarCategoriaMenu(dataCategoriaMenu) {
    var objCategoriaMenu = dataCategoriaMenu;
    try {
        var objCategory = $.parseJSON(objCategoriaMenu);
        var object = {};
        object.request = objCategory;
        var item = Fn_CargarTemplate("datatable-cboCategoria", object);
        $("#cboCategoria").html(item);
    }
    catch (e) {
        Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
    }
  }
    Fn_ListarCategoriaImagenDeslizante(dataCategoriaDeslizante) {
        var objCategoriaDeslizante = dataCategoriaDeslizante;
        try {
            var objCategoryDeslizante = $.parseJSON(objCategoriaDeslizante);
            var objectD = {};
            objectD.request = objCategoryDeslizante;
            var item = Fn_CargarTemplate("datatable-CategoriaImagenDeslizante", objectD);
            $("#CategoriasDeslizante").html(item);
        }
        catch (e) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        }
    }



  Fn_ListarCategoriaMenu_Left(dataCategoriaMenuSubMenu) {
    var objCategoriaMenuSubMenu = dataCategoriaMenuSubMenu;
    try {
        var objCategoryP = $.parseJSON(objCategoriaMenuSubMenu);
        var objectP = {};
        objectP.request = objCategoryP;
        var itemp = Fn_CargarTemplate("datatable-MenuCategoria", objectP);
        $("#MenuSubMenuCategoria").html(itemp);

        for (var i = 0; i < objCategoryP.length; i++) {
            inicioJs.Fn_CargarSubCategorias_Left(objCategoryP[i].IdCategoria);
        }
    }
    catch (e) {
        Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
    }
}

   Fn_CargarSubCategorias_Left(IdCategoria) {
    var success = function (asw) {
        try {
            if (asw.d !== null) {
                var objsubCategoria = $.parseJSON(asw.d);
                var objectS = {};
                objectS.request = objsubCategoria;
                var item = Fn_CargarTemplate("datatable-MenuSubMenuCategoria", objectS);
                $("#SubCategoriaLista_" + objsubCategoria[0].IdCategoria).html(item);
                for (var i = 0; i < objsubCategoria.length; i++) {
                    inicioJs.Fn_CargarSubCategoriasDetalle_Left(objsubCategoria[i].IdSubCategoria);
                }
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

   Fn_CargarSubCategoriasDetalle_Left(IdSubCategoria) {
    var success = function (asw) {
        try {
            if (asw.d !== null) {
                var objsubCategoriaDetalle = $.parseJSON(asw.d);
                var objectD = {};
                objectD.request = objsubCategoriaDetalle;
                var item = Fn_CargarTemplate("datatable-MenuSubMenuCategoriaDetalle", objectD);
                $("#SubCategoriaDetalleLista_" + objsubCategoriaDetalle[0].IdSubCategoria).html(item);
            }
        } catch (e) {
            Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
        }
    };
    var error = function (jqXHR, textStatus, errorThrown) {
        Fn_Mensaje('e', 'Ocurrio un error.', 'message_row');
    };
       fn_Ajax("/WebMethodPaginaMaestra/PaginaMaestra.aspx/SubCategoria_Lista_PorIdSubCategoria", '{IdSubCategoria: "' + IdSubCategoria + '"}', success, error);
}

}