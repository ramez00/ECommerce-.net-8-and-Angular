namespace ECom.Infrastructure.Data.Configurations;
public class PhotoConfig : IEntityTypeConfiguration<Photo>
{
    public void Configure(EntityTypeBuilder<Photo> builder)
    {
        builder.Property(p => p.ImageName)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(p => p.Url)
            .IsRequired()
            .HasMaxLength(500);

    }
}
