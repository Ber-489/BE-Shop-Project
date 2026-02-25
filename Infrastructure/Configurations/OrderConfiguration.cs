namespace Infrastructure.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.ToTable("Orders");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.CreatedAt)
               .IsRequired();

        builder.Property(x => x.Status)
               .HasConversion<int>()
               .IsRequired();

        builder.HasOne(x => x.User)
               .WithMany(x => x.Orders)
               .HasForeignKey(x => x.UserId);
    }
}