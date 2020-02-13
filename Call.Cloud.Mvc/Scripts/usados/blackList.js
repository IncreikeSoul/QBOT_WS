function iniciar() {
    $("#ModalBlackList").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_pk").numeric();
};

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("BlackLists");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function ObtenerPopUp(id) {

    var urlEditarBlackList = blacklist.Urls.editarBlacklist;
    $.ajax({
        url: urlEditarBlackList,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalBlackList").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function buscar() {
    var forgeryToke = $("input[name='__RequestVerificationToken']").val();

    var BlackList = {
        word: $("#Filtro_word").val(),       
    };

    var urlBuscarBlackList = blacklist.Urls.searchBlacklist;
    $.ajax({
        url: urlBuscarBlackList,
        data: {
            filtro: BlackList,
            __RequestVerificationToken: forgeryToke
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
    var word = $("#Item_word").val();
    var enterprise = $("#Item_enterprise").val();
    if (word == "") {
        alert("Ingrese Word");
        return false;
    }
    if (word.filtro =="0-9") {
        alert("Ingrese solo letras");
        return false;
    }
    if (enterprise <= 0) {
        alert("Ingrese Enterprise");
        return false;
    }
    if (enterprise=="solo nuemrosnaelmfaeko"){
        alert("Ingrese solo números");
    }
    else
        return true;
}

function soloNumeros(e) {
    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = ".0123456789";
    especiales = "08-37-38-46";
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
    letras = " .,áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = "8-37-39-46";
    tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla)==-1 && !tecla_especial) {
        return false;
    }
}
