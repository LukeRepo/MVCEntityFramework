using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleConferenze.Models
{
    [Table("Autori")]
    public class Autore
    {
        [Key]
        [Column("AutoreId")]
        public int AutoreId { get; set; }

        [Required]
        [Column("nome")]
        [StringLength(25)]
        public string Nome { get; set; }

        [Required]
        [Column("cognome")]
        [StringLength(25)]
        public string Cognome { get; set; }

        [Required]
        [Column("Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Column("Telefono")]
        [Phone]
        public string Telefono { get; set; }

        [Required]
        [Column("Skills")]
        [StringLength(25)]
        public string Skills { get; set; }

        [InverseProperty("Autore")]
        public ICollection<Registrazione> Registrazioni { get; set; } = new List<Registrazione>();

        public Autore()
        {

        }

        public Autore(int autoreId, string nome, string cognome, string email, string telefono, string skills)
        {
            AutoreId = autoreId;
            Nome = nome;
            Cognome = cognome;
            Email = email;
            Telefono = telefono;
            Skills = skills;
        }

    }
}
