using DeslocamentoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoAPI.Data.Mapping
{
    public class CarroConfiguration : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Carro");

            builder.Property(p => p.Placa)
                .HasColumnName("Placa");

            builder.Property(p => p.Descricao)
                .IsRequired()
                .HasColumnName("Descricao");
        }
    }
}