using GestionaleConferenze.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleConferenze.ViewModels
{
    public class VMPresentazioni
    {
        public int PresentazioneId { get; set; }
        public string Titolo { get; set; }
        public DateTime DataInizio { get; set; }
        public DateTime DataFine { get; set; }
        public int Livello { get; set; }
        public VMAutori Autore { get; set; }

        public List<VMAutori> Autori { get; set; }

        public VMPresentazioni()
        {
            Autori = new List<VMAutori>();
        }

        public VMPresentazioni(IList<Autore> autori)
        {
            Autori = autori.Select(x => new VMAutori(x, false)).ToList();
        }

        public List<Autore> SelectedAutori()
        {
            return Autori.Where(x => x.Selected).Select(x => x.Autore()).ToList();
        }

        
    }
}
