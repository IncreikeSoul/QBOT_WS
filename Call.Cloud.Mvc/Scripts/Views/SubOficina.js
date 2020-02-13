$(document).ready(function () {
    $("#btn_buscar").click(listar);
    $("#btn_registrar").click(registrar);
    $("#slt_empresa_buscar").click(comboOficinaBuscar);
    $("#slt_empresa").click(comboOficina);

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

function listar() {
    var objSubOfficeBE = new Object();
    objSubOfficeBE.Pk_Enterprise = $("#slt_empresa_buscar").val();
    objSubOfficeBE.Pk_Office = $("#slt_oficina_buscar").val();
    objSubOfficeBE.nameSubOffice = $("#txt_sub_oficina_buscar").val();
    objSubOfficeBE.Estado = $("#eventlog-switch").is(":checked") ? 1 : 0;

    $.ajax({
        url: '/Mantenimiento/SubOficinaListar',
        data: JSON.stringify(objSubOfficeBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#dt-tabla tbody").empty();
        $.each(data, function (i, obj) {
            $("#dt-tabla tbody").append("<tr>" +
                "<td>" + (i + 1) + "</td>" +
                "<td>" + obj.nameOffice + "</td>" +
                "<td>" + obj.nameSubOffice + "</td>" +
                "<td>" + obj.Tx_Estado + "</td>" +
                "<td>" +
                "<div>" +
                "<a onclick='editar(" + obj.Pk_SubOffice + "," + obj.Pk_Office + "," + obj.Pk_Enterprise + ",\"" + obj.nameSubOffice + "\", " + obj.Estado + ");' class='btn btn-warning btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-edit'></i>" +
                "</a>" +
                "<a onclick='eliminar(" + obj.Pk_SubOffice + ");' class='btn btn-danger btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
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
    var objSubOfficeBE = new Object();
    objSubOfficeBE.Pk_SubOffice = $("#txt_codigo").val();
    objSubOfficeBE.Pk_Office = $("#slt_oficina").val();
    objSubOfficeBE.Pk_Enterprise = $("#slt_empresa").val();
    objSubOfficeBE.nameSubOffice = $("#txt_sub_oficina").val();
    objSubOfficeBE.Estado = $("#slt_estado").val();

    $.ajax({
        url: '/Mantenimiento/SubOficinaRegistrar',
        data: JSON.stringify(objSubOfficeBE),
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
            var objSubOfficeBE = new Object();
            objSubOfficeBE.Pk_SubOffice = codigo;

            $.ajax({
                url: '/Mantenimiento/SubOficinaEliminar',
                data: JSON.stringify(objSubOfficeBE),
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

function editar(codigo, oficina, empresa, nombre, estado) {
    $("#txt_codigo").val(codigo);
    $("#slt_empresa").val(empresa);
    comboOficina();
    $("#slt_oficina").val(oficina);
    $("#txt_sub_oficina").val(nombre);
    $("#slt_estado").val(estado);
    $('#pop-up-registrar').modal('show');
}

function limpiarPopup() {
    $("#txt_codigo").val("0");
    $("#slt_empresa").val("0");
    $("#slt_oficina").val("0");
    $("#txt_sub_oficina").val("");
    $("#slt_estado").val("1");
}