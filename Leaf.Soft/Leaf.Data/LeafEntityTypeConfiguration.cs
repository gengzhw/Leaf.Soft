using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Leaf.Data
{
   public abstract class LeafEntityTypeConfiguration<T>: IEntityTypeConfiguration<T> where T:class
    {
        protected LeafEntityTypeConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<T> builder)
        {
         
        }
    }
}
