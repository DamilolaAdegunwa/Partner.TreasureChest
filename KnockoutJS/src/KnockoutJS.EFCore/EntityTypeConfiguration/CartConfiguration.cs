﻿using KnockoutJS.Core;
using KnockoutJS.Core.Carts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace KnockoutJS.EFCore
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.HasIndex(c=>c.UserId).IsUnique();
            builder.Property(c => c.UserId).HasMaxLength(255);
        }
    }
}
