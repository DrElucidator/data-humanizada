namespace DataHumanizada;

public static class HumanizadorDeData
{
    public static string Humanizar(DateTime dataInformada, DateTime dataAtual)
    {
        if (dataInformada > dataAtual)
        {
            throw new ArgumentException(
                "A data informada não pode ser posterior à data atual.",
                nameof(dataInformada)
            );
        }

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

        int anos = CalcularAnosCompletos(dataInformada, dataAtual);

        if (anos > 0)
        {
            string anosPorExtenso = ConverterAnosPorExtenso(anos);
            string unidadeAnos = anos == 1 ? "ano" : "anos";
            string descricaoAnos = $"{anosPorExtenso} {unidadeAnos}";

            DateTime dataAposAnos = dataInformada.AddYears(anos);
            int mesesRestantesAposAnos = CalcularMesesCompletos(dataAposAnos, dataAtual);

            if (mesesRestantesAposAnos > 0)
            {
                string mesesPorExtenso = ConverterMesesPorExtenso(mesesRestantesAposAnos)
                    .ToLowerInvariant();
                string unidadeMeses = mesesRestantesAposAnos == 1 ? "mês" : "meses";

                return $"{descricaoAnos} e {mesesPorExtenso} {unidadeMeses} atrás";
            }

            int diasRestantesAposAnos = (dataAtual - dataAposAnos).Days;

            if (diasRestantesAposAnos >= 7)
            {
                int semanasRestantes = diasRestantesAposAnos / 7;
                string semanasPorExtenso = ConverterSemanasPorExtenso(semanasRestantes)
                    .ToLowerInvariant();
                string unidadeSemanas = semanasRestantes == 1 ? "semana" : "semanas";

                return $"{descricaoAnos} e {semanasPorExtenso} {unidadeSemanas} atrás";
            }

            return $"{descricaoAnos} atrás";
        }

        int meses = CalcularMesesCompletos(dataInformada, dataAtual);

        if (meses > 0)
        {
            string mesesPorExtenso = ConverterMesesPorExtenso(meses);
            string unidadeMeses = meses == 1 ? "mês" : "meses";
            string descricaoMeses = $"{mesesPorExtenso} {unidadeMeses}";

            DateTime dataAposMeses = dataInformada.AddMonths(meses);
            int diasRestantes = (dataAtual - dataAposMeses).Days;

            if (diasRestantes >= 7)
            {
                int semanasRestantes = diasRestantes / 7;
                string semanasPorExtenso = ConverterSemanasPorExtenso(semanasRestantes)
                    .ToLowerInvariant();
                string unidadeSemanas = semanasRestantes == 1 ? "semana" : "semanas";

                return $"{descricaoMeses} e {semanasPorExtenso} {unidadeSemanas} atrás";
            }

            if (diasRestantes > 0)
            {
                string diasRestantesPorExtenso = diasRestantes == 1
                    ? "um"
                    : ConverterDiasPorExtenso(diasRestantes).ToLowerInvariant();
                string unidadeDias = diasRestantes == 1 ? "dia" : "dias";

                return $"{descricaoMeses} e {diasRestantesPorExtenso} {unidadeDias} atrás";
            }

            return $"{descricaoMeses} atrás";
        }

        int dias = (int)tempoDecorrido.TotalDays;

        if (dias == 1)
            return "Um dia atrás";

        if (dias is >= 7 and <= 28)
        {
            int semanas = dias / 7;
            string semanasPorExtenso = ConverterSemanasPorExtenso(semanas);
            string unidadeSemanas = semanas == 1 ? "semana" : "semanas";

            return $"{semanasPorExtenso} {unidadeSemanas} atrás";
        }

        string diasPorExtenso = ConverterDiasPorExtenso(dias);

        return $"{diasPorExtenso} dias atrás";
    }

    private static int CalcularAnosCompletos(DateTime dataInformada, DateTime dataAtual)
    {
        int anos = dataAtual.Year - dataInformada.Year;

        if (dataInformada.AddYears(anos) > dataAtual)
            anos--;

        return anos;
    }

    private static string ConverterAnosPorExtenso(int anos)
    {
        return anos switch
        {
            1 => "Um",
            2 => "Dois",
            10 => "Dez",
            _ => throw new NotImplementedException()
        };
    }

    private static int CalcularMesesCompletos(DateTime dataInformada, DateTime dataAtual)
    {
        int meses = (dataAtual.Year - dataInformada.Year) * 12;
        meses += dataAtual.Month - dataInformada.Month;

        if (dataInformada.AddMonths(meses) > dataAtual)
            meses--;

        return meses;
    }

    private static string ConverterMesesPorExtenso(int meses)
    {
        return meses switch
        {
            1 => "Um",
            2 => "Dois",
            _ => throw new NotImplementedException()
        };
    }

    private static string ConverterSemanasPorExtenso(int semanas)
    {
        return semanas switch
        {
            1 => "Uma",
            2 => "Duas",
            3 => "Três",
            4 => "Quatro",
            _ => throw new NotImplementedException()
        };
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
