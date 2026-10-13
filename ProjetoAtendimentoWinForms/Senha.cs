using System;

public class Senha
{
    private int id;
    private DateTime dataGerac;
    private DateTime horaGerac;
    private DateTime dataAtend;
    private DateTime horaAtend;

    public int Id { get => id; set => id = value; }
    public DateTime DataGerac { get => dataGerac; set => dataGerac = value; }
    public DateTime HoraGerac { get => horaGerac; set => horaGerac = value; }
    public DateTime DataAtend { get => dataAtend; set => dataAtend = value; }
    public DateTime HoraAtend { get => horaAtend; set => horaAtend = value; }

    public Senha(int id)
    {
        this.id = id;
        DateTime agora = DateTime.Now;
        this.dataGerac = agora.Date;
        this.horaGerac = agora;
    }

    public string DadosParciais()
    {
        return $"{id} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss}";
    }

    public string DadosCompletos()
    {
        return $"{id} - {dataGerac:dd/MM/yyyy} - {horaGerac:HH:mm:ss} - {dataAtend:dd/MM/yyyy} - {horaAtend:HH:mm:ss}";
    }

    public override string ToString()
    {
        return DadosParciais();
    }
}
