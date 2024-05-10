using System.Runtime.InteropServices;
using System.Text;
using DesafioProjetoHospedagem.Models;
using DesafioProjetoHospedagem.View;

Console.OutputEncoding = Encoding.UTF8;

// Declaração de variáveis para a reserva
List<Pessoa> hospedes = null;
Suite suite = null;
Reserva reserva = null;

bool rodando = true;

do
{
    Console.Clear();
    Console.Write("Bem vindo ao sistema de hotelaria!\n"
                    + "O que deseja fazer?\n\n"
                    + "1 - Cadastrar suite\n"
                    + "2 - Cadastrar hospedes\n"
                    + "3 - Cadastrar reserva\n"
                    + "4 - Mostrar informações da reserva\n"
                    + "5 - Sair\n\n"
                    + "Opção:");

string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            // Cria a suíte
            suite = Menu.CadastrarSuite();
            Menu.DigiteParaContinuar();
            break;
        case "2":
            // Cria os modelos de hóspedes e cadastra na lista de hóspedes
            hospedes = Menu.CadastrarListaDeHospedes();
            Menu.DigiteParaContinuar();
            break;
        case "3":
            // Cria uma nova reserva, passando a suíte e os hóspedes
            reserva = Menu.CadastrarReserva(hospedes, suite);
            Menu.DigiteParaContinuar();
            break;
        case "4":
            // Exibe a quantidade de hóspedes e o valor da diária
            Menu.DetalharReserva(reserva);
            Menu.DigiteParaContinuar();
            break;
        case "5":
            Console.WriteLine("Até logo!");
            rodando = false;
            break;        
        default:
            Console.WriteLine($"\"{opcao}\" não é uma opção válida");
            Menu.DigiteParaContinuar();
            break;
    }
} while (rodando);