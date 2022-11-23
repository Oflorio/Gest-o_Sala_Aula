using System.Security.Cryptography.X509Certificates;
using System.Xml;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Aluno al1 = new Aluno(13241, "João");
Aluno al2 = new Aluno(14241, "Maria");
Aluno al3 = new Aluno(34241, "Manuel");

app.MapGet("/", () => "Hello World!");


app.Run();

class Aluno
{

    //Atributos da classe
    public String nome;
    int numero;

    //Construtor
    public Aluno(int numero, string nome)
    {
        this.numero = numero;
        this.nome = nome;

    }
    // Métodos
    public string toString()
    {
        return "Nome: " + nome + "\nNúmero: " + numero + "\n";
    }

}
class Sala
{
    char bloco;
    int numero;
    int capacidade;

    List<Aluno> presentes = new List<Aluno>();

    //Construtor
    public Sala(char bloco, int numero, int capacidade)
    {
        this.bloco = bloco;
        this.numero = numero;
        this.capacidade = capacidade;
    }
    public string entrar(Aluno al)
    {
        /* Considerações:
         * 1 - O aluno só pode entrar ser houver espaço na sala
         * 2 - O aluno só pode entrar se não estiver la
        */
        if (presentes.Count < capacidade)
        {
            if (presentes.Contains(al))
            {
                return "Aluno já está na sala";
            }
            else
            {
                presentes.Add(al);
                return "O aluno " + al.nome + "entrou na sala" + bloco + " " + numero + ".\n";
            }
        }
        else
        {
            return "Capacidade da sala esgotada";
        }

    }
    public string sair(Aluno al)
    {
        /* Considerações:
             * 1 - O aluno só pode sair se estiver la
        */
        if (presentes.Contains(al))
        {
            presentes.Remove(al); // remove aluno da lista e abre espaço na sala
            return "O Aluno " + al.nome + " saiu da sala.\n";
        }
        else
        {
            return "O Aluno não está na sala.\n";
        }
    }
    public string listaAlunos()
    {
        string result = "Lista de presenças:\n\n";

        foreach (Aluno al in presentes)
        {
            result += al.toString() + "\n";
        }

        return result;

    }

}
}




