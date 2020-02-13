function iniciar() {
    $("#ModalOffice").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_PkOffice").numeric();
};
function grabar() {

    var nameOffice = $("#Item_nameOffice").val();
    var PkEnterprise = $("#Item_PkEnterprise").val();
    

    if (nameOffice == "") {
        alert("Ingrese el nameOffice ");
        return false;
    }
    if (PkBusiness == "") {
        alert("Ingrese el Business");
        return false;
    }

    else
        return true;

}

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Offices");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function ObtenerPopUp(id) {
    var urlEditar = office.Urls.editarOffice;
    $.ajax({
        url: urlEditar,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalOffice").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function buscar() {
   
    var Office = { 
        nameOffice: $("#Filtro_nameOffice").val(),
        PkEnterprise: $("#Filtro_PkEnterprise").val()
    };

    var urlBuscar = office.Urls.buscarOffice;

    $.ajax({
        url: urlBuscar,
        data: {
            filtro: Office
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
}

function soloNumeros(e) {
    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "0123456789";
    especiales = "8-37-38-46";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true;
        }
    }
    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}

function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = "8-44-46-127";
    tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
