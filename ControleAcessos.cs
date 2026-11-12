// CONTROLE DE ACESSOS — atividade de Estrutura de Dados 2
//
// Aplicação de console em C# (.NET 8) implementando usuários, ambientes,
// permissões, fila de até 100 logs por ambiente e persistência em JSON.
//
// Como executar:
//   1. Crie um projeto: dotnet new console -n ControleAcessos
//   2. Substitua o conteúdo de ControleAcessos/Program.cs por este arquivo.
//   3. Entre na pasta e execute: dotnet run
//
// O arquivo dados.json será criado automaticamente no diretório de execução.
// O programa carrega esse arquivo ao iniciar e salva ao escolher a opção 0.

using System.Text.Json;
using System.Text.Json.Serialization;

var cadastro = new Cadastro(Path.Combine(AppContext.BaseDirectory, "dados.json"));
cadastro.Download();
Console.WriteLine("=== Controle de Acessos ===");

while (true)
{
    MostrarMenu();
    int opcao = LerInteiro("Opção: ");
    Console.WriteLine();
    switch (opcao)
    {
        case 0:
            cadastro.Upload();
            Console.WriteLine("Dados salvos. Até logo!");
            return;
        case 1: CadastrarAmbiente(); break;
        case 2: ConsultarAmbiente(); break;
        case 3: ExcluirAmbiente(); break;
        case 4: CadastrarUsuario(); break;
        case 5: ConsultarUsuario(); break;
        case 6: ExcluirUsuario(); break;
        case 7: AlterarPermissao(conceder: true); break;
        case 8: AlterarPermissao(conceder: false); break;
        case 9: RegistrarAcesso(); break;
        case 10: ConsultarLogs(); break;
        default: Console.WriteLine("Opção inválida."); break;
    }
    Console.WriteLine();
}

void MostrarMenu()
{
    Console.WriteLine("0. Sair\n1. Cadastrar ambiente\n2. Consultar ambiente\n3. Excluir ambiente\n4. Cadastrar usuário\n5. Consultar usuário\n6. Excluir usuário\n7. Conceder permissão\n8. Revogar permissão\n9. Registrar acesso\n10. Consultar logs");
}

