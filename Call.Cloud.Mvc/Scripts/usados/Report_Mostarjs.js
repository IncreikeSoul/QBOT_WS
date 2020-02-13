
function iniciar() {
    $("#ModalReport").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar01);
};

function iniciar01() {
    $("#ModalReport").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar02);
}
function buscar01() {

    var urlBuscarAgent = Report.Urls.report;

    var parametro = {
        codigoEmpre: $("#Filtro_pk_enterprise").val(),
      
    };
    

    $.ajax({
        url:urlBuscarAgent,
        data: {
            filtro: parametro

        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
}


function buscar02() {

    var urlBuscarAgent = Report.Urls.report01;

    var parametro = {
        codigoEmpre: $("#Filtro_pk_enterprise11").val(),

    };


    $.ajax({
        url: urlBuscarAgent,
        data: {
            filtro: parametro

        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
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