function Habilitar() {
    var usuario = document.getElementById("TipoPermiso");
    var boton2 = document.getElementById("btn2");
    var boton3 = document.getElementById("btn3");
    var boton4 = document.getElementById("btn4");
    var boton5 = document.getElementById("btn5");

    if (usuario.value == "Administrador") {
        boton2.disabled = true;
        boton3.disabled = true;
        boton4.disabled = true;
        boton5.disabled = true;
    }
    else {
        boton2.disabled = true;
        boton3.disabled = true;
    }
}