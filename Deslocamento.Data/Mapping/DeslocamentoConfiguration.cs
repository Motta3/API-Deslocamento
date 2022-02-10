using DeslocamentoAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoAPI.Data.Mapping
{
    public class DeslocamentoConfiguration : IEntityTypeConfiguration<Deslocamento>
    {
        public void Configure(EntityTypeBuilder<Deslocamento> builder)
        {
            builder.ToTable("Deslocamento");
            builder.HasKey(p => p.Id);

            builder.HasOne(e => e.Carro)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.CarroId)
                .HasConstraintName("FK_Carro_Deslocamento_CarroId");

            builder.HasOne(e => e.Cliente)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.ClienteId)
                .HasConstraintName("FK_Cliente_Deslocamento_ClienteId");

            builder.HasOne(e => e.Condutor)
                .WithMany(d => d.Deslocamentos)
                .HasForeignKey(e => e.CondutorId)
                .HasConstraintName("FK_Condutor_Deslocamento_CondutorId");

            builder.Property(p => p.DataHoraInicio)
                .IsRequired()
                .HasColumnName("DataHoraInicio")
                .HasColumnType("datetime");

            builder.Property(p => p.QuilometragemInicial)
                .IsRequired()
                .HasColumnName("QuilometragemInicial")
                .HasColumnType("decimal");

            builder.Property(p => p.Observacao)
                .HasColumnName("Observacao")
                .HasDefaultValue("Sem observação")
                .HasMaxLength(400);

            builder.Property(p => p.DataHoraFim)
                .HasColumnName("DataHoraFim")
                .HasColumnType("datetime");

            builder.Property(p => p.QuilometragemFinal)
                .HasColumnName("QuilometragemFinal")
                .HasColumnType("decimal");

        }
    }
}