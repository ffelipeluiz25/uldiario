$(document).ready(function () {
    CarregarTela();
    //document.body.style.zoom = 0.80;
});

function CarregarTela() {
    RecuperaMegaSena();
    RecuperaLotoMania();
    RecuperaLotoFacil();
    RecuperaQuina();
    RecuperaLoteca();
    RecuperaTimeMania();
    RecuperaDuplaSena();
    RecuperaSorteSete();
    RecuperaDiaDeSorte();
}

function RecuperaMegaSena() {
    $.ajax({
        url: '/Home/RecuperarUltimoResultadoMegaSena',
        async: true,
        data: {},
        success: function (retorno) {
            if (retorno.sucesso) {
                switch (retorno.tipo) {
                    case 1://Encontrado resultado na base
                        {
                            $('#txtNumeroConcurso').val(retorno.resultado.NumConcurso);
                            $('#txtDataConcurso').val(retorno.resultado.DatConcurso);
                            var numeros = retorno.resultado.NumSorteados.split('-');
                            $('#txtNumero1').val(numeros[0]);
                            $('#txtNumero2').val(numeros[1]);
                            $('#txtNumero3').val(numeros[2]);
                            $('#txtNumero4').val(numeros[3]);
                            $('#txtNumero5').val(numeros[4]);
                            $('#txtNumero6').val(numeros[5]);
                            $('#txtQtdeGanhadoresSena').val(retorno.resultado.QtdeGanhadoresSena);
                            $('#txtValorGanhadoresSena').val(retorno.resultado.ValorGanhadoresSena.toLocaleString('pt-BR'));
                            $('#txtQtdeGanhadoresQuinta').val(retorno.resultado.QtdeGanhadoresQuina);
                            $('#txtValorGanhadoresQuinta').val(retorno.resultado.ValorGanhadoresQuina.toLocaleString('pt-BR'));
                            $('#txtQtdeGanhadoresQuadra').val(retorno.resultado.QtdeGanhadoresQuadra);
                            $('#txtValorGanhadoresQuadra').val(retorno.resultado.ValorGanhadoresQuadra.toLocaleString('pt-BR'));
                            $('#txtValorAcumulado').val(retorno.resultado.ValorAcumulado.toLocaleString('pt-BR'));
                            break;
                        }
                    case 2://Não encontrado
                        {
                            $.getJSON('https://lotericas.io/api/v1/jogos/megasena/lasted').done(function (retorno) {
                                if (retorno.success) {
                                    resultado = retorno.data[0];
                                    $('#txtNumeroConcurso').val(resultado.concurso);
                                    $('#txtDataConcurso').val(resultado.dataStr);
                                    var numeros = resultado.resultadoOrdenado.split('-');
                                    $('#txtNumero1').val(numeros[0]);
                                    $('#txtNumero2').val(numeros[1]);
                                    $('#txtNumero3').val(numeros[2]);
                                    $('#txtNumero4').val(numeros[3]);
                                    $('#txtNumero5').val(numeros[4]);
                                    $('#txtNumero6').val(numeros[5]);
                                    $('#txtQtdeGanhadoresSena').val(resultado.ganhadores);
                                    $('#txtValorGanhadoresSena').val(resultado.valor.toLocaleString('pt-BR'));
                                    $('#txtQtdeGanhadoresQuinta').val(resultado.ganhadores_quina);
                                    $('#txtValorGanhadoresQuinta').val(resultado.valor_quina.toLocaleString('pt-BR'));
                                    $('#txtQtdeGanhadoresQuadra').val(resultado.ganhadores_quadra);
                                    $('#txtValorGanhadoresQuadra').val(resultado.valor_quadra.toLocaleString('pt-BR'));
                                    $('#txtValorAcumulado').val(resultado.valor_acumulado.toLocaleString('pt-BR'));

                                    var megaSena = {
                                        NumConcurso: resultado.concurso,
                                        DatConcurso: resultado.dataStr,
                                        NumSorteados: resultado.resultadoOrdenado,
                                        QtdeGanhadoresSena: resultado.ganhadores,
                                        ValorGanhadoresSenaTeste: resultado.valor.toLocaleString('pt-BR'),
                                        QtdeGanhadoresQuina: resultado.ganhadores_quina,
                                        ValorGanhadoresQuinaTeste: resultado.valor_quina.toLocaleString('pt-BR'),
                                        QtdeGanhadoresQuadra: resultado.ganhadores_quadra,
                                        ValorGanhadoresQuadraTeste: resultado.valor_quadra.toLocaleString('pt-BR'),
                                        ValorAcumuladoTeste: resultado.valor_acumulado.toLocaleString('pt-BR')
                                    }

                                    $.ajax({
                                        url: '/Home/SalvarResultadoMegaSena',
                                        type: "POST",
                                        async: true,
                                        data: { megaSena },
                                        success: function (resultado) { },
                                        error: function (jqXHR, textStatus, errorThrown) {

                                        }
                                    });
                                }
                            });
                        }
                    default:
                }

            }
            else {
                alert(resultado.mensagem);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function RecuperaLotoMania() {
    //$.ajax({
    //    url: '/Home/RecuperarUltimoResultadoLotoMania',
    //    async: true,
    //    data: {},
    //    success: function (resultado) {
    //        if (resultado.sucesso) {
    //            switch (resultado.tipo) {
    //                case 1://Encontrado resultado na base
    //                    {
    //                        break;
    //                    }
    //                case 2://Não encontrado
    //                    {
    //                        $.getJSON('https://lotericas.io/api/v1/jogos/lotomania/lasted').done(function (retorno) {
    //                            if (retorno.success) {
    //                                resultado = retorno.data[0];

    //                                var lotoMania = {
    //                                    NumConcurso: resultado.concurso,
    //                                    DatConcurso: resultado.dataStr,
    //                                    NumSorteados: resultado.resultadoOrdenado,
    //                                    QtdeGanhadoresSena: resultado.ganhadores,
    //                                    ValorGanhadoresSenaTeste: resultado.valor.toLocaleString('pt-BR'),
    //                                    QtdeGanhadoresQuina: resultado.ganhadores_quina,
    //                                    ValorGanhadoresQuinaTeste: resultado.valor_quina.toLocaleString('pt-BR'),
    //                                    QtdeGanhadoresQuadra: resultado.ganhadores_quadra,
    //                                    ValorGanhadoresQuadraTeste: resultado.valor_quadra.toLocaleString('pt-BR'),
    //                                    ValorAcumuladoTeste: resultado.valor_acumulado.toLocaleString('pt-BR')
    //                                }

    //                                $.ajax({
    //                                    url: '/Home/SalvarResultadoMegaSena',
    //                                    type: "POST",
    //                                    async: true,
    //                                    data: { megaSena },
    //                                    success: function (resultado) { },
    //                                    error: function (jqXHR, textStatus, errorThrown) {

    //                                    }
    //                                });
    //                            }
    //                        });
    //                    }
    //                default:
    //            }

    //        }
    //        else {
    //            alert(resultado.mensagem);
    //        }
    //    },
    //    error: function (jqXHR, textStatus, errorThrown) {

    //    }
    //});
}

function RecuperaLotoFacil() { }
function RecuperaQuina() { }
function RecuperaLoteca() { }
function RecuperaTimeMania() { }
function RecuperaDuplaSena() { }
function RecuperaSorteSete() { }
function RecuperaDiaDeSorte() { }