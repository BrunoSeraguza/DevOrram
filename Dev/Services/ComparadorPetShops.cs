using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOrram.Enums;
using DevOrram.Models;

namespace DevOrram.Services
{
    public class ComparadorPetShops
    {
        private readonly List<PetShop> _petshops;

        public ComparadorPetShops(List<PetShop> petshops)
        {
            _petshops = petshops;
        }

        public PetShop EncontrarMelhor(int pequenos, int grandes, DateTime data)
        {
            var tipoDia = (data.DayOfWeek == DayOfWeek.Saturday || data.DayOfWeek == DayOfWeek.Sunday)
                ? TipoDia.FinalDeSemana
                : TipoDia.Semana;

            return _petshops
                .OrderBy(p => p.CalcularPreco(pequenos, grandes, tipoDia))
                .ThenBy(p => p.Distancia)
                .First();
        }
    }
}
