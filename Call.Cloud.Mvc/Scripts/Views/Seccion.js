$(document).ready(function () {
    $("#btn_buscar").click(listar);
    $("#btn_registrar").click(registrar);
    $("#slt_empresa_buscar").click(comboOficinaBuscar);
    $("#slt_oficina_buscar").click(comboSubOficinaBuscar);
    $("#slt_sub_oficina_buscar ").click(comboNegocioBuscar);
    $("#slt_negocio_buscar").click(comboSpeechBuscar);
    $("#slt_empresa").click(comboOficina);
    $("#slt_oficina").click(comboSubOficina);
    $("#slt_sub_oficina").click(comboNegocio);
    $("#slt_negocio").click(comboSpeech);

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
    var objNegocioBE = new Object();
    objNegocioBE.PK_Business = $("#slt_negocio_buscar").val();

    $.ajax({
        url: '/Mantenimiento/SpeechListarCombos',
        data: JSON.stringify(objNegocioBE),
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

function comboSpeech() {
    var objNegocioBE = new Object();
    objNegocioBE.PK_Business = $("#slt_negocio").val();

    $.ajax({
        url: '/Mantenimiento/SpeechListarCombos',
        data: JSON.stringify(objNegocioBE),
        contentType: "application/json;",
        type: 'POST',
        async: false
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_speech").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_speech").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboNegocio() {
    var objOficinaBE = new Object();
    objOficinaBE.Pk_SubOffice = $("#slt_sub_oficina").val();

    $.ajax({
        url: '/Mantenimiento/NegocioListarCombos',
        data: JSON.stringify(objOficinaBE),
        contentType: "application/json;",
        type: 'POST',
        async: false
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_negocio").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_negocio").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboOficina() {
    var objEnterpriseBE = new Object();
    objEnterpriseBE.Pk_Enterprise = $("#slt_empresa").val();

    $.ajax({
        url: '/Mantenimiento/OficinaListarCombos',
        data: JSON.stringify(objEnterpriseBE),
        contentType: "application/json;",
        type: 'POST',
        async: false
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_oficina").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_oficina").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function comboSubOficina() {
    var objOficinaBE = new Object();
    objOficinaBE.Pk_Office = $("#slt_oficina").val();

    $.ajax({
        url: '/Mantenimiento/SubOficinaListarCombos',
        data: JSON.stringify(objOficinaBE),
        contentType: "application/json;",
        type: 'POST',
        async: false
    }).done(function (data, textStatus, jqXhr) {
        $("#slt_sub_oficina").html("<option value='0'>-Seleccione-</option>");
        $.each(data, function (i, obj) {
            $("#slt_sub_oficina").append("<option value='" + obj.Value + "'>" + obj.Key + "</option>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function listar() {
    var objSeccionBE = new Object();
    objSeccionBE.PK_Enterprise = $("#slt_empresa_buscar").val();
    objSeccionBE.PK_SubOffice = $("#slt_sub_oficina_buscar").val();
    objSeccionBE.PK_Office = $("#slt_oficina_buscar").val();
    objSeccionBE.PK_Business = $("#slt_oficina_buscar").val();
    objSeccionBE.PK_Speech = $("#slt_speech_buscar").val();
    objSeccionBE.NameSection = $("#txt_seccion_buscar").val();
    objSeccionBE.Estado = $("#eventlog-switch").is(":checked") ? 1 : 0;

    $.ajax({
        url: '/Mantenimiento/SeccionListar',
        data: JSON.stringify(objSeccionBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#dt-tabla tbody").empty();
        $.each(data, function (i, obj) {
            $("#dt-tabla tbody").append("<tr>" +
                "<td>" + (i + 1) + "</td>" +
                //"<td>" + obj.NameOffice + "</td>" +
                //"<td>" + obj.NameSubOffice + "</td>" +
                "<td>" + obj.NameSpeech + "</td>" +
                "<td>" + obj.NameSection + "</td>" +
                "<td>" + obj.Description + "</td>" +
                "<td>" + obj.Tx_Estado + "</td>" +
                "<td>" +
                "<div>" +
                "<a onclick='editar(" + obj.PK_Section + "," + obj.PK_Speech + "," + obj.PK_Business + "," + obj.PK_SubOffice + "," + obj.PK_Office + "," + obj.PK_Enterprise + ",\"" + obj.NameSpeech + "\",\"" + obj.Description + "\", " + obj.Weight + ", " + obj.TMO + ", " + obj.Estado + ");' class='btn btn-warning btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-edit'></i>" +
                "</a>" +
                "<a onclick='eliminar(" + obj.PK_Section + ");' class='btn btn-danger btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-eraser'></i>" +
                "</a>" +
                "</td> " +
                "</tr>");
        });
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function registrar() {
    var objSeccionBE = new Object();
    objSeccionBE.PK_Section = $("#txt_codigo").val();
    objSeccionBE.PK_Speech = $("#slt_speech").val();
    objSeccionBE.NameSection = $("#txt_seccion").val();
    objSeccionBE.Description = $("#txt_descripcion").val();
    objSeccionBE.Weight = $("#txt_peso").val();
    objSeccionBE.TMO = $("#txt_tmo").val();
    objSeccionBE.Estado = $("#slt_estado").val();

    $.ajax({
        url: '/Mantenimiento/SeccionRegistrar',
        data: JSON.stringify(objSeccionBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        if (data) {
            $('#pop-up-registrar').modal('hide');
            bootbox.alert("Registro realizado correctamente.");
            listar();
        }
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
}

function eliminar(codigo) {
    bootbox.confirm("¿Esta seguro que desea eliminar el registro?", function (r) {
        if (r) {
            var objSeccionBE = new Object();
            objSeccionBE.PK_Section = codigo;

            $.ajax({
                url: '/Mantenimiento/SeccionEliminar',
                data: JSON.stringify(objSeccionBE),
                contentType: "application/json;",
                type: 'POST'
            }).done(function (data, textStatus, jqXhr) {
                if (data) {
                    bootbox.alert("Eliminación realizada correctamente.");
                    listar();
                }
            }).fail(function (data, textStatus, jqXhr) {
                console.log(data);
            });
        }
    });
}

function editar(codigo, speech, negocio, suboficina, oficina, empresa, nombre, descripcion, peso, tmo, estado) {
    $("#txt_codigo").val(codigo);
    $("#slt_empresa").val(empresa);
    comboOficina();
    $("#slt_oficina").val(oficina);
    comboSubOficina();
    $("#slt_sub_oficina").val(suboficina);
    comboNegocio();
    $("#slt_negocio").val(negocio);
    comboSpeech();
    $("#slt_speech").val(speech);
    $("#txt_seccion").val(nombre);
    $("#txt_descripcion").val(descripcion);
    $("#txt_peso").val(peso);
    $("#txt_tmo").val(tmo);
    $("#slt_estado").val(estado);
    $('#pop-up-registrar').modal('show');
}

function limpiarPopup() {
    $("#txt_codigo").val("0");
    $("#slt_empresa").val("0");
    $("#slt_oficina").val("0");
    $("#slt_sub_oficina").val("0");
    $("#txt_negocio").val("");
    $("#slt_estado").val("1");
}