namespace Infrastructure.Configurations;

public class DeviceConfiguration : IEntityTypeConfiguration<Device>
{
    public void Configure(EntityTypeBuilder<Device> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.SerialNumber)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.WifiSSID)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.WifiPassword)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(x => x.IsActive)
            .IsRequired();
    }
}