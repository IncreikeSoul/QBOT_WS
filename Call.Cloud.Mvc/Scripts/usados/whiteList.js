function iniciar() {
    $("#ModalWhiteList").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
    $("#btnBuscarYhimy").on("click", buscarYhimy);
};

function iniciarEditar() {
    $("#Item_PK_word").numeric();
};

function grabar() {
    var word = $("#Item_word").val();
    var porcentaje = $("#Item_porcentaje").val();
    var enterPrise = $("#Item_enterPrise").val();
    if (word == "") {
        alert("Ingrese Word");
        return false;
    }
    if(porcentaje<=0){
        alert("Ingrese porcentaje");
        return false;
    }
    if (enterPrise <= 0) {
        alert("Ingrese Enterprise");
        return false;
    }
    else
        return true;
}

function soloNumeros(e) {
    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = ".0123456789";
    especiales = "8-37-38-46";
    teclado_especial = false;

    for(var i in especiales){
        if (key == especiales[i]) {
            teclado_especial = true;
        }
    }
    if(numeros.indexOf(teclado)==-1 && !teclado_especial){
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


function validacion(text) {
    var rpta = true;
    $("form#" + text + " :input[word]").each(function () {
        if ($(this).val() == "") {
            alert("Por favor, ingrese todos los campos");
            rpta = false;
        }
    });
}
function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("WhiteList");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function ObtenerPopUp(id) {

    var urlWhiteList = whitelist.Urls.editarWhitelist;

    $.ajax({
        url: urlWhiteList,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalWhiteList").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};

function buscar() {
    var WhiteList = {
        word: $("#Filtro_word").val()
    };

    var urlBuscarWhiteList = whitelist.Urls.searchWhitelist;

    $.ajax({
        url: urlBuscarWhiteList,
        data: {
            filtro: WhiteList
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
       
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
}

function buscarYhimy() {
    debugger;

    var urlBuscarWhiteList = whitelist.Urls.searchYhimyWhitelist;

    $.ajax({
        url: urlBuscarWhiteList,
        data: {
            id:1
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
       
        alert(data);

    }).fail(function (data, textStatus, jqXhr) {
        debugger;
        console.log(data);
    });
    return false;
}
