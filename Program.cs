//construir um sistema para um estacionamento, que será usado para gerenciar os veículos estacionados e realizar suas operações, 
//como por exemplo adicionar um veículo, remover um veículo (e exibir o valor cobrado durante o período) e listar os veículos.
 

namespace EstacionamentoApp
{
    //Minha class Estacionamento (POO)
    class Estacionamento
    {
        //Atributos do Estacionamento
        private decimal precoInicial;
        private decimal precoPorHora;
        private List<string> veiculos = new List<string>();

        //Meu construtor
        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        //Meus métodos
        //Método de adicionar
        public void AdicionarVeiculo(string placa)
        {
            veiculos.Add(placa);
            Console.WriteLine($"Veículo {placa} adicionado.");
        }

        //Método de remover
        public void RemoverVeiculo(string placa)
        {
            if (veiculos.Contains(placa))
            {
                Console.Write($"Digite a quantidade de horas que o veículo de placa >> {placa} << permaneceu: ");
                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = this.precoInicial + (this.precoPorHora * horas);

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo da placa >> {placa} << foi removido do estacionamento. Valor total a ser pago: R$ {valorTotal:F2}");
            }
            else
            {
                Console.WriteLine($"Veículo da placa >> {placa} << não foi encontrado.");
            }
        }

        //Método de Listagem
        public void ListarVeiculos()
        {
            if (veiculos.Count == 0)
            {
                Console.WriteLine("Nenhum veículo estacionado.");
                return;
            }

            Console.WriteLine("Veículos estacionados:");
            for (int quantidade = 0; quantidade < veiculos.Count; quantidade++)
            {
                Console.WriteLine($"Carro número {quantidade + 1} de placa: {veiculos[quantidade]}");
            }
            Console.WriteLine($"Total de carros no estacionamento: {veiculos.Count}");
        }
    }

    //class e método principal:
    class Program
    {
        static void Main(string[] args)
        {
            Estacionamento estacionamento = new Estacionamento(5.00m, 2.00m); //valores decimais como argumentos aqui
            string opcao;

            do
            {
                Console.WriteLine("\n===>> Sistema de Estacionamento <<===");
                Console.WriteLine("1 - Adicionar veículo.");
                Console.WriteLine("2 - Remover veículo.");
                Console.WriteLine("3 - Listar veículos.");
                Console.WriteLine("4 - Sair.");
                Console.Write("Por favor. Escolha uma opção: ");
                opcao = Console.ReadLine() ?? "";

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite a placa do veículo: ");
                        string placaAdicionar = Console.ReadLine() ?? "";
                        estacionamento.AdicionarVeiculo(placaAdicionar);
                        break;

                    case "2":
                        Console.Write("Digite a placa do veículo: ");
                        string placaRemover = Console.ReadLine() ?? "";
                        estacionamento.RemoverVeiculo(placaRemover);
                        break;

                    case "3":
                        estacionamento.ListarVeiculos();
                        break;

                    case "4":
                        Console.WriteLine("Encerrando o programa...");
                        Console.WriteLine("Programa encerrado.");
                        break;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

            } while (opcao != "4");
        }
    }
}