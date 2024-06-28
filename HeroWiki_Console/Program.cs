using ServerWiki.Shared.Data.DB;
using ServerWiki_Console;

var ServerDAL = new ServerDAL(new ServerWikiContext());

var serverList = ServerDAL.Read();

foreach (var server in serverList) { Console.WriteLine(server); }

var serverFound = ServerDAL.ReadByName("SyslogServer");
Console.WriteLine($"O Servidor {serverFound} foi encontrado");


Dictionary<string, Server> ServerDict = new();

bool exit = false;
while (!exit)
{
    Console.WriteLine("Você chegou na SERVERWIKI!\n");
    Console.WriteLine("Digite 1 para registrar um servidor");
    Console.WriteLine("Digite 2 para registrar a aplicação de um servidor");
    Console.WriteLine("Digite 3 para mostrar todos os servidores");
    Console.WriteLine("Digite 4 para mostrar as aplicações de um servidor");
    Console.WriteLine("Digite -1 para sair\n");

    Console.Write("Digite sua opção: ");
    int option = int.Parse(Console.ReadLine());

    switch (option)
    {
        case 1:
            ServerRegister();
            break;
        case 2:
            ApplicationRegister();
            break;
        case 3:
            ServerGet();
            break;
        case 4:
            ApplicationGet();
            break;
        case -1:
            Console.WriteLine("Bye!");
            exit = true;
            break;
        default:
            Console.WriteLine("Escolha inválida");
            break;
    }
    Thread.Sleep(1500);
    Console.Clear();
}

void ApplicationGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de aplicações\n");
    Console.Write("Digite o servidor cuja aplicação você quer listar: ");
    string ServerName = Console.ReadLine();
    if (ServerDict.ContainsKey(ServerName))
    {
        Server server = ServerDict[ServerName];
        server.ShowApplications();
    }
    else Console.WriteLine($"Servidor {ServerName} não encontrado");
}

void ServerGet()
{
    Console.Clear();
    Console.WriteLine("Listagem de Servidores\n");
    foreach (var server in ServerDAL.Read())
    {
        Console.WriteLine(server);
    }
}

void ApplicationRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Aplicação\n");
    Console.Write("Digite o servidor cuja aplicação você quer registrar: ");
    string ServerName = Console.ReadLine();
    if (ServerDict.ContainsKey(ServerName))
    {
        Console.Write($"Qual o nome da aplicação de {ServerName}? ");
        string applicationName = Console.ReadLine();
        Server server = ServerDict[ServerName];
        server.AddApplications(new Application(applicationName));
        Console.WriteLine($"Aplicação {applicationName} adicionada ao {ServerName}!");
    }
    else Console.WriteLine($"Servidor {ServerName} não encontrado");
}

void ServerRegister()
{
    Console.Clear();
    Console.WriteLine("Registro de Servidores\n");
    Console.Write("Digite o nome do servidor: ");
    string name = Console.ReadLine();
    Console.Write("Digite o sistema operacional do servidor: ");
    string os = Console.ReadLine();
    Server server = new Server(name, os);
    ServerDAL.create(server);
    Console.WriteLine($"Servidor {name} adicionado!");
}