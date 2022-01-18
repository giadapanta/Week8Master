using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week8Master.Core.Entities;

namespace Week8Master.RepositoryEF
{
   public class MasterContext: DbContext
    {
        //elenco dei DbSet,cioè le tabelle- entità in gioco
        public DbSet<Corso> Corsi { get; set; }
        public DbSet<Studente> Studenti { get; set; }
        public DbSet<Docente> Docenti { get; set; }
        public DbSet<Lezione> Lezioni { get; set; }

        //costruttore
        public MasterContext()
        {

        }
        public MasterContext(DbContextOptions<MasterContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MasterCorsiDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration<Lezione>(new LezioneConfiguration());
            modelBuilder.ApplyConfiguration<Corso>(new CorsoConfiguration());
            modelBuilder.ApplyConfiguration<Studente>(new StudenteConfiguration());
            modelBuilder.ApplyConfiguration<Docente>(new DocenteConfiguration());



        }
    }
}
