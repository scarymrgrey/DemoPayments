using System;
using System.Collections.Generic;
using System.Text;
using Incoding.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Operations.Persistance
{
   public class User : EntityBase
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public class Map : EFClassMap<User>
        {
            public override void OnModel(EntityTypeBuilder<User> entity)
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.Name);
                entity.Property(r => r.Age);
            }
        }
    }
}
