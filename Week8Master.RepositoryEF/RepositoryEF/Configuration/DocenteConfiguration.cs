using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Week8Master.Core.Entities;

namespace Week8Master.RepositoryEF
{
    internal class DocenteConfiguration : IEntityTypeConfiguration<Docente>
    {
        public void Configure(EntityTypeBuilder<Docente> builder)
        {
            builder.HasMany(l=>l.Lezioni).WithOne(d=>d.Docente).HasForeignKey(d=>d.DocenteID);
        }
    }
}