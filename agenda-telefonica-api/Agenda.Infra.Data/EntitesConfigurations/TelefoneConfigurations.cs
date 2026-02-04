using Agenda.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda.Infra.Data.EntitesConfigurations
{
    public class TelefoneConfigurations : IEntityTypeConfiguration<Telefone>
    {
        public void Configure(EntityTypeBuilder<Telefone> builder)
        {
            builder.ToTable("Telefone");

            builder.HasKey(t => new { t.Id, t.IdContato });

            builder.Property(t => t.Id)
                .ValueGeneratedOnAdd();

            builder.Property(t => t.Numero)
                .HasMaxLength(16)
                .IsRequired();

            builder.HasOne(t => t.Contato)
                .WithMany(c => c.Telefones)
                .HasForeignKey(t => t.IdContato)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
