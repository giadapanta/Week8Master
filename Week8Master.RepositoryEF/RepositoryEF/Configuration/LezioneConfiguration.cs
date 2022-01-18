using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8Master.Core.Entities;

namespace Week8Master.RepositoryEF
{
    internal class LezioneConfiguration : IEntityTypeConfiguration<Lezione>
    {
        public void Configure(EntityTypeBuilder<Lezione> builder)
        {
           builder.HasOne(c=>c.Corso).WithMany(l=>l.Lezioni).HasForeignKey(c=>c.CorsoCodice);
           builder.HasOne(d=>d.Docente).WithMany(l=>l.Lezioni).HasForeignKey(d=>d.DocenteID);
        }
    }
}