'use strict';
let cliente = null;

$(function () {
    Fn_Iniciar()
    Fn_Bind();
    Fn_Ubigeo_ObtenerRegiones();
   
});


function Fn_Iniciar() {
    $("#ddlProvincia").html("<option value= 0 > -- Seleccione una Provincia -- </option >");   
    $("#ddlDistrito").html("<option value= 0 > -- Seleccione un Distrito -- </option >");  

    $('#txtNombreCliente').keyup(function () {
        this.value = (this.value + '').replace(/[^A-Za-zñÑáéíóúÁÉÍÓÚ\s]/g, '');
    });

    $('#txtApellPaterno').keyup(function () {
        this.value = (this.value + '').replace(/[^A-Za-zñÑáéíóúÁÉÍÓÚ\s]/g, '');
    });

    $('#txtApellMaterno').keyup(function () {
        this.value = (this.value + '').replace(/[^A-Za-zñÑáéíóúÁÉÍÓÚ\s]/g, '');
    });
}

function Fn_Bind() {
    $("#ddlRegion").change(function (e) {
        var idRegion = $("#ddlRegion").val();
        if (idRegion === "0") {
            $("#ddlProvincia").html("<option value= 0 > -- Seleccione una Provincia -- </option>");        
        }
        else {
            Fn_Ubigeo_ObtenerProvincias_PorIdRegion(idRegion);
        }
        $("#ddlDistrito").html("<option value= 0 > -- Seleccione un Distrito -- </option >");
    })

    $("#ddlProvincia").change(function (e) {
        var idProvincia = $("#ddlProvincia").val();
        if (idProvincia === "0") {
            $("#ddlDistrito").html("<option value= 0 > -- Seleccione un Distrito -- </option >");
        }
        else
        Fn_Ubigeo_ObtenerDistritos_PorIdProvincia(idProvincia);
    })

    $("#btnRegistrarCliente").click(function (e) {
        e.preventDefault();

        if (Fn_ValidarFormulario()) {
            Fn_RegistrarCliente();
        }
    });
}

function Fn_Ubigeo_ObtenerRegiones() {
    try {
        var success = function (asw) {
            var data = JSON.parse(asw.d);
            var contentSelect = "<option value = 0 > -- Seleccione una Región -- </option>";
            var regiones = null;
            var lengthRegiones = 0;

            if (data !== undefined && data !== null) {
                if (data.CodigoRespuesta === EnumTipoMensaje.Exito);
                {
                    regiones = data.Datos
                    lengthRegiones = regiones.length;
                    for (var i = 0; i < lengthRegiones; i++) {
                        contentSelect += "<option value =";
                        contentSelect += regiones[i].IdRegion;
                        contentSelect += ">";
                        contentSelect += regiones[i].RegionNombre;
                        contentSelect += "</option>"
                    }

                    $("#ddlRegion").html(contentSelect);
                }
                if (data.CodigoRespuesta === EnumTipoMensaje.Error) {
                    Fn_Mensaje('e', 'A ocurrido un error cargando las regiones', 'divMensaje');
                }
            }
        }
        var error = function (xhr, ajaxOptions, thrownError) {
            Fn_Mensaje('e', 'A ocurrido un error cargando las regiones', 'divMensaje');
        };
        fn_Ajax("ClienteRegistro.aspx/Ubigeo_ObtenerRegion", "", success, error);
    } catch (e) {
        Fn_Mensaje('e', 'A ocurrido un error', 'divMensaje');
    }
}   

