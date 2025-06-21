using System.Collections.Concurrent;
using System.Dynamic;

public class Carrinho
{
    public int Id { get; }
    public List<Passageiro> Passageiros { get; set; }
    public int TempoDeUso { get; private set; }

    public Carrinho(int id)
    {
        Id = id;
        Passageiros = new List<Passageiro>();
    }
    public void AdicionarTempo(int tempoPasseio)
    {
        TempoDeUso += tempoPasseio; 
    }
    public void Embarcar(List<Passageiro> passageiros)
    {
        Passageiros.AddRange(passageiros);
    }
}


