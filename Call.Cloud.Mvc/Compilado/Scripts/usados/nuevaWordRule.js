function iniciarWordRule() {
    $("#ModalWordRule").on("show.bs.modal", ejecutaModalWordRule);
}

function iniciarEditar() {
    $("#item_PkWorldRule").numeric();
}

function grabar() {

    var word = $("#Item_Word").val();
    var sequence = $("#Item_Sequence").val();
    var timeword = $("#Item_TimeWord").val();
    var weight = $("#Item.Weight").val();

    if (word == "") {
        alert("Ingrese Word");
        return false;
    }
    if (timeword == 0) {
        alert("Ingrese TimeWord");
        return false;
    }
    if (weight == 0) {
        alert("Ingrese Weight");
        return false;
    }
    else
        return true;
}

function ejecutaModalWordRule(event) {
    debugger;
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Word Rules");
    var id = button.data('id');
    var rules = button.data('rules');
    var speech = button.data('speech');
    var section = button.data('section');
    var namespeech = button.data('namespeech');
    var namesection = button.data('namesection');
    ObtenerPopUpWordRule(id, rules, speech, section, namespeech,namesection);
    return true;
}

function ObtenerPopUpWordRule(id, rules, speech, section, namespeech,namesection) {
    debugger;
    var urlEditar = rule.Urls.editarWordReglasUrl
    $.ajax({
        url: urlEditar,
        data: {
            id: id,
            rules: rules,
            speech: speech,
            section: section,
            namespeech: namespeech,
            namesection: namesection
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divModalWordRule").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        debugger;
        console.log(data);
    });
    return false;
}
