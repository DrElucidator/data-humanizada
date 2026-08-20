namespace DataHumanizada.Testes.Unidade;

[TestClass]
public sealed class HumanizadorDeDataTests
{
    [TestMethod]
    public void Humanizar_DataIgualADataAtual_DeveRetornar_AgoraMesmo()
    {
        // Arranjo
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataAtual, dataAtual);

        // Asserção
        Assert.AreEqual("Agora mesmo", resultado);
    }

    [TestMethod]
    public void Humanizar_TrintaSegundosAntes_DeveRetornar_HaTrintaSegundos()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 23, 59, 30);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Há 30 segundos", resultado);
    }

    [TestMethod]
    public void Humanizar_UmSegundoAntes_DeveRetornar_HaUmSegundo()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 23, 59, 59);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Há 1 segundo", resultado);
    }

    [TestMethod]
    public void Humanizar_CincoMinutosAntes_DeveRetornar_HaCincoMinutos()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 23, 55, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Há 5 minutos", resultado);
    }

    [TestMethod]
    public void Humanizar_UmMinutoAntes_DeveRetornar_HaUmMinuto()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 23, 59, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Há 1 minuto", resultado);
    }

    [TestMethod]
    public void Humanizar_QuatroHorasAntes_DeveRetornar_HaQuatroHoras()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 20, 0, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Há 4 horas", resultado);
    }

    [TestMethod]
    public void Humanizar_UmaHoraAntes_DeveRetornar_HaUmaHora()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 23, 0, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Há 1 hora", resultado);
    }

    [TestMethod]
    public void Humanizar_UmDiaAntes_DeveRetornar_UmDiaAtras()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 17, 0, 0, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Um dia atrás", resultado);
    }

    [TestMethod]
    public void Humanizar_DoisDiasAntes_DeveRetornar_DoisDiasAtras()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 6, 16, 0, 0, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Dois dias atrás", resultado);
    }

    [TestMethod]
    [DataRow(3, "Três dias atrás")]
    [DataRow(4, "Quatro dias atrás")]
    [DataRow(5, "Cinco dias atrás")]
    [DataRow(6, "Seis dias atrás")]
    public void Humanizar_DiasCompletosAntesDeUmaSemana_DeveRetornar_DiasAtras(
        int quantidadeDeDias,
        string resultadoEsperado
    )
    {
        // Arranjo
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);
        DateTime dataInformada = dataAtual.AddDays(-quantidadeDeDias);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual(resultadoEsperado, resultado);
    }

    [TestMethod]
    [DataRow(1, "Uma semana atrás")]
    [DataRow(2, "Duas semanas atrás")]
    [DataRow(3, "Três semanas atrás")]
    [DataRow(4, "Quatro semanas atrás")]
    public void Humanizar_SemanasCompletas_DeveRetornar_SemanasAtras(
        int quantidadeDeSemanas,
        string resultadoEsperado
    )
    {
        // Arranjo
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);
        DateTime dataInformada = dataAtual.AddDays(-(quantidadeDeSemanas * 7));

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual(resultadoEsperado, resultado);
    }

    [TestMethod]
    [DataRow(1, "Um mês atrás")]
    [DataRow(2, "Dois meses atrás")]
    public void Humanizar_MesesCompletos_DeveRetornar_MesesAtras(
        int quantidadeDeMeses,
        string resultadoEsperado
    )
    {
        // Arranjo
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);
        DateTime dataInformada = dataAtual.AddMonths(-quantidadeDeMeses);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual(resultadoEsperado, resultado);
    }

    [TestMethod]
    public void Humanizar_UmMesEUmaSemanaAntes_DeveRetornar_UmMesEUmaSemanaAtras()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 5, 11, 0, 0, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Um mês e uma semana atrás", resultado);
    }

    [TestMethod]
    public void Humanizar_UmMesEDoisDiasAntes_DeveRetornar_UmMesEDoisDiasAtras()
    {
        // Arranjo
        DateTime dataInformada = new(2026, 5, 16, 0, 0, 0);
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual("Um mês e dois dias atrás", resultado);
    }

    [TestMethod]
    [DataRow(1, "Um ano atrás")]
    [DataRow(10, "Dez anos atrás")]
    public void Humanizar_AnosCompletos_DeveRetornar_AnosAtras(
        int quantidadeDeAnos,
        string resultadoEsperado
    )
    {
        // Arranjo
        DateTime dataAtual = new(2026, 6, 18, 0, 0, 0);
        DateTime dataInformada = dataAtual.AddYears(-quantidadeDeAnos);

        // Ação
        string resultado = HumanizadorDeData.Humanizar(dataInformada, dataAtual);

        // Asserção
        Assert.AreEqual(resultadoEsperado, resultado);
    }
}
