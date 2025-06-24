using System.Text;

Values values = new Values();
MontanhaRussa montanhaRussa = new MontanhaRussa(values);
async Task Exec()
{
    montanhaRussa.GerarCarrinhos();
    DateTime inicioSimulacao = DateTime.Now;
    var geraPassageirosTask = montanhaRussa.GerarPassageiros();
    var tarefasPasseio = new List<Task>();
    while (montanhaRussa.passageirosAtendidos < values.numeroDePassageiros)
    {
        var carrinho = await montanhaRussa.EmbarcarPassageiros();
        if (carrinho != null && carrinho.Passageiros.Count > 0)
        {
            tarefasPasseio.Add(montanhaRussa.Passeio(carrinho));
        }
    }
    await Task.WhenAll(tarefasPasseio);
    await geraPassageirosTask;
    montanhaRussa.Estatisticas(inicioSimulacao);
}
void imprime(string ascii)
{
    foreach (var line in ascii.Split('\n'))
    {
        Console.WriteLine(line);
        Thread.Sleep(40);
    }
}
while (true)
{
    Console.WriteLine("\nDigite 1 para inserir valores, 2 para valores default, 3 para sair. 4 para easter egg.");
    int decisao = Convert.ToInt32(Console.ReadLine());
    if (decisao == 1)
    {
        Console.Write("Digite o número de carrinhos: ");
        values.numeroDeCarrinhos = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o número de passageiros: ");
        values.numeroDePassageiros = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite a capacidade do carrinho: ");
        values.capacidadeCarrinho = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Digite o tempo de passeio (em segundos): ");
        values.tempoDePasseio = Convert.ToInt32(Console.ReadLine()) * 1000;

        Console.WriteLine("Digite o tempo de embarque/desembarque (em segundos): ");
        values.tempoDeEmbarqueDesembarque = Convert.ToInt32(Console.ReadLine()) * 1000;

        Console.WriteLine("Digite o intervalo mínimo de chegada (em segundos): ");
        values.intervaloMinimo = Convert.ToInt32(Console.ReadLine()) * 1000;

        Console.WriteLine("Digite o intervalo máximo de chegada (em segundos): ");
        values.intervaloMaximo = Convert.ToInt32(Console.ReadLine()) * 1000;

        await Exec();
        Console.WriteLine("Pressione 1 para sair e 2 para reiniciar a simulação.");
        int opcao = Convert.ToInt16(Console.ReadLine());
        if (opcao == 1)
        {
            break;
        }
        else if (opcao == 2)
        {
            montanhaRussa.Retry();
            continue;
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    else if (decisao == 2)
    {
        await Exec();

        Console.WriteLine("Pressione 1 para sair e 2 para reiniciar a simulação.");
        int opcao = Convert.ToInt16(Console.ReadLine());
        if (opcao == 1)
        {
            break;
        }
        else if (opcao == 2)
        {
            montanhaRussa.Retry();
            continue;
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    else if (decisao == 3)
    {
        break;
    }
    else if (decisao == 4)
    {
        await Exec();
        string ascii = @"
                       .,,uod8B8bou,,.
              ..,uod8BBBBBBBBBBBBBBBBRPFT?l!i:.
         ,=m8BBBBBBBBBBBBBBBRPFT?!||||||||||||||
         !...:!TVBBBRPFT||||||||||!!^^""'   ||||
         !.......:!?|||||!!^^""'            ||||
         !.........||||                     ||||
         !.........||||  ##                 ||||
         !.........||||                     ||||
         !.........||||                     ||||
         !.........||||                     ||||
         !.........||||                     ||||
         `.........||||                    ,||||
          .;.......||||               _.-!!|||||
   .,uodWBBBBb.....||||       _.-!!|||||||||!:'
!YBBBBBBBBBBBBBBb..!|||:..-!!|||||||!iof68BBBBBb....
!..YBBBBBBBBBBBBBBb!!||||||||!iof68BBBBBBRPFT?!::   `.
!....YBBBBBBBBBBBBBBbaaitf68BBBBBBRPFT?!:::::::::     `.
!......YBBBBBBBBBBBBBBBBBBBRPFT?!::::::;:!^'`;:::       `.
!........YBBBBBBBBBBRPFT?!::::::::::^''...::::::;         iBBbo.
`..........YBRPFT?!::::::::::::::::::::::::;iof68bo.      WBBBBbo.
  `..........:::::::::::::::::::::::;iof688888888888b.     `YBBBP^'
    `........::::::::::::::::;iof688888888888888888888b.     `
      `......:::::::::;iof688888888888888888888888888888b.
        `....:::;iof688888888888888888888888888888888899fT!
          `..::!8888888888888888888888888888888899fT|!^''
            `' !!988888888888888888888888899fT|!^''
                `!!8888888888888888899fT|!^''
                  `!988888888899fT|!^''
                    `!9899fT|!^''
                      `!^''
";
        imprime(ascii);

        Console.WriteLine("Pressione 1 para sair e 2 para reiniciar a simulação.");
        int opcao = Convert.ToInt16(Console.ReadLine());
        if (opcao == 1)
        {
            break;
        }
        else if (opcao == 2)
        {
            montanhaRussa.Retry();
            continue;
        }
        else
        {
            Console.WriteLine("Opção inválida. Tente novamente.");
        }
    }

    else
    {
        string ascii = @"
           o
           |
         ,'~'.
        /     \
       |   ____|_
       |  '___,,_'         .----------------.
       |  ||(o |o)|       ( KILL ALL HUMANS! )
       |   -------         ,----------------'
       |  _____|         -'
       \  '####,
        -------
      /________\
    (  )        |)
    '_ ' ,------|\         _
   /_ /  |      |_\        ||
  /_ /|  |     o| _\      _|| 
 /_ / |  |      |\ _\____//' |
(  (  |  |      | (_,_,_,____/
 \ _\ |   ------|        
  \ _\|_________|
   \ _\ \__\\__\
   |__| |__||__|
||/__/  |__||__|
        |__||__|
        |__||__|
        /__)/__)
       /__//__/
      /__//__/
     /__//__/.
   .'    '.   '.
  (_kOs____)____)
            ";
        imprime(ascii);
    }
}