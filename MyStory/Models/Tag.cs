﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace MyStory.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Posts = new List<Post>();
        }
        public int Id { get; set; }
        public string TagText { get; set; } // unique key
        public virtual ICollection<Post> Posts { get; set; }
    }

    public class TagMap : EntityTypeConfiguration<Tag>
    {
        public TagMap()
        {
            // Table
            this.ToTable("Tags");

            // Properties
            this.Property(t => t.TagText)
                .IsRequired()
                .HasMaxLength(125);

            // Relationships
            // Relationships with Post entity is defined in PostMap class
        }
    }

}