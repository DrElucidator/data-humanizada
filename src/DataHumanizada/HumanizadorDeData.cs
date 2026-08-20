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

        if (tempoDecorrido.TotalDays < 1)
        {
            int horas = (int)tempoDecorrido.TotalHours;
            string unidadeHoras = horas == 1 ? "hora" : "horas";

            return $"Há {horas} {unidadeHoras}";
        }

        int dias = (int)tempoDecorrido.TotalDays;

        if (dias == 1)
            return "Um dia atrás";

        string diasPorExtenso = ConverterDiasPorExtenso(dias);

        return $"{diasPorExtenso} dias atrás";
    }

    private static string ConverterDiasPorExtenso(int dias)
    {
        return dias switch
        {
            2 => "Dois",
            3 => "Três",
            4 => "Quatro",
            5 => "Cinco",
            6 => "Seis",
            _ => throw new NotImplementedException()
        };
    }
}
