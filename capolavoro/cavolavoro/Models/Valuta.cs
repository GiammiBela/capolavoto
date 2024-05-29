using System.ComponentModel.DataAnnotations;

namespace cavolavoro.Models
{
    public class Valuta
    {
        [Key]
        public int Id { get; set; }
        public string Codice { get; set; }
        public string Nome { get; set; }
        public decimal TassoDiCambio { get; set; }
    }
}
