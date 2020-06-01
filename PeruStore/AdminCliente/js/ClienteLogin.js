'use strict';
let cliente = null;

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
    $("#btnLogin").click(function (e) {
        e.preventDefault();
        if (Fn_ValidarFormulario()) {
            Fn_Login();
        }
    });
}

function Fn_ValidarFormulario() {
    var correo = $("#txtCorreo").val();
    var contrasenha = $("#txtContrasenha").val();

    if (correo.trim().length === 0) {
        Fn_Mensaje('e', 'Correo Electrónico es un campo Obligatorio', 'divMensaje');
        return false;
    }
    else {
        if (!esEmail(correo.trim())) {
            Fn_Mensaje('e', 'Ingrese un Correo Electrónico válido', 'divMensaje');
            return false;
        }
    }
    if (contrasenha.length === 0) {
        Fn_Mensaje('e', 'Password es un campo Obligatorio', 'divMensaje');
        return false;
    }
    return true;
}

function Fn_Login() {
    try {
        var correo = $("#txtCorreo").val();
        var contrasenha = $("#txtContrasenha").val();

        var cliente = new Object();
        cliente.correo = correo.trim();
        cliente.contrasenha = contrasenha;


        var success = function (asw) {
            var data = JSON.parse(asw.d);

            if (data !== undefined && data !== null) {
                if (data.CodigoRespuesta === EnumCodigoRespuesta.Exito) {
                   window.location = data.Datos;
                }
                if (data.CodigoRespuesta === EnumCodigoRespuesta.Error) {
                    Fn_Mensaje('e', data.Mensaje, 'divMensaje');
                }
                if (data.CodigoRespuesta === EnumCodigoRespuesta.Informacion) {
                    Fn_Mensaje('i', data.Mensaje, 'divMensaje');
                }
            }
        };
        var error = function (xhr, ajaxOptions, thrownError) {
            Fn_Mensaje('e', 'A ocurrido un error al Iniciar Sesión', 'divMensaje');
        };
        fn_Ajax("ClienteLogin.aspx/Login", "{ credLogin:" + JSON.stringify(cliente) + "}", success, error);

    } catch (e) {
        Fn_Mensaje('e', 'A ocurrido un error al Iniciar Sesión', 'divMensaje');
    }

}

