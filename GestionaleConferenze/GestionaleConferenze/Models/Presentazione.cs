using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleConferenze.Models
{
    [Table("Presentazioni")]
    public class Presentazione
    {
        [Key]
        [Column("PresentazioneId")]
        public int PresentazioneId { get; set; }

        [Required]
        [Column("Tipo")]
        [StringLength(25)]
        public string Titolo { get; set; }

        [Required]
        [Column("DataInizio")]
        public DateTime DataInizio { get; set; }

        [Required]
        [Column("DataFine")]
        public DateTime DataFine { get; set; }

        [Required]
        [Column("Livello")]
        public int Livello { get; set; }

        [InverseProperty("Presentazione")]
        public ICollection<Registrazione> Registrazioni { get; set; } = new List<Registrazione>();

        public Presentazione()
        {

        }




    }
}