void CadastrarAmbiente()
{
    var nome = LerTexto("Nome do ambiente: ");
    var ambiente = new Ambiente(cadastro.ProximoIdAmbiente(), nome);
    cadastro.AdicionarAmbiente(ambiente);
    Console.WriteLine($"Ambiente cadastrado (ID {ambiente.Id}).");
}
void ConsultarAmbiente()
{
    var ambiente = BuscarAmbiente();
    if (ambiente is null) return;
    Console.WriteLine($"ID: {ambiente.Id} | Nome: {ambiente.Nome} | Permissões: {cadastro.Usuarios.Count(u => u.PossuiPermissao(ambiente))} | Logs: {ambiente.Logs.Count}/100");
}
void ExcluirAmbiente()
{
    var ambiente = BuscarAmbiente();
    if (ambiente is null) return;
    Console.WriteLine(cadastro.RemoverAmbiente(ambiente) ? "Ambiente removido." : "Não foi possível remover o ambiente.");
}
void CadastrarUsuario()
{
    var nome = LerTexto("Nome do usuário: ");
    var usuario = new Usuario(cadastro.ProximoIdUsuario(), nome);
    cadastro.AdicionarUsuario(usuario);
    Console.WriteLine($"Usuário cadastrado (ID {usuario.Id}).");
}
void ConsultarUsuario()
{
    var usuario = BuscarUsuario();
    if (usuario is null) return;
    Console.WriteLine($"ID: {usuario.Id} | Nome: {usuario.Nome}");
    Console.WriteLine(usuario.Ambientes.Count == 0 ? "Sem permissões." : "Ambientes autorizados: " + string.Join(", ", usuario.Ambientes.Select(a => $"{a.Nome} (ID {a.Id})")));
}
void ExcluirUsuario()
{
    var usuario = BuscarUsuario();
    if (usuario is null) return;
    Console.WriteLine(cadastro.RemoverUsuario(usuario) ? "Usuário removido." : "Não foi possível remover: o usuário ainda possui permissões.");
}
void AlterarPermissao(bool conceder)
{
    var ambiente = BuscarAmbiente();
    if (ambiente is null) return;
    var usuario = BuscarUsuario();
    if (usuario is null) return;
    bool sucesso = conceder ? usuario.ConcederPermissao(ambiente) : usuario.RevogarPermissao(ambiente);
    Console.WriteLine(sucesso
        ? (conceder ? "Permissão concedida." : "Permissão revogada.")
        : (conceder ? "O usuário já possui essa permissão." : "O usuário não possui essa permissão."));
}
void RegistrarAcesso()
{
    var ambiente = BuscarAmbiente();
    if (ambiente is null) return;
    var usuario = BuscarUsuario();
    if (usuario is null) return;
    bool autorizado = usuario.PossuiPermissao(ambiente);
    ambiente.RegistrarLog(new Log(DateTime.Now, usuario, autorizado));
    Console.WriteLine(autorizado ? "Acesso autorizado e registrado." : "Acesso negado e registrado.");
}
void ConsultarLogs()
{
    var ambiente = BuscarAmbiente();
    if (ambiente is null) return;
    Console.WriteLine("Filtrar: 1. Todos  2. Autorizados  3. Negados");
    int filtro = LerInteiro("Opção: ");
    if (filtro is < 1 or > 3) { Console.WriteLine("Filtro inválido."); return; }
    var logs = ambiente.Logs.Where(l => filtro == 1 || (filtro == 2 && l.TipoAcesso) || (filtro == 3 && !l.TipoAcesso)).ToList();
    if (logs.Count == 0) { Console.WriteLine("Nenhum log encontrado."); return; }
    foreach (var log in logs)
        Console.WriteLine($"{log.DtAcesso:dd/MM/yyyy HH:mm:ss} | Usuário {log.Usuario.Id} - {log.Usuario.Nome} | {(log.TipoAcesso ? "AUTORIZADO" : "NEGADO")}");
}
Ambiente? BuscarAmbiente()
{
    if (cadastro.Ambientes.Count == 0) { Console.WriteLine("Não há ambientes cadastrados."); return null; }
    Console.WriteLine("Ambientes: " + string.Join(" | ", cadastro.Ambientes.Select(a => $"{a.Id}: {a.Nome}")));
    int id = LerInteiro("ID do ambiente: ");
    var item = cadastro.PesquisarAmbiente(id);
    if (item is null) Console.WriteLine("Ambiente não encontrado.");
    return item;
}
Usuario? BuscarUsuario()
{
    if (cadastro.Usuarios.Count == 0) { Console.WriteLine("Não há usuários cadastrados."); return null; }
    Console.WriteLine("Usuários: " + string.Join(" | ", cadastro.Usuarios.Select(u => $"{u.Id}: {u.Nome}")));
    int id = LerInteiro("ID do usuário: ");
    var item = cadastro.PesquisarUsuario(id);
    if (item is null) Console.WriteLine("Usuário não encontrado.");
    return item;
}

static int LerInteiro(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        if (int.TryParse(Console.ReadLine(), out int valor)) return valor;
        Console.WriteLine("Digite um número inteiro válido.");
    }
}
static string LerTexto(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? valor = Console.ReadLine()?.Trim();
        if (!string.IsNullOrWhiteSpace(valor)) return valor;
        Console.WriteLine("O texto não pode ficar vazio.");
    }
}

public sealed class Usuario
{
    public int Id { get; }
    public string Nome { get; }
    public List<Ambiente> Ambientes { get; } = new();
    public Usuario(int id, string nome) { Id = id; Nome = nome; }
    public bool ConcederPermissao(Ambiente ambiente)
    {
        if (PossuiPermissao(ambiente)) return false;
        Ambientes.Add(ambiente);
        return true;
    }
    public bool RevogarPermissao(Ambiente ambiente)
    {
        var existente = Ambientes.FirstOrDefault(a => a.Id == ambiente.Id);
        return existente is not null && Ambientes.Remove(existente);
    }
    public bool PossuiPermissao(Ambiente ambiente) => Ambientes.Any(a => a.Id == ambiente.Id);
}

public sealed class Ambiente
{
    public const int LimiteLogs = 100;
    public int Id { get; }
    public string Nome { get; }
    public Queue<Log> Logs { get; } = new();
    public Ambiente(int id, string nome) { Id = id; Nome = nome; }
    public void RegistrarLog(Log log)
    {
        if (Logs.Count == LimiteLogs) Logs.Dequeue();
        Logs.Enqueue(log);
    }
}

public sealed class Log
{
    public DateTime DtAcesso { get; }
    public Usuario Usuario { get; }
    public bool TipoAcesso { get; }
    public Log(DateTime dtAcesso, Usuario usuario, bool tipoAcesso) { DtAcesso = dtAcesso; Usuario = usuario; TipoAcesso = tipoAcesso; }
}

