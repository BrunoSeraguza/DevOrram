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
        //TODO FAZER APRESENTACAO
        var comparador = new ComparadorPetShops(petshops);
        //TODO FORMATAR DATA
        //USAR PRIMARY CONSTRUCTOR
        Console.Write("Olá Sr Eduardo, vamos encontrar a melhor opção para levar seus cães! Por favor digite a melhor data para agendarmos (dd/MM/yyyy): ");
        DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        Console.Write("Digite a quantidade de cães pequenos: ");
        int pequenos = int.Parse(Console.ReadLine());

        Console.Write("Digite a quantidade de cães grandes: ");
        int grandes = int.Parse(Console.ReadLine());

        var melhorPetshop = comparador.EncontrarMelhor(pequenos, grandes, data);
        decimal precoFinal = melhorPetshop.CalcularPreco(pequenos, grandes, data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday ? TipoDia.FinalDeSemana : TipoDia.Semana);

        Console.WriteLine($"Melhor petshop: {melhorPetshop.Nome} - Preço Total: R${precoFinal:F2}");
    }
}
