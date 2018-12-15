using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleConferenze.Models
{
    [Table("Registrazioni")]
    public class Registrazione
    {
        public Registrazione() { }

        public Registrazione(int autoreId, int presentazioneId)
        {
            AutoreId = autoreId;
            PresentazioneId = presentazioneId;
        }
        public int AutoreId { get; set; }


        public int PresentazioneId { get; set; }

        [Key]
        [Column("RegistrazioneId")]
        public int RegistrazioneId { get; set; }

        [ForeignKey("AutoreId")]
        [InverseProperty("Registrazioni")]
        public Autore Autore { get; set; }

        [ForeignKey("PresentazioneId")]
        [InverseProperty("Registrazioni")]
        public Presentazione Presentazione { get; set; }

    }
}
