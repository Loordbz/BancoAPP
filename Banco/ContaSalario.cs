using System;
using BancoAPP.Banco;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPP.Banco
{
    class ContaSalario : Conta
    {
        public ContaSalario(int numConta, Cliente cliente, int tipoConta, double saldo, double saldoCred)
            : base(numConta, cliente, tipoConta, saldo, saldoCred)
        {
            NumConta = numConta;
            Cliente = cliente;
            TipoConta = tipoConta;
            Saldo = saldo;
            SaldoCredito(saldoCred);
            
        }

        //00 - Poupança || 01 - Corrente  **Sem cartão de crédito || 02 - Corrente **Com cartão de crédito || 11 - Corrente E Poupança **Sem cartão de crédito || 22 - Corrente E Poupança **Com cartão de crédito || 33 - Poupança apenas || 44 - Salário || 55 - Empresarial
        public double Saldo { get; protected set; }
        public bool SaldoCredito(double valor)
        {
            if(valor != 0)
            {
                SaldoCred = 0;
                return true;
            }
            return true;
        }

        public override bool Depositar(double depositar)
        {
          if((TipoConta + 11) == 55)
            {
                if( depositar <= 0)
                {
                    MsgOperacao = "Desculpe, valor inválido para depósito.";
                }
                Saldo += depositar;
                return true;
            }
            MsgOperacao = "Desculpe, essa conta aceita apenas depósitos de conta empresáriais";
            return false;
        }

        public override bool PagarCredito(double valor)
        {
            if(TipoConta == 44)
            {
                MsgOperacao = "Sua conta é salário, portanto não possui cartão de crédito.";
            }
            return false;
        }

        public override bool Sacar(double sacar)
        {
            if(sacar > SaldoDeb)
            {
                MsgOperacao = "Desculpe, saque indisponível";
            }
            Saldo -= sacar;
            return true;
        }

        public override string ToString()
        {
            return DateTime.Now + "\n" + "Conta Salário: " + this.NumConta + " " + "Titular: " + this.Cliente.Nome + "\nSaldo: " + this.Saldo + "R$ ";
        }
    }
}
