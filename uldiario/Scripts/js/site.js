var enumJogos = {
    megasena: 0,
    lotomania: 1,
    lotofacil1: 2,
    lotofacil2: 3,
    quina1: 4,
    quina2: 5,
    loteca: 6,
    timemania: 7,
    duplasena1: 8,
    duplasena2: 9,
    supersete: 10,
    diadesorte: 11
}

var enumPremiacaoMegaSena = {
    sena: 0,
    quina: 1,
    quadra: 2
}

var enumPremiacaoLotomania = {
    pts20: 0,
    pts19: 1,
    pts18: 2,
    pts17: 3,
    pts16: 4,
    pts15: 5,
    pts0: 6
}

var enumPremiacaoLotofacil = {
    pts15: 0,
    pts14: 1,
    pts13: 2,
    pts12: 3,
    pts11: 4
}

var enumPremiacaoLoteca = {
    acertos14: 0,
    acertos13: 1
}

var enumPremiacaoQuina = {
    quina: 0,
    quadra: 1,
    terno: 2,
    duque: 3
}

var enumPremiacaoTimeMania = {
    acertos7: 0,
    acertos6: 1,
    acertos5: 2,
    acertos4: 3,
    acertos3: 4,
    timecoracao: 5
}

var enumPremiacaoDuplaSena = {
    sena: 0,
    quina: 1,
    quadra: 2,
    terno: 3
}

var enumPremiacaoSuperSete = {
    acertos7: 0,
    acertos6: 1,
    acertos5: 2,
    acertos4: 3,
    acertos3: 4,
    timecoracao: 5
}
var enumPremiacaoDiaDeSorte = {
    acertos7: 0,
    acertos6: 1,
    acertos5: 2,
    acertos4: 3,
    mesdasorte: 4
}

$(document).ready(function () {
    CarregarTela();
    $('[id*=divPrincipal]')[0].style.zoom = 0.25;
    $('[id*=divPrincipal]').show();

});

function CarregarTela() {
    $.ajax({
        url: '/Home/AtualizaJogos',
        data: {},
        success: function (resultado) {
            if (resultado.sucesso) {
                PreencheResultadosMegaSena(resultado);
                PreencheResultadosLotoMania(resultado);
                PreencheResultadosLotoFacil(resultado);
                PreencheResultadosQuina(resultado);
                PreencheResultadosLoteca(resultado);
                PreencheResultadosTimeMania(resultado);
                PreencheResultadosDuplaSena(resultado);
                PreencheResultadosSuperSete(resultado);
                PreencheResultadosDiaDeSorte(resultado);

            }
            else
                alert(resultado.mensagem);

        },
        error: function (jqXHR, textStatus, errorThrown) {

        }
    });
}

function PreencheResultadosMegaSena(resultado) {
    $('.card-mega-sena #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.megasena].numero_concurso);
    $('.card-mega-sena #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.megasena].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.megasena].dezenas;
    $('.card-mega-sena #txtNumero1').val(numeros[0]);
    $('.card-mega-sena #txtNumero2').val(numeros[1]);
    $('.card-mega-sena #txtNumero3').val(numeros[2]);
    $('.card-mega-sena #txtNumero4').val(numeros[3]);
    $('.card-mega-sena #txtNumero5').val(numeros[4]);
    $('.card-mega-sena #txtNumero6').val(numeros[5]);
    var qtdeGanhadoresSena = resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.sena].quantidade_ganhadores;
    if (qtdeGanhadoresSena == 0) {
        $('.card-mega-sena #txtQtdeGanhadoresSena').val('Acumulou');
        $('.card-mega-sena #txtValorGanhadoresSena').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.megasena].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-mega-sena #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.megasena].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    }
    else {
        $('.card-mega-sena #txtQtdeGanhadoresSena').val(resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.sena].quantidade_ganhadores);
        $('.card-mega-sena #txtValorGanhadoresSena').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.sena].valor_total.toLocaleString('pt-BR')));
        $('.card-mega-sena #txtValorAcumulado').val('0');
    }
    $('.card-mega-sena #txtQtdeGanhadoresQuina').val(resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.quina].quantidade_ganhadores);
    $('.card-mega-sena #txtValorGanhadoresQuina').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.quina].valor_total.toLocaleString('pt-BR')));
    $('.card-mega-sena #txtQtdeGanhadoresQuadra').val(resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.quadra].quantidade_ganhadores);
    $('.card-mega-sena #txtValorGanhadoresQuadra').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.megasena].premiacao[enumPremiacaoMegaSena.quadra].valor_total.toLocaleString('pt-BR')));
}

