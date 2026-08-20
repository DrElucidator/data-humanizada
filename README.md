# Data Humanizada

Componente desenvolvido em .NET para descrever, em português, o tempo decorrido entre uma data e hora informada e uma data e hora atual.

O projeto será desenvolvido com TDD. Cada regra deve ser introduzida por um teste automatizado, seguida pela implementação mínima necessária e pela refatoração do código com a suíte aprovada.

## Funcionamento

O componente receberá duas datas:

- a data e hora que será humanizada;
- a data e hora atual usada como referência para o cálculo.

Exemplos de resultados:

```text
17/06/2026 23:59:30 -> Há 30 segundos
17/06/2026 23:55:00 -> Há 5 minutos
17/06/2026 20:00:00 -> Há 4 horas
17/06/2026 00:00:00 -> Um dia atrás
11/05/2026 00:00:00 -> Um mês e uma semana atrás
18/06/2025 00:00:00 -> Um ano atrás
```

Nos casos fornecidos pelo enunciado, a data atual considerada é `18/06/2026 00:00:00`. Ela será informada ao componente em vez de consultada diretamente no sistema, mantendo o cálculo determinístico e permitindo que os testes controlem o instante de referência.

## Regras de negócio

- Uma diferença igual a zero deve retornar `Agora mesmo`.
- Diferenças inferiores a um minuto devem ser apresentadas em segundos.
- Diferenças inferiores a uma hora devem ser apresentadas em minutos completos.
- Diferenças inferiores a um dia devem ser apresentadas em horas completas.
- Períodos maiores devem considerar dias, semanas, meses e anos completos.
- A saída deve conter, no máximo, as duas maiores unidades de tempo completas.
- O cálculo não deve arredondar unidades incompletas.
- O texto deve respeitar o singular e o plural de cada unidade.
- A data informada não pode ser posterior à data atual.
- O cálculo de meses e anos deve respeitar o calendário, incluindo anos bissextos e a quantidade real de dias de cada mês.

## Decisões adotadas

### Data atual recebida como parâmetro

O componente não utilizará `DateTime.Now` internamente. A data atual será recebida como argumento para evitar resultados dependentes do relógio da máquina e tornar os testes repetíveis.

### Datas futuras

Uma data futura será rejeitada por meio de uma exceção de argumento. Mensagens de erro não serão retornadas como se fossem uma data humanizada válida.

### Representação dos números

Para manter coerência com a tabela de exemplos:

- segundos, minutos e horas serão exibidos com algarismos, como `Há 5 minutos`;
- dias, semanas, meses e anos serão escritos por extenso, como `Dois dias atrás` e `Dez anos atrás`.

### Limite de unidades

A saída utilizará no máximo duas unidades. O exemplo opcional com ano, mês e semana não será adotado porque contraria essa regra.

### Cálculo por calendário

Um mês não será tratado como trinta dias, nem um ano como 365 dias. Anos e meses completos serão obtidos por operações de calendário; depois disso, o restante será decomposto nas unidades menores permitidas.

## Estrutura da solução

```text
data-humanizada/
├── DataHumanizada.slnx
├── README.md
├── src/
│   └── DataHumanizada/
│       ├── DataHumanizada.csproj
│       └── HumanizadorDeData.cs
└── tests/
    └── DataHumanizada.Testes.Unidade/
        ├── DataHumanizada.Testes.Unidade.csproj
        ├── HumanizadorDeDataTests.cs
        └── MSTestSettings.cs
```

O projeto `DataHumanizada` contém o componente e suas regras. O projeto `DataHumanizada.Testes.Unidade` contém os casos automatizados que orientarão o desenvolvimento.

Não são necessários banco de dados, Entity Framework Core, migrations, aplicação web, testes de integração ou testes E2E, pois o exercício consiste em um cálculo isolado e determinístico.

## Ordem de desenvolvimento

Os testes serão implementados progressivamente nesta ordem:

1. agora mesmo e segundos;
2. minutos;
3. horas;
4. dias;
5. semanas;
6. meses e unidades restantes;
7. anos e unidades restantes;
8. singular e plural;
9. limite de duas unidades;
10. rejeição de datas futuras;
11. anos bissextos e meses com quantidades diferentes de dias.

## Execução dos testes

Na pasta principal da solução, execute:

```powershell
dotnet test DataHumanizada.slnx
```
