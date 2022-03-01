using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPP.Banco
{
    public abstract class Conta
    {
        public Conta(int numConta, Cliente cliente, int tipoConta, double saldoDeb, double saldoCred)
        {
            NumConta = numConta;
            Cliente = cliente;
            TipoConta = tipoConta;
            SaldoDeb = saldoDeb;
            SaldoCred = saldoCred;
        }
        public int NumConta { get; protected set; }
        public Cliente Cliente { get; protected set; }
        public int TipoConta { get; protected set; }
        //00 - Poupança || 01 - Corrente  **Sem cartão de crédito || 02 - Corrente **Com cartão de crédito || 11 - Corrente E Poupança **Sem cartão de crédito || 22 - Corrente E Poupança **Com cartão de crédito || 33 - Poupança apenas || 44 - Salário || 55 - Empresarial
        public double SaldoDeb { get; protected set; }
        public double SaldoCred { get; protected set; }
        public string MsgOperacao { get; protected set; }

        public abstract bool Sacar(double sacar);
        public abstract bool Depositar(double depositar);
        public abstract bool PagarCredito(double valor);

        public void Transferir(double valor, Conta destino)
        {
            var sucessoTransacaoDeSaque = Sacar(valor);
            var sucessoTransacaoDeDeposito = destino.Depositar(valor);
            if(sucessoTransacaoDeSaque && sucessoTransacaoDeDeposito)
            {
                Console.WriteLine("Transferência realizada com sucesso. \n" + $"De: {Cliente.Nome} \nPara: {destino.Cliente.Nome}\nValor: {valor}R$"); 
            }
            else
            {
                Console.WriteLine("Transferência não realizada com sucesso.");
            }
        }

        
 
    }
}
