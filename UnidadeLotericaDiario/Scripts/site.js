$(document).ready(function () {
    //CarregarTela();
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
        }
    });
});