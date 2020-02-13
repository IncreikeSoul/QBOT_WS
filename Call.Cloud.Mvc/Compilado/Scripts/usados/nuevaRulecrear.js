function iniciarRule() {
    $("#ModalRule").on("show.bs.modal", ejecutaModalRule);
};
function iniciarEditar() {
    $("#Item_PkRule").numeric();
};

function ejecutaModalRule(event) {
    debugger;
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });
    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Reglas");
    var id = button.data('id');
    var section = button.data('section');
    var speech = button.data('speech');
    var namespeech = button.data('namespeech');
    var namesection = button.data('namesection');
    ObtenerPopUpRule(id, section, speech, namespeech, namesection);
    return true;
    
};

function ObtenerPopUpRule(id, section, speech, namespeech, namesection) {
    debugger;
    var urlEditarRule = rule.Urls.editarReglasUrl;
    $.ajax({
        url: urlEditarRule,
        data: {
            id: id,
            section: section,
            speech: speech,
            namespeech: namespeech,
            namesection: namesection
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalRule").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};

function grabarRule() {
    
    var nombrerule = $("#Item_NameRule").val();
    var time = $("#Item_TimeRule").val();
    var weight = $("#Item_wieght").val();

    if (nombrerule == "") {
        alert("Ingrese Rule");
        return false;
    }
    if (time == 0) {
        alert("Ingrese Time");
        return false;
    }
    if (weight == 0) {
        alert("Ingrese Weight");
        return false;
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

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
