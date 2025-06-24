using System.Security.Cryptography.X509Certificates;

public class Passageiro
{
    public int Id { get; }
    public DateTime horaChegada { get; }
    public DateTime? horaEmbarque { get; set; }
    public TaskCompletionSource<bool> EmbarqueCompletionSource { get; } = new();

    public Passageiro(int id)
    {
        Id = id;
        horaChegada = DateTime.Now;
    }
};

