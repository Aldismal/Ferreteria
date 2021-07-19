function EditarDetalle(detallev) {

    $.ajax({
        url: '/DetalleVenta/Editar',
        type: 'POST',
        async: false,
        dataType: 'JSON',
        processData: false,
        data: $('#FrmDetalleV').serialize(),
        success: function (data) {
            var resultado = $.parseJSON(data);

            if (resultado.Mensaje !== '') {
                $('#msgErrorCarga').show('slow');
                $('#msgErrorCarga ').append(resultado.Mensaje);
                window.location = "/Ventas/Index";
            }
            else {
                window.location = "/Ventas/Index";
            }
        }
    });
}

//boton cancelar del modal crear venta
function Cancelar() {
    $('.modal').modal('hide');
}

function EliminarDetalleV(id) {


    $.ajax({
        url: '/DetalleVenta/Eliminar/' + id,
        type: 'Post',
        success: function (data) {
            var obj = data;
            Swal.fire({
                title: 'Desea eliminar el detalle?',
                text: "Se eliminará definitivamente!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire(
                        $(location).attr('href', '/DetalleVenta/Index')
                    )
                }
            })

        }
    });
}

function EliminarVenta(id) {


    $.ajax({
        url: '/Ventas/Eliminar/' + id,
        type: 'Post',
        success: function (data) {
            var obj = data;
            Swal.fire({
                title: 'Desea eliminar la venta?',
                text: "Se eliminará definitivamente!",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Si, eliminar!'
            }).then((result) => {
                if (result.isConfirmed) {
                    Swal.fire(
                        $(location).attr('href', '/Ventas/Index')
                    )
                }
            })

        }
    });
}

//var descripcion = document.getElementById('Descripcion');
//error.style.color = 'red';
function CrearVenta() {
   
    $.ajax({
        url: '/Ventas/CrearV/',
        type: 'POST',
        async: false,
        dataType: 'text',
        processData: false,
        data: $('#FrmVenta').serialize(),
        success: function (data) {
            var resultado = $.parseJSON(data);

            if (resultado.Mensaje !== '') {
                $('#msgErrorCarga').show('slow');
                $('#msgErrorCarga ').append(resultado.Mensaje);

                window.location = "/Ventas/Index";
            }
            else {
                window.location = "/Ventas/Index";
            }
        }
    });

   
}

function CrearDetalle(id) {
    $.ajax({
        url: '/DetalleVenta/CrearDetalle/'+id,
        type: 'POST',
        async: false,
        dataType: 'text',
        processData: false,
        data: $('#FrmDetalle').serialize(),
        success: function (data) {
            var resultado = $.parseJSON(data);

            if (resultado.Mensaje !== '') {
                $('#msgErrorCarga').show('slow');
                $('#msgErrorCarga ').append(resultado.Mensaje);
                window.location = "/DetalleVenta/AgregarDetalle/"+id;
            }
            else {
                window.location = "/DetalleVenta/AgregarDetalle/"+id;
            }
        }
    });
}

function EditarVenta(venta) {


    $.ajax({
        url: '/Ventas/Guardar/',
        type: 'POST',
        async: false,
        dataType: 'text',
        processData: false,
        data: $('#FrmVenta').serialize(),
        success: function (data) {
            var resultado = $.parseJSON(data);

            if (resultado.Mensaje !== '') {
                $('#msgErrorCarga').show('slow');
                $('#msgErrorCarga ').append(resultado.Mensaje);

                window.location = "/Ventas/Index";
            }
            else {
                window.location = "/Ventas/Index";
            }
        }
    });


}