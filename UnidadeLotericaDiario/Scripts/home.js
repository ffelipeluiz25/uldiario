$(document).ready(function () {
    Eventos();
});

function Eventos() {
    $('#sidebarCollapse').on('click', function () {
        $('#sidebar').toggleClass('active');
        $(this).toggleClass('active');
    });

    $('#divTitulo').on('click', function () {
        ConfiguraVisibilidadeDivs('divBodyHome');
    });

    $('[id*=itemMenu]').on('click', function () {
        var cadNameItemMenu = $(this)[0].id.split('itemMenu');
        ConfiguraVisibilidadeDivs('divBodyCad' + cadNameItemMenu[1]);
    });
}

function ConfiguraVisibilidadeDivs(IdDivBodyShow) {
    $('[id*=divBody]').hide();
    $('#' + IdDivBodyShow).show();
}