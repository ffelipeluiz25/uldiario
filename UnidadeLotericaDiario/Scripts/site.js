var urlBase = 'https://lotericas.io/api/v1/jogos';
$(document).ready(function () {
    CarregarTela();
    document.getElementById('container').style.zoom = 0.3;
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
    $.getJSON(urlBase + '/megasena/lasted').done(function (retornoLasted) {
        if (retornoLasted.success) {
            $.ajax({
                url: '/Home/RecuperarUltimoResultadoMegaSena',
                async: true,
                data: {},
                success: function (retorno) {
                    if (retorno.sucesso) {
                        if (retorno.tipo == 1) {
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso) {
                                RecuperaUltimoESalvaMegaSena(retornoLasted.data[0]);
                            }
                            else {
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
                                $('#txtValorGanhadoresSena').val(retorno.resultado.ValorGanhadoresSena);
                                $('#txtQtdeGanhadoresQuinta').val(retorno.resultado.QtdeGanhadoresQuina);
                                $('#txtValorGanhadoresQuinta').val(retorno.resultado.ValorGanhadoresQuina);
                                $('#txtQtdeGanhadoresQuadra').val(retorno.resultado.QtdeGanhadoresQuadra);
                                $('#txtValorGanhadoresQuadra').val(retorno.resultado.ValorGanhadoresQuadra);
                                $('#txtValorAcumulado').val(retorno.resultado.ValorAcumulado);
                            }
                        }
                        else {
                            RecuperaUltimoESalvaMegaSena(retornoLasted.data[0]);
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
    });
}

function RecuperaUltimoESalvaMegaSena(resultado) {
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
        ValorGanhadoresSena: resultado.valor.toLocaleString('pt-BR'),
        QtdeGanhadoresQuina: resultado.ganhadores_quina,
        ValorGanhadoresQuina: resultado.valor_quina.toLocaleString('pt-BR'),
        QtdeGanhadoresQuadra: resultado.ganhadores_quadra,
        ValorGanhadoresQuadra: resultado.valor_quadra.toLocaleString('pt-BR'),
        ValorAcumulado: resultado.valor_acumulado.toLocaleString('pt-BR')
    }
    $.ajax({
        url: '/Home/SalvarResultadoMegaSena',
        type: "POST",
        async: true,
        data: { megaSena },
        success: function (resultado) {
            if (!resultado.sucesso)
                console.log(resultado.mensagem);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function RecuperaLotoMania() {
    $.getJSON(urlBase + '/lotomania/lasted').done(function (retornoLasted) {
        if (retornoLasted.success) {
            $.ajax({
                url: '/Home/RecuperarUltimoResultadoLotoMania',
                async: true,
                data: {},
                success: function (retorno) {
                    if (retorno.sucesso) {
                        if (retorno.tipo == 1) {
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso) {
                                RecuperaUltimoESalvaLotoMania(retornoLasted.data[0]);
                            }
                            else {
                                $('#txtNumConcursoLotomania').val(retorno.resultado.NumConcurso);
                                $('#txtDataConcursoLotomania').val(retorno.resultado.DatConcurso);
                                var numeros = retorno.resultado.NumSorteados.split('-');
                                $('#txtNum1Lotomania').val(numeros[0]);
                                $('#txtNum2Lotomania').val(numeros[1]);
                                $('#txtNum3Lotomania').val(numeros[2]);
                                $('#txtNum4Lotomania').val(numeros[3]);
                                $('#txtNum5Lotomania').val(numeros[4]);
                                $('#txtNum6Lotomania').val(numeros[5]);
                                $('#txtNum7Lotomania').val(numeros[6]);
                                $('#txtNum8Lotomania').val(numeros[7]);
                                $('#txtNum9Lotomania').val(numeros[8]);
                                $('#txtNum10Lotomania').val(numeros[9]);
                                $('#txtNum11Lotomania').val(numeros[10]);
                                $('#txtNum12Lotomania').val(numeros[11]);
                                $('#txtNum13Lotomania').val(numeros[12]);
                                $('#txtNum14Lotomania').val(numeros[13]);
                                $('#txtNum15Lotomania').val(numeros[14]);
                                $('#txtNum16Lotomania').val(numeros[15]);
                                $('#txtNum17Lotomania').val(numeros[16]);
                                $('#txtNum18Lotomania').val(numeros[17]);
                                $('#txtNum19Lotomania').val(numeros[18]);
                                $('#txtNum20Lotomania').val(numeros[19]);
                                $('#txtNum21Lotomania').val(numeros[20]);
                                $('#txtNum22Lotomania').val(numeros[21]);
                                $('#txtNum23Lotomania').val(numeros[22]);
                                $('#txtNum24Lotomania').val(numeros[23]);
                                $('#txtGanhadores20Lotomania').val(retorno.resultado.QtdeGanhadores20pts);
                                $('#txtValor20Lotomania').val(retorno.resultado.ValorGanhadores20pts);
                                $('#txtGanhadores19Lotomania').val(retorno.resultado.QtdeGanhadores19pts);
                                $('#txtValor19Lotomania').val(retorno.resultado.ValorGanhadores19pts);
                                $('#txtGanhadores18Lotomania').val(retorno.resultado.QtdeGanhadores18pts);
                                $('#txtValor18Lotomania').val(retorno.resultado.ValorGanhadores18pts);
                                $('#txtGanhadores17Lotomania').val(retorno.resultado.QtdeGanhadores17pts);
                                $('#txtValor17Lotomania').val(retorno.resultado.ValorGanhadores17pts);
                                $('#txtGanhadores16Lotomania').val(retorno.resultado.QtdeGanhadores16pts);
                                $('#txtValor16Lotomania').val(retorno.resultado.ValorGanhadores16pts);
                                $('#txtGanhadores15Lotomania').val(retorno.resultado.QtdeGanhadores15pts);
                                $('#txtValor15Lotomania').val(retorno.resultado.ValorGanhadores15pts);
                                $('#txtGanhadores0Lotomania').val(retorno.resultado.QtdeGanhadores0pts);
                                $('#txtValor0Lotomania').val(retorno.resultado.ValorGanhadores0pts);
                                $('#txtValorAcumuladoLotomania').val(retorno.resultado.ValorAcumulado);
                            }
                        }
                        else {
                            RecuperaUltimoESalvaLotoMania(retornoLasted.data[0]);
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
    });
}

function RecuperaUltimoESalvaLotoMania(resultado) {
    $('#txtNumConcursoLotomania').val(resultado.concurso);
    $('#txtDataConcursoLotomania').val(resultado.dtApuracaoStr);
    var numeros = resultado.resultadoOrdenado.split('-');
    $('#txtNum1Lotomania').val(numeros[0]);
    $('#txtNum2Lotomania').val(numeros[1]);
    $('#txtNum3Lotomania').val(numeros[2]);
    $('#txtNum4Lotomania').val(numeros[3]);
    $('#txtNum5Lotomania').val(numeros[4]);
    $('#txtNum6Lotomania').val(numeros[5]);
    $('#txtNum7Lotomania').val(numeros[6]);
    $('#txtNum8Lotomania').val(numeros[7]);
    $('#txtNum9Lotomania').val(numeros[8]);
    $('#txtNum10Lotomania').val(numeros[9]);
    $('#txtNum11Lotomania').val(numeros[10]);
    $('#txtNum12Lotomania').val(numeros[11]);
    $('#txtNum13Lotomania').val(numeros[12]);
    $('#txtNum14Lotomania').val(numeros[13]);
    $('#txtNum15Lotomania').val(numeros[14]);
    $('#txtNum16Lotomania').val(numeros[15]);
    $('#txtNum17Lotomania').val(numeros[16]);
    $('#txtNum18Lotomania').val(numeros[17]);
    $('#txtNum19Lotomania').val(numeros[18]);
    $('#txtNum20Lotomania').val(numeros[19]);
    $('#txtNum21Lotomania').val(numeros[20]);
    $('#txtNum22Lotomania').val(numeros[21]);
    $('#txtNum23Lotomania').val(numeros[22]);
    $('#txtNum24Lotomania').val(numeros[23]);
    $('#txtGanhadores20Lotomania').val(resultado.qtGanhadoresFaixa1);
    $('#txtValor20Lotomania').val(resultado.vrRateioFaixa1.toLocaleString('pt-BR'));
    $('#txtGanhadores19Lotomania').val(resultado.qtGanhadoresFaixa2);
    $('#txtValor19Lotomania').val(resultado.vrRateioFaixa2.toLocaleString('pt-BR'));
    $('#txtGanhadores18Lotomania').val(resultado.qtGanhadoresFaixa3);
    $('#txtValor18Lotomania').val(resultado.vrRateioFaixa3.toLocaleString('pt-BR'));
    $('#txtGanhadores17Lotomania').val(resultado.qtGanhadoresFaixa4);
    $('#txtValor17Lotomania').val(resultado.vrRateioFaixa4.toLocaleString('pt-BR'));
    $('#txtGanhadores16Lotomania').val(resultado.qtGanhadoresFaixa5);
    $('#txtValor16Lotomania').val(resultado.vrRateioFaixa5.toLocaleString('pt-BR'));
    //Resultados invertidos
    $('#txtGanhadores15Lotomania').val(resultado.qtGanhadoresFaixa7);
    $('#txtValor15Lotomania').val(resultado.vrRateioFaixa7.toLocaleString('pt-BR'));
    $('#txtGanhadores0Lotomania').val(resultado.qtGanhadoresFaixa6);
    $('#txtValor0Lotomania').val(resultado.vrRateioFaixa6.toLocaleString('pt-BR'));
    //Resultados invertidos

    $('#txtValorAcumuladoLotomania').val(resultado.vrEstimativa.toLocaleString('pt-BR'));
    var lotomania = {
        NumConcurso: resultado.concurso,
        DatConcurso: resultado.dtApuracaoStr,
        NumSorteados: resultado.resultadoOrdenado,
        QtdeGanhadores20pts: resultado.qtGanhadoresFaixa1,
        ValorGanhadores20pts: resultado.vrRateioFaixa1.toLocaleString('pt-BR'),
        QtdeGanhadores19pts: resultado.qtGanhadoresFaixa2,
        ValorGanhadores19pts: resultado.vrRateioFaixa2.toLocaleString('pt-BR'),
        QtdeGanhadores18pts: resultado.qtGanhadoresFaixa3,
        ValorGanhadores18pts: resultado.vrRateioFaixa3.toLocaleString('pt-BR'),
        QtdeGanhadores17pts: resultado.qtGanhadoresFaixa4,
        ValorGanhadores17pts: resultado.vrRateioFaixa4.toLocaleString('pt-BR'),
        QtdeGanhadores16pts: resultado.qtGanhadoresFaixa5,
        ValorGanhadores16pts: resultado.vrRateioFaixa5.toLocaleString('pt-BR'),
        QtdeGanhadores15pts: resultado.qtGanhadoresFaixa7,   //Resultados invertidos
        ValorGanhadores15pts: resultado.vrRateioFaixa7.toLocaleString('pt-BR'),   //Resultados invertidos
        QtdeGanhadores0pts: resultado.qtGanhadoresFaixa6,   //Resultados invertidos
        ValorGanhadores0pts: resultado.vrRateioFaixa6.toLocaleString('pt-BR'),   //Resultados invertidos
        ValorAcumulado: resultado.vrEstimativa.toLocaleString('pt-BR')
    }
    $.ajax({
        url: '/Home/SalvarResultadoLotoMania',
        type: "POST",
        async: true,
        data: { lotomania },
        success: function (resultado) {
            if (!resultado.sucesso)
                console.log(resultado.mensagem);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function RecuperaLotoFacil() {
    $.getJSON(urlBase + '/lotofacil/lasted').done(function (retornoLasted) {
        if (retornoLasted.success) {
            $.ajax({
                url: '/Home/RecuperarUltimoResultadoLotoFacil',
                async: true,
                data: {},
                success: function (retorno) {
                    if (retorno.sucesso) {
                        if (retorno.tipo == 1) {
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso) {
                                RecuperaUltimoESalvaLotoFacil(retornoLasted.data[0]);
                            }
                            else {
                                $('#txtNumConcursoLotomania').val(retorno.resultado.NumConcurso);
                                $('#txtDataConcursoLotomania').val(retorno.resultado.DatConcurso);
                                var numeros = retorno.resultado.NumSorteados.split('-');
                                $('#txtNum1Lotomania').val(numeros[0]);
                                $('#txtNum2Lotomania').val(numeros[1]);
                                $('#txtNum3Lotomania').val(numeros[2]);
                                $('#txtNum4Lotomania').val(numeros[3]);
                                $('#txtNum5Lotomania').val(numeros[4]);
                                $('#txtNum6Lotomania').val(numeros[5]);
                                $('#txtNum7Lotomania').val(numeros[6]);
                                $('#txtNum8Lotomania').val(numeros[7]);
                                $('#txtNum9Lotomania').val(numeros[8]);
                                $('#txtNum10Lotomania').val(numeros[9]);
                                $('#txtNum11Lotomania').val(numeros[10]);
                                $('#txtNum12Lotomania').val(numeros[11]);
                                $('#txtNum13Lotomania').val(numeros[12]);
                                $('#txtNum14Lotomania').val(numeros[13]);
                                $('#txtNum15Lotomania').val(numeros[14]);
                                $('#txtNum16Lotomania').val(numeros[15]);
                                $('#txtNum17Lotomania').val(numeros[16]);
                                $('#txtNum18Lotomania').val(numeros[17]);
                                $('#txtNum19Lotomania').val(numeros[18]);
                                $('#txtNum20Lotomania').val(numeros[19]);
                                $('#txtNum21Lotomania').val(numeros[20]);
                                $('#txtNum22Lotomania').val(numeros[21]);
                                $('#txtNum23Lotomania').val(numeros[22]);
                                $('#txtNum24Lotomania').val(numeros[23]);
                                $('#txtGanhadores20Lotomania').val(retorno.resultado.QtdeGanhadores20pts);
                                $('#txtValor20Lotomania').val(retorno.resultado.ValorGanhadores20pts);
                                $('#txtGanhadores19Lotomania').val(retorno.resultado.QtdeGanhadores19pts);
                                $('#txtValor19Lotomania').val(retorno.resultado.ValorGanhadores19pts);
                                $('#txtGanhadores18Lotomania').val(retorno.resultado.QtdeGanhadores18pts);
                                $('#txtValor18Lotomania').val(retorno.resultado.ValorGanhadores18pts);
                                $('#txtGanhadores17Lotomania').val(retorno.resultado.QtdeGanhadores17pts);
                                $('#txtValor17Lotomania').val(retorno.resultado.ValorGanhadores17pts);
                                $('#txtGanhadores16Lotomania').val(retorno.resultado.QtdeGanhadores16pts);
                                $('#txtValor16Lotomania').val(retorno.resultado.ValorGanhadores16pts);
                                $('#txtGanhadores15Lotomania').val(retorno.resultado.QtdeGanhadores15pts);
                                $('#txtValor15Lotomania').val(retorno.resultado.ValorGanhadores15pts);
                                $('#txtGanhadores0Lotomania').val(retorno.resultado.QtdeGanhadores0pts);
                                $('#txtValor0Lotomania').val(retorno.resultado.ValorGanhadores0pts);
                                $('#txtValorAcumuladoLotomania').val(retorno.resultado.ValorAcumulado);
                            }
                        }
                        else {
                            RecuperaUltimoESalvaLotoFacil(retornoLasted.data[0]);
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
    });
}

function RecuperaUltimoESalvaLotoFacil() {
    $('#txtNumConcursoLotomania').val(resultado.concurso);
    $('#txtDataConcursoLotomania').val(resultado.dtApuracaoStr);
    var numeros = resultado.resultadoOrdenado.split('-');
    $('#txtNum1Lotomania').val(numeros[0]);
    $('#txtNum2Lotomania').val(numeros[1]);
    $('#txtNum3Lotomania').val(numeros[2]);
    $('#txtNum4Lotomania').val(numeros[3]);
    $('#txtNum5Lotomania').val(numeros[4]);
    $('#txtNum6Lotomania').val(numeros[5]);
    $('#txtNum7Lotomania').val(numeros[6]);
    $('#txtNum8Lotomania').val(numeros[7]);
    $('#txtNum9Lotomania').val(numeros[8]);
    $('#txtNum10Lotomania').val(numeros[9]);
    $('#txtNum11Lotomania').val(numeros[10]);
    $('#txtNum12Lotomania').val(numeros[11]);
    $('#txtNum13Lotomania').val(numeros[12]);
    $('#txtNum14Lotomania').val(numeros[13]);
    $('#txtNum15Lotomania').val(numeros[14]);
    $('#txtNum16Lotomania').val(numeros[15]);
    $('#txtNum17Lotomania').val(numeros[16]);
    $('#txtNum18Lotomania').val(numeros[17]);
    $('#txtNum19Lotomania').val(numeros[18]);
    $('#txtNum20Lotomania').val(numeros[19]);
    $('#txtNum21Lotomania').val(numeros[20]);
    $('#txtNum22Lotomania').val(numeros[21]);
    $('#txtNum23Lotomania').val(numeros[22]);
    $('#txtNum24Lotomania').val(numeros[23]);
    $('#txtGanhadores20Lotomania').val(resultado.qtGanhadoresFaixa1);
    $('#txtValor20Lotomania').val(resultado.vrRateioFaixa1.toLocaleString('pt-BR'));
    $('#txtGanhadores19Lotomania').val(resultado.qtGanhadoresFaixa2);
    $('#txtValor19Lotomania').val(resultado.vrRateioFaixa2.toLocaleString('pt-BR'));
    $('#txtGanhadores18Lotomania').val(resultado.qtGanhadoresFaixa3);
    $('#txtValor18Lotomania').val(resultado.vrRateioFaixa3.toLocaleString('pt-BR'));
    $('#txtGanhadores17Lotomania').val(resultado.qtGanhadoresFaixa4);
    $('#txtValor17Lotomania').val(resultado.vrRateioFaixa4.toLocaleString('pt-BR'));
    $('#txtGanhadores16Lotomania').val(resultado.qtGanhadoresFaixa5);
    $('#txtValor16Lotomania').val(resultado.vrRateioFaixa5.toLocaleString('pt-BR'));
    //Resultados invertidos
    $('#txtGanhadores15Lotomania').val(resultado.qtGanhadoresFaixa7);
    $('#txtValor15Lotomania').val(resultado.vrRateioFaixa7.toLocaleString('pt-BR'));
    $('#txtGanhadores0Lotomania').val(resultado.qtGanhadoresFaixa6);
    $('#txtValor0Lotomania').val(resultado.vrRateioFaixa6.toLocaleString('pt-BR'));
    //Resultados invertidos

    $('#txtValorAcumuladoLotomania').val(resultado.vrEstimativa.toLocaleString('pt-BR'));
    var lotomania = {
        NumConcurso: resultado.concurso,
        DatConcurso: resultado.dtApuracaoStr,
        NumSorteados: resultado.resultadoOrdenado,
        QtdeGanhadores20pts: resultado.qtGanhadoresFaixa1,
        ValorGanhadores20pts: resultado.vrRateioFaixa1.toLocaleString('pt-BR'),
        QtdeGanhadores19pts: resultado.qtGanhadoresFaixa2,
        ValorGanhadores19pts: resultado.vrRateioFaixa2.toLocaleString('pt-BR'),
        QtdeGanhadores18pts: resultado.qtGanhadoresFaixa3,
        ValorGanhadores18pts: resultado.vrRateioFaixa3.toLocaleString('pt-BR'),
        QtdeGanhadores17pts: resultado.qtGanhadoresFaixa4,
        ValorGanhadores17pts: resultado.vrRateioFaixa4.toLocaleString('pt-BR'),
        QtdeGanhadores16pts: resultado.qtGanhadoresFaixa5,
        ValorGanhadores16pts: resultado.vrRateioFaixa5.toLocaleString('pt-BR'),
        QtdeGanhadores15pts: resultado.qtGanhadoresFaixa7,   //Resultados invertidos
        ValorGanhadores15pts: resultado.vrRateioFaixa7.toLocaleString('pt-BR'),   //Resultados invertidos
        QtdeGanhadores0pts: resultado.qtGanhadoresFaixa6,   //Resultados invertidos
        ValorGanhadores0pts: resultado.vrRateioFaixa6.toLocaleString('pt-BR'),   //Resultados invertidos
        ValorAcumulado: resultado.vrEstimativa.toLocaleString('pt-BR')
    }
    $.ajax({
        url: '/Home/SalvarResultadoLotoMania',
        type: "POST",
        async: true,
        data: { lotomania },
        success: function (resultado) {
            if (!resultado.sucesso)
                console.log(resultado.mensagem);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function RecuperaQuina() { }
function RecuperaLoteca() { }
function RecuperaTimeMania() { }
function RecuperaDuplaSena() { }
function RecuperaSorteSete() { }
function RecuperaDiaDeSorte() { }