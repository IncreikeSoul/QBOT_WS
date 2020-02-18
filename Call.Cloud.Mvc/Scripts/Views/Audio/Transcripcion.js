$(function () {
    $("#btnTranscriptar").click(function () {
        var objAudioTexto = new Object();
        objAudioTexto.NomDescripcion = $("#txtNombreDesc").val();
        objAudioTexto.nomArchivo = $("#txtArchivo").val();

        $.ajax({
            url: '/Audios/RegistrarDatosByFile',
            data: JSON.stringify(objAudioTexto),
            contentType: "application/json;",
            type: 'POST'
        }).done(function (data, textStatus, jqXhr) {

            alert('Success!!');

        }).fail(function (data, textStatus, jqXhr) {
            alert(data);
        });

    })
});
