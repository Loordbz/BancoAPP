using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPP.Banco
{
    class Poupança : Conta
    {
        public Poupança(int numConta, Cliente cliente, int tipoConta, double poupanca, double saldoCred)
            :base(numConta, cliente, tipoConta, poupanca, saldoCred)
        {
            NumConta = numConta;
            Cliente = cliente;
            tipoConta = 33;
            Poupanca = poupanca;
            SaldoCredito(saldoCred);
        }
        public double Poupanca { get; protected set; }
        public bool SaldoCredito(double valor)
        {
            if (valor != 0)
            {
                SaldoCred = 0;
                return true;
            }
            return true;
        }

        public override bool Depositar(double depositar)
        {
            if(TipoConta == 11 || TipoConta == 22 || TipoConta == 33)
            {
                Poupanca += depositar;
                MsgOperacao = "Dinheiro guardado com sucesso.";
                return true;
            }
            MsgOperacao = "Desculpe, não foi possível realizar a transação";
            return false;
        }

        public override bool Sacar(double sacar)
        {
            if (TipoConta == 11 || TipoConta == 22 || TipoConta == 33)
            {
                Poupanca -= sacar;
                MsgOperacao = "Dinheiro resgatado com sucesso.";
                return true;
            }
            MsgOperacao = "Desculpe, não foi possível realizar a transação";
            return false;
        }

        public override bool PagarCredito(double valor)
        {
            if(TipoConta == 33)
            {
                MsgOperacao = "Sua conta é salário, portanto não possui cartão de crédito.";
            }
            return false;
        }

        public override string ToString()
        {
            return DateTime.Now + "\n" + "Poupança: " + this.NumConta + " " + "Titular: " + this.Cliente.Nome + "\nSaldo: " + this.Poupanca + "R$ ";
        }
    }
}

