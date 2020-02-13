function iniciar() {
    $("#ModalSpeech").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Speech");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};

function ObtenerPopUp(id) {
    //debugger;
    var urlEditarSpeech = speech.Urls.editarSpeechUrl;
        $.ajax({
            url: urlEditarSpeech,
            data: {
                id: id
            },
            type: 'GET'
        }).done(function (data, textStatus, jqXhr) {
            $("#divModalSpeech").html(data);
        }).fail(function (data, textStatus, jqXhr) {
            console.log(data);
        });
        return false;
    
};

function buscar() {
    debugger;
    var Speech = {
        Name: $("#Filtro_Name").val(),
        Description: $("#Filtro_Description").val(),
        PK_Business: $("#Filtro_PK_Business").val()
    };

    var urlBuscarSpeech = speech.Urls.searchSpeechUrl;

    $.ajax({
        url: urlBuscarSpeech,
        data: {
            filtro: Speech
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
}

function grabar() {
    var name = $("#Item_Name").val();
    var descripcion = $("#Item_Description").val();
    if (name == "") {
        alert("Ingrese nombre");
        return false;
    }
    if (descripcion == "") {
        alert("Ingrese descripción");
        return false;
    }
    else
        return true;   
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
    especiales = "8-37-39-46";
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