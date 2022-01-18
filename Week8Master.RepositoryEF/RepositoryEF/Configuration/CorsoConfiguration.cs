using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8Master.Core.Entities;

namespace Week8Master.RepositoryEF
{
    internal class CorsoConfiguration : IEntityTypeConfiguration<Corso>
    {
        public void Configure(EntityTypeBuilder<Corso> builder)
        {
           builder.HasKey(c => c.CorsoCodice);

            builder.HasMany(l =>l.Lezioni).WithOne(c=>c.Corso).HasForeignKey(c =>c.CorsoCodice);
            builder.HasMany(s => s.Studenti).WithOne(c => c.Corso).HasForeignKey(c => c.CorsoCodice);
        }
    }
}