using AllegroConnector.BuildingBlocks.Infrastructure.InternalCommands;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaselinkerConnector.Infrastructure.InternalCommands
{
    internal class InternalCommandEntityTypeConfiguration : IEntityTypeConfiguration<InternalCommand>
    {
        public void Configure(EntityTypeBuilder<InternalCommand> builder)
        {
            builder.ToTable("InternalCommands", "baselinker");

            builder.HasKey(b => b.Id);
            builder.Property(b => b.Id).ValueGeneratedNever();
        }
    }
}
