'use strict';
let informacionJs = null;

$(function () {
    informacionJs = new InformacionJs();
    informacionJs.Fn_Iniciar();
});

class InformacionJs {

    constructor() {
    }


    Fn_Iniciar() {
        informacionJs.Fn_Cargar();
    }

    Fn_Cargar() {
        try {
            informacionJs.Fn_Cabecera();
            informacionJs.Fn_Detalle();
            informacionJs.Fn_Estados();
        } catch (e) {
            Fn_Mensaje('e', "Ocurrio un problema, intentalo otra vez.");
        }
    }

    Fn_Cabecera() {
        try {

            let cabecera = [];
            cabecera.push(JSON.parse($("input[id$=hfCabeceraJson]").val()));
            let objCabecera = { cabecera: cabecera };

            let resumenHtml = Fn_CargarTemplate("cabecera-resumen", objCabecera);
            $("#tbResumen tbody").html(resumenHtml);

            let direccionHtml = Fn_CargarTemplate("cabecera-direccion", objCabecera);
            $("#tbDireccion tbody").html(direccionHtml);

            let montosHtml = Fn_CargarTemplate("cabecera-montos", objCabecera);
            $("#tfMontos").html(montosHtml);


        } catch (e) {
            throw e;
        }
    }

    Fn_Detalle() {
        try {
            let objDetalle = JSON.parse($("input[id$=hfDetalleJson]").val());
            let detalleHtml = Fn_CargarTemplate("detalle", objDetalle);
            $("#tbDetalle tbody").html(detalleHtml);
        } catch (e) {
            throw e;
        }
    }

    Fn_Estados() {
        try {
            let objEstados = JSON.parse($("input[id$=hfEstadosJson]").val());
            let estadosHtml = Fn_CargarTemplate("estados", objEstados);
            $("#tbEstados tbody").html(estadosHtml);
        } catch (e) {
            throw e;
        }
    }
}