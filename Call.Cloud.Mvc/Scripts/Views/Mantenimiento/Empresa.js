$(document).ready(function () {
    $("#btn_buscar").click(listar);
    $("#btn_registrar").click(registrar);

    listar();
});

function listar() {
    var objEnterpriseBE = new Object();
    objEnterpriseBE.Name = $("#txt_empresa_buscar").val();
    objEnterpriseBE.Estado = $("#eventlog-switch").is(":checked") ? 1 : 0;

    $.ajax({
        url: '/Mantenimiento/EmpresaListar',
        data: JSON.stringify(objEnterpriseBE),
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
                "<a onclick='editar(" + obj.Pk_Enterprise + ",\"" + obj.Name + "\", " + obj.Estado + ");' class='btn btn-warning btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
                "<i class='fal fa-edit'></i>" +
                "</a>" +
                "<a onclick='eliminar(" + obj.Pk_Enterprise + ");' class='btn btn-danger btn-sm btn-icon rounded-circle position-relative js-waves-off'>" +
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
    var objEnterpriseBE = new Object();
    objEnterpriseBE.Pk_Enterprise = $("#txt_codigo").val();
    objEnterpriseBE.Name = $("#txt_empresa").val();
    objEnterpriseBE.Estado = $("#slt_estado").val();

    $.ajax({
        url: '/Mantenimiento/EmpresaRegistrar',
        data: JSON.stringify(objEnterpriseBE),
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
            var objEnterpriseBE = new Object();
            objEnterpriseBE.Pk_Enterprise = codigo;
           
            $.ajax({
                url: '/Mantenimiento/EmpresaEliminar',
                data: JSON.stringify(objEnterpriseBE),
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

function editar(codigo, nombre, estado) {
    $("#txt_codigo").val(codigo);
    $("#txt_empresa").val(nombre);
    $("#slt_estado").val(estado);
    $('#pop-up-registrar').modal('show');
}

function limpiarPopup() {
    $("#txt_codigo").val("0");
    $("#txt_empresa").val("");
    $("#slt_estado").val("1");
}