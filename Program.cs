using BancoAPP.Banco;
using System;

namespace BancoAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            Cliente leonardo = new Cliente("Leonardo", 27, "111.222.333-44", "(16)99999-8876", "Av. João bobo, 672");

            ContaCorrente contaLeonardo = new ContaCorrente(010101, leonardo, 22, 1000, 3000);

            Poupança poupancaLeonardo = new Poupança(010101, leonardo, 33, 12000, 0);

            ContaSalario contaSalarioLeonardo = new ContaSalario(010102, leonardo, 44, 0.75, 0);

            ContaEmpresarial Google = new ContaEmpresarial(101010, new Cliente("Google", 50, "000.00000.00000-01", "+1(55)000-0012-3", "Av.California, 1175"), 55, 1000000000, 0);

            Console.WriteLine(leonardo);
            Console.Write("\n");
            Console.WriteLine(contaLeonardo);
            Console.Write("\n");
            Console.WriteLine(poupancaLeonardo);
            Console.Write("\n");
            Console.WriteLine(contaSalarioLeonardo);
            Console.Write("\n");
            Console.WriteLine(Google);
            Console.Write("\n");
            Google.DepositarFuncionario(12000, contaSalarioLeonardo);
            Console.Write("\n");
            Console.WriteLine(contaSalarioLeonardo);
            Console.Write("\n");
            Console.WriteLine(Google);
        }
    }
}
