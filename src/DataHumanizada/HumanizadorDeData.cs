namespace DataHumanizada;

public static class HumanizadorDeData
{
    public static string Humanizar(DateTime dataInformada, DateTime dataAtual)
    {
        ValidarDataInformada(dataInformada, dataAtual);

        TimeSpan tempoDecorrido = dataAtual - dataInformada;

        if (tempoDecorrido == TimeSpan.Zero)
            return "Agora mesmo";

        if (tempoDecorrido.TotalMinutes < 1)
            return FormatarPeriodoCurto((int)tempoDecorrido.TotalSeconds, "segundo");

        if (tempoDecorrido.TotalHours < 1)
            return FormatarPeriodoCurto((int)tempoDecorrido.TotalMinutes, "minuto");

        if (tempoDecorrido.TotalDays < 1)
            return FormatarPeriodoCurto((int)tempoDecorrido.TotalHours, "hora");

        int anos = CalcularAnosCompletos(dataInformada, dataAtual);

        if (anos > 0)
            return HumanizarAnos(dataInformada, dataAtual, anos);

        int meses = CalcularMesesCompletos(dataInformada, dataAtual);

        if (meses > 0)
            return HumanizarMeses(dataInformada, dataAtual, meses);

        int dias = (int)tempoDecorrido.TotalDays;

        return HumanizarDias(dias);
    }

    private static void ValidarDataInformada(DateTime dataInformada, DateTime dataAtual)
    {
        if (dataInformada <= dataAtual)
            return;

        throw new ArgumentException(
            "A data informada não pode ser posterior à data atual.",
            nameof(dataInformada)
        );
    }

    private static string FormatarPeriodoCurto(int quantidade, string unidade)
    {
        string unidadeFormatada = quantidade == 1 ? unidade : $"{unidade}s";

        return $"Há {quantidade} {unidadeFormatada}";
    }

    private static string HumanizarAnos(
        DateTime dataInformada,
        DateTime dataAtual,
        int anos
    )
    {
        string anosPorExtenso = ConverterAnosPorExtenso(anos);
        string unidadeAnos = anos == 1 ? "ano" : "anos";
        string descricaoAnos = $"{anosPorExtenso} {unidadeAnos}";

        DateTime dataAposAnos = dataInformada.AddYears(anos);
        int mesesRestantes = CalcularMesesCompletos(dataAposAnos, dataAtual);

        if (mesesRestantes > 0)
        {
            string mesesPorExtenso = ConverterMesesPorExtenso(mesesRestantes)
                .ToLowerInvariant();
            string unidadeMeses = mesesRestantes == 1 ? "mês" : "meses";

            return $"{descricaoAnos} e {mesesPorExtenso} {unidadeMeses} atrás";
        }

        int diasRestantes = (dataAtual - dataAposAnos).Days;

        if (diasRestantes >= 7)
        {
            int semanasRestantes = diasRestantes / 7;
            string semanasPorExtenso = ConverterSemanasPorExtenso(semanasRestantes)
                .ToLowerInvariant();
            string unidadeSemanas = semanasRestantes == 1 ? "semana" : "semanas";

            return $"{descricaoAnos} e {semanasPorExtenso} {unidadeSemanas} atrás";
        }

        return $"{descricaoAnos} atrás";
    }

    private static string HumanizarMeses(
        DateTime dataInformada,
        DateTime dataAtual,
        int meses
    )
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
            string diasPorExtenso = ConverterDiasPorExtenso(diasRestantes)
                .ToLowerInvariant();
            string unidadeDias = diasRestantes == 1 ? "dia" : "dias";

            return $"{descricaoMeses} e {diasPorExtenso} {unidadeDias} atrás";
        }

        return $"{descricaoMeses} atrás";
    }

    private static string HumanizarDias(int dias)
    {
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
        return ConverterComInicialMaiuscula(anos);
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
        return ConverterComInicialMaiuscula(meses);
    }

    private static string ConverterSemanasPorExtenso(int semanas)
    {
        return semanas switch
        {
            1 => "Uma",
            2 => "Duas",
            _ => ConverterComInicialMaiuscula(semanas)
        };
    }

    private static string ConverterDiasPorExtenso(int dias)
    {
        return ConverterComInicialMaiuscula(dias);
    }

    private static string ConverterComInicialMaiuscula(int numero)
    {
        string numeroPorExtenso = ConversorNumeroPorExtenso.Converter(numero);

        return char.ToUpperInvariant(numeroPorExtenso[0]) + numeroPorExtenso[1..];
    }
}
