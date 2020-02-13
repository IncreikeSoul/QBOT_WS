function iniciar() {
    $("#ModalAgent").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};
function iniciarEditar() {
    $("#Item_pk_audio").numeric();
};
function buscar() {
    
    var Audio = {
        PK_Business: $("#Filtro_PK_Business").val(),
        Fk_Boss: $("#Filtro_Fk_Boss").val(),
        PkAgent: $("#Filtro_PkAgent").val(),
        Placa: $("#Filtro_Placa").val()
    };
   
    var urlBuscarAgent = agent.Urls.findAgentUrl;
    
    $.ajax({
        url: urlBuscarAgent,
        data: {
            filtro: Audio
        },

        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        
        console.log(data);
    });
    return false;
}


function Detalle_Audios(id,path,file) {
    var urlEditAgent = agent.Urls.editarAgentUrl;
    $.ajax({
        url: urlEditAgent,
        data: {
            id: id
        },
        type: 'GET'

    }).done(function (data, textStatus, jqXhr) {
        //

        //var filename = path + file;
	var filename = 'http://kontacta.me/listentome/Content/audios/' + file;

        $("#hdnPathAudio").val(filename);
        $("#divModalAudio").html(data);
       
       
       

    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
};
function ejecutaModal(event) {
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Audios");
    var id = button.data('id');
    var path = button.data("url");
    var file = button.data("file");
    
    Detalle_Audios(id, path, file);
    return true;
};
