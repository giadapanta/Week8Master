using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8Master.Core.Entities;

namespace Week8Master.RepositoryEF
{
    internal class StudenteConfiguration : IEntityTypeConfiguration<Studente>
    {
        public void Configure(EntityTypeBuilder<Studente> builder)
        {
           builder.HasOne(c =>c.Corso).WithMany(s=>s.Studenti).HasForeignKey(c=>c.CorsoCodice);
        }
    }
}