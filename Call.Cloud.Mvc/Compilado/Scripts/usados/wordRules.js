function iniciar() {
    $("#ModalWordRule").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {    
    $("#Item_PkWorldRule").numeric();
};

function grabar() {
    
    var word = $("#Item_Word").val();
    var sequence = $("#Item_Sequence").val();
    var timeword = $("#Item_TimeWord").val();
    var weight = $("#Item.Weight").val();

    if (word == "") {
        alert("Ingrese Word");
        return false;
    }
    if (timeword == 0) {
        alert("Ingrese TimeWord");
        return false;
    }
    if (weight == 0) {
        alert("Ingrese Weight");
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
    modal.find(".modal-title").text("Word Rules");
    var id = button.data('id');
    var rule = button.data('rule');
    ObtenerPopUp(id, rule);
    return true;
};
function ObtenerPopUp(id, rule) {
    var urlEditSection = wordRule.Urls.editarPalabraRegla;
    $.ajax({
        url: urlEditSection,
        data: {
            id: id,
            rule: rule
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalWordRule").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function buscar() {
    var urlBuscarWordRule = wordRule.Urls.searchPalabraRegla;

    var WordRule = {
        PkRule: $("#Filtro_PkRule").val(),
        Word: $("#Filtro_Word").val()
    };
    $.ajax({
        url: urlBuscarWordRule,
        data: {
            filtro: WordRule
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