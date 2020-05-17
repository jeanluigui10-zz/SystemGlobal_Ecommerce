'use strict';
let cliente = null;

$(function () {

    //cliente = new ClienteRegistroJs();
    //cliente.Fn_Iniciar();
    Fn_Ubigeo_ObtenerRegiones();
});

function Fn_Ubigeo_ObtenerRegiones() {
    var success = function (asw) {
        if (asw !== null) {
            if (asw.d.CodigoRespuesta === EnumTipoMensaje.Exito);
            {
                if (asw.d !== null) {
                    console.log(asw.d.Datos);
                    console.log(asw.d.Datos.Regiones);
                    console.log(asw.d.Datos.Regiones.length);
                }
            }
            if (asw.d.CodigoRespuesta === EnumTipoMensaje.Error) {
                fn_message('e', 'A ocurrido un error cargando las regiones', 'message_row');
            }
        }
    }
    var error = function (xhr, ajaxOptions, thrownError) {
        fn_message('e', 'A ocurrido un error cargando las regiones', 'message_row');
    };

    fn_Ajax("ClienteRegistro.aspx/Ubigeo_ObtenerRegion", "", success, error);
}    



class ClienteRegistroJs {

    constructor() {
        //this.Nombre = nombre;
        //this.ApellidoMaterno = apellidoMaterno;
        //this.ApellidoPaterno = apellidoMaterno;
        //this.Email = email;
        //this.Celular = celular;
        //this.Telefono = telefono;
        //this.DireccionPrincipal = direccionPrincipal;
        //this.DireccionSecundaria = direccionSecundaria;
        //this.IdRegion = idRegion;
        //this.IdProvincia = idProvincia;
        //this.IdDistrito = idDistrito;
        //this.CodigoPostal = codigoPostal;
        //this.Contrasenha = contrasenha;
    }


    Fn_Iniciar() {
        //Fn_Bind();    
        Fn_Ubigeo_ObtenerRegiones();

    }

    Fn_Bind() {
        $("#btnRegistrarCliente").click(function (e) {
            e.preventDefault();
            Fn_ValidacionDatos();
        })
    }

    Fn_ValidacionDatos() {
        try {

           
        } catch (e) {
            Fn_Mensaje('e', "Ocurrió un problema, intentalo otra vez.");
            return; 
        }
    }
}