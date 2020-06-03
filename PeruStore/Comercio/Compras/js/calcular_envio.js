'use strict';
let calcularEnvioJs = null;

$(function () {
    calcularEnvioJs = new CalcularEnvioJs("/Comercio/Compras/CalculoEnvio.aspx/");
    calcularEnvioJs.Fn_Iniciar();
});

class CalcularEnvioJs {

    constructor(metodosPagina) {
        this.urlCargarProvincias = "/AdminCliente/ClienteRegistro.aspx/Ubigeo_ObtenerProvincias_PorIdRegion";
        this.urlCargarDistritos = "/AdminCliente/ClienteRegistro.aspx/Ubigeo_ObtenerDistritos_PorIdProvincia";
    }


    Fn_Iniciar() {
        calcularEnvioJs.Fn_Eventos();
    }

    Fn_Eventos() {
        try {

            $("select[id$=cboRegion]").on("change", function (event) {
                var idRegion = $(this).val();
                calcularEnvioJs.Fn_CargarProvincias(idRegion);
            });

            $("select[id$=cboProvincia]").on("change", function (event) {
                var idProvincia = $(this).val();
                calcularEnvioJs.Fn_CargarDistritos(idProvincia);
            });

        } catch (e) {
            // mensaje aqui
        }
    }

    Fn_CargarProvincias(idRegion) {
        try {
            $("select[id$=cboDistrito]").html('<option value="0">--- Selecciones ---</option>');

            var success = function (objRespuesta) {
                let objDatos = JSON.parse(objRespuesta.d);
                if (objDatos !== null || objDatos !== undefined) {
                    let listaProvincias = objDatos.Datos;
                    var selectHtml = "";
                    if (listaProvincias.length > 0) {
                        for (var i = 0; i < listaProvincias.length; i++) {
                            selectHtml += '<option value="' + listaProvincias[i].IdProvincia + '">' + listaProvincias[i].ProvinciaNombre + '</option>';
                        }
                        $("select[id$=cboProvincia]").html(selectHtml);
                    }
                } else {
                    // mensajes aqui
                }
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // mensaje aqui
            };

            fn_Ajax(calcularEnvioJs.urlCargarProvincias, '{strIdRegion: ' + idRegion + '}', success, error);

        } catch (e) {
            // agregar mensaje aqui
        }
    }

    Fn_CargarDistritos(idProvincia) {
        try {

            var success = function (objRespuesta) {
                let objDatos = JSON.parse(objRespuesta.d);
                if (objDatos !== null || objDatos !== undefined) {
                    let listaDistritos = objDatos.Datos;
                    var selectHtml = "";
                    if (listaDistritos.length > 0) {
                        for (var i = 0; i < listaDistritos.length; i++) {
                            selectHtml += '<option value="' + listaDistritos[i].IdDistrito + '">' + listaDistritos[i].DistritoNombre + '</option>';
                        }
                        $("select[id$=cboDistrito]").html(selectHtml);
                    }
                } else {
                    // mensajes aqui
                }
            };

            var error = function (xhr, ajaxOptions, throwError) {
                // mensaje aqui
            };

            fn_Ajax(calcularEnvioJs.urlCargarDistritos, '{strIdProvincia: ' + idProvincia + '}', success, error);

        } catch (e) {
            // agregar mensaje aqui
        }
    }


}