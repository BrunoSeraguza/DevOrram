using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevOrram.Enums;

namespace DevOrram.Models
{
    public class PetShop
    {
        public string Nome { get; }
        public double Distancia { get; }
        public decimal PrecoPequenoSemana { get; }
        public decimal PrecoGrandeSemana { get; }
        public decimal PrecoPequenoFds { get; }
        public decimal PrecoGrandeFds { get; }

        public PetShop(string nome, double distancia, decimal precoPequenoSemana, decimal precoGrandeSemana, decimal precoPequenoFds, decimal precoGrandeFds)
        {
            Nome = nome;
            Distancia = distancia;
            PrecoPequenoSemana = precoPequenoSemana;
            PrecoGrandeSemana = precoGrandeSemana;
            PrecoPequenoFds = precoPequenoFds;
            PrecoGrandeFds = precoGrandeFds;
        }

        public decimal CalcularPreco(int pequenos, int grandes, TipoDia tipoDia)
        {
            return tipoDia == TipoDia.Semana
                ? (pequenos * PrecoPequenoSemana + grandes * PrecoGrandeSemana)
                : (pequenos * PrecoPequenoFds + grandes * PrecoGrandeFds);
        }
    }
}
