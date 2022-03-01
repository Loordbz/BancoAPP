using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPP.Banco
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente(int numConta, Cliente cliente, int tipoConta, double saldoDeb, double saldoCred)
            :base(numConta, cliente, tipoConta, saldoDeb, saldoCred)
        { }

        public override bool Sacar(double sacar)
        {
            if(sacar > SaldoDeb)
            {
                MsgOperacao = $"Erro 05. Transação não autorizada";
            }
            SaldoDeb -= sacar;
            return true;
        }

        public override bool Depositar(double depositar)
        {
            if(depositar <= 0)
            {
                MsgOperacao = $"Erro 00. Transação cancelada, valor inválido.";
            }
            SaldoDeb += depositar;
            return true;
        }

        public override bool PagarCredito(double valor)
        {
            if (TipoConta == 02 || TipoConta == 22)
            {
                if (valor > SaldoCred)
                {
                    MsgOperacao = "Erro 06. Saldo indisponível.";
                }

                SaldoCred -= valor;
                Console.WriteLine($"Compra realizada com sucesso.\nValor na compra de: {valor}R$");
            }
            Console.WriteLine("Erro 51. Você não possui cartão de crédito.");
            return false;
        }
        public override string ToString()
        {
            return DateTime.Now + "\n" + "Conta Corrente: " + this.NumConta + " " + "Titular: " + this.Cliente.Nome + "\nSaldo: " + this.SaldoDeb + "R$ " + "Limite Crédito: " + this.SaldoCred + "R$";
        }
    }
}
