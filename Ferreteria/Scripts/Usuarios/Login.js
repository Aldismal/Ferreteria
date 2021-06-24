function ValidarUsuario() {
    $.ajax({
        url: '/Usuarios/Validar',
        type: 'POST',
        async: false,
        dataType: false,
        processData: false,
        data: $('#frm').serialize(),
        success: function (data) {
            var resultado = $.parseJSON(data);
            if (resultado.Mensaje !== '') {
                $('#error').show('slow');
                $('#error').append(resultado.Mensaje);
            }
            else {
                window.location = "/Home/Index";
            }


        }

    });
}