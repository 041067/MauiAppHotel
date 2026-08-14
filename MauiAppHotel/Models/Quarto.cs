using System;
using System.Collections.Generic;
using System.Text;

namespace MauiAppHotel.Models
{
    public class Quarto
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double ValorDiariaAdulto { get; set; }
        public double ValorDiariaCrianca { get; set; }
    }
}
