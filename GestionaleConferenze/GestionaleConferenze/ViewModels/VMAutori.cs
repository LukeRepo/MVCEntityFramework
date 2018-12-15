using GestionaleConferenze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleConferenze.ViewModels
{
    public class VMAutori
    {
        public int AutoreId { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Skills { get; set; }
        public bool Selected { get; set; }

        public VMAutori()
        {
            Selected = false;
        }

        public VMAutori(Autore a, bool selected)
        {
            AutoreId = a.AutoreId;
            Nome = a.Nome;
            Cognome = a.Cognome;
            Email = a.Email;
            Telefono = a.Telefono;
            Skills = a.Skills;
            Selected = selected;
        }

        public Autore Autore()
        {
            return new Autore(AutoreId, Nome, Cognome, Email, Telefono, Skills);
        }

    }
}
