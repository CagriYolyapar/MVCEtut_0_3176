using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCEtut_0.Models.Entities;

namespace MVCEtut_0.Models.Configurations
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
            builder.HasOne(x => x.AppUserProfile).WithOne(x => x.AppUser).HasForeignKey<AppUserProfile>(x => x.AppUserId).IsRequired();
        }
    }
}