function Fn_Ubigeo_ObtenerProvincias_PorIdRegion(idRegion) {   
    try {
        var success = function (asw) {
            var data = JSON.parse(asw.d);
            var contentSelect = "<option value = 0 > -- Seleccione una Provincia -- </option>";
            var provincia = null;
            var lengthProvincia = 0;

            if (data !== undefined && data !== null) {
                if (data.CodigoRespuesta === EnumTipoMensaje.Exito);
                {
                    provincia = data.Datos
                    lengthProvincia = provincia.length;
                    for (var i = 0; i < lengthProvincia; i++) {
                        contentSelect += "<option value =";
                        contentSelect += provincia[i].IdProvincia;
                        contentSelect += ">";
                        contentSelect += provincia[i].ProvinciaNombre;
                        contentSelect += "</option>"
                    }

                    $("#ddlProvincia").html(contentSelect);
                }
                if (data.CodigoRespuesta === EnumTipoMensaje.Error) {
                    Fn_Mensaje('e', 'A ocurrido un error cargando las Provincias', 'divMensaje');
                }
            }
        }
        var error = function (xhr, ajaxOptions, thrownError) {
            Fn_Mensaje('e', 'A ocurrido un error cargando las Provincias', 'divMensaje');
        };
        fn_Ajax("ClienteRegistro.aspx/Ubigeo_ObtenerProvincias_PorIdRegion", "{ strIdRegion:" + idRegion + "}", success, error);
    } catch (e) {
        Fn_Mensaje('e', 'A ocurrido un error', 'divMensaje');
    }
}

function Fn_Ubigeo_ObtenerDistritos_PorIdProvincia(idProvincia) {
    try {
        var success = function (asw) {
            var data = JSON.parse(asw.d);
            var contentSelect = "<option value = 0 > -- Seleccione un Distrito -- </option>";
            var distritos = null;
            var lengthDistrito = 0;

            if (data !== undefined && data !== null) {
                if (data.CodigoRespuesta === EnumTipoMensaje.Exito);
                {
                    distritos = data.Datos
                    lengthDistrito = distritos.length;
                    for (var i = 0; i < lengthDistrito; i++) {
                        contentSelect += "<option value =";
                        contentSelect += distritos[i].IdDistrito;
                        contentSelect += ">";
                        contentSelect += distritos[i].DistritoNombre;
                        contentSelect += "</option>"
                    }

                    $("#ddlDistrito").html(contentSelect);
                }
                if (data.CodigoRespuesta === EnumTipoMensaje.Error) {
                    Fn_Mensaje('e', 'A ocurrido un error cargando los Distritos', 'divMensaje');
                }
            }
        }
        var error = function (xhr, ajaxOptions, thrownError) {
            Fn_Mensaje('e', 'A ocurrido un error cargando los Distritos', 'divMensaje');
        };
        fn_Ajax("ClienteRegistro.aspx/Ubigeo_ObtenerDistritos_PorIdProvincia", "{ strIdProvincia:" + idProvincia + "}", success, error);
    } catch (e) {
        Fn_Mensaje('e', 'A ocurrido un error', 'divMensaje');
    }
}

