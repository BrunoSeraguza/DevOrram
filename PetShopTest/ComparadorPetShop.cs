using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOrram.Models;
using DevOrram.Services;

namespace PetShopTest
{
    public class ComparadorPetShop
    {
        private readonly List<PetShop> _petshops;

        public ComparadorPetShop()
        {
            _petshops = new List<PetShop>
            {
                new PetShop("Meu Canino Feliz", 2.0, 20m, 40m, 24m, 48m),
                new PetShop("Vai Rex", 1.7, 15m, 50m, 20m, 55m),
                new PetShop("ChowChawgas", 0.8, 30m, 45m, 30m, 45m)
            };
        }

        [Fact]
        public void EncontrarMelhor_DeveRetornarVaiRex_Para2Pequenos1GrandeEmDiaUtil()
        {
            // Arrange
            var comparador = new ComparadorPetShops(_petshops);
            DateTime data = new DateTime(2025, 2, 12); // Quarta feira 

            // Act
            var melhorPetshop = comparador.EncontrarMelhor(2, 1, data);

            // Assert
            Assert.Equal("Vai Rex", melhorPetshop.Nome);
        }

        [Fact]
        public void EncontrarMelhor_DeveRetornarMeuCaninoFeliz_Para1Pequeno1GrandeNoFinalDeSemana()
        {
            // Arrange
            var comparador = new ComparadorPetShops(_petshops);
            DateTime data = new DateTime(2025, 2, 15); // Sábado

            // Act
            var melhorPetshop = comparador.EncontrarMelhor(1, 1, data);

            // Assert
            Assert.Equal("Meu Canino Feliz", melhorPetshop.Nome);
        }

        [Fact]
        public void EncontrarMelhor_DeveRetornarChowChawgas_SePrecosForemIguaisPorSerMaisProximo()
        {
            // Arrange
            var petshopsEmpatados = new List<PetShop>
            {
                new PetShop("Pet A", 5.0, 30m, 45m, 30m, 45m),
                new PetShop("ChowChawgas", 2.0, 30m, 45m, 30m, 45m)
            };
            var comparador = new ComparadorPetShops(petshopsEmpatados);
            DateTime data = new DateTime(2025, 2, 13); // Quinta

            // Act
            var melhorPetshop = comparador.EncontrarMelhor(1, 1, data);

            // Assert
            Assert.Equal("ChowChawgas", melhorPetshop.Nome);
        }
    }
}
