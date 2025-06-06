using System.Collections.Concurrent;
using System.Threading.Tasks;
class MontanhaRussa(Values values)
{
    private SemaphoreSlim semaforo = new SemaphoreSlim(0);
    private ConcurrentQueue<Passageiro> fila = new();
    private ConcurrentQueue<Carrinho> carrinhos = new();


    public void GerarCarrinhos()
    {
        for (int i = 0; i < values.numeroDeCarrinhos; i++)
        {
            var carrinho = new Carrinho(i);
            carrinhos.Enqueue(carrinho);
        }
    }

    public async Task Passeio()
    {
        Carrinho carrinho = await EmbarcarPassageiros();
        Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} começou o passeio.");
        await Task.Delay(values.tempoDePasseio);
        Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} retornou e começou o desembarque.");
        carrinho.Passageiros.Clear(); //é necessário citar desembarque?
        carrinhos.Enqueue(carrinho);


    }

    public async Task<Carrinho> EmbarcarPassageiros()
    {
        await semaforo.WaitAsync();
        if (carrinhos.TryDequeue(out Carrinho carrinho))
        {
            Console.WriteLine($"[{DateTime.Now}] - Carro {carrinho.Id} começou o embarque.");
            var passageirosCarrinho = new List<Passageiro>();
            for (int i = 0; i < values.capacidadeCarrinho; i++)
            {
                if (fila.TryDequeue(out Passageiro passageiro))
                {
                    await Task.Delay(values.tempoDeEmbarqueDesembarque);
                    passageirosCarrinho.Add(passageiro);
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
            Console.WriteLine($"[{passageiro.horaChegada}] - Passageiro {passageiro.Id} chegou.");
            semaforo.Release();

        }
    }
}