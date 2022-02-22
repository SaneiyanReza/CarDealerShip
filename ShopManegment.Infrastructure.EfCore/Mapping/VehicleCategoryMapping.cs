using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.VehicleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore.Mapping
{
    public class VehicleCategoryMapping : IEntityTypeConfiguration<VehicleCategory>
    {
        public void Configure(EntityTypeBuilder<VehicleCategory> builder)
        {
            builder.ToTable("VehicleCategories");
            builder.HasKey(x=>x.ID);    

            builder.Property(x => x.Name).HasMaxLength(225).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(255);
            builder.Property(x => x.PictureTitle).HasMaxLength(500);
            builder.Property(x => x.Keyword).HasMaxLength(80).IsRequired();
            builder.Property(x => x.MetaDiscription).HasMaxLength(150).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.Vehicles)
               .WithOne(x => x.VehicleCategory)
               .HasForeignKey(x => x.CategoryID);
        }
    }
}
