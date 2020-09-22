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
    objNegocioBE.PK_Business = $("#slt_negocio_buscar").val();
    objNegocioBE.NameSpeech = $("#txt_speech_buscar").val();
    objNegocioBE.Estado = $("#eventlog-switch").is(":checked") ? 1 : 0;
    console.log("Pk_Enterprise: " + objNegocioBE.Pk_Enterprise + "| Pk_Office: " + objNegocioBE.Pk_Office);

    $.ajax({
        url: '/Mantenimiento/SpeechListar',
        data: JSON.stringify(objNegocioBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#dt-tabla tbody").empty();
        $.each(data, function (i, obj) {
            $("#dt-tabla tbody").append("<tr>" +
                "<td>" + (i + 1) + "</td>" +
                //"<td>" + obj.NameOffice + "</td>" +
                //"<td>" + obj.NameSubOffice + "</td>" +
                "<td>" + obj.NameBusiness + "</td>" +
                "<td>" + obj.NameSpeech + "</td>" +
                "<td>" + obj.Description + "</td>" +
                "<td>" + obj.Tx_Estado + "</td>" +
                "<td>" +
                "<div>" +
                "<a onclick='editar(" + obj.PK_Speech + "," + obj.PK_Business + "," + obj.PK_SubOffice + "," + obj.PK_Office + "," + obj.PK_Enterprise + ",\"" + obj.NameSpeech + "\",\"" + obj.Description + "\", " + obj.Estado + ");' class='btn btn-warning btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-edit'></i>" +
                "</a>" +
                "<a onclick='eliminar(" + obj.PK_Speech + ");' class='btn btn-danger btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-eraser'></i>" +
                "</a>" +
                "</td> " +
                "</tr>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

