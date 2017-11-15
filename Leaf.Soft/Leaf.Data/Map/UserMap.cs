using Leaf.Core.Domain.Users;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaf.Data.Map
{
   public partial class UserMap: IEntityTypeConfiguration<User>
    {
        public UserMap()
        {

        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.Id);

        }
    }
}
