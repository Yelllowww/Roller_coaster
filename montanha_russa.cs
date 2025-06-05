using System.Collections.Concurrent;

class MontanhaRussa
{
    private ConcurrentQueue<Passageiro> fila = new();
    private List<Carrinho> carrinhos = new();
}