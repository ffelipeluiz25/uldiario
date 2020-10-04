var urlBase = 'https://lotericas.io/api/v1/jogos';
$(document).ready(function () {
    CarregarTela();
});

function FormataValoresCom1CasaDecimal(valor) {
    var valorFormatado = '';
    var splitValor = valor.split(',');
    if (splitValor.length > 1 && splitValor[1] != null) {
        var centavos = splitValor[1];
        if (centavos.length == 1) {
            valorFormatado = valor + "0";
            return valorFormatado;
        }
    }
    return valor;
}

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
                                $('#txtValorGanhadoresSena').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresSena));
                                $('#txtQtdeGanhadoresQuinta').val(retorno.resultado.QtdeGanhadoresQuina);
                                $('#txtValorGanhadoresQuinta').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresQuina));
                                $('#txtQtdeGanhadoresQuadra').val(retorno.resultado.QtdeGanhadoresQuadra);
                                $('#txtValorGanhadoresQuadra').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresQuadra));
                                $('#txtValorAcumulado').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado));
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
    $('#txtValorGanhadoresSena').val(FormataValoresCom1CasaDecimal(resultado.valor.toLocaleString('pt-BR')));
    $('#txtQtdeGanhadoresQuinta').val(resultado.ganhadores_quina);
    $('#txtValorGanhadoresQuinta').val(FormataValoresCom1CasaDecimal(resultado.valor_quina.toLocaleString('pt-BR')));
    $('#txtQtdeGanhadoresQuadra').val(resultado.ganhadores_quadra);
    $('#txtValorGanhadoresQuadra').val(FormataValoresCom1CasaDecimal(resultado.valor_quadra.toLocaleString('pt-BR')));
    $('#txtValorAcumulado').val(FormataValoresCom1CasaDecimal(resultado.valor_acumulado.toLocaleString('pt-BR')));
    var megaSena = {
        NumConcurso: resultado.concurso,
        DatConcurso: resultado.dataStr,
        NumSorteados: resultado.resultadoOrdenado,
        QtdeGanhadoresSena: resultado.ganhadores,
        ValorGanhadoresSena: FormataValoresCom1CasaDecimal(resultado.valor.toLocaleString('pt-BR')),
        QtdeGanhadoresQuina: resultado.ganhadores_quina,
        ValorGanhadoresQuina: FormataValoresCom1CasaDecimal(resultado.valor_quina.toLocaleString('pt-BR')),
        QtdeGanhadoresQuadra: resultado.ganhadores_quadra,
        ValorGanhadoresQuadra: FormataValoresCom1CasaDecimal(resultado.valor_quadra.toLocaleString('pt-BR')),
        ValorAcumulado: FormataValoresCom1CasaDecimal(resultado.valor_acumulado.toLocaleString('pt-BR'))
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
                                $('#txtGanhadores20Lotomania').val(retorno.resultado.QtdeGanhadores20pts);
                                $('#txtValor20Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores20pts));
                                $('#txtGanhadores19Lotomania').val(retorno.resultado.QtdeGanhadores19pts);
                                $('#txtValor19Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores19pts));
                                $('#txtGanhadores18Lotomania').val(retorno.resultado.QtdeGanhadores18pts);
                                $('#txtValor18Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores18pts));
                                $('#txtGanhadores17Lotomania').val(retorno.resultado.QtdeGanhadores17pts);
                                $('#txtValor17Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores17pts));
                                $('#txtGanhadores16Lotomania').val(retorno.resultado.QtdeGanhadores16pts);
                                $('#txtValor16Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores16pts));
                                $('#txtGanhadores15Lotomania').val(retorno.resultado.QtdeGanhadores15pts);
                                $('#txtValor15Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores15pts));
                                $('#txtGanhadores0Lotomania').val(retorno.resultado.QtdeGanhadores0pts);
                                $('#txtValor0Lotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores0pts));
                                $('#txtValorAcumuladoLotomania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado));
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
    $('#txtGanhadores20Lotomania').val(resultado.qtGanhadoresFaixa1);
    $('#txtValor20Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa1.toLocaleString('pt-BR')));
    $('#txtGanhadores19Lotomania').val(resultado.qtGanhadoresFaixa2);
    $('#txtValor19Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa2.toLocaleString('pt-BR')));
    $('#txtGanhadores18Lotomania').val(resultado.qtGanhadoresFaixa3);
    $('#txtValor18Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa3.toLocaleString('pt-BR')));
    $('#txtGanhadores17Lotomania').val(resultado.qtGanhadoresFaixa4);
    $('#txtValor17Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa4.toLocaleString('pt-BR')));
    $('#txtGanhadores16Lotomania').val(resultado.qtGanhadoresFaixa5);
    $('#txtValor16Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa5.toLocaleString('pt-BR')));
    //Resultados invertidos
    $('#txtGanhadores15Lotomania').val(resultado.qtGanhadoresFaixa7);
    $('#txtValor15Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa7.toLocaleString('pt-BR')));
    $('#txtGanhadores0Lotomania').val(resultado.qtGanhadoresFaixa6);
    $('#txtValor0Lotomania').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa6.toLocaleString('pt-BR')));
    //Resultados invertidos

    $('#txtValorAcumuladoLotomania').val(resultado.vrEstimativa.toLocaleString('pt-BR'));
    var lotomania = {
        NumConcurso: resultado.concurso,
        DatConcurso: resultado.dtApuracaoStr,
        NumSorteados: resultado.resultadoOrdenado,
        QtdeGanhadores20pts: resultado.qtGanhadoresFaixa1,
        ValorGanhadores20pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa1.toLocaleString('pt-BR')),
        QtdeGanhadores19pts: resultado.qtGanhadoresFaixa2,
        ValorGanhadores19pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa2.toLocaleString('pt-BR')),
        QtdeGanhadores18pts: resultado.qtGanhadoresFaixa3,
        ValorGanhadores18pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa3.toLocaleString('pt-BR')),
        QtdeGanhadores17pts: resultado.qtGanhadoresFaixa4,
        ValorGanhadores17pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa4.toLocaleString('pt-BR')),
        QtdeGanhadores16pts: resultado.qtGanhadoresFaixa5,
        ValorGanhadores16pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa5.toLocaleString('pt-BR')),
        QtdeGanhadores15pts: resultado.qtGanhadoresFaixa7,   //Resultados invertidos
        ValorGanhadores15pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa7.toLocaleString('pt-BR')),   //Resultados invertidos
        QtdeGanhadores0pts: resultado.qtGanhadoresFaixa6,   //Resultados invertidos
        ValorGanhadores0pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa6.toLocaleString('pt-BR')),   //Resultados invertidos
        ValorAcumulado: FormataValoresCom1CasaDecimal(resultado.vrEstimativa.toLocaleString('pt-BR'))
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
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso_1) {
                                RecuperaUltimoESalvaLotoFacil(retornoLasted.data[0]);
                            }
                            else {
                                $('#txtNumConcursoLotofacil_2').val(retorno.resultado.NumConcurso_1);
                                $('#txtDataConcursoLotofacil_2').val(retorno.resultado.DatConcurso_1);
                                var numeros = retorno.resultado.NumSorteados_1.split('-');
                                $('#txtNum1Lotofacil_2').val(numeros[0]);
                                $('#txtNum2Lotofacil_2').val(numeros[1]);
                                $('#txtNum3Lotofacil_2').val(numeros[2]);
                                $('#txtNum4Lotofacil_2').val(numeros[3]);
                                $('#txtNum5Lotofacil_2').val(numeros[4]);
                                $('#txtNum6Lotofacil_2').val(numeros[5]);
                                $('#txtNum7Lotofacil_2').val(numeros[6]);
                                $('#txtNum8Lotofacil_2').val(numeros[7]);
                                $('#txtNum9Lotofacil_2').val(numeros[8]);
                                $('#txtNum10Lotofacil_2').val(numeros[9]);
                                $('#txtNum11Lotofacil_2').val(numeros[10]);
                                $('#txtNum12Lotofacil_2').val(numeros[11]);
                                $('#txtNum13Lotofacil_2').val(numeros[12]);
                                $('#txtNum14Lotofacil_2').val(numeros[13]);
                                $('#txtNum15Lotofacil_2').val(numeros[14]);

                                $('#txtGanhadores15Lotofacil_2').val(retorno.resultado.QtdeGanhadores15pts_1);
                                $('#txtValor15Lotofacil_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores15pts_1.toLocaleString('pt-BR')));
                                $('#txtGanhadores14Lotofacil_2').val(retorno.resultado.QtdeGanhadores14pts_1);
                                $('#txtValor14Lotofacil_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores14pts_1.toLocaleString('pt-BR')));
                                $('#txtGanhadores13Lotofacil_2').val(retorno.resultado.QtdeGanhadores13pts_1);
                                $('#txtValor13Lotofacil_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores13pts_1.toLocaleString('pt-BR')));
                                $('#txtGanhadores12Lotofacil_2').val(retorno.resultado.QtdeGanhadores12pts_1);
                                $('#txtValor12Lotofacil_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores12pts_1.toLocaleString('pt-BR')));
                                $('#txtGanhadores11Lotofacil_2').val(retorno.resultado.QtdeGanhadores11pts_1);
                                $('#txtValor11Lotofacil_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores11pts_1.toLocaleString('pt-BR')));
                                $('#txtValorAcumuladoLotofacil_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado_1.toLocaleString('pt-BR')));


                                ///resultado 2 jogo
                                $('#txtNumConcursoLotofacil').val(retorno.resultado.NumConcurso_2);
                                $('#txtDataConcursoLotofacil').val(retorno.resultado.DatConcurso_2);
                                var numeros = retorno.resultado.NumSorteados_2.split('-');
                                $('#txtNum1Lotofacil').val(numeros[0]);
                                $('#txtNum2Lotofacil').val(numeros[1]);
                                $('#txtNum3Lotofacil').val(numeros[2]);
                                $('#txtNum4Lotofacil').val(numeros[3]);
                                $('#txtNum5Lotofacil').val(numeros[4]);
                                $('#txtNum6Lotofacil').val(numeros[5]);
                                $('#txtNum7Lotofacil').val(numeros[6]);
                                $('#txtNum8Lotofacil').val(numeros[7]);
                                $('#txtNum9Lotofacil').val(numeros[8]);
                                $('#txtNum10Lotofacil').val(numeros[9]);
                                $('#txtNum11Lotofacil').val(numeros[10]);
                                $('#txtNum12Lotofacil').val(numeros[11]);
                                $('#txtNum13Lotofacil').val(numeros[12]);
                                $('#txtNum14Lotofacil').val(numeros[13]);
                                $('#txtNum15Lotofacil').val(numeros[14]);

                                $('#txtGanhadores15Lotofacil').val(retorno.resultado.QtdeGanhadores15pts_2);
                                $('#txtValor15Lotofacil').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores15pts_2.toLocaleString('pt-BR')));
                                $('#txtGanhadores14Lotofacil').val(retorno.resultado.QtdeGanhadores14pts_2);
                                $('#txtValor14Lotofacil').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores14pts_2.toLocaleString('pt-BR')));
                                $('#txtGanhadores13Lotofacil').val(retorno.resultado.QtdeGanhadores13pts_2);
                                $('#txtValor13Lotofacil').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores13pts_2.toLocaleString('pt-BR')));
                                $('#txtGanhadores12Lotofacil').val(retorno.resultado.QtdeGanhadores12pts_2);
                                $('#txtValor12Lotofacil').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores12pts_2.toLocaleString('pt-BR')));
                                $('#txtGanhadores11Lotofacil').val(retorno.resultado.QtdeGanhadores11pts_2);
                                $('#txtValor11Lotofacil').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores11pts_2.toLocaleString('pt-BR')));
                                $('#txtValorAcumuladoLotofacil').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado_2.toLocaleString('pt-BR')));
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

function RecuperaUltimoESalvaLotoFacil(resultado) {
    $.getJSON(urlBase + '/lotofacil/' + resultado.concursoAnterior).done(function (retornoLasted) {
        if (retornoLasted.success) {
            var resultado2 = retornoLasted.data;
            $('#txtNumConcursoLotofacil_2').val(resultado.concurso);
            $('#txtDataConcursoLotofacil_2').val(resultado.dt_apuracaoStr);
            var numeros = resultado.resultadoOrdenado.split('-');
            $('#txtNum1Lotofacil_2').val(numeros[0]);
            $('#txtNum2Lotofacil_2').val(numeros[1]);
            $('#txtNum3Lotofacil_2').val(numeros[2]);
            $('#txtNum4Lotofacil_2').val(numeros[3]);
            $('#txtNum5Lotofacil_2').val(numeros[4]);
            $('#txtNum6Lotofacil_2').val(numeros[5]);
            $('#txtNum7Lotofacil_2').val(numeros[6]);
            $('#txtNum8Lotofacil_2').val(numeros[7]);
            $('#txtNum9Lotofacil_2').val(numeros[8]);
            $('#txtNum10Lotofacil_2').val(numeros[9]);
            $('#txtNum11Lotofacil_2').val(numeros[10]);
            $('#txtNum12Lotofacil_2').val(numeros[11]);
            $('#txtNum13Lotofacil_2').val(numeros[12]);
            $('#txtNum14Lotofacil_2').val(numeros[13]);
            $('#txtNum15Lotofacil_2').val(numeros[14]);
            $('#txtGanhadores15Lotofacil_2').val(resultado.qt_ganhador_faixa1);
            $('#txtValor15Lotofacil_2').val(FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa1.toLocaleString('pt-BR')));
            $('#txtGanhadores14Lotofacil_2').val(resultado.qt_ganhador_faixa2);
            $('#txtValor14Lotofacil_2').val(FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa2.toLocaleString('pt-BR')));
            $('#txtGanhadores13Lotofacil_2').val(resultado.qt_ganhador_faixa3);
            $('#txtValor13Lotofacil_2').val(FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa3.toLocaleString('pt-BR')));
            $('#txtGanhadores12Lotofacil_2').val(resultado.qt_ganhador_faixa4);
            $('#txtValor12Lotofacil_2').val(FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa4.toLocaleString('pt-BR')));
            $('#txtGanhadores11Lotofacil_2').val(resultado.qt_ganhador_faixa5);
            $('#txtValor11Lotofacil_2').val(FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa5.toLocaleString('pt-BR')));
            $('#txtValorAcumuladoLotofacil_2').val(FormataValoresCom1CasaDecimal(resultado.vrAcumuladoEspecial.toLocaleString('pt-BR')));

            ///resultado 2 jogo
            $('#txtNumConcursoLotofacil').val(resultado2.concurso);
            $('#txtDataConcursoLotofacil').val(resultado2.dt_apuracaoStr);
            var numeros = resultado2.resultadoOrdenado.split('-');
            $('#txtNum1Lotofacil').val(numeros[0]);
            $('#txtNum2Lotofacil').val(numeros[1]);
            $('#txtNum3Lotofacil').val(numeros[2]);
            $('#txtNum4Lotofacil').val(numeros[3]);
            $('#txtNum5Lotofacil').val(numeros[4]);
            $('#txtNum6Lotofacil').val(numeros[5]);
            $('#txtNum7Lotofacil').val(numeros[6]);
            $('#txtNum8Lotofacil').val(numeros[7]);
            $('#txtNum9Lotofacil').val(numeros[8]);
            $('#txtNum10Lotofacil').val(numeros[9]);
            $('#txtNum11Lotofacil').val(numeros[10]);
            $('#txtNum12Lotofacil').val(numeros[11]);
            $('#txtNum13Lotofacil').val(numeros[12]);
            $('#txtNum14Lotofacil').val(numeros[13]);
            $('#txtNum15Lotofacil').val(numeros[14]);

            $('#txtGanhadores15Lotofacil').val(resultado2.qt_ganhador_faixa1);
            $('#txtValor15Lotofacil').val(FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa1.toLocaleString('pt-BR')));
            $('#txtGanhadores14Lotofacil').val(resultado2.qt_ganhador_faixa2);
            $('#txtValor14Lotofacil').val(FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa2.toLocaleString('pt-BR')));
            $('#txtGanhadores13Lotofacil').val(resultado2.qt_ganhador_faixa3);
            $('#txtValor13Lotofacil').val(FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa3.toLocaleString('pt-BR')));
            $('#txtGanhadores12Lotofacil').val(resultado2.qt_ganhador_faixa4);
            $('#txtValor12Lotofacil').val(FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa4.toLocaleString('pt-BR')));
            $('#txtGanhadores11Lotofacil').val(resultado2.qt_ganhador_faixa5);
            $('#txtValor11Lotofacil').val(FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa5.toLocaleString('pt-BR')));
            $('#txtValorAcumuladoLotofacil').val(FormataValoresCom1CasaDecimal(resultado2.vrAcumuladoEspecial.toLocaleString('pt-BR')));


            var lotofacil = {
                NumConcurso_1: resultado.concurso,
                DatConcurso_1: resultado.dt_apuracaoStr,
                NumSorteados_1: resultado.resultadoOrdenado,
                QtdeGanhadores15pts_1: resultado.qt_ganhador_faixa1,
                ValorGanhadores15pts_1: FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa1.toLocaleString('pt-BR')),
                QtdeGanhadores14pts_1: resultado.qt_ganhador_faixa2,
                ValorGanhadores14pts_1: FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa2.toLocaleString('pt-BR')),
                QtdeGanhadores13pts_1: resultado.qt_ganhador_faixa3,
                ValorGanhadores13pts_1: FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa3.toLocaleString('pt-BR')),
                QtdeGanhadores12pts_1: resultado.qt_ganhador_faixa4,
                ValorGanhadores12pts_1: FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa4.toLocaleString('pt-BR')),
                QtdeGanhadores11pts_1: resultado.qt_ganhador_faixa5,
                ValorGanhadores11pts_1: FormataValoresCom1CasaDecimal(resultado.vr_rateio_faixa5.toLocaleString('pt-BR')),
                ValorAcumulado_1: FormataValoresCom1CasaDecimal(resultado.vrAcumuladoEspecial.toLocaleString('pt-BR')),
                NumConcurso_2: resultado2.concurso,
                DatConcurso_2: resultado2.dt_apuracaoStr,
                NumSorteados_2: resultado2.resultadoOrdenado,
                QtdeGanhadores15pts_2: resultado2.qt_ganhador_faixa1,
                ValorGanhadores15pts_2: FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa1.toLocaleString('pt-BR')),
                QtdeGanhadores14pts_2: resultado2.qt_ganhador_faixa2,
                ValorGanhadores14pts_2: FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa2.toLocaleString('pt-BR')),
                QtdeGanhadores13pts_2: resultado2.qt_ganhador_faixa3,
                ValorGanhadores13pts_2: FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa3.toLocaleString('pt-BR')),
                QtdeGanhadores12pts_2: resultado2.qt_ganhador_faixa4,
                ValorGanhadores12pts_2: FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa4.toLocaleString('pt-BR')),
                QtdeGanhadores11pts_2: resultado2.qt_ganhador_faixa5,
                ValorGanhadores11pts_2: FormataValoresCom1CasaDecimal(resultado2.vr_rateio_faixa5.toLocaleString('pt-BR')),
                ValorAcumulado_2: FormataValoresCom1CasaDecimal(resultado2.vrAcumuladoEspecial.toLocaleString('pt-BR'))
            }
            $.ajax({
                url: '/Home/SalvarResultadoLotoFacil',
                type: "POST",
                async: true,
                data: { lotofacil },
                success: function (resultado) {
                    if (!resultado.sucesso)
                        console.log(resultado.mensagem);
                },
                error: function (jqXHR, textStatus, errorThrown) {

                }
            });
        }
    });
}

