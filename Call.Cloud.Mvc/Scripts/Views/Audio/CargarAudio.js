
function cargaDatos() {
    var objNegocioBE = new Object();
    objNegocioBE.PK_Business = "aa";
    objNegocioBE.Pk_SubOffice = "bnnnb";
    alert("porrfaaa: " + JSON.stringify(objNegocioBE));

    /*$.ajax({
        url: '/CargaAudio/IniciarCarga',
        data: JSON.stringify(objNegocioBE),
        contentType: "application/json;",
        type: 'POST' 
    }).done(function (data, textStatus, jqXhr) {
        if (data) {
            $('#pop-up-registrar').modal('hide');
            bootbox.alert("Registro realizado correctamente.");
            listar();
        }
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });*/
}





