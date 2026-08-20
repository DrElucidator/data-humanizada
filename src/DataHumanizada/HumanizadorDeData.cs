namespace DataHumanizada;

public static class HumanizadorDeData
{
    public static string Humanizar(DateTime dataInformada, DateTime dataAtual)
    {
        TimeSpan tempoDecorrido = dataAtual - dataInformada;

        if (tempoDecorrido == TimeSpan.Zero)
            return "Agora mesmo";

        if (tempoDecorrido.TotalMinutes < 1)
        {
            int segundos = (int)tempoDecorrido.TotalSeconds;
            string unidadeSegundos = segundos == 1 ? "segundo" : "segundos";

            return $"Há {segundos} {unidadeSegundos}";
        }

        if (tempoDecorrido.TotalHours < 1)
        {
            int minutos = (int)tempoDecorrido.TotalMinutes;
            string unidadeMinutos = minutos == 1 ? "minuto" : "minutos";

            return $"Há {minutos} {unidadeMinutos}";
        }

        int horas = (int)tempoDecorrido.TotalHours;
        string unidadeHoras = horas == 1 ? "hora" : "horas";

        return $"Há {horas} {unidadeHoras}";
    }
}
