using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Emprestimo
    {
        public int idDoAmigo;
        public int idDaRevista;
        public bool emAberto;
        public DateTime dataDoEmprestimo;
        public DateTime dataDeDevolucao;

        public void Cadastrar(Revista[] revistasEmprestadas, Emprestimo[] emprestimos, Emprestimo newEmprestimo, Cliente[] amigos, Revista[] revistas)
        {
            Cliente.Lista(amigos);
            VerificaSeOAmigoPossuiEmprestimosEmAberto(newEmprestimo, amigos);
            Cliente.DeixarClienteIndisponivel(idDoAmigo, amigos);

            Revista.Listar(revistas);
            VerificaSeARevistaEstaDisponivel(newEmprestimo, revistas);
            Revista.DeixarRevistaIndisponivel(idDaRevista, revistas);

            newEmprestimo.emAberto = true;
            newEmprestimo.dataDoEmprestimo = DateTime.Today;
            Console.WriteLine("A sua data de devolução do livro é: " + (DateTime.Today.AddDays(7)));
            newEmprestimo.dataDeDevolucao = DateTime.Today.AddDays(7);

            Revista.DeixarRevistaIndisponivel(idDaRevista, revistas);

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
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", " NOME DO AMIGO ", "NOME DA REVISTA", "   DEVOLUÇÃO  ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < emprestimos.Length; i++)
            {
                if (emprestimos[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", i, amigos[emprestimos[i].idDoAmigo].nome, revistas[emprestimos[i].idDaRevista].Nome, emprestimos[i].dataDeDevolucao);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            Console.ReadKey();
        }
        public static void Excluir(Emprestimo[] emprestimos, Cliente[] amigos, Revista[] revistas)
        {
            Emprestimo.TodosOsEmprestimos(emprestimos, amigos, revistas);
            Console.WriteLine("Digite o id do Emprstimo q deseja excluir: ");
            int id = Convert.ToInt32(Console.ReadLine());

            emprestimos[id] = null;
        }
        public static void Devolver(Revista[] revistasEmprestadas, Emprestimo[] emprestimos, Cliente[] amigos, Revista[] revistas)
        {
            Emprestimo.TodosOsEmprestimos(emprestimos, amigos, revistas);
            int id;
            do
            {
                Console.WriteLine("Digite o Id do Emprestimo a ser encerrado: ");
                id = Convert.ToInt32(Console.ReadLine());
            } while (emprestimos[id].emAberto == false);
            Cliente.DeixarClienteDisponivel(emprestimos[id].idDoAmigo, amigos);
            Revista.DeixarRevistaDisponivel(emprestimos[id].idDaRevista, revistas);
            emprestimos[id].emAberto = false;

        }
        //Metodos complementares
        private void VerificaSeARevistaEstaDisponivel(Emprestimo newEmprestimo, Revista[] revistas)
        {
            do
            {
                Console.WriteLine("Digite o id da revista disponível q esse amigo deseja pegar:");
                newEmprestimo.idDaRevista = Convert.ToInt32(Console.ReadLine());
            } while (revistas[idDaRevista].disponivel == false);
        }
        private void VerificaSeOAmigoPossuiEmprestimosEmAberto(Emprestimo newEmprestimo, Cliente[] amigos)
        {
            do
            {
                Console.WriteLine("Digite o id do amigo que deseja pegar um livro: ");
                newEmprestimo.idDoAmigo = Convert.ToInt32(Console.ReadLine());
            } while (amigos[idDoAmigo].possuiEmprestimoEmAberto == true);
        }
    }
}