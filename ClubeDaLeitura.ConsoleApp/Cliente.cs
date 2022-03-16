using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Cliente
    {
        public string nome;
        public string nomeDoResponsavel;
        public string telefone;
        public string endereco;

        public void Cadastrar(Cliente[] amigos, Cliente newAmigo)
        {
            Console.Write("O Nome Do amigo: ");
            newAmigo.nome = Console.ReadLine();
            Console.Write("O Nome Do responsável: ");
            newAmigo.nomeDoResponsavel = Console.ReadLine();
            Console.Write("O telefone de contato: ");
            newAmigo.telefone = Console.ReadLine();
            Console.Write("O Endereço: ");
            newAmigo.endereco = Console.ReadLine();

            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null || amigos[i] == default)
                {
                    amigos[i] = newAmigo;
                    break;
                }
            }
        }
        public static void Editar(Cliente[] amigos)
        {
            //Motsrar lista de Clientes
            Console.WriteLine("Digite o id do cliente q deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.Write("O Nome Do amigo: ");
            amigos[id].nome = Console.ReadLine();
            Console.Write("O Nome Do responsável: ");
            amigos[id].nomeDoResponsavel = Console.ReadLine();
            Console.Write("O telefone de contato: ");
            amigos[id].telefone = Console.ReadLine();
            Console.Write("O Endereço: ");
            amigos[id].endereco = Console.ReadLine();
        }
        public static void Lista(Cliente[] amigos)
        {
            Console.WriteLine(" _____________________________________________________");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", "    NOME  ", "  N° TELEFONE ", "   ENDEREÇO  ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", i, amigos[i].nome, amigos[i].telefone, amigos[i].endereco);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            Console.ReadKey();
        }
        public static void Excluir(Cliente[] amigos)
        {
            Console.WriteLine("Digite o id do cliente q deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            amigos[id] = null;
        }
    }
}