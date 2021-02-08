using System;

namespace ProAgil.Domain.Entities
{
    public class Lote
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? Data { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public Evento Eventos { get;  }
        
    }
}