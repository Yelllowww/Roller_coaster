using System.Collections.Concurrent;
using System.Threading.Tasks;

class MontanhaRussa(Values values)
{
    public int passageirosAtendidos = 0;
    private SemaphoreSlim semaforo = new SemaphoreSlim(1, 1);
    private SemaphoreSlim passageirosDisponiveis = new SemaphoreSlim(0);
    public ConcurrentQueue<Passageiro> fila = new();
    private ConcurrentQueue<Carrinho> carrinhos = new();
    private int passageirosCriados = 0;
    private double tempoTotalEspera = 0;
    private List<double> temposDeEspera = new();
 
    public void GerarCarrinhos()
    {
        for (int i = 0; i < values.numeroDeCarrinhos; i++)
        {
            var carrinho = new Carrinho(i);
            carrinhos.Enqueue(carrinho);
        }
    }

    public async Task Passeio(Carrinho carrinho)
    {
        await semaforo.WaitAsync();
        try
        {
            var inicio = DateTime.Now;

            Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} começou o passeio.");
            await Task.Delay(values.tempoDePasseio);

            var fim = DateTime.Now;
            Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} retornou e começou o desembarque.");
            var tempoPasseio = (fim - inicio).TotalMilliseconds;
            carrinho.AdicionarTempo((int)tempoPasseio);
            passageirosAtendidos += carrinho.Passageiros.Count;
            foreach (var passageiro in carrinho.Passageiros)
            {
                await Task.Delay(values.tempoDeEmbarqueDesembarque);
                Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} desembarcou o passageiro {passageiro.Id}.");
            }
            carrinho.Passageiros.Clear(); //é necessário citar desembarque? //sim
            carrinhos.Enqueue(carrinho);
        }
        finally
        {
            semaforo.Release();
        }
    }

    public async Task<Carrinho> EmbarcarPassageiros()
    {
        if (carrinhos.TryDequeue(out Carrinho carrinho))
        {
            var passageirosCarrinho = new List<Passageiro>();
            Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} começou o embarque.");
            while (passageirosCarrinho.Count < values.capacidadeCarrinho)
            {
                if (passageirosCriados >= values.numeroDePassageiros && fila.IsEmpty)
                {
                    break;
                }
                await passageirosDisponiveis.WaitAsync();
                if (fila.TryDequeue(out Passageiro passageiro))
                {
                    await Task.Delay(values.tempoDeEmbarqueDesembarque);
                    passageirosCarrinho.Add(passageiro);
                    
                    var tempoEspera = (DateTime.Now - passageiro.horaChegada).TotalMilliseconds;
                    tempoTotalEspera += tempoEspera;
                    temposDeEspera.Add(tempoEspera);
                    Console.WriteLine($"[{passageiro.horaChegada}] - Passageiro {passageiro.Id} embarcou no carro {carrinho.Id}.");
                }
                else
                {
                    break;
                }
            }
            carrinho.Embarcar(passageirosCarrinho);
            return carrinho;
        }
        return null;
    }
    public async Task GerarPassageiros()
    {
        var ids = Enumerable.Range(0, values.numeroDePassageiros).ToList();
        var random = new Random();
        int intervalo = random.Next(values.intervaloMinimo, values.intervaloMaximo);

        for (int i = 0; i < values.numeroDePassageiros; i++)
        {
            await Task.Delay(intervalo);
            int index = random.Next(ids.Count);
            int id = ids[index];
            ids.RemoveAt(index);
            var passageiro = new Passageiro(id);
            fila.Enqueue(passageiro); 
            passageirosDisponiveis.Release();
            passageirosCriados++;
            Console.WriteLine($"[{passageiro.horaChegada}] - Passageiro {passageiro.Id} chegou.");

        }
    }
    public void Estatisticas(DateTime inicioSimulacao)
    {
        var tempoTotalSimulacao = (DateTime.Now - inicioSimulacao).TotalMilliseconds;
        double tempoMinimo = temposDeEspera.Min();
        double tempoMaximo = temposDeEspera.Max();
        double tempoMedio = temposDeEspera.Average();
        Console.WriteLine($"\nTempo mínimo de espera na fila: {tempoMinimo:F2}");
        Console.WriteLine($"Tempo máximo de espera na fila: {tempoMaximo:F2}");
        Console.WriteLine($"Tempo médio de espera na fila: {tempoMedio:F2}");
        foreach (var carrinho in carrinhos)
        {
            float tempoDeUso = carrinho.TempoDeUso;
            double eficiencia = tempoDeUso / tempoTotalSimulacao * 100;

            Console.WriteLine($"Carro {carrinho.Id} - Eficiência: {eficiencia:F2}%");
        }
    }
}