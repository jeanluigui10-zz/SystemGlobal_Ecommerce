jQuery(function($) {
    $('#contactform').validate({
        rules: {
            name: {
                required: true,
                minlength: 2
            },
            email: {
                required: true,
                email: true
            },
            apellidoPaterno: {
                required: true,
                apellidoPaterno: true
            },
            apellidoMaterno: {
                required: true,
                apellidoMaterno: true
            },
            tipodocumento: {
                required: true,
                tipodocumento: true
            },
            password: {
                required: true,
                password: true
            },
            message: {
                required: true,
            }
        },
        messages: {
            name: {
                required: "Por favor ingrese su nombre",
                minlength: "Su nombre debe constar de al menos 2 caracteres"
            },
            email: {
                required: "Por favor ingrese su correo"
            },
            apellidoPaterno: {
                required: "Por favor ingrese su Apellido Paterno"
            },
            apellidoMaterno: {
                required: "Por favor ingrese su Apellido Materno"
            },
            tipodocumento: {
                required: "Por favor ingrese su documento"
            },
            password: {
                required: "Por favor ingrese su Contraseña"
            },
            message: {
                required: "Por favor ingrese su mensaje"
            }
        },
        submitHandler: function(form) {
            $(form).ajaxSubmit({
                type:"POST",
                data: $(form).serialize(),
                url:"external/form/contact-form.php",
                success: function() {
                      $('#success').fadeIn();
            $( '#contactform' ).each(function(){this.reset();});
                },
                error: function() {
                    $('#contactform').fadeTo( "slow", 1, function() {
                        $('#error').fadeIn();
                    });
                }
            });
        }
    });
    $('#newsletterform').validate({
        rules: {
            email: {
                required: true,
                email: true
            }
        },
        submitHandler: function(form) {
            $(form).ajaxSubmit({
                type:"POST",
                data: $(form).serialize(),
                url:"external/form/newsletter-form.php",
                success: function() {
                      $('#success').fadeIn();
            $('#newsletterform').each(function(){this.reset();});
                },
                error: function() {
                    $('#newsletterform').fadeTo( "slow", 1, function() {
                        $('#error').fadeIn();
                    });
                }
            });
        }
    });
});