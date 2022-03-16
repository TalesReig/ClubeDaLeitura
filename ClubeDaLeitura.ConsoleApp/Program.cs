using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Program
    {

        static Caixa[] caixas = new Caixa[10];
        static Cliente[] amigos = new Cliente[1000];
        static Revista[] revistas = new Revista[1000];
        static Emprestimo[] emprestimos = new Emprestimo[1000];
        static int resposta;
        static void Main(string[] args)
        {
            do
            {

                MostrarMenuPrincipal();
                resposta = Convert.ToInt32(Console.ReadLine());
                switch (resposta)
                {
                    case 1:
                        MenuDeEmprestimos();
                        break;
                    case 2:
                        MenuDeRevistas();
                        break;
                    case 3:
                        MenuDeAmigos();
                        break;
                    case 4:
                        MenuDeCaixas();
                        break;
                }
                Console.Clear();
            } while (resposta != 5);
        }

        //revista caixa - revista amigo - amigo imprestimo
        private static void MostrarMenuPrincipal()
        {
            Console.WriteLine(" _________________________________________________________________");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("|                            Menu Principal                       |");
            Console.WriteLine("|_________________________________________________________________|");
            Console.WriteLine("|                                                                 |");
            Console.WriteLine("| [1]Emprestimos | [2]Resvistas | [3]Amigos | [4]Caixa  |[5] Sair |");
            Console.WriteLine("|_________________________________________________________________|");
            Console.Write("\n Resposta: ");
        }
        private static void MenuDeEmprestimos()
        {
            Console.Clear();
            MostrarMenuEmprestimos();
            resposta = Convert.ToInt32(Console.ReadLine());
            switch (resposta)
            {
                case 1:
                    Emprestimo newEmprestimo = new Emprestimo();
                    newEmprestimo.Cadastrar( emprestimos, newEmprestimo);
                    break;
                case 2:
                    //função1
                    break;
                case 3:
                    //função1
                    break;
                case 4:
                    //função1
                    break;
            }
            Console.Clear();
        }
        private static void MostrarMenuEmprestimos()
        {
            Console.WriteLine(" ________________________________________________________________");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                       Menu De Emprestimos                      |");
            Console.WriteLine("|________________________________________________________________|");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("| [1]Cadastrar | [2]Editar | [3]Listar | [4]Excluir |[5] Voltar  |");
            Console.WriteLine("|________________________________________________________________|");
            Console.Write("\n Resposta: ");
        }
        private static void MenuDeRevistas()
        {
            MostrarMenuRevistas();
            resposta = Convert.ToInt32(Console.ReadLine());
            
            switch (resposta)
            {
                case 1:
                    Revista newRevista = new Revista();
                    newRevista.Cadastrar(revistas, newRevista);
                    break;
                case 2:
                    Revista.Editar(revistas);
                    break;
                case 3:
                    Revista.Listar(revistas);
                    break;
                case 4:
                    Revista.Excluir(revistas);
                    break;
            }
            Console.Clear();
        }
        private static void MostrarMenuRevistas()
        {
            Console.WriteLine(" ________________________________________________________________");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                          Menu De Revistas                      |");
            Console.WriteLine("|________________________________________________________________|");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("| [1]Cadastrar | [2]Editar | [3]Listar | [4]Excluir |[5] Voltar  |");
            Console.WriteLine("|________________________________________________________________|");
            Console.Write("\n Resposta: ");
        }
        private static void MenuDeAmigos()
        {
            MostrarMenuAmigos();
            resposta = Convert.ToInt32(Console.ReadLine());
            switch (resposta)
            {
                case 1:
                    Cliente amigo = new Cliente();
                    amigo.Cadastrar(amigos, amigo);
                    break;
                case 2:
                    Cliente.Editar(amigos);
                    break;
                case 3:
                    Cliente.Lista(amigos);
                    break;
                case 4:
                    Cliente.Excluir(amigos);
                    break;
            }
            Console.Clear();
        }
        private static void MostrarMenuAmigos()
        {
            Console.WriteLine(" ________________________________________________________________");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                          Menu De Clientes                      |");
            Console.WriteLine("|________________________________________________________________|");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("| [1]Cadastrar | [2]Editar | [3]Listar | [4]Caixa  |[5] Excluir  |");
            Console.WriteLine("|________________________________________________________________|");
            Console.Write("\n Resposta: ");
        }
        private static void MenuDeCaixas()
        {
            MostrarMenuCaixas();
            resposta = Convert.ToInt32(Console.ReadLine());
            switch (resposta)
            {
                case 1:
                    Caixa newCaixa = new Caixa();
                    newCaixa.Cadastrar(caixas, newCaixa);
                    break;
                case 2:
                    Caixa.Editar(caixas);
                    break;
                case 3:
                    Caixa.Listar(caixas);
                    break;
                case 4:
                    Caixa.Excluir(caixas);
                    break;
            }
            Console.Clear();
        }
        private static void MostrarMenuCaixas()
        {
            Console.WriteLine(" ________________________________________________________________");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("|                            Menu De Caixas                      |");
            Console.WriteLine("|________________________________________________________________|");
            Console.WriteLine("|                                                                |");
            Console.WriteLine("| [1]Cadastrar | [2]Editar | [3]Listar | [4]Excluir |[5] Voltar  |");
            Console.WriteLine("|________________________________________________________________|");
            Console.Write("\n Resposta: ");
        }
    }
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

            for(int i = 0; i < caixas.Length; i++)
            {
                if(caixas[i] == null || caixas[i] == default)
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
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", id++ , caixas[i].cor, caixas[i].etiqueta, caixas[i].numero);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
        }

        public static void AdicionarRevistaNaCaixa( int idDaCaixa, Revista revista )
        {
            //for e if, até achar um vazio
            //caixas[idDaCaixa].revistasNaCaixa[i] = revista;
        }

    }
    internal class Revista
    {
        public int idDaRevista;
        public int numeroEdicao;
        public string Nome;
        public DateTime anoDeFabricacao;

        public void Cadastrar( Revista[] revistas, Revista newRevista)
        {
            
            Console.Write("O Nome Da revista: ");
            newRevista.Nome = Console.ReadLine();
            Console.Write("O número da Edição: ");
            newRevista.numeroEdicao = Convert.ToInt32(Console.ReadLine());
            Console.Write("A Data de Fabricação: ");
            newRevista.anoDeFabricacao = Convert.ToDateTime(Console.ReadLine());
            Console.Write("O ID da caixa em q a revista se encontra: ");
            newRevista.idDaRevista = Convert.ToInt32(Console.ReadLine());

            AdcionarNaCaixa(idDaRevista, newRevista);

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
            revistas[id].idDaRevista = Convert.ToInt32(Console.ReadLine());
        }
        public static void Listar(Revista[] revistas)
        {
            MostrarRevistas(revistas);
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
            Caixa.AdicionarRevistaNaCaixa(idDaCaixa , revista);
        }
        //métodos complementares
        private static void MostrarRevistas(Revista[] revistas)
        {
            Console.WriteLine(" _____________________________________________________");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", "    COR   ", "  NUMERO  ", " ETIQUETA ");
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
            newAmigo.nomeDoResponsavel =Console.ReadLine();
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
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", "    COR   ", "  NUMERO  ", " ETIQUETA ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", i, amigos[i].nome, amigos[i].telefone, amigos[i].endereco);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
        }
        public static void Excluir(Cliente[] amigos)
        {
            Console.WriteLine("Digite o id do cliente q deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            amigos[id] = null;
        }
    }
    internal class Emprestimo
    {
        public int idDoAmigo;
        public int idDaRevista;
        public bool emAberto;
        public DateTime dataDoEmprestimo;
        public DateTime dataDeDevolucao;

        public void Cadastrar(Emprestimo[] emprestimos, Emprestimo newEmprestimo)
        {
            Console.WriteLine("Digite o id do amigo que deseja pegar um livro: ");
            newEmprestimo.idDoAmigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o id da revista q esse amigo deseja pegar:");
            newEmprestimo.idDaRevista = Convert.ToInt32(Console.ReadLine());
            newEmprestimo.emAberto = true;
            newEmprestimo.dataDoEmprestimo = DateTime.Today;
            Console.WriteLine("A sua data de devolução do livro é: "+ (DateTime.Today.AddDays(7)));
            newEmprestimo.dataDeDevolucao = DateTime.Today.AddDays(7);

            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null || emprestimos[i] == default)
                {
                    emprestimos[i] = newEmprestimo;
                    break;
                }
            }
        }
        public static void Editar(Emprestimo[] emprestimos, Cliente[] amigos, Revista[] revistas)
        {
            Emprestimo.TodosOsEmprestimos(emprestimos, amigos, revistas);

            Console.WriteLine("ID Do Emprestimo q deseja alterar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o id do amigo que deseja pegar um livro: ");
            emprestimos[id].idDoAmigo = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o id da revista q esse amigo deseja pegar:");
            emprestimos[id].idDaRevista = Convert.ToInt32(Console.ReadLine());
            emprestimos[id].emAberto = true;
            Console.WriteLine("Número de dias a adicioanr na data de vencimento: ");
            int dias = Convert.ToInt32(Console.ReadLine());
            emprestimos[id].dataDeDevolucao = DateTime.Today.AddDays(7).AddDays(dias);
        }
        public static void TodosOsEmprestimos(Emprestimo[] emprestimos, Cliente[] amigos, Revista[] revistas)
        {
            Console.WriteLine(" _____________________________________________________");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", "    COR   ", "  NUMERO  ", " ETIQUETA ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", i, amigos[emprestimos[i].idDoAmigo].nome, revistas[emprestimos[i].idDaRevista].Nome, emprestimos[i].dataDeDevolucao);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
        }
        public static void Excluir(Emprestimo[] emprestimos, Cliente[] amigos, Revista[] revistas)
        {
            Emprestimo.TodosOsEmprestimos(emprestimos, amigos, revistas);
            Console.WriteLine("Digite o id do Emprstimo q deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            emprestimos[id] = null;
        }
        //metodos extra
        public static void Encerrar(Emprestimo[] emprestimos)
        {
            
        }
        //Metodos complementares
    }
}
