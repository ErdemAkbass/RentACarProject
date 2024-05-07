using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations;

public class ModelConfiguration : IEntityTypeConfiguration<Model>
{
    public void Configure(EntityTypeBuilder<Model> builder)
    {
        builder.ToTable("Models").HasKey(m => m.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Name).HasColumnName("Name").IsRequired();
        builder.Property(b => b.BrandId).HasColumnName("BrandId").IsRequired();
        builder.Property(b => b.FuelId).HasColumnName("FuelId").IsRequired();
        builder.Property(b => b.TransmissionId).HasColumnName("TransmissionId").IsRequired();
        builder.Property(b => b.DailyPrice).HasColumnName("DailyPrice").IsRequired();
        builder.Property(b => b.ImageUrl).HasColumnName("ImageUrl").IsRequired();


        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(m => m.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(m => m.DeletedDate).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name, name: "UK_Models_Name").IsUnique();

        builder.HasOne(b => b.Brand);
        builder.HasOne(b => b.Fuel);
        builder.HasOne(b => b.Transmission);
        builder.HasMany(b => b.Cars);
        
        
        

        builder.HasQueryFilter(m => !m.DeletedDate.HasValue);
    }
}