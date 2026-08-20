namespace DataHumanizada;

public static class HumanizadorDeData
{
    public static string Humanizar(DateTime dataInformada, DateTime dataAtual)
    {
        TimeSpan tempoDecorrido = dataAtual - dataInformada;

        if (tempoDecorrido == TimeSpan.Zero)
            return "Agora mesmo";

        int segundos = (int)tempoDecorrido.TotalSeconds;

        return $"Há {segundos} segundos";
    }
}