function RecuperaQuina() {
    $.getJSON(urlBase + '/quina/lasted').done(function (retornoLasted) {
        if (retornoLasted.success) {
            $.ajax({
                url: '/Home/RecuperarUltimoResultadoQuina',
                async: true,
                data: {},
                success: function (retorno) {
                    if (retorno.sucesso) {
                        if (retorno.tipo == 1) {
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso) {
                                RecuperaUltimoESalvaQuina(retornoLasted.data[0]);
                            }
                            else {
                                $('#txtNumConcursoQuina_2').val(retorno.resultado.NumConcurso_1);
                                $('#txtDataConcursoQuina_2').val(retorno.resultado.DatConcurso_1);
                                var numeros = retorno.resultado.NumSorteados_1.split('-');
                                $('#txtNum1Quina_2').val(numeros[0]);
                                $('#txtNum2Quina_2').val(numeros[1]);
                                $('#txtNum3Quina_2').val(numeros[2]);
                                $('#txtNum4Quina_2').val(numeros[3]);
                                $('#txtNum5Quina_2').val(numeros[4]);
                                $('#txtGanhadoresQuinaQuina_2').val(retorno.resultado.QtdeGanhadoresQuina_1);
                                $('#txtValorQuinaQuina_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresQuina_1.toLocaleString('pt-BR')));
                                $('#txtGanhadoresQuinaQuadra_2').val(retorno.resultado.QtdeGanhadoresQuadra_1);
                                $('#txtValorQuinaQuadra_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresQuadra_1.toLocaleString('pt-BR')));
                                $('#txtGanhadoresQuinaTerno_2').val(retorno.resultado.QtdeGanhadoresTerno_1);
                                $('#txtValorQuinaTerno_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresTerno_1.toLocaleString('pt-BR')));
                                $('#txtGanhadoresQuinaDuque_2').val(retorno.resultado.QtdeGanhadoresDuque_1);
                                $('#txtValorQuinaDuque_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresDuque_1.toLocaleString('pt-BR')));
                                $('#txtValorAcumuladoQuina_2').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado_1.toLocaleString('pt-BR')));

                                ///resultado 1 jogo invertido somente para apresentação correta na tela
                                $('#txtNumConcursoQuina').val(retorno.resultado.NumConcurso_2);
                                $('#txtDataConcursoQuina').val(retorno.resultado.DatConcurso_2);
                                var numeros_2 = retorno.resultado.NumSorteados_2.split('-');
                                $('#txtNum1Quina').val(numeros_2[0]);
                                $('#txtNum2Quina').val(numeros_2[1]);
                                $('#txtNum3Quina').val(numeros_2[2]);
                                $('#txtNum4Quina').val(numeros_2[3]);
                                $('#txtNum5Quina').val(numeros_2[4]);
                                $('#txtGanhadoresQuinaQuina').val(retorno.resultado.QtdeGanhadoresQuina_2);
                                $('#txtValorQuinaQuina').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresQuina_2.toLocaleString('pt-BR')));
                                $('#txtGanhadoresQuinaQuadra').val(retorno.resultado.QtdeGanhadoresQuadra_2);
                                $('#txtValorQuinaQuadra').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresQuadra_2.toLocaleString('pt-BR')));
                                $('#txtGanhadoresQuinaTerno').val(retorno.resultado.QtdeGanhadoresTerno_2);
                                $('#txtValorQuinaTerno').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresTerno_2.toLocaleString('pt-BR')));
                                $('#txtGanhadoresQuinaDuque').val(retorno.resultado.QtdeGanhadoresDuque_2);
                                $('#txtValorQuinaDuque').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresDuque_2.toLocaleString('pt-BR')));
                                $('#txtValorAcumuladoQuina').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado_2.toLocaleString('pt-BR')));
                            }
                        }
                        else {
                            RecuperaUltimoESalvaQuina(retornoLasted.data[0]);
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

function RecuperaUltimoESalvaQuina(resultado) {
    $.getJSON(urlBase + '/quina/' + resultado.concursoAnterior).done(function (retornoLasted) {
        if (retornoLasted.success) {
            var resultado2 = retornoLasted.data;
            $('#txtNumConcursoQuina_2').val(resultado.concurso);
            $('#txtDataConcursoQuina_2').val(resultado.dataStr);
            var numeros = resultado.resultadoOrdenado.split('-');
            $('#txtNum1Quina_2').val(numeros[0]);
            $('#txtNum2Quina_2').val(numeros[1]);
            $('#txtNum3Quina_2').val(numeros[2]);
            $('#txtNum4Quina_2').val(numeros[3]);
            $('#txtNum5Quina_2').val(numeros[4]);
            $('#txtGanhadoresQuinaQuina_2').val(resultado.ganhadores);
            $('#txtValorQuinaQuina_2').val(FormataValoresCom1CasaDecimal(resultado.valor.toLocaleString('pt-BR')));
            $('#txtGanhadoresQuinaQuadra_2').val(resultado.ganhadores_quadra);
            $('#txtValorQuinaQuadra_2').val(FormataValoresCom1CasaDecimal(resultado.valor_quadra.toLocaleString('pt-BR')));
            $('#txtGanhadoresQuinaTerno_2').val(resultado.ganhadores_terno);
            $('#txtValorQuinaTerno_2').val(FormataValoresCom1CasaDecimal(resultado.valor_terno.toLocaleString('pt-BR')));
            $('#txtGanhadoresQuinaDuque_2').val(resultado.qt_ganhador_duque);
            $('#txtValorQuinaDuque_2').val(FormataValoresCom1CasaDecimal(resultado.vr_rateio_duque.toLocaleString('pt-BR')));
            $('#txtValorAcumuladoQuina_2').val(FormataValoresCom1CasaDecimal(resultado.vrAcumulado.toLocaleString('pt-BR')));


            ///resultado 1 jogo invertido somente para apresentação correta na tela
            $('#txtNumConcursoQuina').val(resultado2.concurso);
            $('#txtDataConcursoQuina').val(resultado2.dataStr);
            var numeros = resultado2.resultadoOrdenado.split('-');
            $('#txtNum1Quina').val(numeros[0]);
            $('#txtNum2Quina').val(numeros[1]);
            $('#txtNum3Quina').val(numeros[2]);
            $('#txtNum4Quina').val(numeros[3]);
            $('#txtNum5Quina').val(numeros[4]);
            $('#txtGanhadoresQuinaQuina').val(resultado2.ganhadores);
            $('#txtValorQuinaQuina').val(FormataValoresCom1CasaDecimal(resultado2.valor.toLocaleString('pt-BR')));
            $('#txtGanhadoresQuinaQuadra').val(resultado2.ganhadores_quadra);
            $('#txtValorQuinaQuadra').val(FormataValoresCom1CasaDecimal(resultado2.valor_quadra.toLocaleString('pt-BR')));
            $('#txtGanhadoresQuinaTerno').val(resultado2.ganhadores_terno);
            $('#txtValorQuinaTerno').val(FormataValoresCom1CasaDecimal(resultado2.valor_terno.toLocaleString('pt-BR')));
            $('#txtGanhadoresQuinaDuque').val(resultado2.qt_ganhador_duque);
            $('#txtValorQuinaDuque').val(FormataValoresCom1CasaDecimal(resultado2.vr_rateio_duque.toLocaleString('pt-BR')));
            $('#txtValorAcumuladoQuina').val(FormataValoresCom1CasaDecimal(resultado2.vrAcumulado.toLocaleString('pt-BR')));


            var quina = {
                NumConcurso_1: resultado.concurso,
                DatConcurso_1: resultado.dataStr,
                NumSorteados_1: resultado.resultadoOrdenado,
                QtdeGanhadoresQuina_1: resultado.ganhadores,
                ValorGanhadoresQuina_1: FormataValoresCom1CasaDecimal(resultado.valor.toLocaleString('pt-BR')),
                QtdeGanhadoresQuadra_1: resultado.ganhadores_quadra,
                ValorGanhadoresQuadra_1: FormataValoresCom1CasaDecimal(resultado.valor_quadra.toLocaleString('pt-BR')),
                QtdeGanhadoresTerno_1: resultado.ganhadores_terno,
                ValorGanhadoresTerno_1: FormataValoresCom1CasaDecimal(resultado.valor_terno.toLocaleString('pt-BR')),
                QtdeGanhadoresDuque_1: resultado.qt_ganhador_duque,
                ValorGanhadoresDuque_1: FormataValoresCom1CasaDecimal(resultado.vr_rateio_duque.toLocaleString('pt-BR')),
                ValorAcumulado_1: FormataValoresCom1CasaDecimal(resultado.vrAcumulado.toLocaleString('pt-BR')),

                NumConcurso_2: resultado2.concurso,
                DatConcurso_2: resultado2.dataStr,
                NumSorteados_2: resultado2.resultadoOrdenado,
                QtdeGanhadoresQuina_2: resultado2.ganhadores,
                ValorGanhadoresQuina_2: FormataValoresCom1CasaDecimal(resultado2.valor.toLocaleString('pt-BR')),
                QtdeGanhadoresQuadra_2: resultado2.ganhadores_quadra,
                ValorGanhadoresQuadra_2: FormataValoresCom1CasaDecimal(resultado2.valor_quadra.toLocaleString('pt-BR')),
                QtdeGanhadoresTerno_2: resultado2.ganhadores_terno,
                ValorGanhadoresTerno_2: FormataValoresCom1CasaDecimal(resultado2.valor_terno.toLocaleString('pt-BR')),
                QtdeGanhadoresDuque_2: resultado2.qt_ganhador_duque,
                ValorGanhadoresDuque_2: FormataValoresCom1CasaDecimal(resultado2.vr_rateio_duque.toLocaleString('pt-BR')),
                ValorAcumulado_2: FormataValoresCom1CasaDecimal(resultado2.vrAcumulado.toLocaleString('pt-BR'))
            }
            $.ajax({
                url: '/Home/SalvarResultadoQuina',
                type: "POST",
                async: true,
                data: { quina },
                success: function (resultado) {
                    if (!resultado.sucesso)
                        console.log(resultado.mensagem);
                },
                error: function (jqXHR, textStatus, errorThrown) {

                }
            });
        }
    });
}

function RecuperaLoteca() {
    $.getJSON(urlBase + '/loteca/lasted').done(function (retornoLasted) {
        if (retornoLasted.success) {
            $.ajax({
                url: '/Home/RecuperarUltimoResultadoLoteca',
                async: true,
                data: {},
                success: function (retorno) {
                    if (retorno.sucesso) {
                        if (retorno.tipo == 1) {
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso) {
                                RecuperaUltimoESalvaLoteca(retornoLasted.data[0]);
                            }
                            else {
                                $('#txtNumConcursoLoteca').val(retorno.resultado.NumConcurso);
                                $('#txtDataConcursoLoteca').val(retorno.resultado.DatConcurso);
                                $('#txtGanhadores15ptsLoteca').val(retorno.resultado.QtdeGanhadores15pts);
                                $('#txtValor15ptsLoteca').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores15pts));
                                $('#txtGanhadores16ptsLoteca').val(retorno.resultado.QtdeGanhadores16pts);
                                $('#txtValor16ptsLoteca').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores16pts));
                                $('#txtValorAcumuladoLoteca').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado));
                                for (var i = 0; i < retorno.resultado.ListaJogos.length; i++) {
                                    AlteraResultadosLoteca(retorno.resultado.ListaJogos[i].IndTipoResultado, i);
                                }
                            }
                        }
                        else {
                            RecuperaUltimoESalvaLoteca(retornoLasted.data[0]);
                        }
                    }
                    else {
                        alert(retorno.mensagem);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                }
            });
        }
    });
}

