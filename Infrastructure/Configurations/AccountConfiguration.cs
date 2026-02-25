namespace Infrastructure.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Phone)
               .IsRequired()
               .HasMaxLength(20);

        builder.HasIndex(x => x.Phone)
               .IsUnique();

        builder.Property(x => x.PasswordHash)
               .HasMaxLength(500);

        builder.Property(x => x.IsFirstLogin)
               .IsRequired();

        builder.Property(x => x.RefreshToken)
               .HasMaxLength(500);
    }
}