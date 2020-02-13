function iniciar() {
    $("#ModalSubOffice").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_PkSubOffice").numeric();
};
function grabar() {

    var nameSubOffice = $("#Item_nameSubOffice").val();
    var PkOffice = $("#Item_PkOffice").val();


    if (nameSubOffice == "") {
        alert("Ingrese el nameOffice ");
        return false;
    }
    if (PkOffice == "") {
            alert("Ingrese el Office");
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
    modal.find(".modal-title").text("SubOffices");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function ObtenerPopUp(id) {
    var urlEditar = suboffice.Urls.editarSubOffice;

    $.ajax({
        url: urlEditar,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalSubOffice").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function buscar() {
    
    var SubOffice = {

        nameOffice: $("#Filtro_nameSubOffice").val(),
        PkEnterprise: $("#Filtro_PkOffice").val()
    };

    var urlBuscar = suboffice.Urls.buscarSubOffice;

    $.ajax({
        url: urlBuscar,
        data: {
            filtro: SubOffice
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
