function iniciar() {
    $("#ModalSection").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_Weight").numeric();
};

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Secciones");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function ObtenerPopUp(id) {
    $.ajax({
        url: '/CallCloud/Section/Editar',
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalSection").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function buscar() {
    debugger;
    var forgeryToke = $("input[name='__RequestVerificationToken']").val();

    var Section = {
        PkSection: 0,
        SectionName: $("#Filtro_SectionName").val(),
        PkSpeech: $("#Filtro_PkSpeech").val()

    };
    $.ajax({
        url: '/CallCloud/Section/Buscar',
        data: {
            filtro: Section,
            __RequestVerificationToken: forgeryToke
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};

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
    numeros = "0123456789";
    especiales = "8-37-39-46";
    tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial && numeros.indexOf(tecla) == -1) {
        return false;
    };

    function grabar() {
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
    }

}
