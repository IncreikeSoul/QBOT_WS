$(document).ready(function () {
    $("#btn_buscar").click(listar);
    $("#btn_registrar").click(registrar);
    $("#slt_empresa_buscar").click(comboOficinaBuscar);
    $("#slt_oficina_buscar").click(comboSubOficinaBuscar);
    $("#slt_sub_oficina_buscar ").click(comboNegocioBuscar); 
    $("#slt_empresa").click(comboOficina);
    $("#slt_oficina").click(comboSubOficina);
    $("#slt_sub_oficina").click(comboNegocio); 

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
    var objNegocioBE = new Object();
    objNegocioBE.Pk_Enterprise = $("#slt_empresa_buscar").val();
    objNegocioBE.Pk_SubOffice = $("#slt_sub_oficina_buscar").val();
    objNegocioBE.Pk_Office = $("#slt_oficina_buscar").val();
    objNegocioBE.PK_Business = $("#slt_negocio_buscar").val();
    objNegocioBE.NameSpeech = $("#txt_speech_buscar").val();
    objNegocioBE.Estado = $("#eventlog-switch").is(":checked") ? 1 : 0;
    
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

function registrar() {
    var objSpeechBE = new Object();
    objSpeechBE.PK_Speech = $("#txt_codigo").val();
    objSpeechBE.PK_Business = $("#slt_negocio").val();
    objSpeechBE.NameSpeech = $("#txt_speech").val();
    objSpeechBE.Description = $("#txt_descripcion").val();
    objSpeechBE.Estado = $("#slt_estado").val();

    $.ajax({
        url: '/Mantenimiento/SpeechRegistrar',
        data: JSON.stringify(objSpeechBE),
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
            var objSpeechBE = new Object();
            objSpeechBE.PK_Speech = codigo;

            $.ajax({
                url: '/Mantenimiento/SpeechEliminar',
                data: JSON.stringify(objSpeechBE),
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

function editar(codigo, negocio, suboficina, oficina, empresa, nombre, descripcion, estado) {
    $("#txt_codigo").val(codigo);
    $("#slt_empresa").val(empresa);
    comboOficina();
    $("#slt_oficina").val(oficina);
    comboSubOficina();
    $("#slt_sub_oficina").val(suboficina);
    comboNegocio();
    $("#slt_negocio").val(negocio);
    $("#txt_speech").val(nombre);
    $("#txt_descripcion").val(descripcion);
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