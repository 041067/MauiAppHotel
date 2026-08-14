using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class Hospedagem
    {
        public int Id { get; set; }

        public Quarto QuartoSelecionado { get; set; }

        public string NomeQuarto { get; set; }

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
                // Validação defensiva: retorna 0 se o quarto não foi selecionado
                if (QuartoSelecionado == null)
                    return 0;

                double valorAdultos =
                    QtdAdultos * QuartoSelecionado.ValorDiariaAdulto;

                double valorCriancas =
                    QtdCriancas * QuartoSelecionado.ValorDiariaCrianca;

                return (valorAdultos + valorCriancas) * Estadia;
            }
        }
    }
}
