namespace DataHumanizada;

internal static class ConversorNumeroPorExtenso
{
    public static string Converter(int numero)
    {
        if (numero is <= 0 or > 9999)
            throw new ArgumentOutOfRangeException(nameof(numero));

        if (numero < 20)
            return ConverterAteDezenove(numero);

        if (numero < 100)
        {
            int dezenas = numero / 10;
            int unidades = numero % 10;
            string descricaoDezenas = ConverterDezena(dezenas);

            return unidades == 0
                ? descricaoDezenas
                : $"{descricaoDezenas} e {ConverterAteDezenove(unidades)}";
        }

        if (numero < 1000)
            return ConverterCentena(numero);

        int milhares = numero / 1000;
        int restante = numero % 1000;
        string descricaoMilhares = milhares == 1
            ? "mil"
            : $"{Converter(milhares)} mil";

        if (restante == 0)
            return descricaoMilhares;

        string conector = restante < 100 || restante % 100 == 0 ? " e " : " ";

        return $"{descricaoMilhares}{conector}{Converter(restante)}";
    }

    private static string ConverterAteDezenove(int numero)
    {
        return numero switch
        {
            0 => "zero",
            1 => "um",
            2 => "dois",
            3 => "três",
            4 => "quatro",
            5 => "cinco",
            6 => "seis",
            7 => "sete",
            8 => "oito",
            9 => "nove",
            10 => "dez",
            11 => "onze",
            12 => "doze",
            13 => "treze",
            14 => "quatorze",
            15 => "quinze",
            16 => "dezesseis",
            17 => "dezessete",
            18 => "dezoito",
            19 => "dezenove",
            _ => throw new ArgumentOutOfRangeException(nameof(numero))
        };
    }

    private static string ConverterDezena(int dezena)
    {
        return dezena switch
        {
            2 => "vinte",
            3 => "trinta",
            4 => "quarenta",
            5 => "cinquenta",
            6 => "sessenta",
            7 => "setenta",
            8 => "oitenta",
            9 => "noventa",
            _ => throw new ArgumentOutOfRangeException(nameof(dezena))
        };
    }

    private static string ConverterCentena(int numero)
    {
        if (numero == 100)
            return "cem";

        int centenas = numero / 100;
        int restante = numero % 100;

        string descricaoCentenas = centenas switch
        {
            1 => "cento",
            2 => "duzentos",
            3 => "trezentos",
            4 => "quatrocentos",
            5 => "quinhentos",
            6 => "seiscentos",
            7 => "setecentos",
            8 => "oitocentos",
            9 => "novecentos",
            _ => throw new ArgumentOutOfRangeException(nameof(numero))
        };

        return restante == 0
            ? descricaoCentenas
            : $"{descricaoCentenas} e {Converter(restante)}";
    }
}
