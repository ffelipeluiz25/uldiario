$(document).ready(function () {
    EventosTela();
});

function EventosTela() {

}

function Entrar() {

    if ($('txtLogin').val()) { }
    if ($('txtSenha').val()) { }

    var modeloLogin = {
        login: $('txtLogin').val(),
        senha: $('txtSenha').val()
    }

    $.ajax({
        url: '/Home/Entrar',
        async: true,
        data: { modeloLogin},
        success: function (resultado) {
            if (resultado.sucesso) {
               
            }
            else
                alert(resultado.mensagem);

        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}