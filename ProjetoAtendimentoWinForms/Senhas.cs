using System.Collections.Generic;

public class Senhas
{
    private int proximoAtendimento;
    private Queue<Senha> filaSenhas;

    public int ProximoAtendimento => proximoAtendimento;
    public Queue<Senha> FilaSenhas => filaSenhas;

    public Senhas()
    {
        filaSenhas = new Queue<Senha>();
        proximoAtendimento = 1;
    }

    public void Gerar()
    {
        Senha novaSenha = new Senha(proximoAtendimento);
        filaSenhas.Enqueue(novaSenha);
        proximoAtendimento++;
    }
}
