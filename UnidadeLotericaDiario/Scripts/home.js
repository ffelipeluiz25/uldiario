var mobile = false;
$(document).ready(function () {
    Eventos();
    VerificaIsMobile();
    
});

function VerificaIsMobile() {
    if (/Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent)) {
        mobile = true;
    }
}

function Eventos() {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $(this).toggleClass('active');
    });

    $('#btnLogout').on('click', function () {
        $.ajax({
            url: '/Login/Logout',
            data: { },
            type: "POST",
            async: true,
            success: function (retorno) {
                if (retorno.sucesso)
                    window.location.href = '/';
            },
            error: function (jqXHR, textStatus, errorThrown) {
                console.log(jqXHR);
                console.log(textStatus);
                console.log(errorThrown);
            }
        });

    });
    
    
    $('#divTitulo').on('click', function () {
        ConfiguraVisibilidadeDivs('divBodyHome');
    });

    $('[id*=itemMenu]').on('click', function () {
        var cadNameItemMenu = $(this)[0].id.split('itemMenu');
        ConfiguraVisibilidadeDivs('divBodyCad' + cadNameItemMenu[1]);
    });

    $('#itemMenuPainelResultados').on('click', function () {
        if (mobile) { window.location.href = '/painel-resultados-mobile'; } else { window.location.href = '/painel-resultados'; }
    });
}

function ConfiguraVisibilidadeDivs(IdDivBodyShow) {
    $('[id*=divBody]').hide();
    $('#' + IdDivBodyShow).show();
}