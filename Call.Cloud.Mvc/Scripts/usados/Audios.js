function iniciar() {
    $("#ModalAgent").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", listarAudios);
    $("#Filtro_PK_Business").on("change", comboSpeechBuscar);
    $("#Filtro_PK_Business").on("change", comboAgentBuscar);
    listarAudios();
};

function iniciarEditar() {
    $("#Item_pk_audio").numeric();
};

function comboSpeechBuscar() {
    var objOficinaBE = new Object();
    objOficinaBE.PK_Business = $("#Filtro_PK_Business").val();

    $.ajax({
        url: '/Mantenimiento/SpeechListarCombos',
        data: JSON.stringify(objOficinaBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_speech_buscar").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_speech_buscar").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboAgentBuscar() {
    var objOficinaBE = new Object();
    objOficinaBE.PK_Business = $("#Filtro_PK_Business").val();

    $.ajax({
        url: '/Mantenimiento/AgentListarCombos',
        data: JSON.stringify(objOficinaBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_agent_buscar").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_agent_buscar").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function listarAudios() {
    var objAudioBE = new Object();
    objAudioBE.PK_Business = $("#Filtro_PK_Business").val() == "" ? 0 : $("#Filtro_PK_Business").val();
    objAudioBE.PK_Speech = $("#slt_speech_buscar").val();
    objAudioBE.PkAgent = $("#slt_agent_buscar").val();

    $.ajax({
        url: '/Audios/listarAudio',
        data: JSON.stringify(objAudioBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#dt-tabla-audio tbody").empty();
        $.each(data, function (i, obj) {
            $("#dt-tabla-audio tbody").append("<tr>" +
                "<td>" + obj.pk_auido + "</td>" +
                "<td>" + obj.FirstName + "</td>" +
                "<td>" + obj.nameBusiness + "</td>" +
                "<td>" + obj.filesize + "</td>" +
                "<td>" + obj.seconds + "</td>" +
                "<td>" + obj.date + "</td>" +
                "<td>" + obj.dateCreated + "</td>" +
                "<td>" + obj.state + "</td>" +
                "<td>"+
                "<a class='btn btn-sm btn-primary btn-round' title='Detalle de Audio' data-toggle='modal' data-original-title='editar' data-target='#ModalAgent' data-id='" + obj.pk_auido + "' data-url='" + obj.direccionAudio + "' data-file='" + obj.fileName + "' >"+
                        "<i class='fal fa-file-archive'></i>"+
                    "</a >"+
                "</td >"+
                "<td>"+
                "<a class='btn btn-sm btn-primary btn-round' title='Reproducir' data-toggle='tooltip' onclick='reproducirAudio(\"" + obj.direccionAudio + "\",\"" + obj.fileName + "\")' data-original-title='Reproducir'>"+
                        "<i class='fal fa-play'></i>"+
                    "</a>"+
                "</td>"+
                "<td>"+
                "<a class='btn btn-sm btn-primary btn-round' title='Pausar' data-toggle='tooltip' onclick='pausarAudio(\"" + obj.direccionAudio + "\",\"" + obj.fileName + "\")' data-original-title='Pausar'>"+
                        "<i class='fal fa-pause'></i>"+
                    "</a>"+
                "</td>" +
                "</tr>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}
/*
function buscar() {
    var Audio = {
        PK_Business: $("#Filtro_PK_Business").val(),
        Fk_Boss: $("#Filtro_Fk_Boss").val(),
        PkAgent: $("#Filtro_PkAgent").val(),
        Placa: $("#Filtro_Placa").val()
    };
    var urlBuscarAgent = agent.Urls.findAgentUrl;
    $.ajax({
        url: urlBuscarAgent,
        data: {
            filtro: Audio
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
}*/

function Detalle_Audios(id,path,file) {
    var urlEditAgent = agent.Urls.editarAgentUrl;
    $.ajax({
        url: urlEditAgent,
        data: {
            id: id
        },
        type: 'GET'

    }).done(function (data, textStatus, jqXhr) {
        //

        //var filename = path + file;
        //var filename = '../../assets/Archivos/Audios/success/09122020/111920/' + file;

        //$("#hdnPathAudio").val(filename);
        $("#divModalAudio").html(data);

    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};

function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Audios");
    var id = button.data('id');
    var path = button.data("url");
    var file = button.data("file");
    
    Detalle_Audios(id, path, file);
    return true;
};
