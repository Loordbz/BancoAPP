using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoAPP.Banco
{
    public class Cliente
    {
        public Cliente(string nome, int idade, string cpf, string tel, string endereco)
        {
            Nome = nome;
            Idade = idade;
            Cpf = cpf;
            Tel = tel;
            Endereco = endereco;
        }

        public string Nome { get; private set; }
        public int Idade { get; private set; }
        public string Cpf { get; private set; }
        public string Tel { get; private set; }
        public string Endereco { get; private set; }
        public override string ToString()
        {
            return "Nome: " + this.Nome + " " + "Idade: " + this.Idade + "\nTel: " + this.Tel + "\nCPF: " + this.Cpf + "\nEndereço: " + this.Endereco;
        }
    }
}