public sealed class Cadastro
{
    private readonly string _arquivo;
    public List<Usuario> Usuarios { get; private set; } = new();
    public List<Ambiente> Ambientes { get; private set; } = new();
    public Cadastro(string arquivo) => _arquivo = arquivo;
    public void AdicionarUsuario(Usuario usuario) => Usuarios.Add(usuario);
    public bool RemoverUsuario(Usuario usuario) => !usuario.Ambientes.Any() && Usuarios.Remove(usuario);
    public Usuario? PesquisarUsuario(int id) => Usuarios.FirstOrDefault(u => u.Id == id);
    public void AdicionarAmbiente(Ambiente ambiente) => Ambientes.Add(ambiente);
    public bool RemoverAmbiente(Ambiente ambiente)
    {
        var existente = Ambientes.FirstOrDefault(a => a.Id == ambiente.Id);
        if (existente is null) return false;
        foreach (var usuario in Usuarios) usuario.RevogarPermissao(existente);
        return Ambientes.Remove(existente);
    }
    public Ambiente? PesquisarAmbiente(int id) => Ambientes.FirstOrDefault(a => a.Id == id);
    public int ProximoIdUsuario() => Usuarios.Count == 0 ? 1 : Usuarios.Max(u => u.Id) + 1;
    public int ProximoIdAmbiente() => Ambientes.Count == 0 ? 1 : Ambientes.Max(a => a.Id) + 1;

    public void Upload()
    {
        var dados = new DadosPersistidos
        {
            Usuarios = Usuarios.Select(u => new UsuarioDto { Id = u.Id, Nome = u.Nome, Ambientes = u.Ambientes.Select(a => a.Id).ToList() }).ToList(),
            Ambientes = Ambientes.Select(a => new AmbienteDto { Id = a.Id, Nome = a.Nome, Logs = a.Logs.Select(l => new LogDto { DtAcesso = l.DtAcesso, UsuarioId = l.Usuario.Id, TipoAcesso = l.TipoAcesso }).ToList() }).ToList()
        };
        string? pasta = Path.GetDirectoryName(_arquivo);
        if (!string.IsNullOrEmpty(pasta)) Directory.CreateDirectory(pasta);
        File.WriteAllText(_arquivo, JsonSerializer.Serialize(dados, new JsonSerializerOptions { WriteIndented = true }));
    }
    public void Download()
    {
        if (!File.Exists(_arquivo)) return;
        try
        {
            var dados = JsonSerializer.Deserialize<DadosPersistidos>(File.ReadAllText(_arquivo));
            if (dados is null) return;
            Ambientes = dados.Ambientes.Select(a => new Ambiente(a.Id, a.Nome)).ToList();
            Usuarios = dados.Usuarios.Select(u => new Usuario(u.Id, u.Nome)).ToList();
            foreach (var u in dados.Usuarios)
            {
                var usuario = PesquisarUsuario(u.Id)!;
                foreach (int ambienteId in u.Ambientes)
                {
                    var ambiente = PesquisarAmbiente(ambienteId);
                    if (ambiente is not null) usuario.ConcederPermissao(ambiente);
                }
            }
            foreach (var a in dados.Ambientes)
            {
                var ambiente = PesquisarAmbiente(a.Id)!;
                foreach (var l in a.Logs.TakeLast(Ambiente.LimiteLogs))
                {
                    var usuario = PesquisarUsuario(l.UsuarioId);
                    if (usuario is not null) ambiente.RegistrarLog(new Log(l.DtAcesso, usuario, l.TipoAcesso));
                }
            }
        }
        catch (JsonException ex)
        {
            Console.WriteLine($"Aviso: arquivo de dados inválido; a aplicação iniciou sem carregar os dados. {ex.Message}");
            Usuarios = new(); Ambientes = new();
        }
    }
    private sealed class DadosPersistidos { public List<UsuarioDto> Usuarios { get; set; } = new(); public List<AmbienteDto> Ambientes { get; set; } = new(); }
    private sealed class UsuarioDto { public int Id { get; set; } public string Nome { get; set; } = ""; public List<int> Ambientes { get; set; } = new(); }
    private sealed class AmbienteDto { public int Id { get; set; } public string Nome { get; set; } = ""; public List<LogDto> Logs { get; set; } = new(); }
    private sealed class LogDto { public DateTime DtAcesso { get; set; } public int UsuarioId { get; set; } public bool TipoAcesso { get; set; } }
}
