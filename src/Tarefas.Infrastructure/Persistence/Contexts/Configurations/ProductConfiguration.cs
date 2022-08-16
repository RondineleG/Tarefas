using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tarefas.Domain.Models;

namespace Tarefas.Infrastructure.Persistence.Contexts.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefas");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).IsRequired().ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Status).IsRequired().HasConversion(new EnumToStringConverter<EStatus>()); ;
        }
    }
}