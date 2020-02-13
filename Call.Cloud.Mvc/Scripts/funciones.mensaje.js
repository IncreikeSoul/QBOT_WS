function mensaje(mensaje) {
    return "<div class='alert alert-primary' role='alert'>" +
        "<strong>Mensaje!</strong> " + mensaje + "." +
        "</div>";
}

function peligro(mensaje) {
    return "<div class='alert alert-danger' role='alert'>" +
        "<strong>Peligro!</strong> " + mensaje + "." +
        "</div>";
}

function informacion(mensaje) {
    return "<div class='alert alert-info' role='alert'>" +
        "<strong>Información!</strong> " + mensaje + "." +
        "</div>";
}

function advertencia(mensaje) {
    return "<div class='alert alert-warning' role='alert'>" +
        "<strong>Advertencia!</strong> " + mensaje + "." +
        "</div>";
}

function satisfactorio(mensaje) {
    return "<div class='alert alert-success' role='alert'>" +
        "<strong>Satisfactorio!</strong> " + mensaje + "." +
        "</div>";
}