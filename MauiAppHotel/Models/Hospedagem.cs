using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public Quarto QuartoSelecionado { get; set; }
        public int QtdAdultos { get; set; }
        public int QtdCriancas { get; set; }
        public DateTime DataCheckIn { get; set; }
        public DateTime DataCheckOut { get; set; }

        public int Estadia
        {
            get => DataCheckOut.Subtract(DataCheckIn).Days;
        }

        public double ValorTotal
        {
            get
            {
                double valor_adutos = QtdAdultos * QuartoSelecionado.ValorDiariaAdulto;
                double valor_criancas = QtdCriancas * QuartoSelecionado.ValorDiariaCrianca;

                double total = (valor_adutos + valor_criancas) * Estadia;

                return total;
            }
        }
    }
}