function RecuperaUltimoESalvaLoteca(resultado) {
    $('#txtNumConcursoLoteca').val(resultado.concurso);
    $('#txtDataConcursoLoteca').val(resultado.dtApuracaoStr);
    $('#txtGanhadores15ptsLoteca').val(resultado.qtGanhadorFaixa1);
    $('#txtValor15ptsLoteca').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa1.toLocaleString('pt-BR')));
    $('#txtGanhadores16ptsLoteca').val(resultado.qtGanhadorFaixa2);
    $('#txtValor16ptsLoteca').val(FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa2.toLocaleString('pt-BR')));
    $('#txtValorAcumuladoLoteca').val(FormataValoresCom1CasaDecimal(resultado.vrConcursoAcumulado.toLocaleString('pt-BR')));

    var loteca = {
        NumConcurso: resultado.concurso,
        DatConcurso: resultado.dtApuracaoStr,
        QtdeGanhadores15pts: resultado.qtGanhadorFaixa1,
        ValorGanhadores15pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa1.toLocaleString('pt-BR')),
        QtdeGanhadores16pts: resultado.qtGanhadorFaixa2,
        ValorGanhadores16pts: FormataValoresCom1CasaDecimal(resultado.vrRateioFaixa2.toLocaleString('pt-BR')),
        ValorAcumulado: FormataValoresCom1CasaDecimal(resultado.vrConcursoAcumulado.toLocaleString('pt-BR'))
    }
    $.ajax({
        url: '/Home/SalvarResultadoLoteca',
        type: "POST",
        async: true,
        data: { loteca },
        success: function (resultadoSalvarLoteca) {

            if (!resultadoSalvarLoteca.sucesso)
                console.log(resultadoSalvarLoteca.mensagem);
            else {
                for (var i = 0; i < resultado.jogos.length; i++) {
                    var jogosLoteca = {
                        NumConcurso: resultado.jogos[i].concurso,
                        IndFaixa: (i + 1),
                        IndTipoResultado: resultado.jogos[i].colunaUm ? 1 : (resultado.jogos[i].colunaDois ? 2 : 3)
                    }
                    AlteraResultadosLoteca(jogosLoteca.IndTipoResultado, i);
                    $.ajax({
                        url: '/Home/SalvarResultadoJogosLoteca',
                        type: "POST",
                        async: true,
                        data: { jogosLoteca },
                        success: function (resultado) {
                            if (!resultado.sucesso)
                                console.log(resultado.mensagem);
                        },
                        error: function (jqXHR, textStatus, errorThrown) {

                        }
                    });
                }

            }
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function AlteraResultadosLoteca(tipo, index) {
    switch (tipo) {

        case 1:
            {
                $('#txtNum' + (index + 1) + 'UmLoteca').val('X');
                $('#txtNum' + (index + 1) + 'MeioLoteca').val('');
                $('#txtNum' + (index + 1) + 'DoisLoteca').val('');
                break;
            }
        case 2:
            {
                $('#txtNum' + (index + 1) + 'UmLoteca').val('');
                $('#txtNum' + (index + 1) + 'MeioLoteca').val('');
                $('#txtNum' + (index + 1) + 'DoisLoteca').val('X');
                break;
            }
        case 3:
            {
                $('#txtNum' + (index + 1) + 'UmLoteca').val('');
                $('#txtNum' + (index + 1) + 'MeioLoteca').val('X');
                $('#txtNum' + (index + 1) + 'DoisLoteca').val('');
                break;
            }
    }
}

function RecuperaTimeMania() {
    $.getJSON(urlBase + '/timemania/lasted').done(function (retornoLasted) {
        if (retornoLasted.success) {
            $.ajax({
                url: '/Home/RecuperarUltimoResultadoTimeMania',
                async: true,
                data: {},
                success: function (retorno) {
                    if (retorno.sucesso) {
                        if (retorno.tipo == 1) {
                            if (Number(retornoLasted.data[0].concurso) > retorno.resultado.NumConcurso) {
                                RecuperaUltimoESalvaTimeMania(retornoLasted.data[0]);
                            }
                            else {
                                $('#txtNumConcursoTimemania').val(retorno.resultado.NumConcurso);
                                $('#txtDataConcursoTimemania').val(retorno.resultado.DatConcurso);
                                var numeros = retorno.resultado.NumSorteados.split('-');
                                $('#txtNum1Timemania').val(numeros[0]);
                                $('#txtNum2Timemania').val(numeros[1]);
                                $('#txtNum3Timemania').val(numeros[2]);
                                $('#txtNum4Timemania').val(numeros[3]);
                                $('#txtNum5Timemania').val(numeros[4]);
                                $('#txtNum6Timemania').val(numeros[5]);
                                $('#txtNum7Timemania').val(numeros[6]);

                                $('#txtGanhadores7Timemania').val(retorno.resultado.QtdeGanhadores7pts);
                                $('#txtValor7Timemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores7pts));
                                $('#txtGanhadores6Timemania').val(retorno.resultado.QtdeGanhadores6pts);
                                $('#txtValor6Timemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores6pts));
                                $('#txtGanhadores5Timemania').val(retorno.resultado.QtdeGanhadores5pts);
                                $('#txtValor5Timemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores5pts));
                                $('#txtGanhadores4Timemania').val(retorno.resultado.QtdeGanhadores4pts);
                                $('#txtValor4Timemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores4pts));
                                $('#txtGanhadores3Timemania').val(retorno.resultado.QtdeGanhadores3pts);
                                $('#txtValor3Timemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadores3pts));

                                $('#txtGanhadoresTimeCoracaoTimemania').val(retorno.resultado.QtdeGanhadoresTimeCoracao);
                                $('#txtValorTimeCoracaoTimemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorGanhadoresTimeCoracao));
                                $('#txtGanhadoresTimeSorteadoTimeMania').val(retorno.resultado.DscTimeSorteado);
                                $('#txtValorAcumuladoTimemania').val(FormataValoresCom1CasaDecimal(retorno.resultado.ValorAcumulado));
                            }
                        }
                        else {
                            RecuperaUltimoESalvaTimeMania(retornoLasted.data[0]);
                        }
                    }
                    else {
                        alert(retorno.mensagem);
                    }
                },
                error: function (jqXHR, textStatus, errorThrown) {
                }
            });
        }
    });
}

function RecuperaUltimoESalvaTimeMania(resultado) {
    $('#txtNumConcursoTimemania').val(resultado.concurso);
    $('#txtDataConcursoTimemania').val(resultado.dt_APURACAOStr);
    var numeros = resultado.de_RESULTADO.split('-');
    $('#txtNum1Timemania').val(numeros[0]);
    $('#txtNum2Timemania').val(numeros[1]);
    $('#txtNum3Timemania').val(numeros[2]);
    $('#txtNum4Timemania').val(numeros[3]);
    $('#txtNum5Timemania').val(numeros[4]);
    $('#txtNum6Timemania').val(numeros[5]);
    $('#txtNum7Timemania').val(numeros[6]);

    $('#txtGanhadores7Timemania').val(resultado.qt_GANHADOR_FAIXA_1);
    $('#txtValor7Timemania').val(FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_1.toLocaleString('pt-BR')));
    $('#txtGanhadores6Timemania').val(resultado.qt_GANHADOR_FAIXA_2);
    $('#txtValor6Timemania').val(FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_2.toLocaleString('pt-BR')));
    $('#txtGanhadores5Timemania').val(resultado.qt_GANHADOR_FAIXA_3);
    $('#txtValor5Timemania').val(FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_3.toLocaleString('pt-BR')));
    $('#txtGanhadores4Timemania').val(resultado.qt_GANHADOR_FAIXA_4);
    $('#txtValor4Timemania').val(FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_4.toLocaleString('pt-BR')));
    $('#txtGanhadores3Timemania').val(resultado.qt_GANHADOR_FAIXA_5);
    $('#txtValor3Timemania').val(FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_5.toLocaleString('pt-BR')));

    $('#txtGanhadoresTimeCoracaoTimemania').val(resultado.qt_GANHADOR_TIME_CORACAO);
    $('#txtValorTimeCoracaoTimemania').val(FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_TIME_CORACAO.toLocaleString('pt-BR')));
    $('#txtGanhadoresTimeSorteadoTimeMania').val(resultado.timeCoracao);
    $('#txtValorAcumuladoTimemania').val(FormataValoresCom1CasaDecimal(resultado.vr_ACUMULADO_PROXIMO_CONCURSO.toLocaleString('pt-BR')));
    var timemania = {
        NumConcurso: resultado.concurso,
        DatConcurso: resultado.dt_APURACAOStr,
        NumSorteados: resultado.de_RESULTADO,
        QtdeGanhadores7pts: resultado.qt_GANHADOR_FAIXA_1,
        ValorGanhadores7pts: FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_1.toLocaleString('pt-BR')),
        QtdeGanhadores6pts: resultado.qt_GANHADOR_FAIXA_2,
        ValorGanhadores6pts: FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_2.toLocaleString('pt-BR')),
        QtdeGanhadores5pts: resultado.qt_GANHADOR_FAIXA_3,
        ValorGanhadores5pts: FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_3.toLocaleString('pt-BR')),
        QtdeGanhadores4pts: resultado.qt_GANHADOR_FAIXA_4,
        ValorGanhadores4pts: FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_4.toLocaleString('pt-BR')),
        QtdeGanhadores3pts: resultado.qt_GANHADOR_FAIXA_5,
        ValorGanhadores3pts: FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_FAIXA_5.toLocaleString('pt-BR')),
        QtdeGanhadoresTimeCoracao: resultado.qt_GANHADOR_TIME_CORACAO,
        ValorGanhadoresTimeCoracao: FormataValoresCom1CasaDecimal(resultado.vr_RATEIO_TIME_CORACAO.toLocaleString('pt-BR')),
        DscTimeSorteado: resultado.timeCoracao,
        ValorAcumulado: FormataValoresCom1CasaDecimal(resultado.vr_ACUMULADO_PROXIMO_CONCURSO.toLocaleString('pt-BR'))
    }
    $.ajax({
        url: '/Home/SalvarResultadoTimeMania',
        type: "POST",
        async: true,
        data: { timemania },
        success: function (resultado) {
            if (!resultado.sucesso)
                console.log(resultado.mensagem);
        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function RecuperaDuplaSena() { }

function RecuperaUltimoESalvaDuplaSena(resultado) {

}

function RecuperaSorteSete() { }

function RecuperaUltimoESalvaSorteSete(resultado) {

}

function RecuperaDiaDeSorte() { }

function RecuperaUltimoESalvaDiaDeSort(resultado) {

}