function PreencheResultadosLotoMania(resultado) {
    $('.card-lotomania #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.lotomania].numero_concurso);
    $('.card-lotomania #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.lotomania].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.lotomania].dezenas;
    $('.card-lotomania #txtNumero1').val(numeros[0]);
    $('.card-lotomania #txtNumero2').val(numeros[1]);
    $('.card-lotomania #txtNumero3').val(numeros[2]);
    $('.card-lotomania #txtNumero4').val(numeros[3]);
    $('.card-lotomania #txtNumero5').val(numeros[4]);
    $('.card-lotomania #txtNumero6').val(numeros[5]);
    $('.card-lotomania #txtNumero7').val(numeros[6]);
    $('.card-lotomania #txtNumero8').val(numeros[7]);
    $('.card-lotomania #txtNumero9').val(numeros[8]);
    $('.card-lotomania #txtNumero10').val(numeros[9]);
    $('.card-lotomania #txtNumero11').val(numeros[10]);
    $('.card-lotomania #txtNumero12').val(numeros[11]);
    $('.card-lotomania #txtNumero13').val(numeros[12]);
    $('.card-lotomania #txtNumero14').val(numeros[13]);
    $('.card-lotomania #txtNumero15').val(numeros[14]);
    $('.card-lotomania #txtNumero16').val(numeros[15]);
    $('.card-lotomania #txtNumero17').val(numeros[16]);
    $('.card-lotomania #txtNumero18').val(numeros[17]);
    $('.card-lotomania #txtNumero19').val(numeros[18]);
    $('.card-lotomania #txtNumero20').val(numeros[19]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts20].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-lotomania #txtQtdeGanhadores20pts').val('Acumulou');
        $('.card-lotomania #txtValorGanhadores20pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-lotomania #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    }
    else {
        $('.card-lotomania #txtQtdeGanhadores20pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts20].quantidade_ganhadores);
        $('.card-lotomania #txtValorGanhadores20pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts20].valor_total.toLocaleString('pt-BR')));
        $('.card-lotomania #txtValorAcumulado').val('0');
    }


    $('.card-lotomania #txtQtdeGanhadores19pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts19].quantidade_ganhadores);
    $('.card-lotomania #txtValorGanhadores19pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts19].valor_total.toLocaleString('pt-BR')));
    $('.card-lotomania #txtQtdeGanhadores18pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts18].quantidade_ganhadores);
    $('.card-lotomania #txtValorGanhadores18pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts18].valor_total.toLocaleString('pt-BR')));
    $('.card-lotomania #txtQtdeGanhadores17pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts17].quantidade_ganhadores);
    $('.card-lotomania #txtValorGanhadores17pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts17].valor_total.toLocaleString('pt-BR')));
    $('.card-lotomania #txtQtdeGanhadores16pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts16].quantidade_ganhadores);
    $('.card-lotomania #txtValorGanhadores16pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts16].valor_total.toLocaleString('pt-BR')));
    $('.card-lotomania #txtQtdeGanhadores15pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts15].quantidade_ganhadores);
    $('.card-lotomania #txtValorGanhadores15pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts15].valor_total.toLocaleString('pt-BR')));
    $('.card-lotomania #txtQtdeGanhadores0pts').val(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts0].quantidade_ganhadores);
    $('.card-lotomania #txtValorGanhadores0pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotomania].premiacao[enumPremiacaoLotomania.pts0].valor_total.toLocaleString('pt-BR')));

}

function PreencheResultadosLotoFacil(resultado) {
    //painel 1
    $('.card-lotofacil #txtNumeroConcurso1').val(resultado.listaResultado[enumJogos.lotofacil1].numero_concurso);
    $('.card-lotofacil #txtDataConcurso1').val(FormataData(resultado.listaResultado[enumJogos.lotofacil1].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.lotofacil1].dezenas;
    $('.card-lotofacil #txtNumero1_1').val(numeros[0]);
    $('.card-lotofacil #txtNumero2_1').val(numeros[1]);
    $('.card-lotofacil #txtNumero3_1').val(numeros[2]);
    $('.card-lotofacil #txtNumero4_1').val(numeros[3]);
    $('.card-lotofacil #txtNumero5_1').val(numeros[4]);
    $('.card-lotofacil #txtNumero6_1').val(numeros[5]);
    $('.card-lotofacil #txtNumero7_1').val(numeros[6]);
    $('.card-lotofacil #txtNumero8_1').val(numeros[7]);
    $('.card-lotofacil #txtNumero9_1').val(numeros[8]);
    $('.card-lotofacil #txtNumero10_1').val(numeros[9]);
    $('.card-lotofacil #txtNumero11_1').val(numeros[10]);
    $('.card-lotofacil #txtNumero12_1').val(numeros[11]);
    $('.card-lotofacil #txtNumero13_1').val(numeros[12]);
    $('.card-lotofacil #txtNumero14_1').val(numeros[13]);
    $('.card-lotofacil #txtNumero15_1').val(numeros[14]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts15].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-lotofacil #txtQtdeGanhadores15pts_1')[0].style = 'font-size: 2.125rem;';
        $('.card-lotofacil #txtQtdeGanhadores15pts_1').val('Acumulou');
        $('.card-lotofacil #txtValorGanhadores15pts_1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-lotofacil #txtValorAcumulado1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-lotofacil #txtQtdeGanhadores15pts_1').val(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts15].quantidade_ganhadores);
        $('.card-lotofacil #txtValorGanhadores15pts_1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts15].valor_total.toLocaleString('pt-BR')));
        $('.card-lotofacil #txtValorAcumulado1').val('0');
    }

    $('.card-lotofacil #txtQtdeGanhadores14pts_1').val(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts14].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores14pts_1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts14].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores13pts_1').val(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts13].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores13pts_1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts13].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores12pts_1').val(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts12].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores12pts_1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts12].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores11pts_1').val(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts11].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores11pts_1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil1].premiacao[enumPremiacaoLotofacil.pts11].valor_total.toLocaleString('pt-BR')));


    //painel 2
    $('.card-lotofacil #txtNumeroConcurso2').val(resultado.listaResultado[enumJogos.lotofacil2].numero_concurso);
    $('.card-lotofacil #txtDataConcurso2').val(FormataData(resultado.listaResultado[enumJogos.lotofacil2].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.lotofacil2].dezenas;
    $('.card-lotofacil #txtNumero1_2').val(numeros[0]);
    $('.card-lotofacil #txtNumero2_2').val(numeros[1]);
    $('.card-lotofacil #txtNumero3_2').val(numeros[2]);
    $('.card-lotofacil #txtNumero4_2').val(numeros[3]);
    $('.card-lotofacil #txtNumero5_2').val(numeros[4]);
    $('.card-lotofacil #txtNumero6_2').val(numeros[5]);
    $('.card-lotofacil #txtNumero7_2').val(numeros[6]);
    $('.card-lotofacil #txtNumero8_2').val(numeros[7]);
    $('.card-lotofacil #txtNumero9_2').val(numeros[8]);
    $('.card-lotofacil #txtNumero10_2').val(numeros[9]);
    $('.card-lotofacil #txtNumero11_2').val(numeros[10]);
    $('.card-lotofacil #txtNumero12_2').val(numeros[11]);
    $('.card-lotofacil #txtNumero13_2').val(numeros[12]);
    $('.card-lotofacil #txtNumero14_2').val(numeros[13]);
    $('.card-lotofacil #txtNumero15_2').val(numeros[14]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts15].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-lotofacil #txtQtdeGanhadores15pts_2')[0].style = 'font-size: 2.125rem;';
        $('.card-lotofacil #txtQtdeGanhadores15pts_2').val('Acumulou');
        $('.card-lotofacil #txtValorGanhadores15pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-lotofacil #txtValorAcumulado2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-lotofacil #txtQtdeGanhadores15pts_2').val(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts15].quantidade_ganhadores);
        $('.card-lotofacil #txtValorGanhadores15pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts15].valor_total.toLocaleString('pt-BR')));
        $('.card-lotofacil #txtValorAcumulado2').val('0');
    }
    $('.card-lotofacil #txtQtdeGanhadores15pts_2').val(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts15].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores15pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts15].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores14pts_2').val(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts14].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores14pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts14].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores13pts_2').val(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts13].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores13pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts13].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores12pts_2').val(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts12].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores12pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts12].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtQtdeGanhadores11pts_2').val(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts11].quantidade_ganhadores);
    $('.card-lotofacil #txtValorGanhadores11pts_2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].premiacao[enumPremiacaoLotofacil.pts11].valor_total.toLocaleString('pt-BR')));
    $('.card-lotofacil #txtValorAcumulado2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.lotofacil2].valor_acumulado.toLocaleString('pt-BR')));
}

function PreencheResultadosQuina(resultado) {
    $('.card-quina #txtNumeroConcurso1').val(resultado.listaResultado[enumJogos.quina1].numero_concurso);
    $('.card-quina #txtDataConcurso1').val(FormataData(resultado.listaResultado[enumJogos.quina1].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.quina1].dezenas;
    $('.card-quina #txtNumero1_1').val(numeros[0]);
    $('.card-quina #txtNumero2_1').val(numeros[1]);
    $('.card-quina #txtNumero3_1').val(numeros[2]);
    $('.card-quina #txtNumero4_1').val(numeros[3]);
    $('.card-quina #txtNumero5_1').val(numeros[4]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.quina].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-quina #txtQtdeGanhadoresQuina1')[0].style = 'font-size: 2.125rem;';
        $('.card-quina #txtQtdeGanhadoresQuina1').val('Acumulou');
        $('.card-quina #txtValorGanhadoresQuina1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina1].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-quina #txtValorAcumulado1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina1].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-quina #txtQtdeGanhadoresQuina1').val(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.quina].quantidade_ganhadores);
        $('.card-quina #txtValorGanhadoresQuina1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.quina].valor_total.toLocaleString('pt-BR')));
        $('.card-quina #txtValorAcumulado1').val('0');
    }

    $('.card-quina #txtQtdeGanhadoresQuadra1').val(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.quadra].quantidade_ganhadores);
    $('.card-quina #txtValorGanhadoresQuadra1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.quadra].valor_total.toLocaleString('pt-BR')));
    $('.card-quina #txtQtdeGanhadoresTerno1').val(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.terno].quantidade_ganhadores);
    $('.card-quina #txtValorGanhadoresTerno1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.terno].valor_total.toLocaleString('pt-BR')));
    $('.card-quina #txtQtdeGanhadoresDuque1').val(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.duque].quantidade_ganhadores);
    $('.card-quina #txtValorGanhadoresDuque1').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina1].premiacao[enumPremiacaoQuina.duque].valor_total.toLocaleString('pt-BR')));


    $('.card-quina #txtNumeroConcurso2').val(resultado.listaResultado[enumJogos.quina2].numero_concurso);
    $('.card-quina #txtDataConcurso2').val(FormataData(resultado.listaResultado[enumJogos.quina2].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.quina2].dezenas;
    $('.card-quina #txtNumero1_2').val(numeros[0]);
    $('.card-quina #txtNumero2_2').val(numeros[1]);
    $('.card-quina #txtNumero3_2').val(numeros[2]);
    $('.card-quina #txtNumero4_2').val(numeros[3]);
    $('.card-quina #txtNumero5_2').val(numeros[4]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.quina].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-quina #txtQtdeGanhadoresQuina2')[0].style = 'font-size: 2.125rem;';
        $('.card-quina #txtQtdeGanhadoresQuina2').val('Acumulou');
        $('.card-quina #txtValorGanhadoresQuina2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina2].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-quina #txtValorAcumulado2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina2].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-quina #txtQtdeGanhadoresQuina2').val(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.quina].quantidade_ganhadores);
        $('.card-quina #txtValorGanhadoresQuina2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.quina].valor_total.toLocaleString('pt-BR')));
        $('.card-quina #txtValorAcumulado2').val('0');
    }

    $('.card-quina #txtQtdeGanhadoresQuadra2').val(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.quadra].quantidade_ganhadores);
    $('.card-quina #txtValorGanhadoresQuadra2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.quadra].valor_total.toLocaleString('pt-BR')));
    $('.card-quina #txtQtdeGanhadoresTerno2').val(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.terno].quantidade_ganhadores);
    $('.card-quina #txtValorGanhadoresTerno2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.terno].valor_total.toLocaleString('pt-BR')));
    $('.card-quina #txtQtdeGanhadoresDuque2').val(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.duque].quantidade_ganhadores);
    $('.card-quina #txtValorGanhadoresDuque2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.quina2].premiacao[enumPremiacaoQuina.duque].valor_total.toLocaleString('pt-BR')));

}

function PreencheResultadosLoteca(resultado) {
    $('.card-loteca #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.loteca].numero_concurso);
    $('.card-loteca #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.loteca].data_concurso));
    var jogos = resultado.listaResultado[enumJogos.loteca].jogos;
    for (var i = 0; i < 14; i++) {
        var index = (i + 1);
        if (jogos[i].coluna_um) {
            $('.card-loteca #txtNumero0_' + index).val('X');
        } else if (jogos[i].coluna_meio) {
            $('.card-loteca #txtNumero1_' + index).val('X');
        } else if (jogos[i].coluna_dois) {
            $('.card-loteca #txtNumero2_' + index).val('X');
        }
    }
    var qtdeGanhadores = resultado.listaResultado[enumJogos.loteca].premiacao[enumPremiacaoLoteca.acertos14].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-loteca #txtQtdeGanhadores14pts')[0].style = 'font-size: 2.125rem;';
        $('.card-loteca #txtQtdeGanhadores14pts').val('Acumulou');
        $('.card-loteca #txtValorGanhadores14pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.loteca].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-loteca #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.loteca].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-loteca #txtQtdeGanhadores14pts').val(resultado.listaResultado[enumJogos.loteca].premiacao[enumPremiacaoLoteca.acertos14].quantidade_ganhadores);
        $('.card-loteca #txtValorGanhadores14pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.loteca].premiacao[enumPremiacaoLoteca.acertos14].valor_total.toLocaleString('pt-BR')));
        $('.card-loteca #txtValorAcumulado').val('0');
    }

    $('.card-loteca #txtQtdeGanhadores13pts').val(resultado.listaResultado[enumJogos.loteca].premiacao[enumPremiacaoLoteca.acertos13].quantidade_ganhadores);
    $('.card-loteca #txtValorGanhadores13pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.loteca].premiacao[enumPremiacaoLoteca.acertos13].valor_total.toLocaleString('pt-BR')));
}

function PreencheResultadosTimeMania(resultado) {
    $('.card-timemania #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.timemania].numero_concurso);
    $('.card-timemania #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.timemania].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.timemania].dezenas;
    $('.card-timemania #txtNumero1').val(numeros[0]);
    $('.card-timemania #txtNumero2').val(numeros[1]);
    $('.card-timemania #txtNumero3').val(numeros[2]);
    $('.card-timemania #txtNumero4').val(numeros[3]);
    $('.card-timemania #txtNumero5').val(numeros[4]);
    $('.card-timemania #txtNumero6').val(numeros[5]);
    $('.card-timemania #txtNumero7').val(numeros[6]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos7].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-timemania #txtQtdeGanhadores7pts').val('Acumulou');
        $('.card-timemania #txtValorGanhadores7pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-timemania #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-timemania #txtQtdeGanhadores7pts').val(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos7].quantidade_ganhadores);
        $('.card-timemania #txtValorGanhadores7pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos7].valor_total.toLocaleString('pt-BR')));
        $('.card-timemania #txtValorAcumulado').val('0');
    }
    
    $('.card-timemania #txtQtdeGanhadores6pts').val(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos6].quantidade_ganhadores);
    $('.card-timemania #txtValorGanhadores6pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos6].valor_total.toLocaleString('pt-BR')));
    $('.card-timemania #txtQtdeGanhadores5pts').val(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos5].quantidade_ganhadores);
    $('.card-timemania #txtValorGanhadores5pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos5].valor_total.toLocaleString('pt-BR')));
    $('.card-timemania #txtQtdeGanhadores4pts').val(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos4].quantidade_ganhadores);
    $('.card-timemania #txtValorGanhadores4pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos4].valor_total.toLocaleString('pt-BR')));
    $('.card-timemania #txtQtdeGanhadores3pts').val(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos3].quantidade_ganhadores);
    $('.card-timemania #txtValorGanhadores3pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.acertos3].valor_total.toLocaleString('pt-BR')));
    $('.card-timemania #txtQtdeGanhadoresTimeSorteado').val(resultado.listaResultado[enumJogos.timemania].nome_time_coracao);
    $('.card-timemania #txtQtdeGanhadoresTimeCoracao').val(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.timecoracao].quantidade_ganhadores);
    $('.card-timemania #txtValorGanhadoresTimeCoracao').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.timemania].premiacao[enumPremiacaoTimeMania.timecoracao].valor_total.toLocaleString('pt-BR')));
}

function PreencheResultadosDuplaSena(resultado) {
    $('.card-dupla-sena #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.duplasena1].numero_concurso);
    $('.card-dupla-sena #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.duplasena1].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.duplasena1].dezenas;
    $('.card-dupla-sena #txtNumero1').val(numeros[0]);
    $('.card-dupla-sena #txtNumero2').val(numeros[1]);
    $('.card-dupla-sena #txtNumero3').val(numeros[2]);
    $('.card-dupla-sena #txtNumero4').val(numeros[3]);
    $('.card-dupla-sena #txtNumero5').val(numeros[4]);
    $('.card-dupla-sena #txtNumero6').val(numeros[5]);
    var qtdeGanhadoresSena = resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.sena].quantidade_ganhadores;
    if (qtdeGanhadoresSena == 0) {
        $('.card-dupla-sena #txtQtdeGanhadoresSena')[0].style = 'font-size: 2.125rem;';
        $('.card-dupla-sena #txtQtdeGanhadoresSena').val('Acumulou');
        $('.card-dupla-sena #txtValorGanhadoresSena').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena1].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-dupla-sena #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena1].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    }
    else {
        $('.card-dupla-sena #txtQtdeGanhadoresSena').val(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.sena].quantidade_ganhadores);
        $('.card-dupla-sena #txtValorGanhadoresSena').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.sena].valor_total.toLocaleString('pt-BR')));
        $('.card-dupla-sena #txtValorAcumulado').val('0');
    }
    $('.card-dupla-sena #txtQtdeGanhadoresQuina').val(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.quina].quantidade_ganhadores);
    $('.card-dupla-sena #txtValorGanhadoresQuina').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.quina].valor_total.toLocaleString('pt-BR')));
    $('.card-dupla-sena #txtQtdeGanhadoresQuadra').val(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.quadra].quantidade_ganhadores);
    $('.card-dupla-sena #txtValorGanhadoresQuadra').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.quadra].valor_total.toLocaleString('pt-BR')));
    $('.card-dupla-sena #txtQtdeGanhadoresTerno').val(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.terno].quantidade_ganhadores);
    $('.card-dupla-sena #txtValorGanhadoresTerno').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena1].premiacao[enumPremiacaoDuplaSena.terno].valor_total.toLocaleString('pt-BR')));

    var numeros = resultado.listaResultado[enumJogos.duplasena2].dezenas;
    $('.card-dupla-sena #txtNumero7').val(numeros[0]);
    $('.card-dupla-sena #txtNumero8').val(numeros[1]);
    $('.card-dupla-sena #txtNumero9').val(numeros[2]);
    $('.card-dupla-sena #txtNumero10').val(numeros[3]);
    $('.card-dupla-sena #txtNumero11').val(numeros[4]);
    $('.card-dupla-sena #txtNumero12').val(numeros[5]);
    var qtdeGanhadoresSena = resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.sena].quantidade_ganhadores;
    if (qtdeGanhadoresSena == 0) {
        $('.card-dupla-sena #txtQtdeGanhadoresSena2')[0].style = 'font-size: 2.125rem;';
        $('.card-dupla-sena #txtQtdeGanhadoresSena2').val('Acumulou');
        $('.card-dupla-sena #txtValorGanhadoresSena2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena2].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-dupla-sena #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena2].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    }
    else {
        $('.card-dupla-sena #txtQtdeGanhadoresSena2').val(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.sena].quantidade_ganhadores);
        $('.card-dupla-sena #txtValorGanhadoresSena2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.sena].valor_total.toLocaleString('pt-BR')));
        $('.card-dupla-sena #txtValorAcumulado').val('0');
    }
    $('.card-dupla-sena #txtQtdeGanhadoresQuina2').val(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.quina].quantidade_ganhadores);
    $('.card-dupla-sena #txtValorGanhadoresQuina2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.quina].valor_total.toLocaleString('pt-BR')));
    $('.card-dupla-sena #txtQtdeGanhadoresQuadra2').val(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.quadra].quantidade_ganhadores);
    $('.card-dupla-sena #txtValorGanhadoresQuadra2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.quadra].valor_total.toLocaleString('pt-BR')));
    $('.card-dupla-sena #txtQtdeGanhadoresTerno2').val(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.terno].quantidade_ganhadores);
    $('.card-dupla-sena #txtValorGanhadoresTerno2').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.duplasena2].premiacao[enumPremiacaoDuplaSena.terno].valor_total.toLocaleString('pt-BR')));

}

