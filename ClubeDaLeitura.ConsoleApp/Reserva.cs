using System;

namespace ClubeDaLeitura.ConsoleApp
{
    internal class Reserva
    {
        bool valida;
        int idAmigo;
        int idRevista;
        DateTime diaDaReserva;


        public void Cadastrar(Reserva[] reservas, Reserva reserva, Cliente[] amigos, Revista[] revistas)
        {
            reserva.valida = true;
            //mostrar tabela de amigos
            Console.WriteLine("");
            reserva.idAmigo = Convert.ToInt32(Console.ReadLine());
            //mostrar tabela de Revistas
            Console.WriteLine("");
            reserva.idRevista = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] == null || reservas[i] == default)
                {
                    reservas[i] = reserva;
                    break;
                }
            }
        }

        public static void Editar(Reserva[] reservas, Cliente[] amigos, Revista[] revistas)
        {
            Reserva.Listar(reservas, amigos, revistas);
            Console.WriteLine("");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("");
            reservas[id].valida = Convert.ToBoolean(Console.ReadLine());
            //mostrar tabela de amigos
            Console.WriteLine("");
            reservas[id].idAmigo = Convert.ToInt32(Console.ReadLine());
            //mostrar tabela de Revistas
            Console.WriteLine("");
            reservas[id].idRevista = Convert.ToInt32(Console.ReadLine());
        }
        public static void Listar(Reserva[] reservas, Cliente[] amigos, Revista[] revistas)
        {
            AtualizarReservas(reservas);

            Console.WriteLine(" _____________________________________________________");
            Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", " ID ", " NOME DO AMIGO ", "NOME DA REVISTA", "   EM ABERTO  ");
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            for (int i = 0; i < reservas.Length; i++)
            {
                if (reservas[i] != null)
                {
                    Console.WriteLine("|{0,-5}|{1,-15}|{2,-15}|{3,-15}|", i, amigos[reservas[i].idAmigo].nome, revistas[reservas[i].idRevista].Nome, reservas[i].valida);
                }
            }
            Console.WriteLine("|_____|_______________|_______________|_______________|");
            Console.ReadKey();
        }
        public static void Excluir(Reserva[] reservas, Cliente[] amigos, Revista[] revistas)
        {
            Reserva.Listar(reservas, amigos, revistas);
            Console.WriteLine("");
            int id = Convert.ToInt32(Console.ReadLine());

            reservas[id] = null;
        }

        public static void AtualizarReservas(Reserva[] reservas)
        {
            for(int i = 0;i < reservas.Length; i++)
            {
                if(reservas[i].diaDaReserva.AddDays(2) == DateTime.Today)
                {
                    reservas[i].valida = false;
                } 
            }
        }

        //public static void Emprestar(Reserva[] reservas){
        //  Reserva.Listar(reservas, amigos, revistas);
        //  id da reserva que deseja efetivar
        //  if a reserva estiver válida emprestar
        //  caso contrário avisar que a reserva expirou
        //}
    }
}