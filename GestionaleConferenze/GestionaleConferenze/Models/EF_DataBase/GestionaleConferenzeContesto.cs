using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleConferenze.Models.EF_DataBase
{
    public class GestionaleConferenzeContesto : DbContext
    {
        public virtual DbSet<Registrazione> Concefernze { get; set; }
        public virtual DbSet<Autore> Autori { get; set; }
        public virtual DbSet<Presentazione> Presentazioni { get; set; }

        public GestionaleConferenzeContesto() { }
        public GestionaleConferenzeContesto(DbContextOptions<GestionaleConferenzeContesto> options) : base(options)
        {

        }

      

    }
}
