'use strict';

$(function () {
    Fn_Iniciar()
    Fn_Bind();
});

function Fn_Iniciar() {
    $("input").keypress(function (e) {
        if (e.which === 13) {
            return false;
        }
    });
}

function Fn_Bind() {
    $("#btnResetear").click(function (e) {
        e.preventDefault();
        if (Fn_ValidarCampos()) {
            Fn_CambiarClaveCliente()();
        }
    });
}

function Fn_ValidarCampos() {
    var contrasenha = $("#txtContrasenha").val();
    var contrasenhaConfirm = $("#txtContrasenhaConfirmacion").val();

    if (contrasenha.length === 0) {
        Fn_Mensaje('e', 'Ingrese el nuevo password', 'divMensaje');
        return false;
    }    
    if (contrasenhaConfirm.length === 0) {
        Fn_Mensaje('e', 'Confirme el nuevo password', 'divMensaje');
        return false;
    }
    if (contrasenha !== contrasenhaConfirm) {
        Fn_Mensaje('e', 'El password de confirmación no coincide, vuelva a intentarlo nuevamente', 'divMensaje');
        return false;
    }

    return true;
}

function Fn_CambiarClaveCliente() {
    try {
        var contrasenha = $("#txtContrasenha").val();
        var success = function (asw) {
            var data = JSON.parse(asw.d);

            if (data !== undefined && data !== null) {
                if (data.CodigoRespuesta === EnumCodigoRespuesta.Error) {
                    Fn_Mensaje('e', data.Mensaje, 'divMensaje');
                }

                if (data.CodigoRespuesta === EnumCodigoRespuesta.Exito) {
                    window.location = data.Datos;
                }
            }
        };
        var error = function (xhr, ajaxOptions, thrownError) {
            Fn_Mensaje('e', 'A ocurrido un error al Cambiar clave', 'divMensaje');
        };
        fn_Ajax("ClienteResetearClave.aspx/ActualizarClave", "{ password:" + JSON.stringify(contrasenha) + "}", success, error);
    } catch (e) {
        Fn_Mensaje('e', 'A ocurrido un error al Cambiar clave', 'divMensaje');
    }
}