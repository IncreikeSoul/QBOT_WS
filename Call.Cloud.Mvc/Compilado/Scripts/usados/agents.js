function iniciar() {
    $("#ModalAgent").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_Dni").numeric();
};
function grabar() {
    var firstname = $("#Item_FirstName").val();
    var lastname = $("#Item_LastName").val();
    var dni = $("#Item_Dni").val();
    dni = 8;

    if(firstname ==""){
        alert("Ingrese el First Name");
        return false;
    }
    if(lastname==""){
        alert("Ingrese el Last Name");
        return false;
    }
    if(dni == 0){
        alert("Ingrese DNI");
        return false;
    }
    if(dni.value.length !=8){
        alert("Ingrese 8 caracteres");
    }
    else
        return true;
    
}
function validacion(text) {
    var rpta=true;
    $("form#"+text+" :input[name]").each(function () {
        if ($(this).val() == "") {
            alert("Por favor, ingrese todos los campos");
            rpta= false;
        }
    });
    return rpta;
}

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto', 
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget); 
    modal.find(".modal-title").text("Agentes");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};
function ObtenerPopUp(id) {
    var urlEditAgent = agent.Urls.editarAgentUrl;
    $.ajax({
        url: urlEditAgent,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        $("#divModalAgent").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });    
    return false;
};
function buscar() {       
    var Agent = {
        FirstName: $("#Filtro_FirstName").val(),
        LastName: $("#Filtro_LastName").val(),
        PkBussines: $("#Filtro_PkBussines").val()
    };

    var urlBuscarAgent = agent.Urls.searchAgentUrl;

    $.ajax({
        url: urlBuscarAgent,
        data: {
            filtro: Agent
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
