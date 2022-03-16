using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Revista
    {
        public int idDaCaixa;
        public int numeroEdicao;
        public string Nome;
        public DateTime anoDeFabricacao;

        public void Cadastrar(Revista[] revistas, Revista newRevista, Caixa[] caixas)
        {
            Caixa.Listar(caixas);
            Console.Write("O ID da caixa em q a revista se encontra: ");
            newRevista.idDaCaixa = Convert.ToInt32(Console.ReadLine());
            Console.Write("O Nome Da revista: ");
            newRevista.Nome = Console.ReadLine();
            Console.Write("O número da Edição: ");
            newRevista.numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.Write("A Data de Fabricação: ");
            newRevista.anoDeFabricacao = Convert.ToDateTime(Console.ReadLine());

            AdcionarNaCaixa(idDaCaixa, newRevista);

            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null || revistas[i] == default)
                {
                    revistas[i] = newRevista;
                    break;
                }
            }
        }
        public static void Editar(Revista[] revistas)
        {
            //mostrar lista de revistas
            Console.Write("Digite o id da revista q deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("O Tipo da Coleção: ");
            revistas[id].Nome = Console.ReadLine();
            Console.Write("O número da Edição: ");
            revistas[id].numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.Write("A Data de Fabricação: ");
            revistas[id].anoDeFabricacao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("O ID da caixa em q a revista se encontra: ");
            revistas[id].idDaCaixa = Convert.ToInt32(Console.ReadLine());
        }
        public static void Listar(Revista[] revistas)
        {
            MostrarRevistas(revistas);
            Console.ReadKey();
        }
        public static void Excluir(Revista[] revistas)
        {
            Revista.Listar(revistas);

            Console.Write("ID da revista que vai ser excluida: ");
            int id = Convert.ToInt32(Console.ReadLine());

            revistas[id] = null;
        }

        //Metodos extras
        public void AdcionarNaCaixa(int idDaCaixa, Revista revista)
        {
            Caixa.AdicionarRevistaNaCaixa(idDaCaixa, revista);
        }
        //métodos complementares
        private static void MostrarRevistas(Revista[] revistas)
        {
            Console.WriteLine(" _____________________________________________________");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", "    NOME   ", "    N° EDICAO   ", "   FABRICAÇÃO  ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", i, revistas[i].Nome, revistas[i].numeroEdicao, revistas[i].anoDeFabricacao);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
        }

    }
}