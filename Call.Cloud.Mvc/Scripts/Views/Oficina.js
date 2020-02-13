$(document).ready(function () {
    $("#btn_buscar").click(listar);
    $("#btn_registrar").click(registrar);

    listar();
});

function listar() {
    var objOfficeBE = new Object();
    objOfficeBE.Pk_Enterprise = $("#slt_empresa_buscar").val();
    objOfficeBE.Name = $("#txt_oficina_buscar").val();
    objOfficeBE.Estado = $("#eventlog-switch").is(":checked") ? 1 : 0;

    $.ajax({
        url: '/Mantenimiento/OficinaListar',
        data: JSON.stringify(objOfficeBE),
        contentType: "application/json;",
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#dt-tabla tbody").empty();
        $.each(data, function (i, obj) {
            $("#dt-tabla tbody").append("<tr>" +
                "<td>" + (i + 1) + "</td>" +
                "<td>" + obj.Name + "</td>" +
                "<td>" + obj.Tx_Estado + "</td>" +
                "<td>" +
                "<div>" +
                "<a onclick='editar(" + obj.Pk_Office + "," + obj.Pk_Enterprise + ",\"" + obj.Name + "\", " + obj.Estado + ");' class='btn btn-warning btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-edit'></i>" +
                "</a>" +
                "<a onclick='eliminar(" + obj.Pk_Office + ");' class='btn btn-danger btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
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
    var objOfficeBE = new Object();
    objOfficeBE.Pk_Office = $("#txt_codigo").val();
    objOfficeBE.Pk_Enterprise = $("#slt_empresa").val();
    objOfficeBE.Name = $("#txt_oficina").val();
    objOfficeBE.Estado = $("#slt_estado").val();

    $.ajax({
        url: '/Mantenimiento/OficinaRegistrar',
        data: JSON.stringify(objOfficeBE),
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
            var objOfficeBE = new Object();
            objOfficeBE.Pk_Office = codigo;

            $.ajax({
                url: '/Mantenimiento/OficinaEliminar',
                data: JSON.stringify(objOfficeBE),
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

function editar(codigo, empresa, nombre, estado) {
    $("#txt_codigo").val(codigo);
    $("#slt_empresa").val(empresa);
    $("#txt_oficina").val(nombre);
    $("#slt_estado").val(estado);
    $('#pop-up-registrar').modal('show');
}

function limpiarPopup() {
    $("#txt_codigo").val("0");
    $("#slt_empresa").val("0");
    $("#txt_oficina").val("");
    $("#slt_estado").val("1");
}