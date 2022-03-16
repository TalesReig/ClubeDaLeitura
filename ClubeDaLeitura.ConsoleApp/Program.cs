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
            ContrutorDeCaixaParaTeste();
            ContrutorDeAmigoParaTeste();
            ContrutorDeRevistaParaTeste();
            ContrutorDeEmprestimosParaTeste();

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

        private static void ContrutorDeEmprestimosParaTeste()
        {
            Emprestimo emprestimoTeste = new Emprestimo();
            emprestimoTeste.idDaRevista = 0;
            emprestimoTeste.idDoAmigo = 0;
            emprestimoTeste.dataDoEmprestimo = DateTime.Today;
            emprestimoTeste.dataDeDevolucao = DateTime.Today.AddDays(5);
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] == null || emprestimos[i] == default)
                {
                    emprestimos[i] = emprestimoTeste;
                    break;
                }
            }
        }
        private static void ContrutorDeAmigoParaTeste()
        {
            Cliente amigoTeste = new Cliente();
            amigoTeste.nome = " Lucas";
            amigoTeste.nomeDoResponsavel = "Pedro";
            amigoTeste.telefone = "9999-9999";
            amigoTeste.endereco = "Lages-SC";
            for (int i = 0; i < amigos.Length; i++)
            {
                if (amigos[i] == null || amigos[i] == default)
                {
                    amigos[i] = amigoTeste;
                    break;
                }
            }
        }
        private static void ContrutorDeRevistaParaTeste()
        {
            Revista revistaTeste = new Revista();
            revistaTeste.idDaCaixa = 0;
            revistaTeste.Nome = "Tio Patinhas";
            revistaTeste.numeroEdicao = 500;
            revistaTeste.anoDeFabricacao = DateTime.Today;
            for (int i = 0; i < revistas.Length; i++)
            {
                if (revistas[i] == null || revistas[i] == default)
                {
                    revistas[i] = revistaTeste;
                    break;
                }
            }
        }
        private static void ContrutorDeCaixaParaTeste()
        {
            Caixa caixaTeste = new Caixa();
            caixaTeste.cor = "Azul";
            caixaTeste.etiqueta = "12Ab";
            caixaTeste.numero = 500;
            for (int i = 0; i < caixas.Length; i++)
            {
                if (caixas[i] == null || caixas[i] == default)
                {
                    caixas[i] = caixaTeste;
                    break;
                }
            }
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
                    newEmprestimo.Cadastrar( emprestimos, newEmprestimo,amigos,revistas);
                    break;
                case 2:
                    Emprestimo.Editar(emprestimos, amigos, revistas);
                    break;
                case 3:
                    Emprestimo.TodosOsEmprestimos(emprestimos, amigos, revistas);
                    break;
                case 4:
                    Emprestimo.Excluir(emprestimos, amigos, revistas);
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
                    newRevista.Cadastrar(revistas, newRevista,caixas);
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
}
