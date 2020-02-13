function iniciarSection() {
    $("#ModalSection").on("show.bs.modal", ejecutaModalSection);
};
function iniciarEditar() {
    $("#Item_PkSection").numeric();
};
function ejecutaModalSection(event) {
    debugger;
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Secciones");
    var id = button.data('id');
    var namespeech = button.data('namespeech');
    var speech = button.data('speech');
    ObtenerPopUp(id, namespeech,speech);
    return true;
};
function ObtenerPopUp(id, namespeech,speech) {
    debugger;
    var urlEditarSection = section.Urls.editarSectionUrl;
    $.ajax({
        url: urlEditarSection,
        data: {
            id: id,
            namespeech: namespeech,
            speech: speech
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divModalSection").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        debugger;
        console.log(data);
    });
    return false;
};
function grabarSection() {
    var nombre = $("#Item_SectionName").val();
    var descripcion = $("#Item_description").val();
    var weight = $("#Item_Weight").val();
    var TMO = $("#Item_TMO").val();

    if (nombre == "") {
        alert("Ingrese nombre");
        return false;
    }
    if (descripcion == "") {
        alert("Ingrese descripción");
        return false;
    }
    if (weight == 0) {
        alert("Ingrese Weight");
        return false;
    }
    if (TMO == 0) {
        alert("Ingrese TMO");
        return false;
    }
    else
        return true;
};
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
};

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
};

