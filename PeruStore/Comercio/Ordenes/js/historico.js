'use strict';
let historicoJs = null;

$(function () {
    historicoJs = new HistoricoJs("");
    historicoJs.Fn_Iniciar();
});

class HistoricoJs {

    constructor() {
    }


    Fn_Iniciar() {
        historicoJs.Fn_Limpiar();
        historicoJs.Fn_Cargar();
    }

    Fn_Limpiar() {
        try {
            $("#tbHistorico tbody").html("");
        } catch (e) {
            console.log(e);
        }
    }

    Fn_Cargar() {
        try {

            let ordenHistorico = JSON.parse($("input[id$=hfOrdenHistorico]").val());
            if (ordenHistorico === undefined || ordenHistorico === null) {
                Fn_Mensaje('e', "Ocurrio un error al cargar sus ordenes.");
            } else {
                let htmlBody = Fn_CargarTemplate("historico-template", ordenHistorico);
                $("#tbHistorico tbody").html(htmlBody);
            }

        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

}