/**
 * MENSAJES DE EVENTOS
 * @param {any} resultado
 */

function fnc_resultado_registro(resultado) {
    switch (resultado) {
        case 1: satifactorio("Registro ingresado correctamente."); break;
        case 2: advertencia("Ocurrio un error, por favor intentar nuevamente."); break;
        case 3: peligro("Se perdio la session del usuario, salir y volver a ingresar."); break;
    }
}

function fnc_resultado_actualizar(resultado) {
    switch (resultado) {
        case 1: satifactorio("Registro actualizado correctamente."); break;
        case 2: advertencia("Ocurrio un error, por favor intentar nuevamente."); break;
        case 3: peligro("Se perdio la session del usuario, salir y volver a ingresar."); break;
    }
}

function fnc_resultado_busqueda(resultado) {
    switch (resultado) {
        case 1: satifactorio("Busqueda realizada correctamente."); break;
        case 2: advertencia("Ocurrio un error, por favor intentar nuevamente."); break;
        case 3: peligro("Se perdio la session del usuario, salir y volver a ingresar."); break;
        case 4: advertencia("No se encontraron resultados de la busqueda."); break;
    }
}

/*DATATABLE*/
//DATATABLE POR DEFAULT
var responsiveHelper_dt_basic = undefined;

var breakpointDefinition = {
    tablet: 1024,
    phone: 480
};

function iniciarDatatable(table) {
    $(table).dataTable({
        "sDom": "<'dt-toolbar'<'col-xs-12 col-sm-6'f><'col-sm-6 col-xs-12 hidden-xs'l>r>" +
            "t" +
            "<'dt-toolbar-footer'<'col-sm-6 col-xs-12 hidden-xs'i><'col-xs-12 col-sm-6'p>>",
        "autoWidth": true,
        "oLanguage": {
            "sSearch": '<span class="input-group-addon"><i class="glyphicon glyphicon-search"></i></span>'
        },
        "preDrawCallback": function () {
            // Initialize the responsive datatables helper once.
            if (!responsiveHelper_dt_basic) {
                responsiveHelper_dt_basic = new ResponsiveDatatablesHelper($(table), breakpointDefinition);
            }
        },
        "rowCallback": function (nRow) {
            responsiveHelper_dt_basic.createExpandIcon(nRow);
        },
        "drawCallback": function (oSettings) {
            responsiveHelper_dt_basic.respond();
        }
    });
}

function obtenerFechaActual() {
    var today = new Date();
    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!

    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }
    var today = dd + '/' + mm + '/' + yyyy;
    return today;
}

function formatDecimal(number, decimals) {
    return number.toFixed(decimals);
}

function formatMiles2Decimal(number) {
    return formatMiles(formatDecimal(number, 2));
}

function formatMiles3Decimal(number) {
    return formatMiles(formatDecimal(number, 3));
}

function formatMiles(number) {

    var decimalSeparator = ".";
    var thousandSeparator = ",";

    var result = String(number);

    var parts = result.split(decimalSeparator);

    if (!parts[1]) {
        parts[1] = "00";
    }

    result = parts[0].split("").reverse().join("");

    result = result.replace(/(\d{3}(?!$))/g, "$1" + thousandSeparator);

    parts[0] = result.split("").reverse().join("");

    return parts.join(decimalSeparator);
}

function ajax_download(url, data, input_name) {
    var $iframe,
        iframe_doc,
        iframe_html;

    $('#download_iframe').remove();
    if (($iframe = $('#download_iframe')).length === 0) {
        $iframe = $("<iframe id='download_iframe'" +
            " style='display: none' src='about:blank'></iframe>"
        ).appendTo("body");
    }

    iframe_doc = $iframe[0].contentWindow || $iframe[0].contentDocument;
    if (iframe_doc.document) {
        iframe_doc = iframe_doc.document;
    }

    iframe_html = "<html><head></head><body><form method='POST' action='" + url + "'>";
    $.each(data, function (index, value) {
        iframe_html += "<input type=hidden name='" + index + "' value='" + value + "'/>";
    });
    iframe_html += "</form></body></html>";

    iframe_doc.open();
    iframe_doc.write(iframe_html);
    $(iframe_doc).find('form').submit();
}