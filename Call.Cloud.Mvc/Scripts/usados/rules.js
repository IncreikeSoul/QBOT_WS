function iniciar() {
    $("#ModalRule").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_PkRule").numeric();
};

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget); 
    modal.find(".modal-title").text("Reglas");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function grabar() {
    debugger;
    var nombrerule = $("#Item_NameRule").val();
    var time = $("#Item_TimeRule").val();
    var weight = $("#Item_wieght").val();

    if(nombrerule ==""){
        alert("Ingrese Rule");
        return false;
    }
    if(time==0){
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
function validacion(text) {
    var rpta = true;
    $("form#" + text + " :input[name]").each(function () {
        if ($(this).val() == "") {
            alert("Por favor, ingrese todos los campos");
            rpta = false;
        }
    });
    return rpta;
}

function ObtenerPopUp(id) {
    $.ajax({
        url: '/Rule/Editar',
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalRule").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function buscar() {
    var forgeryToke = $("input[name='__RequestVerificationToken']").val();  

    var Rule = {
        PkRule: 0,
        PkCat: $("#Filtro_PkCat").val(),
        PkSection: $("#Filtro_PkSection").val(),
        Name: $("#Filtro_Name").val()
    };
    $.ajax({
        url: '/Rule/Buscar',
        data: {
            filtro: Rule,
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

function soloNumeros(e) {
    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "0123456789";
    especiales = "8-14-15-37-38-46";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true;
        }
    }
    if (numeros.indexOf(teclado) == -1 && teclado_especial) {
        return false;
    }
}

function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz";
    especiales = "8-14-15-37-39-46";
    tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && tecla_especial) {
        return false;
    }
}