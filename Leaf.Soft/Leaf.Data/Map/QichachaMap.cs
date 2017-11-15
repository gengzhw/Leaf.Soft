using Leaf.Core.Domain.Spreads;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaf.Data.Map
{
    public partial class QichachaMap: IEntityTypeConfiguration<Qichacha>
    {
        public QichachaMap()
        {

        }

        public void Configure(EntityTypeBuilder<Qichacha> builder)
        {
            builder.ToTable("qichachatb1");
            builder.HasKey(x => x.Id);
        }
    }
}
