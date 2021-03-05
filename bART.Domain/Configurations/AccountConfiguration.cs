using bART.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace bART.Domain.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<AccountEntity>
    {
        public void Configure(EntityTypeBuilder<AccountEntity> builder)
        {
            builder.HasKey(e => e.Name);
            builder.HasMany(e => e.Contacts)
                .WithOne(contact => contact.Account)
                .HasForeignKey(e => e.AccountName)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
