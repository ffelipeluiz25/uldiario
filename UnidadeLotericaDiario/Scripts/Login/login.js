$(document).ready(function () {
    Eventos();
    VerificarUsuarioLogado();
});

function VerificarUsuarioLogado() {
    $.ajax({
        url: '/Login/VerificarUsuarioLogado',
        async: true,
        data: {},
        type: "POST",
        success: function (retorno) {
            if (retorno.sucesso)
                window.location.href = '/home';
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log(jqXHR);
            console.log(textStatus);
            console.log(errorThrown);
        }
    });
}

function Eventos() {

    $('#btnEntrar').on('click', function (e) {
        var modelo = {
            Login: $('#txtLogin').val(),
            Senha: $('#txtSenha').val()
        }
        $.ajax({
            url: '/Login/Logar',
            data: { modelo },
            type: "POST",
            async: true,
            success: function (retorno) {
                if (retorno.sucesso) 
                    window.location.href = '/home';
                else
                    alert(retorno.mensagem);
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            }
        });
    });

}