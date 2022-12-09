using System;
using app_transferencia_netbank_dio.Enum;
using Transferencia_Bancaria_dotnet.Models;

internal class Program
{
    static List<Conta> listaContas = new List<Conta>();

    static void Main(string[] args)
    {

        string opcaoUsuario = ObterOpcaoUsuario();
        while (opcaoUsuario.ToUpper() != "x")
        {
            switch (opcaoUsuario)
            {
                case "1": ListarConta(); break;
                case "2": InserirConta(); break;
                case "3": Transferir(); break;
                case "4": Sacar(); break;
                case "5": Depositar(); break;
                case "6": Console.Clear(); break;
                default:
                    throw new ArgumentOutOfRangeException();


            }


        }
        Console.WriteLine("Obrigado por utilizar nossos serviços");
        Console.ReadLine();
    }


    private static void Transferir()
    {
        Console.WriteLine($"Digite o numero da conta de origem: ");
        int indiceContaOrigem = int.Parse(Console.ReadLine());

        Console.Write("Digite o numero da conta de destino");
        int indiceContaDestino = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser transferido");
        double valorTransferencia = double.Parse(Console.ReadLine());

        listaContas[indiceContaOrigem].Transferir(valorTransferencia, listaContas[indiceContaDestino]);

    }
    private static void Sacar()
    {
        Console.WriteLine($"Digite o numero da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser sacado");
        double valorSaque = double.Parse(Console.ReadLine());

        listaContas[indiceConta].Sacar(valorSaque);


    }

    private static void Depositar()
    {
        Console.WriteLine($"Digite o numero da conta: ");
        int indiceConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o valor a ser Depositado");
        double valorDeposito = double.Parse(Console.ReadLine());

        listaContas[indiceConta].Depositar(valorDeposito);
    }

    private static void InserirConta()
    {
        Console.WriteLine("Inserir nova conta");

        Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
        int entradaTipoConta = int.Parse(Console.ReadLine());

        Console.Write("Digite o nome do cliente");
        string entradaNome = Console.ReadLine();

        Console.Write("Digite o saldo inicial");
        double entradaSaldo = double.Parse(Console.ReadLine());

        Console.Write("Digite o Credito");
        double entradaCredito = double.Parse(Console.ReadLine());

        Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta,
        saldo: entradaSaldo,
        credito: entradaCredito,
        nome: entradaNome);

        listaContas.Add(novaConta);

    }

    private static void ListarConta()
    {
        Console.WriteLine("Listar contas");
        if (listaContas.Count == 0)
        {
            Console.WriteLine("Nenhuma conta cadastrada");
            return;
        }

        for (int i = 0; i < listaContas.Count; i++)
        {
            Conta conta = listaContas[i];
            Console.Write($"#{i} - ");
            Console.WriteLine(conta);

        }

    }

    private static string ObterOpcaoUsuario()
    {

        Console.WriteLine();
        Console.WriteLine(" NetBank a Seu Dispor");
        Console.WriteLine("Informe a opçáo desejada");
        Console.WriteLine("1 - Listar contas");
        Console.WriteLine("2 - Inserir nova conta");
        Console.WriteLine("3 - Transferir");
        Console.WriteLine("4 - Sacar");
        Console.WriteLine("5 - Depositar");
        Console.WriteLine("6 Limpar tela");
        Console.WriteLine("X - Sair");
        Console.WriteLine();

        string opcaoUsuario = Console.ReadLine().ToUpper();
        Console.WriteLine();
        return opcaoUsuario;

    }

}