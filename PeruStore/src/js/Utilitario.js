
//Ingresa solo números
$('.input-number').on('input', function () {
    this.value = this.value.replace(/[^0-9]/g, '');
});

//Valida si es email valido
function esEmail(email) {
     var regex = /^([a-zA-Z0-9_.+-])+\@(([a-zA-Z0-9-])+\.)+([a-zA-Z0-9]{2,6})+$/;
    return regex.test(email);
}

