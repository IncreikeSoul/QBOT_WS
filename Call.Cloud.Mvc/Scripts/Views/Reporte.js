$(document).ready(function () {
    $("#btn_buscar").click(listar);
    $("#slt_empresa_buscar").click(comboOficinaBuscar);
    $("#slt_oficina_buscar").click(comboSubOficinaBuscar);
    $("#slt_sub_oficina_buscar ").click(comboNegocioBuscar);
    $("#slt_negocio_buscar").click(comboSpeechBuscar);
    $("#slt_negocio_buscar").click(comboAgentBuscar); 
    comboOficinaBuscar();
    listar();
});

function comboOficinaBuscar() {
    var objEnterpriseBE = new Object();
    objEnterpriseBE.Pk_Enterprise = $("#slt_empresa_buscar").val();

    $.ajax({
        url: '/Mantenimiento/OficinaListarCombos',
        data: JSON.stringify(objEnterpriseBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_oficina_buscar").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_oficina_buscar").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboSubOficinaBuscar() {
    var objOficinaBE = new Object();
    objOficinaBE.Pk_Office = $("#slt_oficina_buscar").val();

    $.ajax({
        url: '/Mantenimiento/SubOficinaListarCombos',
        data: JSON.stringify(objOficinaBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_sub_oficina_buscar").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_sub_oficina_buscar").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboNegocioBuscar() {
    var objOficinaBE = new Object();
    objOficinaBE.Pk_SubOffice = $("#slt_sub_oficina_buscar").val();

    $.ajax({
        url: '/Mantenimiento/NegocioListarCombos',
        data: JSON.stringify(objOficinaBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_negocio_buscar").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_negocio_buscar").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboSpeechBuscar() {
    var objOficinaBE = new Object();
    objOficinaBE.PK_Business = $("#slt_negocio_buscar").val();

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
    objOficinaBE.PK_Business = $("#slt_negocio_buscar").val();

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

function listar() {
    var objNegocioBE = new Object();
    objNegocioBE.Pk_Enterprise = $("#slt_empresa_buscar").val();
    objNegocioBE.Pk_SubOffice = $("#slt_sub_oficina_buscar").val();
    objNegocioBE.Pk_Office = $("#slt_oficina_buscar").val();
    objNegocioBE.FK_Business = $("#slt_negocio_buscar").val();
    objNegocioBE.FK_Speech = $("#slt_speech_buscar").val();
    objNegocioBE.FK_Agent = $("#slt_agent_buscar").val();

    $.ajax({
        url: '/Reporte/ReporteListar',
        data: JSON.stringify(objNegocioBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#dt-tabla-reporte tbody").empty();
        $.each(data, function (i, obj) {
            $("#dt-tabla-reporte tbody").append("<tr>" +
                "<td>" + obj.PK_audio + "</td>" +
                "<td>" + obj.dateCreated + "</td>" +
                "<td>" + obj.fileName + "</td>" +
                "<td>" + obj.duracion + "</td>" +
                "<td>" + obj.filesize + "</td>" +
                "<td>" + obj.transcription + "</td>" +
                "<td>" + obj.porcentaje + "</td>" +
                "<td>" +
                "<button class='btn btn-sm btn-primary btn-round' title='Detalle' data-toggle='modal' data-original-title='detalle' data-target='#ModalEvaluacion' onclick='cargarDetallesEvaluacion(" + obj.PK_audio + ")'>"+
                    "<i class='fal fa-file-archive'></i>"+
                "</button>" +
                "</td>" +
                "</tr>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function cargarDetallesEvaluacion(id) {
    listarEvalSection(id);
    listarEvalRules(id);
    listarEvalDiccionario();
}

function listarEvalSection(PK_Audio) {
    var objEvalBE = new Object();
    objEvalBE.PK_Audio = PK_Audio;

    $.ajax({
        url: '/Reporte/EvaluacionSectionListar',
        data: JSON.stringify(objEvalBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#tableDetailsSeccion tbody").empty();
        if (data.length === 0) {
            $("#tableDetailsSeccion tbody").append("<tr>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "</tr>");
        } else {
            $.each(data, function (i, obj) {
                $("#tableDetailsSeccion tbody").append("<tr>" +
                "<td>" + (i + 1) + "</td>" +
                "<td>" + obj.nom_section + "</td>" +
                "<td>" + obj.descripcion + "</td>" +
                "<td>" + obj.weight + "</td>" +
                "<td>" + obj.porcentaje + "</td>" +
                "</tr>");
            });
        }
        
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function listarEvalRules(PK_Audio) {
    var objEvalBE = new Object();
    objEvalBE.PK_Audio = PK_Audio;

    $.ajax({
        url: '/Reporte/EvaluacionRulesListar',
        data: JSON.stringify(objEvalBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#tableDetailsRule tbody").empty();
        if (data.length === 0) {
            $("#tableDetailsRule tbody").append("<tr>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "<td> - </td>" +
                "</tr>");
        } else {
            $.each(data, function (i, obj) {
                $("#tableDetailsRule tbody").append("<tr>" +
                    "<td>" + (i + 1) + "</td>" +
                    "<td>" + obj.nom_rules + "</td>" +
                    "<td>" + obj.weight + "</td>" +
                    "<td>" + obj.word + "</td>" +
                    "<td>" + obj.porcentaje + "</td>" +
                    "</tr>");
            });
        }
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function listarEvalDiccionario() {
    $.ajax({
        url: '/Reporte/EvaluacionDiccionarioListar',
        data: {},
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#tableDetailsDiccionario tbody").empty();
        $.each(data, function (i, obj) {
            $("#tableDetailsDiccionario tbody").append("<tr>" +
                "<td>" + (i + 1) + "</td>" +
                "<td>" + obj.nom_section + "</td>" +
                "<td>" + obj.nom_rules + "</td>" +
                "<td>" + obj.word + "</td>" +
                "<td>" + obj.weight + "</td>" +
                "</tr>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

