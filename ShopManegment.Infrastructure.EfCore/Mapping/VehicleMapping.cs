using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.VehicleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore.Mapping
{
    public class VehicleMapping : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("Vehicle");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Name).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Model).HasMaxLength(255).IsRequired();
            builder.Property(x => x.CarFunction).HasMaxLength(25).IsRequired();
            builder.Property(x => x.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Keyword).HasMaxLength(100).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.VehicleCategory)
               .WithMany(x => x.Vehicles)
               .HasForeignKey(x => x.CategoryID);

        }
    }
}
