namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Email)
               .IsRequired()
               .HasMaxLength(255);

        builder.HasMany(x => x.Orders)
               .WithOne(x => x.User)
               .HasForeignKey(x => x.UserId);
    }
}