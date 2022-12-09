using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using app_transferencia_netbank_dio.Enum;

namespace Transferencia_Bancaria_dotnet.Models
{
    public class Conta
    {
        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            TipoConta = tipoConta;
            Saldo = saldo;
            Credito = credito;
            Nome = nome;
        }

        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public bool Sacar(double valorSaque)
        {
            // Validacao de saldo suficiente 
            if (Saldo - valorSaque < (this.Credito * -1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }
            Saldo -= valorSaque;
            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo} ");
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            //Saldo = Saldo + valorDeposito;
            Console.WriteLine($"Saldo atual da conta de {Nome} é {Saldo}");
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if (Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {

            string retorno = "";
            retorno += "TipoConta" + " " + TipoConta + " | ";
            retorno += "Nome" + " " + Nome + " | ";
            retorno += "Saldo" + " " + Saldo + " | ";
            retorno += "Credito" + " " + Credito + " | ";
            return retorno;

        }

    }
}