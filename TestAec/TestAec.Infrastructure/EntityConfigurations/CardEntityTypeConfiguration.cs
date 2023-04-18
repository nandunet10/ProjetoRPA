using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestAec.Domain.AggregatesModel;

namespace TestAec.Infrastructure.EntityConfigurations
{
    public class CardEntityTypeConfiguration : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.ToTable("Cards", "dbo");

            builder.HasKey(p => p.CardId);

            builder.Property(p => p.CardId).HasColumnName("cardId").ValueGeneratedOnAdd();

            builder.Property(p => p.Titulo).HasColumnName("titulo");
            builder.Property(p => p.Area).HasColumnName("area");
            builder.Property(p => p.Descricao).HasColumnName("descricao");
            builder.Property(p => p.Autor).HasColumnName("autor");
            builder.Property(p => p.DataPublicacao).HasColumnName("dataPublicao").HasColumnType("Date");
        }
    }
}
