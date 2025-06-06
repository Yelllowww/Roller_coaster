while (true)
{
    Values values = new Values();
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

    MontanhaRussa montanhaRussa = new MontanhaRussa(values);
    montanhaRussa.GerarCarrinhos();
    montanhaRussa.GerarPassageiros().Wait();
    Console.WriteLine("Pressione 1 para sair e 2 para reiniciar a simulação.");
    int opcao = Convert.ToInt16(Console.ReadLine());
    if (opcao == 1)
    {
        break;
    }
    else if (opcao == 2)
    {
        continue;
    }
    else
    {
        Console.WriteLine("Opção inválida. Tente novamente.");
    }
}