function Fn_ValidarFormulario() {
    var nombre = $("#txtNombreCliente").val();
    var apellPaterno = $("#txtApellPaterno").val();
    var apellMaterno = $("#txtApellMaterno").val();
    var correo = $("#txtCorreo").val();
    var celular = $("#txtCelular").val();
    var telefono = $("#txtTelefono").val();
    var direccionPrincipal = $("#txtDireccionPrincipal").val();
    var direccionSecundaria = $("#txtDireccionSecundaria").val();
    var strIdRegion = $("#ddlRegion").val();
    var strIdProvincia = $("#ddlProvincia").val();
    var strIdDistrito = $("#ddlDistrito").val();
    var codigoPostal = $("#txtCodigoPostal").val();
    var contrasenha = $("#txtContrasenha").val();
    var contrasenhaConfirm = $("#txtContrasenhaConfirm").val();

    if (nombre.trim().length === 0) {
        Fn_Mensaje('e', 'Nombre es un campo Obligatorio', 'divMensaje');
        return false;
    }
    if (apellPaterno.trim().length === 0) {
        Fn_Mensaje('e', 'Apellido Paterno es un campo Obligatorio', 'divMensaje');
        return false;
    }
    if (apellMaterno.trim().length === 0) {
        Fn_Mensaje('e', 'Apellido Materno es un campo Obligatorio', 'divMensaje');
        return false;
    }

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

    if (celular.trim().length === 0) {
        Fn_Mensaje('e', 'Celular es un campo Obligatorio', 'divMensaje');
        return false;
    }

    if (direccionPrincipal.trim().length === 0) {
        Fn_Mensaje('e', 'Dirección Principal es un campo Obligatorio', 'divMensaje');
        return false;
    }

    if (strIdRegion === "0") {
        Fn_Mensaje('e', 'Por favor seleccione una Región', 'divMensaje');
        return false;
    }

    if (strIdProvincia === "0") {
        Fn_Mensaje('e', 'Por favor seleccione una Provincia', 'divMensaje');
        return false;
    }

    if (strIdDistrito === "0") {
        Fn_Mensaje('e', 'Por favor seleccione un Distrito', 'divMensaje');
        return false;
    }

    if (codigoPostal.trim().length === 0) {
        Fn_Mensaje('e', 'Código Postal es un campo Obligatorio', 'divMensaje');
        return false;
    } 

    /****************************Validacion de Password****************************/
    if (contrasenha.length === 0) {
        Fn_Mensaje('e', 'Password es un campo Obligatorio', 'divMensaje');
        return false;
    }
    
    if (contrasenhaConfirm.length === 0) {
        Fn_Mensaje('e', 'Confirme el password ingresado', 'divMensaje');
        return false;
    }

    if (contrasenha !== contrasenhaConfirm ) {
        Fn_Mensaje('e', 'El password de confirmación no coincide', 'divMensaje');
        return false;
    }

    return true;
    /******************************************************************************/
}

function Fn_RegistrarCliente() {
    try {
        var nombre = $("#txtNombreCliente").val();
        var apellPaterno = $("#txtApellPaterno").val();
        var apellMaterno = $("#txtApellMaterno").val();
        var correo = $("#txtCorreo").val();
        var celular = $("#txtCelular").val();
        var telefono = $("#txtTelefono").val();
        var direccionPrincipal = $("#txtDireccionPrincipal").val();
        var direccionSecundaria = $("#txtDireccionSecundaria").val();
        var strIdRegion = $("#ddlRegion").val();
        var strIdProvincia = $("#ddlProvincia").val();
        var strIdDistrito = $("#ddlDistrito").val();
        var codigoPostal = $("#txtCodigoPostal").val();
        var contrasenha = $("#txtContrasenha").val();
        var contrasenhaConfirm = $("#txtContrasenhaConfirm").val();

        var cliente = new Object();
        cliente.nombre = nombre;
        cliente.apellPaterno = apellPaterno.trim();
        cliente.apellMaterno = apellMaterno.trim();
        cliente.correo = correo.trim();
        cliente.celular = celular.trim();
        cliente.telefono = telefono.trim();
        cliente.direccionPrincipal = direccionPrincipal.trim();
        cliente.direccionSecundaria = direccionSecundaria.trim();
        cliente.IdRegion = parseInt(strIdRegion.trim());
        cliente.IdProvincia = parseInt(strIdProvincia.trim());
        cliente.IdDistrito = parseInt(strIdDistrito.trim());
        cliente.codigoPostal = codigoPostal.trim();
        cliente.contrasenha = contrasenha;


        var success = function (asw) {
            var data = JSON.parse(asw.d);


            if (data !== undefined && data !== null) {
                if (data.CodigoRespuesta === EnumTipoMensaje.Exito);
                {

                }
                if (data.CodigoRespuesta === EnumTipoMensaje.Error) {

                }
            }
        }
        var error = function (xhr, ajaxOptions, thrownError) {
            Fn_Mensaje('e', 'A ocurrido un error al registrar', 'divMensaje');
        };
        fn_Ajax("ClienteRegistro.aspx/RegistrarCliente", "{ cliente:" + JSON.stringify(cliente) + "}", success, error);

    } catch (e) {
        Fn_Mensaje('e', 'A ocurrido un error al registrar', 'divMensaje');
    }

}

