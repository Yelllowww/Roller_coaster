using System.Collections.Concurrent;
class MontanhaRussa
{
    private ConcurrentQueue<Passageiro> fila = new();
    private List<Carrinho> carrinhos = new();

    public void GerarPassageiros()
    {
        var ids = Enumerable.Range(0, Values.numeroDePassageiros - 1).ToList();
        var random = new Random();

        for (int i = 0; i <= Values.numeroDePassageiros; i++)
        {
            int index = random.Next(ids.Count);
            int id = ids[index];
            ids.RemoveAt(index);
            var passageiro = new Passageiro(id);
            fila.Enqueue(passageiro);
            Console.WriteLine($"[{passageiro.horaChegada}] - Passageiro {passageiro.Id} chegou.");
        }
    }
}