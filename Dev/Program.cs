using System.Globalization;
using DevOrram.Enums;
using DevOrram.Models;
using DevOrram.Services;

public class Program
{
    public static void Main()
    {
        var petshops = new List<PetShop>
        {
            new PetShop("Meu Canino Feliz", 2.0, 20m, 40m, 24m, 48m),
            new PetShop("Vai Rex", 1.7, 15m, 50m, 20m, 55m),
            new PetShop("ChowChawgas", 0.8, 30m, 45m, 30m, 45m)
        };
  
        var comparador = new ComparadorPetShops(petshops);
     
 
        DateTime data;
        while (true)
        {
            Console.Write("Olá Sr Eduardo, vamos encontrar a melhor opção para levar seus cães! Por favor, digite a melhor data para agendarmos (dd/MM/yyyy): ");
            string entradaData = Console.ReadLine();

            if (DateTime.TryParseExact(entradaData, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out data))
            {
                break; 
            }
            Console.WriteLine("Data inválida! Por favor, digite novamente no formato dd/MM/yyyy.");
        }
  
        int pequenos = LerNumero("Digite a quantidade de cães pequenos que  deseja levar: ");
        int grandes = LerNumero("Digite a quantidade de cães grandes que  deseja levar: ");

        var melhorPetshop = comparador.EncontrarMelhor(pequenos, grandes, data);
        decimal precoFinal = melhorPetshop.CalcularPreco(pequenos, grandes, data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday ? TipoDia.FinalDeSemana : TipoDia.Semana);

        Console.WriteLine($"Melhor petshop: {melhorPetshop.Nome} - Preço Total: R${precoFinal:F2}");
    }
    private static int LerNumero(string mensagem)
    {
        int numero;
        while (true)
        {
            Console.Write(mensagem);
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out numero) && numero >= 0)
            {
                return numero;
            }
            Console.WriteLine("Valor inválido! Digite um número válido para continuarmos.");
        }
    }
}
