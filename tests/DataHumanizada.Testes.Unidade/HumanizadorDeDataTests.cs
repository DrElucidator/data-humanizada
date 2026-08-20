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
}
