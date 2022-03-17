using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Caixa
    {
        public string cor;
        public string etiqueta;
        public int numero;
        public Revista[] revistasNaCaixa = new Revista[100];

        public void Cadastrar(Caixa[] caixas, Caixa newCaixa)
        {
            Console.Write("A cor da caixa: ");
            newCaixa.cor = Console.ReadLine();
            Console.Write("A Etiqueta Da caixa: ");
            newCaixa.etiqueta = Console.ReadLine();
            Console.Write("O número da caixa: ");
            newCaixa.numero = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null || caixas[i] == default)
                {
                    caixas[i] = newCaixa;
                    break;
                }
            }
        }
        public static void Editar(Caixa[] caixas)
        {
            MostrarCaixas(caixas);

            Console.WriteLine("O Id da Caixa q deseja Editar:");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("A cor da caixa: ");
            caixas[id].cor = Console.ReadLine();
            Console.WriteLine("A etiqueta Da caixa: ");
            caixas[id].etiqueta = Console.ReadLine();
            Console.WriteLine("O número da caixa: ");
            caixas[id].numero = Convert.ToInt32(Console.ReadLine());
        }
        public static void Listar(Caixa[] caixas)
        {
            MostrarCaixas(caixas);
            Console.ReadKey();
        }
        public static void Excluir(Caixa[] caixas)
        {
            MostrarCaixas(caixas);
            Console.WriteLine("O Id da Caixa q deseja Excluir:");

            int id = Convert.ToInt32(Console.ReadLine());

            caixas[id] = null;
        }

        //Metodos complementares
        private static void MostrarCaixas(Caixa[] caixas)
        {
            int id = 0;
            Console.WriteLine(" _____________________________________________________");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", "    COR   ", "  NUMERO  ", " ETIQUETA ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", id++, caixas[i].cor, caixas[i].etiqueta, caixas[i].numero);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            Console.ReadKey();
        }

        public static void AdicionarRevistaNaCaixa(Caixa[] caixas,Revista[] revistasEmprestadas, int idDaCaixa, Revista revista)
        {
            for(int i = 0; i < caixas[idDaCaixa].revistasNaCaixa.Length; i++)
            {
                if(caixas[idDaCaixa].revistasNaCaixa[i] == null)
                {
                    caixas[idDaCaixa].revistasNaCaixa[i] = revista;
                    break;
                }
            }
        }

    }
}