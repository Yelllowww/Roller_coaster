using System.Dynamic;

public class Carrinho
{
    public int Id { get; }
    //public List<Passageiro> Passageiros { get; } = new();
    public TimeSpan tempoDeUso { get; private set; }

    public Carrinho(int id)
    {
        Id = id;
    }

    public void Passeio(int tempo)
    {
        //executa o passeio
        //desembarca os passageiros
        //registra o tempo
    }
}


