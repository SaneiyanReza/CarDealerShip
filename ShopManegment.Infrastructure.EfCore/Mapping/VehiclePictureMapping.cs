using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.VehiclePictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManegment.Infrastructure.EfCore.Mapping
{
    public class VehiclePictureMapping : IEntityTypeConfiguration<VehiclePicture>
    {
        public void Configure(EntityTypeBuilder<VehiclePicture> builder)
        {
            builder.ToTable("VehiclePictures");

            builder.HasKey(x => x.ID);

            builder.Property(x => x.Picture).HasMaxLength(1000).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Vehicle)
                .WithMany(x => x.VehiclePictures)
                .HasForeignKey(x => x.VehicleID);
        }
    }
}
