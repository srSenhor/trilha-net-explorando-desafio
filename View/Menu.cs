using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DesafioProjetoHospedagem.Models;
using Newtonsoft.Json;

namespace DesafioProjetoHospedagem.View
{
    public class Menu
    {
        public static Suite CadastrarSuite()
        {
            Console.WriteLine("Qual o tipo da suíte?");
            string tipo = Console.ReadLine();

            Console.WriteLine("Qual a capacidade da suite?");
            int capacidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Qual o valor da diária?");
            decimal valorDiaria = Convert.ToDecimal(Console.ReadLine());

            return new Suite(tipoSuite: tipo, capacidade: capacidade, valorDiaria: valorDiaria);
        }
        public static List<Pessoa> CadastrarListaDeHospedes()
        {
            Console.WriteLine("Cadastrando lista de hóspedes. (Aperte só \"Enter\" para parar)");
            bool rodando = true;

            List<Pessoa> hospedes = new List<Pessoa>();

            do
            {
                Console.WriteLine("Qual o nome do cliente?");
                string nome = Console.ReadLine();

                if (nome.Equals(""))
                {
                    rodando = false;
                } 
                else
                {
                    hospedes.Add(new Pessoa(nome: nome));
                }
            } while (rodando);

            return hospedes;
        }
        public static Reserva CadastrarReserva(List<Pessoa> hospedes, Suite suite)
        {
            Console.WriteLine("Quantos dias o cliente pretende ficar?");
            int quantidadeDias = Convert.ToInt32(Console.ReadLine());

            Reserva reserva = new Reserva(diasReservados: quantidadeDias);

            try
            {
                reserva.CadastrarSuite(suite);
                reserva.CadastrarHospedes(hospedes);
            }
            catch (NullReferenceException)
            {
                Console.WriteLine($"Não foi possível cadastrar reserva pois a lista de hóspedes/suite fornecida está vazia");
                return null;
            }

            string reservaJson = $"{JsonConvert.SerializeObject(reserva)}\n";
            File.AppendAllText("Database/reservas.json", reservaJson);

            return reserva;
        }
        public static void DetalharReserva(Reserva reserva)
        {
            try
            {
                Console.WriteLine($"Tipo da suíte: {reserva.Suite.TipoSuite}");
                Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
                Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
            }
            catch (NullReferenceException)
            {
                Console.WriteLine("Não foi possível exibir o conteúdo pois não há reserva cadastrada.");
            }
        }
        public static void DigiteParaContinuar()
        {
            Console.WriteLine("Digite qualquer coisa para continuar");
            Console.ReadLine();
        }
    }
}