function PreencheResultadosSuperSete(resultado) {
    $('.card-super-sete #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.supersete].numero_concurso);
    $('.card-super-sete #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.supersete].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.supersete].dezenas;
    $('.card-super-sete #txtNumero1').val(numeros[0]);
    $('.card-super-sete #txtNumero2').val(numeros[1]);
    $('.card-super-sete #txtNumero3').val(numeros[2]);
    $('.card-super-sete #txtNumero4').val(numeros[3]);
    $('.card-super-sete #txtNumero5').val(numeros[4]);
    $('.card-super-sete #txtNumero6').val(numeros[5]);
    $('.card-super-sete #txtNumero7').val(numeros[6]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos7].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-super-sete #txtQtdeGanhadores7pts')[0].style = 'font-size: 2.125rem;';
        $('.card-super-sete #txtQtdeGanhadores7pts').val('Acumulou');
        $('.card-super-sete #txtValorGanhadores7pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-super-sete #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-super-sete #txtQtdeGanhadores7pts').val(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos7].quantidade_ganhadores);
        $('.card-super-sete #txtValorGanhadores7pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos7].valor_total.toLocaleString('pt-BR')));
        $('.card-super-sete #txtValorAcumulado').val('0');
    }
    
    $('.card-super-sete #txtQtdeGanhadores6pts').val(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos6].quantidade_ganhadores);
    $('.card-super-sete #txtValorGanhadores6pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos6].valor_total.toLocaleString('pt-BR')));
    $('.card-super-sete #txtQtdeGanhadores5pts').val(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos5].quantidade_ganhadores);
    $('.card-super-sete #txtValorGanhadores5pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos5].valor_total.toLocaleString('pt-BR')));
    $('.card-super-sete #txtQtdeGanhadores4pts').val(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos4].quantidade_ganhadores);
    $('.card-super-sete #txtValorGanhadores4pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos4].valor_total.toLocaleString('pt-BR')));
    $('.card-super-sete #txtQtdeGanhadores3pts').val(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos3].quantidade_ganhadores);
    $('.card-super-sete #txtValorGanhadores3pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.supersete].premiacao[enumPremiacaoSuperSete.acertos3].valor_total.toLocaleString('pt-BR')));
    
}

function PreencheResultadosDiaDeSorte(resultado) {
    $('.card-dia-de-sorte #txtNumeroConcurso').val(resultado.listaResultado[enumJogos.diadesorte].numero_concurso);
    $('.card-dia-de-sorte #txtDataConcurso').val(FormataData(resultado.listaResultado[enumJogos.diadesorte].data_concurso));
    var numeros = resultado.listaResultado[enumJogos.diadesorte].dezenas;
    $('.card-dia-de-sorte #txtNumero1').val(numeros[0]);
    $('.card-dia-de-sorte #txtNumero2').val(numeros[1]);
    $('.card-dia-de-sorte #txtNumero3').val(numeros[2]);
    $('.card-dia-de-sorte #txtNumero4').val(numeros[3]);
    $('.card-dia-de-sorte #txtNumero5').val(numeros[4]);
    $('.card-dia-de-sorte #txtNumero6').val(numeros[5]);
    $('.card-dia-de-sorte #txtNumero7').val(numeros[6]);
    var qtdeGanhadores = resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos7].quantidade_ganhadores;
    if (qtdeGanhadores == 0) {
        $('.card-dia-de-sorte #txtQtdeGanhadores7pts')[0].style = 'font-size: 2.125rem;';
        $('.card-dia-de-sorte #txtQtdeGanhadores7pts').val('Acumulou');
        $('.card-dia-de-sorte #txtValorGanhadores7pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].valor_acumulado.toLocaleString('pt-BR')));
        $('.card-dia-de-sorte #txtValorAcumulado').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].valor_estimado_proximo_concurso.toLocaleString('pt-BR')));
    } else {
        $('.card-dia-de-sorte #txtQtdeGanhadores7pts').val(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos7].quantidade_ganhadores);
        $('.card-dia-de-sorte #txtValorGanhadores7pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos7].valor_total.toLocaleString('pt-BR')));
        $('.card-dia-de-sorte #txtValorAcumulado').val('0');
    }
    
    $('.card-dia-de-sorte #txtQtdeGanhadores6pts').val(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos6].quantidade_ganhadores);
    $('.card-dia-de-sorte #txtValorGanhadores6pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos6].valor_total.toLocaleString('pt-BR')));
    $('.card-dia-de-sorte #txtQtdeGanhadores5pts').val(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos5].quantidade_ganhadores);
    $('.card-dia-de-sorte #txtValorGanhadores5pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos5].valor_total.toLocaleString('pt-BR')));
    $('.card-dia-de-sorte #txtQtdeGanhadores4pts').val(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos4].quantidade_ganhadores);
    $('.card-dia-de-sorte #txtValorGanhadores4pts').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.acertos4].valor_total.toLocaleString('pt-BR')));
    $('.card-dia-de-sorte #txtNumMesSorteado').val(resultado.listaResultado[enumJogos.diadesorte].dezena_mes_sorte);
    $('.card-dia-de-sorte #txtNumGanhadores').val(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.mesdasorte].quantidade_ganhadores);
    $('.card-dia-de-sorte #txtValorTotal').val(FormataValores2CasaDecimais(resultado.listaResultado[enumJogos.diadesorte].premiacao[enumPremiacaoDiaDeSorte.mesdasorte].valor_total.toLocaleString('pt-BR')));
    
}

function FormataValores2CasaDecimais(valor) {
    valorformatado = valor;
    var valorSplit = valor.split(',');
    if (valorSplit != null && valorSplit.length > 1) {
        if (valorSplit[1].length == 1)
            valorformatado = valorSplit[0] + ',' + valorSplit[1] + '0';
        else
            valorformatado = valorSplit[0] + ',' + valorSplit[1];
    }
    else if (valor != '0') {
        valorformatado = valor + ',00';
    }
    return valorformatado;
}

function FormataData(data) {
    return new Date(data).toLocaleDateString("pt-BR");
}