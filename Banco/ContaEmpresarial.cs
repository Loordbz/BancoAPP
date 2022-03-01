using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPP.Banco
{
    public class ContaEmpresarial:Conta
    {
        public ContaEmpresarial(int numConta, Cliente cliente, int tipoConta, double saldo, double emprestimo)
            :base(numConta, cliente, tipoConta, saldo, emprestimo)
        {
            NumConta = numConta;
            Cliente = cliente;
            TipoConta = tipoConta;
            SaldoDeb = saldo;
            
        }
        public double Emprestimo { get; protected set; }
        public override bool Sacar(double sacar)
        {
            if (sacar > SaldoDeb)
            {
                MsgOperacao = $"Erro 05. Transação não autorizada";
            }
            SaldoDeb -= sacar;
            return true;
        }

        public override bool Depositar(double depositar)
        {
            if (depositar <= 0)
            {
                MsgOperacao = $"Erro 00. Transação cancelada, valor inválido.";
            }
            SaldoDeb += depositar;
            return true;
        }

        public void DepositarFuncionario(double valor, Conta destino)
        {
            var sucessoSacarConta = Sacar(valor);
            var sucessoPagarFuncionario = destino.Depositar(valor);
            if (sucessoSacarConta && sucessoPagarFuncionario)
            {
                Console.WriteLine("Pagamento realizado com sucesso.");
            }
            else
            {
                Console.WriteLine("Houve um erro, operação cancelada.");
            }           
        }

        public override bool PagarCredito(double valor)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return DateTime.Now + "\n" + "Conta Empresarial: " + this.NumConta + " " + "Titular: " + this.Cliente.Nome + "\nSaldo: " + this.SaldoDeb + "R$";
        }
    }
}
